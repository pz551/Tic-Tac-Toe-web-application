using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Helpers;

namespace TicTacToe
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((UserSession)Session["currentSession"] == null)
            {
                Login.Visible = true;
                LogOffBtn.Visible = false;
                return;
            }
            Login.Visible = false;
            LogOffBtn.Visible = true;
          
                
        }
        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string sessionID = Guid.NewGuid().ToString();
            Application.Lock();
            Person currentPerson = (Person)Application[Login.UserName];
            Application.UnLock();
            if (currentPerson == null)
            {
                Create_Session(sessionID, Login.UserName, 10);

                var newPerson = new Person()
                {
                    UserID = Login.UserName,
                    UserPwd = Crypto.HashPassword(Login.Password),

                };

                Application[Login.UserName] = newPerson;
                e.Authenticated = true;
                Response.Redirect("./TicTacToe.aspx");
                return;
            }


            if (Crypto.VerifyHashedPassword(currentPerson.UserPwd, Login.Password))
            {
                Create_Session(sessionID, Login.UserName, 10);

                e.Authenticated = true;
                Response.Redirect("./TicTacToe.aspx");
                return;
            }

            e.Authenticated = false;




        }
        protected void Create_Session(string sessionID, string username, int timeout)
        {
            Session["currentSession"] = new UserSession()
            {
                SessionID = sessionID,
                UserName = username
            };
            Session.Timeout = timeout;
            var cookie = new HttpCookie("TicTacToe");
            cookie["UserSession"] = sessionID;
            Response.Cookies.Add(cookie);
        }

    

        protected void LogOffBtn_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            LogOffBtn.Visible = false;
            Login.Visible = true;
           // Status.Text = "You have been successfully logged out from the application.";

        }
    }
}