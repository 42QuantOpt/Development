using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XA_DATASETLib;
using System.Windows.Forms;

namespace Exercise_1
{
    class Class주식종목마스터
    {
        XAQueryClass myXAQueryClass_t9945 = new XAQueryClass();
        XAQueryClass myXAQueryClass_t1101 = new XAQueryClass();
        Timer myTimer = new Timer();
        Timer myTimer_1 = new Timer();

        public Class주식종목마스터()
        {
            myXAQueryClass_t9945.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(myXAQueryClass_t9945_ReceiveData);

            myXAQueryClass_t9945.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(myXAQueryClass_t9945_ReceiveMessage);

            myXAQueryClass_t9945.ResFileName = @"C:\ETRADE\xingAPI\Res\t9945.res";
            myXAQueryClass_t9945.SetFieldData("t9945InBlock", "gubun", 0, "1");
            myXAQueryClass_t9945.Request(false);

            myTimer.Tick += new EventHandler(myTimer_Tick);
            myTimer.Interval = 1000;
            myTimer.Start();
        }

        void myTimer_Tick(object sender, EventArgs e)
        {
            myXAQueryClass_t9945.SetFieldData("t9945InBlock", "gubun", 0, "2");
            myXAQueryClass_t9945.Request(false);
            myTimer.Stop();
        }

        void myXAQueryClass_t9945_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage + "<t9945>", this.GetType().ToString());
            }
        }

        int 종목수 = 0;
        string 마지막code = "";

        void myXAQueryClass_t9945_ReceiveData(string szTrCode)
        {

            int cnt = myXAQueryClass_t9945.GetBlockCount("t9945OutBlock");

            for (int i = 0; i < cnt; i++)
            {
                string 종목명 = myXAQueryClass_t9945.GetFieldData("t9945OutBlock", "hname", i);
                string 단축코드 = myXAQueryClass_t9945.GetFieldData("t9945OutBlock", "shcode", i).Trim();
                string 확장코드 = myXAQueryClass_t9945.GetFieldData("t9945OutBlock", "expcode", i).Trim();

                string 소속부 = "";
                if (myXAQueryClass_t9945.GetFieldData("t9945InBlock", "gubun", 0) == "1")
                {
                    소속부 = "거래소";
                }
                else if (myXAQueryClass_t9945.GetFieldData("t9945InBlock", "gubun", 0) == "2")
                {
                    소속부 = "코스닥";
                }

                List<string> value = new List<string>();
                value.Add(종목명);
                value.Add(확장코드);
                value.Add(소속부);

                Form1.Master주식종목.Add(단축코드, value);

                종목수++;

                //Console.WriteLine(종목수 + "\t" + 단축코드 + "\t" + 종목명 + "\t" + 확장코드 + "\t" + 소속부);
                마지막code = 단축코드;
            }

            if (myXAQueryClass_t9945.GetFieldData("t9945InBlock", "gubun", 0) == "1")
            {
                myXAQueryClass_t1101.ResFileName = @"C:\ETRADE\xingAPI\Res\t1101.res";
                myXAQueryClass_t1101.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(myXAQueryClass_t1101_ReceiveData);
                myXAQueryClass_t1101.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(myXAQueryClass_t1101_ReceiveMessage);

                myTimer_1.Interval = 220;
                myTimer_1.Tick += new EventHandler(myTimer_1_Tick);

                myTimer_1.Start();
            }

        }

        void myTimer_1_Tick(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, List<string>> code in Form1.Master주식종목)
            {
                if (code.Value.Count == 3)
                {
                    myXAQueryClass_t1101.SetFieldData("t1101InBlock", "shcode", 0, code.Key);
                    myXAQueryClass_t1101.Request(false);

                    if (code.Key == 마지막code)
                        myTimer_1.Stop();
                    break;
                }
            }
        }

        void myXAQueryClass_t1101_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                MessageBox.Show(nMessageCode + " : " + szMessage + "<t1101>", this.GetType().ToString());
            }
        }

        void myXAQueryClass_t1101_ReceiveData(string szTrCode)
        {
            string _code=myXAQueryClass_t1101.GetFieldData("t1101OutBlock", "shcode", 0);
            string 상한가 = myXAQueryClass_t1101.GetFieldData("t1101OutBlock", "uplmtprice", 0);
            string 하한가 = myXAQueryClass_t1101.GetFieldData("t1101OutBlock", "dnlmtprice", 0);

            if (Form1.Master주식종목[_code].Count == 3)
            {
                Form1.Master주식종목[_code].Add(상한가);
                Form1.Master주식종목[_code].Add(하한가);
            }

            if (_code == 마지막code)
            {
                myTimer = null;
                myTimer_1 = null;
            }
        }

        ~Class주식종목마스터()
        {
            Console.WriteLine("Class주식종목마스터 종료");
        }
    }
}
