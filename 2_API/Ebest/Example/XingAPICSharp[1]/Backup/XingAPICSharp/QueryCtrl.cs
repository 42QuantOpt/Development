using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using XA_DATASETLib;

//Implementation of ETRADE COM.
//Date : 2010/05/23
//Writer : KurtKorea@yahoo.co.kr

namespace XingAPICSharp
{
    public class QueryCtrl : _IXAQueryEvents, _IXARealEvents
    {
        public IXAReal m_Real;
        public IXAReal m_Real2;
        public IXAQuery m_Query;
        protected bool m_bRealSet;

        public XingAPIForm ptForm;

        public QueryCtrl()
        {
            m_bRealSet = false;

            UCOMIConnectionPoint icp;
            UCOMIConnectionPointContainer icpc;

            int dwCookie = 0;
            m_Query = new XAQuery();
            m_Query.ResFileName = "\\res\\t1101.res";
            icpc = (UCOMIConnectionPointContainer)m_Query;
            Guid IID_QueryEvents = typeof(_IXAQueryEvents).GUID;
            icpc.FindConnectionPoint(ref IID_QueryEvents, out icp);
            icp.Advise(this, out dwCookie);

            dwCookie = 0;
            m_Real = new XAReal();
            m_Real.ResFileName = "\\res\\S3_.res";     //KOSPI체결
            icpc = (UCOMIConnectionPointContainer)m_Real;
            Guid IID_RealEvents = typeof(_IXARealEvents).GUID;
            icpc.FindConnectionPoint(ref IID_RealEvents, out icp);
            icp.Advise(this, out dwCookie);

            dwCookie = 0;
            m_Real2 = new XAReal();
            m_Real2.ResFileName = "\\res\\H1.res";     //KOSPI체결
            icpc = (UCOMIConnectionPointContainer)m_Real2;
            icpc.FindConnectionPoint(ref IID_RealEvents, out icp);
            icp.Advise(this, out dwCookie);
        }
        ~QueryCtrl()
        {
               
        }


        #region _IXAQueryEvents 멤버

        void _IXAQueryEvents.ReceiveData(string szTrCode)
        {
            ptForm.현재가.Text = m_Query.GetFieldData("t1101OutBlock", "price", 0);
            ptForm.매수1호가.Text = m_Query.GetFieldData("t1101OutBlock", "bidho1", 0);
            ptForm.매수2호가.Text = m_Query.GetFieldData("t1101OutBlock", "bidho2", 0);
            ptForm.매수3호가.Text = m_Query.GetFieldData("t1101OutBlock", "bidho3", 0);
            ptForm.매수4호가.Text = m_Query.GetFieldData("t1101OutBlock", "bidho4", 0);
            ptForm.매수5호가.Text = m_Query.GetFieldData("t1101OutBlock", "bidho5", 0);

            if ( !m_bRealSet )
            {
                m_bRealSet = true;
                m_Real.SetFieldData("InBlock", "shcode", ptForm.textBox4.Text);
                m_Real.AdviseRealData();

                m_Real2.SetFieldData("InBlock", "shcode", ptForm.textBox4.Text);
                m_Real2.AdviseRealData();
            }

            throw new NotImplementedException();
        }

        void _IXAQueryEvents.ReceiveMessage(bool bIsSystemError, string nMessageCode, string szMessage)
        {
            ptForm.lblMessage.Text = nMessageCode;
            throw new NotImplementedException();
        }

        #endregion

        #region _IXARealEvents 멤버

        void _IXARealEvents.ReceiveRealData(string szTrCode)
        {
            if (szTrCode == "H1_")
            {
                ptForm.매수1호가.Text = m_Real2.GetFieldData("OutBlock", "bidho1");
                ptForm.매수2호가.Text = m_Real2.GetFieldData("OutBlock", "bidho2");
                ptForm.매수3호가.Text = m_Real2.GetFieldData("OutBlock", "bidho3");
                ptForm.매수4호가.Text = m_Real2.GetFieldData("OutBlock", "bidho4");
                ptForm.매수5호가.Text = m_Real2.GetFieldData("OutBlock", "bidho5");
            } else if ( szTrCode == "S3_")
            {
                ptForm.현재가.Text = m_Real.GetFieldData("OutBlock", "price");
            }
            
            throw new NotImplementedException();
        }

        #endregion
    }
}
