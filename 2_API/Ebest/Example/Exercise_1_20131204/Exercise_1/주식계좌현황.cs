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
    public partial class 주식계좌현황 : Form
    {
        DataTable table_잔고현황 = new DataTable();
        DataTable table_미체결현황 = new DataTable();
        DataTable table_체결현황 = new DataTable();

        XAQueryClass t0425 = new XAQueryClass();
        XAQueryClass t0424 = new XAQueryClass();


        XARealClass SC0 = new XARealClass();//주식주문접수
        XARealClass SC1 = new XARealClass();//주식주문체결
        XARealClass SC2 = new XARealClass();//주식주문정정
        XARealClass SC3 = new XARealClass();//주식주문취소
        XARealClass SC4 = new XARealClass();//주식주문거부

        XARealClass K3_ = new XARealClass();//KOSDAQ체결
        XARealClass S3_ = new XARealClass();//KOSPI체결

        Timer myTimer_t0424 = new Timer();
        string 연속key_t0424 = "";

        Timer myTimer_t0425 = new Timer();
        string 연속key_t0425 = "";

        string 계좌번호 = "";

        public 주식계좌현황()
        {
            InitializeComponent();

            table_잔고현황.Columns.Add("종목코드");
            table_잔고현황.Columns.Add("종목명");
            table_잔고현황.Columns.Add("잔고수량");
            table_잔고현황.Columns.Add("매도가능수량");
            table_잔고현황.Columns.Add("평균단가");
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
                if (acc.Value[2] == "주식위탁")
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
                MessageBox.Show("등록된 주식계좌가 없습니다");
                this.Close();
            }

            t0424.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(t0424_ReceiveData);
            t0424.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(t0424_ReceiveMessage);

            t0425.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(t0425_ReceiveData);
            t0425.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(t0425_ReceiveMessage);

            t0424.ResFileName = @"C:\ETRADE\xingAPI\Res\t0424.res";
            t0425.ResFileName = @"C:\ETRADE\xingAPI\Res\t0425.res";

            myTimer_t0424.Tick += new EventHandler(myTimer_t0424_Tick);
            myTimer_t0425.Tick += new EventHandler(myTimer_t0425_Tick);

            SC0.ResFileName = @"C:\ETRADE\xingAPI\Res\SC0.res";
            SC1.ResFileName = @"C:\ETRADE\xingAPI\Res\SC1.res";
            SC2.ResFileName = @"C:\ETRADE\xingAPI\Res\SC2.res";
            SC3.ResFileName = @"C:\ETRADE\xingAPI\Res\SC3.res";
            SC4.ResFileName = @"C:\ETRADE\xingAPI\Res\SC4.res";

            K3_.ResFileName = @"C:\ETRADE\xingAPI\Res\K3_.res";
            S3_.ResFileName = @"C:\ETRADE\xingAPI\Res\S3_.res";

            SC0.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(SC0_ReceiveRealData);
            SC1.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(SC1_ReceiveRealData);
            SC2.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(SC2_ReceiveRealData);
            SC3.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(SC3_ReceiveRealData);
            SC4.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(SC4_ReceiveRealData);

            K3_.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(K3__ReceiveRealData);
            S3_.ReceiveRealData += new _IXARealEvents_ReceiveRealDataEventHandler(S3__ReceiveRealData);
        }

        void SC0_ReceiveRealData(string szTrCode)//주식주문접수
        {
            string accno = SC0.GetFieldData("OutBlock", "accno");//계좌번호

            if (계좌번호 != accno)
                return;

            string trcode = SC0.GetFieldData("OutBlock", "trcode");//TRCODE  //SONAT000:신규주문, SONAT001:정정주문, SONAT002:취소주문

            if (trcode != "SONAT000")//신규주문 접수에 대해서만 처리한다. 
                return;

            string ordno = int.Parse(SC0.GetFieldData("OutBlock", "ordno")).ToString();//주문번호
            string shtcode = SC0.GetFieldData("OutBlock", "shtcode").Replace("A","").Trim();//단축종목번호
            string hname = SC0.GetFieldData("OutBlock", "hname");//종목명
            string bnstp = "매도";
            if (SC0.GetFieldData("OutBlock", "bnstp") == "2")//매매구분 1:매도, 2:매수
            {
                bnstp = "매수";
            }
            string ordqty = SC0.GetFieldData("OutBlock", "ordqty");//주문수량
            string ordprice = SC0.GetFieldData("OutBlock", "ordprice");//주문가격           

            //잔고현황의 매도가능수량 갱신
            if (bnstp == "매도")
            {
                foreach (DataRow row in table_잔고현황.Select("종목코드 = '" + shtcode + "'"))
                {
                    row["매도가능수량"] = int.Parse(row["매도가능수량"].ToString()) - int.Parse(ordqty);
                }
            }

            //미체결 현황 갱신.
            DataRow newrow = table_미체결현황.NewRow();
            newrow["주문번호"] = ordno;
            newrow["종목코드"] = shtcode;
            newrow["종목명"] = hname;
            newrow["매매구분"] = bnstp;
            newrow["주문가격"] = ordprice;
            newrow["주문수량"] = ordqty;
            newrow["미체결수량"] = ordqty;
            table_미체결현황.Rows.InsertAt(newrow, 0);
        }

        void SC1_ReceiveRealData(string szTrCode)//주식주문체결
        {
            string 계좌번호 = SC1.GetFieldData("OutBlock", "accno");
            if (계좌번호 != this.계좌번호)
                return;
            string 주문번호 = int.Parse(SC1.GetFieldData("OutBlock", "ordno")).ToString();
            string 종목코드 = from표준to단축(SC1.GetFieldData("OutBlock", "Isuno").Trim());
            string 종목명 = SC1.GetFieldData("OutBlock", "Isunm");
            string 체결가격 = SC1.GetFieldData("OutBlock", "execprc");
            string 체결수량 = SC1.GetFieldData("OutBlock", "execqty");
            string 매매구분 = "매도";
            if (SC1.GetFieldData("OutBlock", "bnstp") == "2")
                매매구분 = "매수";

            //잔고현황 갱신
            bool 처리완료 = false;
            for (int i = table_잔고현황.Rows.Count - 1; i >= 0; i--)
            {
                if (table_잔고현황.Rows[i]["종목코드"].ToString() == 종목코드)
                {
                    처리완료 = true;

                    if (매매구분 == "매수")//추가진입
                    {
                        table_잔고현황.Rows[i]["평균단가"] = (double.Parse(table_잔고현황.Rows[i]["평균단가"].ToString()) * double.Parse(table_잔고현황.Rows[i]["잔고수량"].ToString()) + double.Parse(체결가격) * double.Parse(체결수량)) / (double.Parse(table_잔고현황.Rows[i]["잔고수량"].ToString()) + double.Parse(체결수량));

                        table_잔고현황.Rows[i]["잔고수량"] = int.Parse(table_잔고현황.Rows[i]["잔고수량"].ToString()) + int.Parse(체결수량);
                        table_잔고현황.Rows[i]["매도가능수량"] = int.Parse(table_잔고현황.Rows[i]["매도가능수량"].ToString()) + int.Parse(체결수량);
                    }
                    else//청산
                    {
                        table_잔고현황.Rows[i]["잔고수량"] = int.Parse(table_잔고현황.Rows[i]["잔고수량"].ToString()) - int.Parse(체결수량);
                        if (int.Parse(table_잔고현황.Rows[i]["잔고수량"].ToString()) == 0)//전부청산
                        {
                            table_잔고현황.Rows.RemoveAt(i);
                            현재가요청해제(종목코드);
                        }
                    }
                }
            }
            if (!처리완료)
            {
                DataRow newrow = table_잔고현황.NewRow();
                newrow["종목코드"] = 종목코드;
                newrow["종목명"] = 종목명;
                newrow["잔고수량"] = 체결수량;
                newrow["매도가능수량"] = 체결수량;
                newrow["평균단가"] = 체결가격;
                newrow["현재가"] = "";
                newrow["평가손익"] = "";
                table_잔고현황.Rows.Add(newrow);

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
            if (!처리완료)
            {
                MessageBox.Show("미체결현황에 없는 주문체결임(주문번호 : " + 주문번호 + ", 종목명 : " + 종목명 + ")");
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

        void SC2_ReceiveRealData(string szTrCode)//주식주문정정
        {
            string accno = SC2.GetFieldData("OutBlock", "accno");//계좌번호
            if (계좌번호 != accno)
                return;

            string ordno = int.Parse(SC2.GetFieldData("OutBlock", "ordno")).ToString();//주문번호
            string orgordno = int.Parse(SC2.GetFieldData("OutBlock", "orgordno")).ToString();//원주문번호
            string code = from표준to단축(SC2.GetFieldData("OutBlock", "Isuno").Trim());//종목코드
            string 종목명 = SC2.GetFieldData("OutBlock", "Isunm");
            string dosugb = "매도";
            if (SC2.GetFieldData("OutBlock", "bnstp") == "2")//매도수구분 1 매도, 2 매수
            {
                dosugb = "매수";
            }
            string mdfycnfqty = SC2.GetFieldData("OutBlock", "mdfycnfqty");//정정확인수량
            string mdfycnfprc = SC2.GetFieldData("OutBlock", "mdfycnfprc");//정정확인가격
            
            for (int i = table_미체결현황.Rows.Count - 1; i >= 0; i--)
            {
                if (int.Parse(table_미체결현황.Rows[i]["주문번호"].ToString()) == int.Parse(orgordno))//주문번호와 원주문 번호를 비교 해야 함.
                {
                    int 미체결수량 = int.Parse(table_미체결현황.Rows[i]["미체결수량"].ToString());
                    if (미체결수량 > int.Parse(mdfycnfqty))//일부 정정
                    {
                        table_미체결현황.Rows[i]["미체결수량"] = 미체결수량 - int.Parse(mdfycnfqty);
                    }
                    else//전부 정정
                    {
                        table_미체결현황.Rows.RemoveAt(i);
                    }

                    DataRow newrow = table_미체결현황.NewRow();
                    newrow["주문번호"] = ordno;
                    newrow["종목코드"] = code;
                    newrow["종목명"] = 종목명;
                    newrow["매매구분"] = dosugb;
                    newrow["주문가격"] = mdfycnfprc;
                    newrow["주문수량"] = mdfycnfqty;
                    newrow["미체결수량"] = mdfycnfqty;
                    table_미체결현황.Rows.InsertAt(newrow, 0);

                    break;
                }
            }
        }

        void SC3_ReceiveRealData(string szTrCode)//주식주문취소
        {
            string accno = SC3.GetFieldData("OutBlock", "accno");//계좌번호
            if (계좌번호 != accno)
                return;

            string code = from표준to단축(SC3.GetFieldData("OutBlock", "Isuno").Trim());//종목코드
            string orgordno = int.Parse(SC3.GetFieldData("OutBlock", "orgordno")).ToString();//원주문번호
            string canccnfqty = SC3.GetFieldData("OutBlock", "canccnfqty");//취소확인수량
            string bnstp = "매도";
            if (SC3.GetFieldData("OutBlock", "bnstp") == "2")//매도수구분 1 매도, 2 매수
            {
                bnstp = "매수";
            }

            for (int i = table_미체결현황.Rows.Count - 1; i >= 0; i--)
            {
                if (int.Parse(table_미체결현황.Rows[i]["주문번호"].ToString()) == int.Parse(orgordno))//주문번호와 원주문 번호를 비교 해야 함.
                {
                    int 미체결수량 = int.Parse(table_미체결현황.Rows[i]["미체결수량"].ToString());
                    if (미체결수량 > int.Parse(canccnfqty))//일부 취소
                    {
                        table_미체결현황.Rows[i]["미체결수량"] = 미체결수량 - int.Parse(canccnfqty);
                    }
                    else//전부 취소
                    {
                        table_미체결현황.Rows.RemoveAt(i);
                    }

                    //매도취소 ==> 잔고현황의 매도가능수량에대한 복구
                    //if (table_미체결현황.Rows[i]["매매구분"].ToString() == "매도")
                    if (bnstp == "매도")
                    {
                        foreach (DataRow row in table_잔고현황.Select("종목코드 = '" + code + "'"))
                        {
                            row["매도가능수량"] = int.Parse(row["매도가능수량"].ToString()) + int.Parse(canccnfqty);
                        }
                    }

                    break;
                }
            }           
        }

        void SC4_ReceiveRealData(string szTrCode)//주식주문거부
        {
            string accno = SC4.GetFieldData("OutBlock", "accno");//계좌번호
            if (계좌번호 != accno)
                return;

            string trcode = SC4.GetFieldData("OutBlock", "trcode");//trcode  SONAT000:신규주문, SONAT001:정정주문, SONAT002:취소주문, SONAS100:체결확인           
            string ordno = int.Parse(SC4.GetFieldData("OutBlock", "ordno")).ToString();//주문번호
            string orgordno = int.Parse(SC4.GetFieldData("OutBlock", "orgordno")).ToString();//원주문번호
            string code = SC4.GetFieldData("OutBlock", "Isuno");//종목코드
            string 종목명 = SC4.GetFieldData("OutBlock", "Isunm");//종목명

            if (trcode == "SONAT001" || trcode == "SONAT002") //정정또는 취소와 관련하여 tabl에서 처리할 작업은 없슴. 
            {
                MessageBox.Show("정정/취소 주문에 대하여 거부되었슴.(주문번호 : " + ordno + ", 원부문번호 : " + orgordno + ", 종목명 : " + 종목명 + ")");
                return;
            }

            string bnstp = "매도";
            if (SC4.GetFieldData("OutBlock", "bnstp") == "2")//매도수구분 1 매도, 2 매수
            {
                bnstp = "매수";
            }
            string rjtqty = SC4.GetFieldData("OutBlock", "rjtqty");//거부수량

            if (trcode == "SONAT000")//SONAT000:신규주문
            {
                MessageBox.Show("신규주문에 대하여 거부되었슴.(주문번호 : " + ordno + ", 종목명 : " + 종목명 + ")");
                for (int i = table_미체결현황.Rows.Count - 1; i >= 0; i--)
                {
                    if (int.Parse(table_미체결현황.Rows[i]["주문번호"].ToString()) == int.Parse(orgordno))//주문번호와 원주문 번호를 비교 해야 함.
                    {
                        int 미체결수량 = int.Parse(table_미체결현황.Rows[i]["미체결수량"].ToString());
                        if (미체결수량 > int.Parse(rjtqty))//일부 거부?
                        {
                            table_미체결현황.Rows[i]["미체결수량"] = 미체결수량 - int.Parse(rjtqty);
                        }
                        else//전부 거부
                        {
                            table_미체결현황.Rows.RemoveAt(i);
                        }

                        //매도거부 ==> 잔고현황의 매도가능수량에대한 복구
                        //if (table_미체결현황.Rows[i]["매매구분"].ToString() == "매도")
                        if (bnstp == "매도")
                        {
                            foreach (DataRow row in table_잔고현황.Select("종목코드 = '" + code + "'"))
                            {
                                row["매도가능수량"] = int.Parse(row["매도가능수량"].ToString()) + int.Parse(rjtqty);
                            }
                        }
                        
                        break;
                    }
                }
            }           
        }

        void K3__ReceiveRealData(string szTrCode)
        {
            string 단축코드 = K3_.GetFieldData("OutBlock", "shcode").Trim();
            string 현재가 = K3_.GetFieldData("OutBlock", "price");

            foreach (DataRow row in table_잔고현황.Select("종목코드 = '" + 단축코드 + "'"))
            {
                row["현재가"] = 현재가;
                평가손익계산(row);
            }
        }

        void S3__ReceiveRealData(string szTrCode)
        {
            string 단축코드 = S3_.GetFieldData("OutBlock", "shcode").Trim();
            string 현재가 = S3_.GetFieldData("OutBlock", "price");

            foreach (DataRow row in table_잔고현황.Select("종목코드 = '" + 단축코드 + "'"))
            {
                row["현재가"] = 현재가;
                평가손익계산(row);
            }
        }

        private void 평가손익계산(DataRow row)
        {
            row["평가손익"] = int.Parse(row["잔고수량"].ToString()) * (int.Parse(row["현재가"].ToString()) - int.Parse(row["평균단가"].ToString()));
        }

        void myTimer_t0425_Tick(object sender, EventArgs e)
        {
            t0425.SetFieldData("t0424InBlock", "cts_ordno", 0, 연속key_t0425);
            t0425.Request(true);
            myTimer_t0425.Stop();
        }

        void myTimer_t0424_Tick(object sender, EventArgs e)
        {
            t0424.SetFieldData("t0425InBlock", "cts_expcode", 0, 연속key_t0424);
            t0424.Request(true);
            myTimer_t0424.Stop();
        }


        void t0425_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage, this.GetType().ToString());
            }
        }

        void t0425_ReceiveData(string szTrCode)//주식 체결/미체결
        {
            int cnt = t0425.GetBlockCount("t0425OutBlock1");

            for (int i = 0; i < cnt; i++)
            {
                string 주문번호 = t0425.GetFieldData("t0425OutBlock1", "ordno", i);
                string 종목코드 = t0425.GetFieldData("t0425OutBlock1", "expcode", i);
                string 주문수량 = t0425.GetFieldData("t0425OutBlock1", "qty", i);
                string 주문가격 = t0425.GetFieldData("t0425OutBlock1", "price", i);
                string 체결수량 = t0425.GetFieldData("t0425OutBlock1", "cheqty", i);
                string 체결가격 = t0425.GetFieldData("t0425OutBlock1", "cheprice", i);
                string 미체결수량 = t0425.GetFieldData("t0425OutBlock1", "ordrem", i);
                string 매매구분 = t0425.GetFieldData("t0425OutBlock1", "medosu", i);
                string 종목명 = 종목명불러오기(종목코드);
                //Console.WriteLine("체결수량 : " + 체결수량 + ",      미체결수량 : " + 미체결수량);

                if (int.Parse(체결수량) > 0)
                {
                    //Console.WriteLine("if (int.Parse(체결수량) > 0)");
                    DataRow newrow = table_체결현황.NewRow();
                    newrow["주문번호"] = 주문번호;
                    newrow["종목코드"] = 종목코드;
                    newrow["매매구분"] = 매매구분;
                    newrow["주문가격"] = 주문가격;
                    newrow["주문수량"] = 주문수량;
                    newrow["체결수량"] = 체결수량;
                    newrow["체결가격"] = 체결가격;
                    newrow["종목명"] = 종목명;

                    table_체결현황.Rows.Add(newrow);
                }

                if (int.Parse(미체결수량) > 0)
                {
                    //Console.WriteLine("if (int.Parse(미체결수량) > 0)");
                    DataRow newrow1 = table_미체결현황.NewRow();
                    newrow1["주문번호"] = 주문번호;
                    newrow1["종목코드"] = 종목코드;
                    newrow1["매매구분"] = 매매구분;
                    newrow1["주문가격"] = 주문가격;
                    newrow1["주문수량"] = 주문수량;
                    newrow1["미체결수량"] = 미체결수량;
                    newrow1["종목명"] = 종목명;

                    table_미체결현황.Rows.Add(newrow1);
                }
            }

            if (t0425.IsNext)
            {
                연속key_t0425 = t0425.GetFieldData("t0425OutBlock", "cts_ordno", 0);

                myTimer_t0425.Interval = 1000;
                myTimer_t0425.Start();
            }
            else
            {
                myTimer_t0425.Stop();
            }
        }

        void t0424_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage, this.GetType().ToString());
            }
        }

        void t0424_ReceiveData(string szTrCode)//주식잔고2
        {
            int cnt = t0424.GetBlockCount("t0424OutBlock1");

            for (int i = 0; i < cnt; i++)
            {
                string 종목코드 = t0424.GetFieldData("t0424OutBlock1", "expcode", i).Trim();
                string 잔고수량 = t0424.GetFieldData("t0424OutBlock1", "janqty", i);
                string 매도가능수량 = t0424.GetFieldData("t0424OutBlock1", "mdposqt", i);
                string 평균단가 = t0424.GetFieldData("t0424OutBlock1", "pamt", i);
                string 종목명 = t0424.GetFieldData("t0424OutBlock1", "hname", i);
                string 현재가 = t0424.GetFieldData("t0424OutBlock1", "price", i);
                string 평가손익 = t0424.GetFieldData("t0424OutBlock1", "dtsunik", i);
                
                DataRow newrow = table_잔고현황.NewRow();
                newrow["종목코드"] = 종목코드;
                newrow["잔고수량"] = 잔고수량;
                newrow["매도가능수량"] = 매도가능수량;
                newrow["평균단가"] = 평균단가;
                newrow["종목명"] = 종목명;
                newrow["현재가"] = 현재가;
                newrow["평가손익"] = 평가손익;
                table_잔고현황.Rows.Add(newrow);

                현재가요청(종목코드);
            }
            if (t0424.IsNext)
            {
                연속key_t0424 = t0424.GetFieldData("t0424OutBlock", "cts_expcode", 0);
                
                myTimer_t0424.Interval = 1000;
                myTimer_t0424.Start();
            }
            else
            {
                myTimer_t0424.Stop();
            }
        }

        private void 현재가요청(string code)
        {
            if (!Form1.Master주식종목.ContainsKey(code))
            {
                MessageBox.Show("현재가요청(" + code + ") : 해당코드가 Master주식종목에 등록되어있지 않습니다.");
                return;
            }
            string 소속부 = Form1.Master주식종목[code][2];

            if (소속부 == "거래소")
            {
                S3_.SetFieldData("InBlock", "shcode", code);
                S3_.AdviseRealData();
            }
            else if (소속부 == "코스닥")
            {
                K3_.SetFieldData("InBlock", "shcode", code);
                K3_.AdviseRealData();
            }
        }

        private void 현재가요청해제(string code)
        {
            string 소속부 = Form1.Master주식종목[code][2];

            if (소속부 == "거래소")
            {
                S3_.UnadviseRealDataWithKey(code);
            }
            else if (소속부 == "코스닥")
            {
                K3_.UnadviseRealDataWithKey(code);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Text = "주식계좌현황 : " + comboBox1.SelectedItem.ToString() + "(" + label2.Text + ")";

            table_잔고현황.Clear();
            table_미체결현황.Clear();
            table_체결현황.Clear();

            K3_.UnadviseRealData();
            S3_.UnadviseRealData();

            계좌번호 = comboBox1.SelectedItem.ToString();

            t0424.SetFieldData("t0424InBlock", "accno", 0, comboBox1.SelectedItem.ToString());
            t0424.SetFieldData("t0424InBlock", "passwd", 0, textBox1.Text);
            t0424.SetFieldData("t0424InBlock", "prcgb", 0, "1");
            t0424.SetFieldData("t0424InBlock", "chegb", 0, "2");
            t0424.SetFieldData("t0424InBlock", "dangb", 0, "0");
            t0424.SetFieldData("t0424InBlock", "charge", 0, "0");
            t0424.Request(false);

            t0425.SetFieldData("t0425InBlock", "accno", 0, comboBox1.SelectedItem.ToString());
            t0425.SetFieldData("t0425InBlock", "passwd", 0, textBox1.Text);
            //t0425.SetFieldData("t0425InBlock", "expcode", 0, "값");
            t0425.SetFieldData("t0425InBlock", "chegb", 0, "0");//모의투자시 체결분에 대해서는 응답이 안오는 현상이 있슴.
            t0425.SetFieldData("t0425InBlock", "medosu", 0, "0");
            t0425.SetFieldData("t0425InBlock", "sortgb", 0, "1");
            t0425.Request(false);

            SC0.UnadviseRealData();
            SC1.UnadviseRealData();
            SC2.UnadviseRealData();
            SC3.UnadviseRealData();
            SC4.UnadviseRealData();

            SC0.AdviseRealData();
            SC1.AdviseRealData();
            SC2.AdviseRealData();
            SC3.AdviseRealData();
            SC4.AdviseRealData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accnum = comboBox1.SelectedItem.ToString();
            label2.Text = Form1.Acclist[accnum][1];
            textBox1.Text = Form1.Acclist[accnum][0];
        }

        private string 종목명불러오기(string Code)
        {
            string 종목명 = "";
            foreach (KeyValuePair<string, List<string>> aaa in Form1.Master주식종목)
            {
                if (aaa.Key == Code)
                {
                    종목명 = aaa.Value[0];
                    break;
                }
            }
            return 종목명;
        }

        private string from표준to단축(string code)
        {
            string 반환값 = "";
            foreach (KeyValuePair<string, List<string>> 종목 in Form1.Master주식종목)
            {
                if (종목.Value[1] == code)
                {
                    반환값 = 종목.Key;
                    break;
                }
            }
            return 반환값;
        }

        ~주식계좌현황()
        {
            SC0.UnadviseRealData();
            SC1.UnadviseRealData();
            SC2.UnadviseRealData();
            SC3.UnadviseRealData();
            SC4.UnadviseRealData();
            K3_.UnadviseRealData();
            S3_.UnadviseRealData();

            SC0 = null;
            SC1 = null;
            SC2 = null;
            SC3 = null;
            SC4 = null;
            K3_ = null;
            S3_ = null;
        }
    }
}
