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
    public partial class 선옵주문 : Form
    {
        XAQueryClass CFOAT00100 = new XAQueryClass();
        XAQueryClass CFOAT00200 = new XAQueryClass();
        XAQueryClass CFOAT00300 = new XAQueryClass();
        
        string 주문유형 = "";

        public 선옵주문()
        {
            InitializeComponent();
            
            CFOAT00100.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(CFOAT00100_ReceiveData);
            CFOAT00100.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(CFOAT00100_ReceiveMessage);
            CFOAT00100.ResFileName = @"C:\ETRADE\xingAPI\Res\CFOAT00100.res";
            
            CFOAT00200.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(CFOAT00200_ReceiveData);
            CFOAT00200.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(CFOAT00200_ReceiveMessage);
            CFOAT00200.ResFileName = @"C:\ETRADE\xingAPI\Res\CFOAT00200.res";
            
            CFOAT00300.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(CFOAT00300_ReceiveData);
            CFOAT00300.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(CFOAT00300_ReceiveMessage);
            CFOAT00300.ResFileName = @"C:\ETRADE\xingAPI\Res\CFOAT00300.res";

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
                MessageBox.Show("등록된 계좌가 없습니다");
                this.Close();
            }
        }

        private void 매도주문()
        {         
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "AcntNo", 0, comboBox1.SelectedItem.ToString());
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "Pwd", 0, textBox5.Text.Trim());
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "FnoIsuNo", 0, from단축to확장(textBox1.Text.Trim()));
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "BnsTpCode", 0, "1");
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "FnoOrdprcPtnCode", 0, "00");
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "OrdPrc", 0, textBox3.Text.Trim());
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "OrdQty", 0, textBox2.Text.Trim());
            CFOAT00100.Request(false);            
        }

        void CFOAT00100_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage, this.GetType().ToString());
            }
        }

        void CFOAT00100_ReceiveData(string szTrCode)
        {
            toolStripStatusLabel1.Text = CFOAT00100.GetFieldData("CFOAT00100OutBlock2", "OrdNo", 0);
        }

        private void 매수주문()
        {
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "AcntNo", 0, comboBox1.SelectedItem.ToString());
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "Pwd", 0, textBox5.Text.Trim());
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "FnoIsuNo", 0, from단축to확장(textBox1.Text.Trim()));
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "BnsTpCode", 0, "2");
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "FnoOrdprcPtnCode", 0, "00");
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "OrdPrc", 0, textBox3.Text.Trim());
            CFOAT00100.SetFieldData("CFOAT00100InBlock1", "OrdQty", 0, textBox2.Text.Trim());
            CFOAT00100.Request(false);        
        }

        private void 정정주문()
        {
            CFOAT00200.SetFieldData("CFOAT00200InBlock1", "AcntNo", 0, comboBox1.SelectedItem.ToString());
            CFOAT00200.SetFieldData("CFOAT00200InBlock1", "Pwd", 0, textBox5.Text.Trim());
            CFOAT00200.SetFieldData("CFOAT00200InBlock1", "FnoIsuNo", 0, from단축to확장(textBox1.Text.Trim()));
            CFOAT00200.SetFieldData("CFOAT00200InBlock1", "OrgOrdNo", 0, textBox4.Text.Trim());
            CFOAT00200.SetFieldData("CFOAT00200InBlock1", "FnoOrdprcPtnCode", 0, "00");
            CFOAT00200.SetFieldData("CFOAT00200InBlock1", "OrdPrc", 0, textBox3.Text.Trim());
            CFOAT00200.SetFieldData("CFOAT00200InBlock1", "MdfyQty", 0, textBox2.Text.Trim());
            CFOAT00200.Request(false); 
        }

        void CFOAT00200_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage, this.GetType().ToString());
            }
        }

        void CFOAT00200_ReceiveData(string szTrCode)
        {
            toolStripStatusLabel1.Text = CFOAT00200.GetFieldData("CFOAT00200OutBlock2", "OrdNo", 0);
        }

        private void 취소주문()
        {          
            CFOAT00300.SetFieldData("CFOAT00300InBlock1", "AcntNo", 0, comboBox1.SelectedItem.ToString());
            CFOAT00300.SetFieldData("CFOAT00300InBlock1", "Pwd", 0, textBox5.Text.Trim());
            CFOAT00300.SetFieldData("CFOAT00300InBlock1", "FnoIsuNo", 0, from단축to확장(textBox1.Text.Trim()));
            CFOAT00300.SetFieldData("CFOAT00300InBlock1", "OrgOrdNo", 0, textBox4.Text.Trim());
            CFOAT00300.SetFieldData("CFOAT00300InBlock1", "CancQty", 0, textBox2.Text.Trim());
            CFOAT00300.Request(false);
        }

        void CFOAT00300_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage, this.GetType().ToString());
            }
        }

        void CFOAT00300_ReceiveData(string szTrCode)
        {
            toolStripStatusLabel1.Text = CFOAT00300.GetFieldData("CFOAT00300OutBlock2", "OrdNo", 0);
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

        private string from단축to확장(string code)
        {
            string 종목명 = "";
            foreach (KeyValuePair<string, List<string>> aaa in Form1.Master선옵종목)
            {
                if (aaa.Key == code)
                {
                    종목명 = aaa.Value[1];
                    break;
                }
            }
            return 종목명;

        }

    }
}
