using System;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Windows.Forms;
using XA_SESSIONLib;

//Implementation of ETRADE COM.
//Date : 2010/05/23
//Writer : KurtKorea@yahoo.co.kr

namespace XingAPICSharp
{
    public class SessionCtrl : _IXASessionEvents
    {
        public IXASession m_Session;
        protected UCOMIConnectionPoint m_icp;
        protected UCOMIConnectionPointContainer m_icpc;
        protected int m_dwCookie;
        public XingAPIForm ptForm;

        public SessionCtrl ()
        {
            int m_dwCookie = 0;
            m_Session = new XASession();
            m_icpc = (UCOMIConnectionPointContainer)m_Session;
            Guid IID_SessionEvents = typeof(_IXASessionEvents).GUID;
            m_icpc.FindConnectionPoint(ref IID_SessionEvents, out m_icp);
            m_icp.Advise(this, out m_dwCookie);       
        }
        ~SessionCtrl()
        {
            m_Session.Logout();
            m_Session.DisconnectServer();
        }

        #region _IXASessionEvents 멤버

        void _IXASessionEvents.Disconnect()
        {
            ptForm.lblMessage.Text = "Disconnect";
            throw new NotImplementedException();
        }

        void _IXASessionEvents.Login(string szCode, string szMsg)
        {
            ptForm.lblMessage.Text = szCode + ":" + szMsg;
            throw new NotImplementedException();
        }

        void _IXASessionEvents.Logout()
        {
            ptForm.lblMessage.Text = "LogOut";
            throw new NotImplementedException();
        }

        #endregion
    }
}
