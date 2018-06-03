using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XA_DATASETLib;

namespace Exercise_1
{
    public partial class 선물계좌현황 : Form
    {
        DataTable table_잔고현황 = new DataTable();
        DataTable table_미체결현황 = new DataTable();
        DataTable table_체결현황 = new DataTable();

        XAQueryClass t0441 = new XAQueryClass();
        XAQueryClass t0434 = new XAQueryClass();

        XARealClass C01 = new XARealClass();
        XARealClass H01 = new XARealClass();
        XARealClass O01 = new XARealClass();

        XARealClass FC0 = new XARealClass();
        XARealClass OC0 = new XARealClass();

        Timer myTimer_t0441 = new Timer();
        string 연속키_t0441_cts_expcode = "";
        string 연속키_t0441_cts_medocd = "";

        Timer myTimer_t0434 = new Timer();
        string 연속키_t0434_cts_ordno = "";

        string 계좌번호 = "";

        Dictionary<string, List<string>> Parking_체결데이타 = new Dictionary<string, List<string>>(); //Key:주문번호, value<종목코드,종목명,매매구분,체결가격,체결수량,진입청산(진입,청산,SAR)>

        public 선물계좌현황()
        {
            InitializeComponent();

            table_잔고현황.Columns.Add("종목코드");
            table_잔고현황.Columns.Add("종목명");
            table_잔고현황.Columns.Add("매매구분"); 
            table_잔고현황.Columns.Add("잔고수량"); 
            table_잔고현황.Columns.Add("청산가능수량");
            table_잔고현황.Columns.Add("평균진입단가"); 
            table_잔고현황.Columns.Add("현재가");
            table_잔고현황.Columns.Add("평가손익");

            table_미체결현황.Columns.Add("주문번호");
            table_미체결현황.Columns.Add("종목코드");
            table_미체결현황.Columns.Add("종목명");
            table_미체결현황.Columns.Add("매매구분");
            table_미체결현황.Columns.Add("주문가격");
            table_미체결현황.Columns.Add("주문수량");
            table_미체결현황.Columns.Add("미체결수량");

            table_체결현황.Columns.Add("주문번호");
            table_체결현황.Columns.Add("종목코드");
            table_체결현황.Columns.Add("종목명");
            table_체결현황.Columns.Add("매매구분");
            table_체결현황.Columns.Add("주문가격");
            table_체결현황.Columns.Add("주문수량");
            table_체결현황.Columns.Add("체결가격");
            table_체결현황.Columns.Add("체결수량");

            dataGridView1.DataSource = table_잔고현황;
            dataGridView2.DataSource = table_미체결현황;
            dataGridView3.DataSource = table_체결현황;

            foreach (KeyValuePair<string, List<string>> acc in Form1.Acclist)
            {
                if (acc.Value[2] == "선물옵션")
                {
                    comboBox1.Items.Add(acc.Key);
                }
            }

            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
                this.Show();
            }
            else
            {
                MessageBox.Show("등록된 선물/옵션계좌가 없습니다");
                this.Close();
            }


            t0441.ResFileName = @"C:\ETRADE\xingAPI\Res\t0441.res";
            t0441.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(t0441_ReceiveData);
            t0441.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(t0441_ReceiveMessage);

            t0434.ResFileName = @"C:\ETRADE\xingAPI\Res\t0434.res";
            t0434.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(t0434_ReceiveMessage);
            t0434.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(t0434_ReceiveData);

            myTimer_t0441.Tick += new EventHandler(myTimer_t0441_Tick);
            myTimer_t0434.Tick += new EventHandler(myTimer_t0434_Tick);

            C01.ResFileName = @"C:\ETRADE\xingAPI\Res\C01.res";
            H01.ResFileName = @"C:\ETRADE\xingAPI\Res\H01.res";
            O01.ResFileName = @"C:\ETRADE\xingAPI\Res\O01.res";
            FC0.ResFileName = @"C:\ETRADE\xingAPI\Res\FC0.res";
            OC0.ResFileName = @"C:\ETRADE\xingAPI\Res\OC0.res";

            C01.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(C01_ReceiveRealData);
            H01.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(H01_ReceiveRealData);
            O01.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(O01_ReceiveRealData);
            FC0.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(FC0_ReceiveRealData);
            OC0.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(OC0_ReceiveRealData);
        }

        void OC0_ReceiveRealData(string szTrCode)
        {
            string 단축코드 = OC0.GetFieldData("OutBlock", "optcode").Trim();
            string 현재가 = OC0.GetFieldData("OutBlock", "price");

            foreach (DataRow row in table_잔고현황.Select("종목코드 = '" + 단축코드 + "'"))
            {
                row["현재가"] = 현재가;
                평가손익계산(row);
            }
        }

        void FC0_ReceiveRealData(string szTrCode)
        {
            string 단축코드 = FC0.GetFieldData("OutBlock", "futcode").Trim();
            string 현재가 = FC0.GetFieldData("OutBlock", "price");

            foreach (DataRow row in table_잔고현황.Select("종목코드 = '" + 단축코드 + "'"))
            {
                row["현재가"] = 현재가;
                평가손익계산(row);
            }
        }

        private void 평가손익계산(DataRow row)
        {
            if (row["매매구분"].ToString() == "매수")
            {
                row["평가손익"] = 500000d * double.Parse(row["잔고수량"].ToString()) * (double.Parse(row["현재가"].ToString()) - double.Parse(row["평균진입단가"].ToString()));
            }
            else if (row["매매구분"].ToString() == "매도")
            {
                row["평가손익"] = 500000d * double.Parse(row["잔고수량"].ToString()) * (double.Parse(row["평균진입단가"].ToString()) - double.Parse(row["현재가"].ToString()));
            }
        }

        void O01_ReceiveRealData(string szTrCode)//접수
        {
            string accno = O01.GetFieldData("OutBlock", "accno");//계좌번호

            if (계좌번호 != accno)
                return;

            string trcode = O01.GetFieldData("OutBlock", "trcode");//TRCODE  //SONBT001:신규주문, SONBT002:정정주문, SONBT003:취소주문

            if (trcode != "SONBT001")//신규주문 접수에 대해서만 처리한다. 정정/취소는 확인(H01_Tr 에서 처리함).
                return;

            string ordno =int.Parse( O01.GetFieldData("OutBlock", "ordno")).ToString();//주문번호
            string fnoIsuno = O01.GetFieldData("OutBlock", "fnoIsuno");//선물옵션종목번호 8자리
            string fnoIsunm = O01.GetFieldData("OutBlock", "fnoIsunm");//선물옵션종목명
            string bnstp = "매도";
            if (O01.GetFieldData("OutBlock", "bnstp") == "2")//매매구분 1:매도, 2:매수
            {
                bnstp = "매수";
            }
            string ordqty = O01.GetFieldData("OutBlock", "ordqty");//주문수량
            string ordprc = O01.GetFieldData("OutBlock", "ordprc");//주문가격
            string unercqty = O01.GetFieldData("OutBlock", "unercqty");//미체결수량

            if (Parking_체결데이타.Count > 0 && Parking_체결데이타.ContainsKey(ordno))//parking된 체결데이타가 있으면 처리..<<<<<##################<<<<<<<<<<
            {
                //일부체결의 경우만 나머지 부분에 대하여 처리
                if (int.Parse(Parking_체결데이타[ordno][4]) < int.Parse(ordqty))//일부체결
                {
                    //미체결 현황 갱신.
                    DataRow newrow1 = table_미체결현황.NewRow();
                    newrow1["주문번호"] = ordno;
                    newrow1["종목코드"] = fnoIsuno;
                    newrow1["종목명"] = fnoIsunm;
                    newrow1["매매구분"] = bnstp;
                    newrow1["주문가격"] = ordprc;
                    newrow1["주문수량"] = ordqty;
                    //newrow1["미체결수량"] = unercqty;
                    newrow1["미체결수량"] = int.Parse(ordqty) - int.Parse(Parking_체결데이타[ordno][4]);
                    table_미체결현황.Rows.Add(newrow1);
                }
                Parking_체결데이타.Remove(ordno);

                if (Parking_체결데이타[ordno][5] == "청산")
                {
                    //잔고현황의 청산가능수량 갱신
                    foreach (DataRow row in table_잔고현황.Select("종목코드 = '" + fnoIsuno + "'"))
                    {
                        row["청산가능수량"] = int.Parse(row["청산가능수량"].ToString()) - int.Parse(ordqty);
                    }
                }
                return;
            }

            //잔고현황의 청산가능수량 갱신
            foreach (DataRow row in table_잔고현황.Select("종목코드 = '" + fnoIsuno + "'"))
            {
                if (row["매매구분"].ToString() != bnstp)
                {
                    row["청산가능수량"] = int.Parse(row["청산가능수량"].ToString()) - int.Parse(ordqty);
                }
            }

            //미체결 현황 갱신.
            DataRow newrow = table_미체결현황.NewRow();
            newrow["주문번호"] = ordno;
            newrow["종목코드"] = fnoIsuno;
            newrow["종목명"] = fnoIsunm;
            newrow["매매구분"] = bnstp;
            newrow["주문가격"] = ordprc;
            newrow["주문수량"] = ordqty;
            newrow["미체결수량"] = unercqty;
            table_미체결현황.Rows.Add(newrow);
        }

        void H01_ReceiveRealData(string szTrCode)//정정/취소
        {
            string accno = H01.GetFieldData("OutBlock", "accno");//계좌번호
            if (계좌번호 != accno)
                return;

            string trcode = H01.GetFieldData("OutBlock", "trcode");//trcode  회원처리호가  (정상) : TTRODP11301, (거부) : TTRODP11321, (자동취소) : TTRODP11303
            string ordno = int.Parse(H01.GetFieldData("OutBlock", "ordno")).ToString();//주문번호
            string orgordno = int.Parse(H01.GetFieldData("OutBlock", "orgordno")).ToString();//원주문번호
            string code = from표준to단축( H01.GetFieldData("OutBlock", "expcode"));//종목코드
            string 종목명=종목명불러오기(code);
            string dosugb = "매도";
            if (H01.GetFieldData("OutBlock", "dosugb") == "2")//매도수구분 1 매도, 2 매수
            {
                dosugb = "매수";
            }
            string mocagb = H01.GetFieldData("OutBlock", "mocagb");//정정취소구분 1 신규, 2 정정, 3 취소
            string qty2 = H01.GetFieldData("OutBlock", "qty2");//호가수량
            string price = H01.GetFieldData("OutBlock", "price");//호가가격
            string qty = H01.GetFieldData("OutBlock", "qty");//실정정취소수량
            string rejcode = H01.GetFieldData("OutBlock", "rejcode");//거부사유

            if (trcode == "TTRODP11301")//(정상) : TTRODP11301
            {
                for (int i = table_미체결현황.Rows.Count - 1; i >= 0; i--)
                {
                    if (int.Parse(table_미체결현황.Rows[i]["주문번호"].ToString()) == int.Parse(orgordno))//주문번호와 원주문 번호를 비교 해야 함.
                    {
                        int 미체결수량 = int.Parse(table_미체결현황.Rows[i]["미체결수량"].ToString());
                        if (미체결수량 > int.Parse(qty))//일부 정정/취소
                        {
                            table_미체결현황.Rows[i]["미체결수량"] = 미체결수량 - int.Parse(qty);
                        }
                        else//전부 정정/취소
                        {
                            table_미체결현황.Rows.RemoveAt(i);
                        }

                        if (mocagb == "2")//정정
                        {
                            DataRow newrow = table_미체결현황.NewRow();
                            newrow["주문번호"] = ordno;
                            newrow["종목코드"] = code;
                            newrow["종목명"] = 종목명;
                            newrow["매매구분"] = dosugb;
                            newrow["주문가격"] = price;
                            newrow["주문수량"] = qty;
                            newrow["미체결수량"] = qty;
                            table_미체결현황.Rows.Add(newrow);
                        }
                        else if (mocagb == "3")//취소 ==> 잔고현황의 청산가능수량에대한 복구
                        {
                            foreach (DataRow row in table_잔고현황.Select("종목코드 = '" + code + "' And 매매구분 <> '" + dosugb + "'"))
                            {
                                row["청산가능수량"] = int.Parse(row["청산가능수량"].ToString()) + int.Parse(qty);
                            }
                        }

                        break;
                    }
                }
            }
            else if (trcode == "TTRODP11321")//(거부) : TTRODP11321 //정정또는 취소와 관련하여 tabl에서 처리할 작업은 없슴. 
            {
                MessageBox.Show(rejcode + " : 주문번호 " + ordno + "에 대한 주문이 거부 되었습니다.");

                if (mocagb == "1")//신규주문에 대한 거부확인은 미체결현황과 잔고현황의 청산가능수량에대한 원위치 작업이 필요함.
                {
                    //미체결현황의 거부주문 삭제.
                    for (int i = 0; i < table_미체결현황.Rows.Count; i++)
                    {
                        if (int.Parse(table_미체결현황.Rows[i]["주문번호"].ToString()) == int.Parse(ordno))
                        {
                            table_미체결현황.Rows.RemoveAt(i);
                            break;
                        }
                    }

                    //잔고현황의 청산가능수량에대한 원위치 작업
                    foreach (DataRow row in table_잔고현황.Select("종목코드 = '" + code + "' And 매매구분 <> '" + dosugb + "'"))
                    {
                        row["청산가능수량"] = int.Parse(row["청산가능수량"].ToString()) + int.Parse(qty2);//호가수량만큼 복귀
                    }
                }
            }

        }

        void C01_ReceiveRealData(string szTrCode)//주문체결
        {
            string 계좌번호 = C01.GetFieldData("OutBlock", "accno");
            if (계좌번호 != this.계좌번호)
                return;
            string 주문번호 = int.Parse(C01.GetFieldData("OutBlock", "ordno")).ToString();
            string 종목코드 = from표준to단축(C01.GetFieldData("OutBlock", "expcode"));
            string 종목명 = 종목명불러오기(종목코드);
            string 체결가격 = C01.GetFieldData("OutBlock", "cheprice");
            string 체결수량 = C01.GetFieldData("OutBlock", "chevol");
            string 매매구분 = "매도";
            string 진입청산 = "";

            if (C01.GetFieldData("OutBlock", "dosugb") == "2")
                매매구분 = "매수";

            //잔고현황 갱신
            bool 처리완료 = false;
            for (int i = table_잔고현황.Rows.Count - 1; i >= 0; i--)
            {
                if (table_잔고현황.Rows[i]["종목코드"].ToString() == 종목코드)
                {
                    처리완료 = true;

                    string 잔고의매매구분 = table_잔고현황.Rows[i]["매매구분"].ToString();

                    if (잔고의매매구분 == 매매구분)//추가진입
                    {
                        table_잔고현황.Rows[i]["평균진입단가"] = (double.Parse(table_잔고현황.Rows[i]["평균진입단가"].ToString()) * double.Parse(table_잔고현황.Rows[i]["잔고수량"].ToString()) + double.Parse(체결가격) * double.Parse(체결수량)) / (double.Parse(table_잔고현황.Rows[i]["잔고수량"].ToString()) + double.Parse(체결수량));

                        table_잔고현황.Rows[i]["잔고수량"] = int.Parse(table_잔고현황.Rows[i]["잔고수량"].ToString()) + int.Parse(체결수량);
                        table_잔고현황.Rows[i]["청산가능수량"] = int.Parse(table_잔고현황.Rows[i]["청산가능수량"].ToString()) + int.Parse(체결수량);
                        진입청산 = "진입";
                    }
                    else//청산
                    {
                        진입청산 = "청산";

                        table_잔고현황.Rows[i]["잔고수량"] = int.Parse(table_잔고현황.Rows[i]["잔고수량"].ToString()) - int.Parse(체결수량);
                        if (int.Parse(table_잔고현황.Rows[i]["잔고수량"].ToString()) == 0)//전부청산
                        {
                            table_잔고현황.Rows.RemoveAt(i);
                            현재가요청해제(종목코드);
                        }
                        else if (int.Parse(table_잔고현황.Rows[i]["잔고수량"].ToString()) < 0)//SAR
                        {
                            table_잔고현황.Rows[i]["잔고수량"] = Math.Abs(int.Parse(table_잔고현황.Rows[i]["잔고수량"].ToString()));
                            table_잔고현황.Rows[i]["평균진입단가"] = 체결가격;
                            table_잔고현황.Rows[i]["매매구분"] = 매매구분;
                            table_잔고현황.Rows[i]["청산가능수량"] = table_잔고현황.Rows[i]["잔고수량"].ToString();
                            진입청산 = "SAR";
                        }
                        
                    }
                }
            }
            if (!처리완료)
            {
                DataRow newrow = table_잔고현황.NewRow();
                newrow["종목코드"] = 종목코드;
                newrow["종목명"] = 종목명;
                newrow["매매구분"] = 매매구분;
                newrow["잔고수량"] = 체결수량;
                newrow["청산가능수량"] = 체결수량;
                newrow["평균진입단가"] = 체결가격;
                newrow["현재가"] = "";
                newrow["평가손익"] = "";
                table_잔고현황.Rows.Add(newrow);
                진입청산 = "진입";

                현재가요청(종목코드);
            }

            string 주문수량 = "";
            string 주문가격 = "";

            //미체결현황 갱신
            처리완료 = false;
            for (int i = table_미체결현황.Rows.Count - 1; i >= 0; i--)
            {
                if (int.Parse(table_미체결현황.Rows[i]["주문번호"].ToString()) == int.Parse(주문번호))
                {
                    처리완료 = true;
                    주문수량 = table_미체결현황.Rows[i]["주문수량"].ToString();
                    주문가격 = table_미체결현황.Rows[i]["주문가격"].ToString();
                    table_미체결현황.Rows[i]["미체결수량"] = int.Parse(table_미체결현황.Rows[i]["미체결수량"].ToString()) - int.Parse(체결수량);
                    if (int.Parse(table_미체결현황.Rows[i]["미체결수량"].ToString()) <= 0)
                    {
                        table_미체결현황.Rows.RemoveAt(i);
                    }
                    break;
                }
            }

            if (!처리완료)//미체결주문 접수전 체결이므로 Parking!!!
            {
                List<string> newlist = new List<string>();
                newlist.Add(종목코드);
                newlist.Add(종목명);
                newlist.Add(매매구분);
                newlist.Add(체결가격);
                newlist.Add(체결수량);
                newlist.Add(진입청산);//진입,청산.SAR
                Parking_체결데이타.Add(int.Parse(주문번호).ToString(), newlist);
            }

            //체결현황 갱신
            처리완료 = false;
            for (int i = 0; i < table_체결현황.Rows.Count; i++)
            {
                if (int.Parse(table_체결현황.Rows[i]["주문번호"].ToString()) == int.Parse(주문번호))
                {
                    처리완료 = true;
                    table_체결현황.Rows[i]["체결가격"] = (double.Parse(table_체결현황.Rows[i]["체결가격"].ToString()) * double.Parse(table_체결현황.Rows[i]["체결수량"].ToString()) + double.Parse(체결가격) * double.Parse(체결수량)) / (double.Parse(table_체결현황.Rows[i]["체결수량"].ToString()) + double.Parse(체결수량));
                    table_체결현황.Rows[i]["체결수량"] = int.Parse(table_체결현황.Rows[i]["체결수량"].ToString()) + int.Parse(체결수량);
                    break;
                }
            }

            if (!처리완료)
            {
                DataRow newrow = table_체결현황.NewRow();
                newrow["주문번호"] = 주문번호;
                newrow["종목코드"] = 종목코드;
                newrow["종목명"] = 종목명;
                newrow["매매구분"] = 매매구분;
                newrow["주문가격"] = 주문가격;
                newrow["주문수량"] = 주문수량;
                newrow["체결가격"] = 체결가격;
                newrow["체결수량"] = 체결수량;
                table_체결현황.Rows.InsertAt(newrow, 0);
            }
        }

        void myTimer_t0434_Tick(object sender, EventArgs e)
        {
            t0434.SetFieldData("t0434InBlock", "cts_ordno", 0, 연속키_t0434_cts_ordno);
            t0434.Request(true);
            myTimer_t0434.Stop();
        }

        void t0434_ReceiveData(string szTrCode)
        {
            int cnt = t0434.GetBlockCount("t0434OutBlock1");
            for (int i = 0; i < cnt; i++)
            {
                DataRow newrow_체결 = table_체결현황.NewRow();
                DataRow newrow_미체결 = table_미체결현황.NewRow();

                string 주문번호 = int.Parse(t0434.GetFieldData("t0434OutBlock1", "ordno", i)).ToString();
                string 매도매수 = t0434.GetFieldData("t0434OutBlock1", "medosu", i);
                string 주문수량 = t0434.GetFieldData("t0434OutBlock1", "qty", i);
                string 주문가격 = t0434.GetFieldData("t0434OutBlock1", "price", i);
                string 체결수량 = t0434.GetFieldData("t0434OutBlock1", "cheqty", i);
                string 체결가격 = t0434.GetFieldData("t0434OutBlock1", "cheprice", i);
                string 미체결수량 = t0434.GetFieldData("t0434OutBlock1", "ordrem", i);
                string 종목코드 = t0434.GetFieldData("t0434OutBlock1", "expcode", i);
                string 종목명 = 종목명불러오기(t0434.GetFieldData("t0434OutBlock1", "expcode", i));
                if (int.Parse(체결수량) > 0)
                {
                    newrow_체결["주문번호"] = 주문번호;
                    newrow_체결["종목코드"] = 종목코드;
                    newrow_체결["종목명"] = 종목명;
                    newrow_체결["매매구분"] = 매도매수;
                    newrow_체결["주문가격"] = 주문가격;
                    newrow_체결["주문수량"] = 주문수량;
                    newrow_체결["체결가격"] = 체결가격;
                    newrow_체결["체결수량"] = 체결수량;

                    table_체결현황.Rows.Add(newrow_체결);
                }

                if (int.Parse(미체결수량) > 0)
                {
                    newrow_미체결["주문번호"] = 주문번호;
                    newrow_미체결["종목코드"] = 종목코드;
                    newrow_미체결["종목명"] = 종목명;
                    newrow_미체결["매매구분"] = 매도매수;
                    newrow_미체결["주문가격"] = 주문가격;
                    newrow_미체결["주문수량"] = 주문수량;
                    newrow_미체결["미체결수량"] = 미체결수량;

                    table_미체결현황.Rows.Add(newrow_미체결);
                }
            }

            if (t0434.IsNext)
            {
                연속키_t0434_cts_ordno = t0434.GetFieldData("t0434OutBlock", "cts_ordno", 0);
                myTimer_t0434.Interval = 1000;
                myTimer_t0434.Start();
            }
            else
            {
                myTimer_t0434.Stop();
            }
        }


        void t0434_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage, this.GetType().ToString());
            }
        }

        void myTimer_t0441_Tick(object sender, EventArgs e)
        {
            t0441.SetFieldData("t0441InBlock", "cts_expcode", 0, 연속키_t0441_cts_expcode);
            t0441.SetFieldData("t0441InBlock", "cts_medocd", 0, 연속키_t0441_cts_medocd);
            t0441.Request(true);
            myTimer_t0441.Stop();
        }

        void t0441_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage, this.GetType().ToString());
            }
        }

        private void 현재가요청(string code)
        {
            if (code.Substring(0, 3) == "101")
            {
                FC0.SetFieldData("InBlock", "futcode", code);
                FC0.AdviseRealData();
            }
            else
            {
                OC0.SetFieldData("InBlock", "optcode", code);
                OC0.AdviseRealData();
            }
        }

        private void 현재가요청해제(string code)
        {
            if (code.Substring(0, 3) == "101")
            {
                FC0.UnadviseRealDataWithKey(code);
            }
            else
            {
                OC0.UnadviseRealDataWithKey(code);
            }
        }

        void t0441_ReceiveData(string szTrCode)
        {
            int cnt = t0441.GetBlockCount("t0441OutBlock1");
            for (int i = 0; i < cnt; i++)
            {
                DataRow newrow = table_잔고현황.NewRow();
                newrow["종목코드"] = t0441.GetFieldData("t0441OutBlock1", "expcode", i);
                newrow["종목명"] = 종목명불러오기(t0441.GetFieldData("t0441OutBlock1", "expcode", i));
                newrow["매매구분"] = t0441.GetFieldData("t0441OutBlock1", "medosu", i);
                newrow["잔고수량"] = t0441.GetFieldData("t0441OutBlock1", "jqty", i);
                newrow["청산가능수량"] = t0441.GetFieldData("t0441OutBlock1", "cqty", i);
                newrow["평균진입단가"] = t0441.GetFieldData("t0441OutBlock1", "pamt", i);
                newrow["현재가"] = t0441.GetFieldData("t0441OutBlock1", "price", i);
                newrow["평가손익"] = t0441.GetFieldData("t0441OutBlock1", "dtsunik1", i);
                table_잔고현황.Rows.Add(newrow);

                현재가요청(newrow["종목코드"].ToString());
            }

            if (t0441.IsNext)
            {
                연속키_t0441_cts_expcode = t0441.GetFieldData("t0441OutBlock", "cts_expcode", 0);
                연속키_t0441_cts_medocd = t0441.GetFieldData("t0441OutBlock", "cts_medocd", 0);
                myTimer_t0441.Interval = 1000;
                myTimer_t0441.Start();
            }
            else
            {
                myTimer_t0441.Stop();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, List<string>> acc in Form1.Acclist)
            {
                if (comboBox1.SelectedItem.ToString() == acc.Key)
                {
                    label1.Text = acc.Value[1];
                    textBox1.Text = acc.Value[0];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "선물옵션계좌현황 : " + comboBox1.SelectedItem.ToString() + "(" + label1.Text + ")";

            table_미체결현황.Clear();
            table_잔고현황.Clear();
            table_체결현황.Clear();

            FC0.UnadviseRealData();
            OC0.UnadviseRealData();

            계좌번호 = comboBox1.SelectedItem.ToString();

            t0441.SetFieldData("t0441InBlock", "accno", 0, comboBox1.SelectedItem.ToString());
            t0441.SetFieldData("t0441InBlock", "passwd", 0, textBox1.Text);
            t0441.Request(false);

            t0434.SetFieldData("t0434InBlock", "accno", 0, comboBox1.SelectedItem.ToString());
            t0434.SetFieldData("t0434InBlock", "passwd", 0, textBox1.Text);
            //t0434.SetFieldData("t0434InBlock", "expcode", 0, "값");
            t0434.SetFieldData("t0434InBlock", "chegb", 0, "0");
            t0434.SetFieldData("t0434InBlock", "sortgb", 0, "1");
            t0434.Request(false);

            O01.UnadviseRealData();
            H01.UnadviseRealData();
            C01.UnadviseRealData();

            O01.AdviseRealData();
            H01.AdviseRealData();
            C01.AdviseRealData();
        }

        private string 종목명불러오기(string Code)
        {
            string 종목명 = "";
            foreach(KeyValuePair<string,List<string>> aaa in Form1.Master선옵종목)
            {
                if (aaa.Key == Code)
                {
                    종목명= aaa.Value[0];
                    break;
                }
            }
            return 종목명;
        }

        private string from표준to단축(string code)
        {
            string 반환값 = "";
            foreach (KeyValuePair<string, List<string>> 종목 in Form1.Master선옵종목)
            {
                if (종목.Value[1] == code)
                {
                    반환값 = 종목.Key;
                    break;
                }
            }
            return 반환값;
        }

        ~선물계좌현황()
        {
            C01.UnadviseRealData();
            H01.UnadviseRealData();
            O01.UnadviseRealData();
            FC0.UnadviseRealData();
            OC0.UnadviseRealData();

            C01 = null;
            H01 = null;
            O01 = null;
            FC0 = null;
            OC0 = null;
        }
    }
}
