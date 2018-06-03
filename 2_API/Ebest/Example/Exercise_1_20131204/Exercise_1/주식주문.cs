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
    public partial class 주식주문 : Form
    {
        XAQueryClass CSPAT00600 = new XAQueryClass();//정상
        XAQueryClass CSPAT00700 = new XAQueryClass();//정정
        XAQueryClass CSPAT00800 = new XAQueryClass();//취소
        
        string 주문유형 = "";

        public 주식주문()
        {
            InitializeComponent();

            CSPAT00600.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(CSPAT00600_ReceiveData);
            CSPAT00600.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(CSPAT00600_ReceiveMessage);
            CSPAT00600.ResFileName = @"C:\ETRADE\xingAPI\Res\CSPAT00600.res";

            CSPAT00700.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(CSPAT00700_ReceiveData);
            CSPAT00700.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(CSPAT00700_ReceiveMessage);
            CSPAT00700.ResFileName = @"C:\ETRADE\xingAPI\Res\CSPAT00700.res";

            CSPAT00800.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(CSPAT00800_ReceiveData);
            CSPAT00800.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(CSPAT00800_ReceiveMessage);
            CSPAT00800.ResFileName = @"C:\ETRADE\xingAPI\Res\CSPAT00800.res";

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
                MessageBox.Show("등록된 계좌가 없습니다");
                this.Close();
            }
        }
        void CSPAT00600_ReceiveData(string szTrCode)
        {
            toolStripStatusLabel1.Text = CSPAT00600.GetFieldData("CSPAT00600OutBlock2", "OrdNo", 0);
        }
        
        void CSPAT00700_ReceiveData(string szTrCode)
        {
            toolStripStatusLabel1.Text = CSPAT00700.GetFieldData("CSPAT00700OutBlock2", "OrdNo", 0);
        }
        
        void CSPAT00800_ReceiveData(string szTrCode)
        {
            toolStripStatusLabel1.Text = CSPAT00800.GetFieldData("CSPAT00800OutBlock2", "OrdNo", 0);
        }


        void CSPAT00600_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage, this.GetType().ToString());
            }
        }
        void CSPAT00700_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage, this.GetType().ToString());
            }
        }
        void CSPAT00800_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage, this.GetType().ToString());
            }
        }        

        private void 매도주문()
        {
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "AcntNo", 0, comboBox1.SelectedItem.ToString());
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "InptPwd", 0, textBox5.Text.Trim());
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "IsuNo", 0, textBox1.Text.Trim());
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "OrdQty", 0, textBox2.Text.Trim());
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "OrdPrc", 0, textBox3.Text.Trim());
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "BnsTpCode", 0, "1");
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "OrdprcPtnCode", 0, "00");
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "MgntrnCode", 0, "000");
            //CSPAT00600.SetFieldData("CSPAT00600InBlock1", "LoanDt", 0, "값");
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "OrdCndiTpCode", 0, "0");
            CSPAT00600.Request(false);             
        }     

        private void 매수주문()
        {
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "AcntNo", 0, comboBox1.SelectedItem.ToString());
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "InptPwd", 0, textBox5.Text.Trim());
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "IsuNo", 0, textBox1.Text.Trim());
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "OrdQty", 0, textBox2.Text.Trim());
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "OrdPrc", 0, textBox3.Text.Trim());
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "BnsTpCode", 0, "2");
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "OrdprcPtnCode", 0, "00");
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "MgntrnCode", 0, "000");
            //CSPAT00600.SetFieldData("CSPAT00600InBlock1", "LoanDt", 0, "값");
            CSPAT00600.SetFieldData("CSPAT00600InBlock1", "OrdCndiTpCode", 0, "0");
            CSPAT00600.Request(false);             
        }

        private void 정정주문()
        {
            CSPAT00700.SetFieldData("CSPAT00700InBlock1", "OrgOrdNo", 0, textBox4.Text.Trim());
            CSPAT00700.SetFieldData("CSPAT00700InBlock1", "AcntNo", 0, comboBox1.SelectedItem.ToString());
            CSPAT00700.SetFieldData("CSPAT00700InBlock1", "InptPwd", 0, textBox5.Text.Trim());
            CSPAT00700.SetFieldData("CSPAT00700InBlock1", "IsuNo", 0, textBox1.Text.Trim());
            CSPAT00700.SetFieldData("CSPAT00700InBlock1", "OrdQty", 0, textBox2.Text.Trim());
            CSPAT00700.SetFieldData("CSPAT00700InBlock1", "OrdprcPtnCode", 0, "00");
            CSPAT00700.SetFieldData("CSPAT00700InBlock1", "OrdCndiTpCode", 0, "0");
            CSPAT00700.SetFieldData("CSPAT00700InBlock1", "OrdPrc", 0, textBox3.Text.Trim());
            CSPAT00700.Request(false);             
        }

        private void 취소주문()
        {
            CSPAT00800.SetFieldData("CSPAT00800InBlock1", "OrgOrdNo", 0, textBox4.Text.Trim());
            CSPAT00800.SetFieldData("CSPAT00800InBlock1", "AcntNo", 0, comboBox1.SelectedItem.ToString());
            CSPAT00800.SetFieldData("CSPAT00800InBlock1", "InptPwd", 0, textBox5.Text.Trim());
            CSPAT00800.SetFieldData("CSPAT00800InBlock1", "IsuNo", 0, textBox1.Text.Trim());
            CSPAT00800.SetFieldData("CSPAT00800InBlock1", "OrdQty", 0, textBox2.Text.Trim());
            CSPAT00800.Request(false);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, List<string>> acc in Form1.Acclist)
            {
                if (comboBox1.SelectedItem.ToString() == acc.Key)
                {
                    label5.Text = acc.Value[1];
                    textBox5.Text = acc.Value[0];
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                주문유형 = ((RadioButton)sender).Text;
                //MessageBox.Show(주문유형);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (주문유형)
            {
                case "매도":
                    매도주문();
                    break;
                case "매수":
                    매수주문();
                    break;
                case "정정":
                    정정주문();
                    break;
                case "취소":
                    취소주문();
                    break;
                default:
                    MessageBox.Show("주문유형이 지정되지 않았습니다.");
                    break;
            }
        }

        //private string from단축to확장(string code)
        //{
        //    string 종목명 = "";
        //    foreach (KeyValuePair<string, List<string>> aaa in Form1.Master선옵종목)
        //    {
        //        if (aaa.Key == code)
        //        {
        //            종목명 = aaa.Value[1];
        //            break;
        //        }
        //    }
        //    return 종목명;

        //}
    }
}
