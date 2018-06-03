using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exercise_1
{
    public partial class Form1 : Form
    {
        public static Dictionary<string, List<string>> Acclist = new Dictionary<string, List<string>>();//key : 계좌번호, value : list<비밀번호, 계좌명, 상품구분>
        public static Dictionary<string, List<string>> Master주식종목 = new Dictionary<string, List<string>>();//key : 단축코드, value : list<종목명, 확장코드, 소속부, 상한가, 하한가>
        public static Dictionary<string, List<string>> Master선옵종목 = new Dictionary<string, List<string>>(); //<단축코드, <종목명, 확장코드, 만기년월, 상한가, 하한가,행사가>>

        public Form1()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login myLogin = new Login();

            if (myLogin.DialogResult == DialogResult.OK)
            {
                loginToolStripMenuItem.Enabled = false;
            }

            foreach (KeyValuePair<string, List<string>> acc in Acclist)
            {
                Console.Write(acc.Key + "    ");
                Console.Write(acc.Value[0] + "    ");
                Console.Write(acc.Value[1] + "    ");
                Console.WriteLine(acc.Value[2] + "    ");
            }

            Master주식종목.Clear();
            Master선옵종목.Clear();
            Class주식종목마스터 myClass주식종목마스터 = new Class주식종목마스터();
            Class선옵종목마스터 myClass선옵종목마스터 = new Class선옵종목마스터();


        }

        private void 주식계좌현황ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            주식계좌현황 my주식계좌현황 = new 주식계좌현황();
        }

        private void 선물계좌현황ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            선물계좌현황 my선물계좌현황 = new 선물계좌현황();
        }

        private void 선옵주문ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            선옵주문 my선옵주문 = new 선옵주문();
        }

        private void 주식주문ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            주식주문 my주식주문 = new 주식주문();
        }

    }
}
