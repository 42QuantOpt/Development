using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XA_DATASETLib;

namespace Exercise_1
{
    class Class선옵종목마스터
    {
        XAQueryClass myXAQueryClass_t9943 = new XAQueryClass();
        XAQueryClass myXAQueryClass_t9944 = new XAQueryClass();
        XAQueryClass myXAQueryClass_t2101 = new XAQueryClass();

        System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        string 마지막코드 = "";

        public Class선옵종목마스터()
        {
            myXAQueryClass_t9943.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(myXAQueryClass_t9943_ReceiveData);
            myXAQueryClass_t9943.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(myXAQueryClass_t9943_ReceiveMessage);
            myXAQueryClass_t9943.ResFileName = @"C:\ETRADE\xingAPI\Res\t9943.res";
            myXAQueryClass_t9943.Request(false);

            myXAQueryClass_t9944.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(myXAQueryClass_t9944_ReceiveData);
            myXAQueryClass_t9944.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(myXAQueryClass_t9944_ReceiveMessage);
            myXAQueryClass_t9944.ResFileName = @"C:\ETRADE\xingAPI\Res\t9944.res";
            myXAQueryClass_t9944.Request(false);

            myXAQueryClass_t2101.ReceiveData += new _IXAQueryEvents_ReceiveDataEventHandler(myXAQueryClass_t2101_ReceiveData);
            myXAQueryClass_t2101.ReceiveMessage += new _IXAQueryEvents_ReceiveMessageEventHandler(myXAQueryClass_t2101_ReceiveMessage);
            myXAQueryClass_t2101.ResFileName = @"C:\ETRADE\xingAPI\Res\t2101.res";
        }

        void myXAQueryClass_t2101_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                System.Windows.Forms.MessageBox.Show(nMessageCode + " : " + szMessage + "<t2101>", this.GetType().ToString());
            }
        }

        void myXAQueryClass_t2101_ReceiveData(string szTrCode)
        {
            string 단축코드 = myXAQueryClass_t2101.GetFieldData("t2101InBlock", "focode", 0);
            string 행사가 = myXAQueryClass_t2101.GetFieldData("t2101OutBlock", "actprice", 0);
            string 상한가 = myXAQueryClass_t2101.GetFieldData("t2101OutBlock", "uplmtprice", 0);//상한가
            string 하한가 = myXAQueryClass_t2101.GetFieldData("t2101OutBlock", "dnlmtprice", 0);//하한가

            if (Form1.Master선옵종목.ContainsKey(단축코드) && Form1.Master선옵종목[단축코드].Count == 3)
            {
                Form1.Master선옵종목[단축코드].Add(상한가);
                Form1.Master선옵종목[단축코드].Add(하한가);
                Form1.Master선옵종목[단축코드].Add(행사가);
                //Console.WriteLine(단축코드 + "\t" + 상한가 + "\t" + 하한가 + "\t" + 행사가);
            }            
        }

        void myXAQueryClass_t9944_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                System.Windows.Forms.MessageBox.Show(nMessageCode + " : " + szMessage + "<t9944>", this.GetType().ToString());
            }
        }

        void myXAQueryClass_t9944_ReceiveData(string szTrCode)
        {
            int cnt_t9944OutBlock = myXAQueryClass_t9944.GetBlockCount("t9944OutBlock");
            for (int i = 0; i < cnt_t9944OutBlock; i++)
            {
                List<string> list = new List<string>();
                string 단축코드 = myXAQueryClass_t9944.GetFieldData("t9944OutBlock", "shcode", i);
                string yyyy = "";
                if (단축코드.Substring(3, 1) == "H")
                    yyyy = "2013";
                else if (단축코드.Substring(3, 1) == "J")
                    yyyy = "2014";
                else if (단축코드.Substring(3, 1) == "K")
                    yyyy = "2015";
                string 종목명 = myXAQueryClass_t9944.GetFieldData("t9944OutBlock", "hname", i);
                string 확장코드 = myXAQueryClass_t9944.GetFieldData("t9944OutBlock", "expcode", i);
                string 만기년월 = yyyy + 종목명.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("월", "");
                list.Add(종목명);
                list.Add(확장코드);
                list.Add(만기년월);
                if (!Form1.Master선옵종목.ContainsKey(단축코드))
                    Form1.Master선옵종목.Add(단축코드, list);

                마지막코드 = 단축코드;
            }

            myTimer.Tick += new EventHandler(myTimer_Tick);
            myTimer.Interval = 220;
            myTimer.Start();
        }
        
        void myTimer_Tick(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, List<string>> code in Form1.Master선옵종목)
            {
                if (code.Value.Count == 3)
                {
                    myXAQueryClass_t2101.SetFieldData("t2101InBlock", "focode", 0, code.Key);
                    myXAQueryClass_t2101.Request(false);

                    if (code.Key == 마지막코드)
                        myTimer.Stop();
                    break;
                }
            }
        }

        void myXAQueryClass_t9943_ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            if (bIsSystemError)
            {
                System.Windows.Forms.MessageBox.Show(nMessageCode + " : " + szMessage + "<t9943>", this.GetType().ToString());
            }
        }

        void myXAQueryClass_t9943_ReceiveData(string szTrCode)
        {
            int cnt_t9943OutBlock = myXAQueryClass_t9943.GetBlockCount("t9943OutBlock");
            for (int i = 0; i < cnt_t9943OutBlock; i++)
            {
                List<string> list = new List<string>();
                string 단축코드 = myXAQueryClass_t9943.GetFieldData("t9943OutBlock", "shcode", i);

                if (단축코드.Substring(0, 1) == "4")
                    continue;

                string yyyy = "";
                if (단축코드.Substring(3, 1) == "H")
                    yyyy = "2013";
                else if (단축코드.Substring(3, 1) == "J")
                    yyyy = "2014";
                else if (단축코드.Substring(3, 1) == "K")
                    yyyy = "2015";
                string 종목명 = myXAQueryClass_t9943.GetFieldData("t9943OutBlock", "hname", i);
                string 확장코드 = myXAQueryClass_t9943.GetFieldData("t9943OutBlock", "expcode", i);
                string 만기년월 = yyyy + 종목명.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)[1].Replace("월물", "");
                list.Add(종목명);
                list.Add(확장코드);                
                list.Add(만기년월);
                if (!Form1.Master선옵종목.ContainsKey(단축코드))
                    Form1.Master선옵종목.Add(단축코드, list);
            }
        }
    }
}
