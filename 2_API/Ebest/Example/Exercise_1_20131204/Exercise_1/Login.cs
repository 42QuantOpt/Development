using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XA_SESSIONLib;
using XA_DATASETLib;
using System.Threading;
namespace Exercise_1
{
    public partial class Login : Form
    {
        XASessionClass myXASessionClass = new XASessionClass();
        XAQueryClass myXAQueryClass = new XAQueryClass();

        string 서버명 = "demo.etrade.co.kr";
        int 포트 = 20001;
        public Login()
        {
            InitializeComponent();

            dataGridView1.Columns["확인"].ReadOnly = false;

            myXASessionClass._IXASessionEvents_Event_Login += new _IXASessionEvents_LoginEventHandler(myXASessionClass__IXASessionEvents_Event_Login);


            myXAQueryClass.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(myXAQueryClass_ReceiveData);
            myXAQueryClass.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(myXAQueryClass_ReceiveMessage);

            this.ShowDialog();
        }

        void myXAQueryClass_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage, this.GetType().ToString());
            }
        }

        void myXAQueryClass_ReceiveData(string szTrCode)
        {
            string 계좌번호 = myXAQueryClass.GetFieldData("CACBQ21900OutBlock1", "AcntNo", 0);
            string 계좌명 =myXAQueryClass.GetFieldData("CACBQ21900OutBlock2", "AcntNm", 0);
            string 상품 = myXAQueryClass.GetFieldData("CACBQ21900OutBlock2", "PrdtDtlNm", 0);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["계좌번호"].Value.ToString() == 계좌번호)
                {
                    row.Cells["계좌명"].Value=계좌명;
                    row.Cells["상품"].Value = 상품;
                    break;
                }
            }
        }

        void myXASessionClass__IXASessionEvents_Event_Login(string szCode, string szMsg)
        {
            if (szCode == "0000")
            {
                int 계좌수 = myXASessionClass.GetAccountListCount();

                for (int i = 0; i < 계좌수; i++)
                {
                    dataGridView1.Rows.Add(new string[] { myXASessionClass.GetAccountList(i), "", "", "", "" });

                }
            }
            else
            {
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb_모의계좌.Checked)
            {
                서버명 = "demo.etrade.co.kr";
                포트 = 20001;
            }
            else
            {
                서버명 = "hts.etrade.co.kr";
                포트 = 20001;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (myXASessionClass.ConnectServer(서버명, 포트))
            {
                Console.WriteLine("ConnectServer 성공");
                if (myXASessionClass.Login(textBox1.Text, textBox2.Text, textBox3.Text, 0, false))
                {
                    Console.WriteLine("Login 전송");
                }
                else
                {
                }
            }
            else
            {
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (rdb_모의계좌.Checked)//모의투자는 CACBQ21900를 지원안함.
            {
                string 상품상세명 = "";
                if (e.RowIndex == 0)
                    상품상세명 = "선물옵션";
                else
                    상품상세명 = "주식위탁";

                dataGridView1.Rows[e.RowIndex].Cells["계좌명"].Value = "모의투자";//계좌명
                dataGridView1.Rows[e.RowIndex].Cells["상품"].Value = 상품상세명;//상품상세명
            }
            else if (e.ColumnIndex == 2)
            {
                string 계좌번호 = dataGridView1.Rows[e.RowIndex].Cells["계좌번호"].Value.ToString().Trim();
                string 비밀번호 = dataGridView1.Rows[e.RowIndex].Cells["비밀번호"].Value.ToString().Trim();

                myXAQueryClass.ResFileName = @"C:\ETRADE\xingAPI\Res\CACBQ21900.res";//CACBQ21900
                myXAQueryClass.SetFieldData("CACBQ21900InBlock1", "RecCnt", 0, "1");
                myXAQueryClass.SetFieldData("CACBQ21900InBlock1", "AcntNo", 0, 계좌번호);
                myXAQueryClass.SetFieldData("CACBQ21900InBlock1", "InptPwd", 0, 비밀번호);
                myXAQueryClass.Request(false);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells["비밀번호"].Value = textBox4.Text.Trim();

                DataGridViewCellEventArgs args = new DataGridViewCellEventArgs(2, row.Index);

                dataGridView1_CellClick(null, args);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1.Acclist.Clear();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
               

                string 계좌번호 = row.Cells["계좌번호"].Value.ToString();
                string 비밀번호 = row.Cells["비밀번호"].Value.ToString();
                string 계좌명 = row.Cells["계좌명"].Value.ToString();
                string 상품="";
                if (row.Cells["상품"].Value.ToString().Contains("종합") || row.Cells["상품"].Value.ToString().Contains("주식위탁"))
                {
                    상품 = "주식위탁";
                }
                else if (row.Cells["상품"].Value.ToString().Contains("선물옵션"))
                {
                    상품 = "선물옵션";
                }

                if (상품 != "")
                {
                    List<string> value = new List<string>();
                    value.Add(비밀번호);
                    value.Add(계좌명);
                    value.Add(상품);

                    Form1.Acclist.Add(계좌번호, value);
                }
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
