using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XingAPICSharp
{
    public partial class XingAPIForm : Form
    {

        protected SessionCtrl m_Session;
        protected QueryCtrl m_Query;

        public XingAPIForm()
        {
            InitializeComponent();
            m_Session = new SessionCtrl();
            m_Query = new QueryCtrl();
            m_Query.ptForm = this;
            m_Session.ptForm = this;
        }

        ~XingAPIForm()
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            m_Session.m_Session.ConnectServer("hts.etrade.co.kr", 20001);
            m_Session.m_Session.Login(textBox1.Text, textBox2.Text, textBox3.Text, (int)XA_SESSIONLib.XA_SERVER_TYPE.XA_SIMUL_SERVER, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_Query.m_Query.SetFieldData("t1101InBlock", "shcode", 0, textBox4.Text);
            m_Query.m_Query.Request(false);
        }
    }
}
