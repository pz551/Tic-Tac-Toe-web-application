using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TicTacToe
{
    public partial class TicTacToe : System.Web.UI.Page
    {
        private bool firstPlayerTurn;
        private int moves;
        private int d1, d2 ;
        private int row1, row2, row3 ;
        private int col1, col2, col3;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var cookie = Request.Cookies.Get("TicTacToe");
                var Session = (UserSession)HttpContext.Current.Session["currentSession"];
                if (!(cookie != null && Session != null && cookie["UserSession"] == Session.SessionID))
                {
                    Board.Visible = false;
                    Alert.Visible = true;
                    return;
                }
                
                ViewState["Moves"] = 0;
                ViewState["D1"] = 0;
                ViewState["D2"] = 0;

                ViewState["Col1"] = 0;
                ViewState["Col2"] = 0;
                ViewState["Col3"] = 0;
                ViewState["Row1"] = 0;
                ViewState["Row2"] = 0;
                ViewState["Row3"] = 0;

                ViewState["Turn"] = false;
   
                Board.Visible = true;
                Alert.Visible = false;
            }
            firstPlayerTurn = (bool)ViewState["Turn"];
            moves = (int)ViewState["Moves"];
            d1 = (int)ViewState["D1"];
            d2 = (int)ViewState["D2"];

            row1 = (int)ViewState["Row1"];
            row2 = (int)ViewState["Row2"];
            row3 = (int)ViewState["Row3"];

            col1 = (int)ViewState["Col1"];
            col2 = (int)ViewState["Col2"];
            col3 = (int)ViewState["Col3"];
            if (firstPlayerTurn)
                Status.Text = "Current player is O";
            else
                Status.Text = "Current player is X";

        }
     


        protected void Btn11Click(object sender, EventArgs e)
        {
            Move(Btn11, Img11, 1, 1);

        }

        protected void Btn12Click(object sender, EventArgs e)
        {
            Move(Btn12, Img12, 1, 2);

        }
        protected void Btn13Click(object sender, EventArgs e)
        {
            Move(Btn13, Img13, 1, 3);

        }
        protected void Btn21Click(object sender, EventArgs e)
        {
            Move(Btn21, Img21, 2, 1);

        }
        protected void Btn22Click(object sender, EventArgs e)
        {
            Move(Btn22, Img22, 2, 2);

        }
        protected void Btn23Click(object sender, EventArgs e)
        {
            Move(Btn23, Img23, 2, 3);

        }
        protected void Btn31Click(object sender, EventArgs e)
        {
            Move(Btn31, Img31, 3, 1);

        }
        protected void Btn32Click(object sender, EventArgs e)
        {
            Move(Btn32, Img32, 3, 2);

        }
        protected void Btn33Click(object sender, EventArgs e)
        {
            Move(Btn33, Img33, 3, 3);

        }

        protected void Move(Button btn, Image img, int row, int col)
        {
            btn.Visible = false;
            img.Visible = true;
            moves++;
            if (firstPlayerTurn)
                img.ImageUrl = "Content/O.PNG";
            else
                img.ImageUrl = "Content/X.PNG";
            ViewState["Turn"] = !firstPlayerTurn;
            ViewState["Moves"] = moves;

            int change = 0;
            if (firstPlayerTurn) change = 1; else change = -1;

            if (row == 1) row1 += change;
            //  Status.Text = moves.ToString();
            if (row == 2) row2 += change;
            //  Status.Text = row2.ToString();
            if (row == 3) row3 += change;


            if (col == 1) col1 += change;

            if (col == 2) col2 += change;

            if (col == 3) col3 += change;

            if (row == col) d1 += change;
            if (row + col == 4) d2 += change;

            ViewState["Row1"] = row1;
            ViewState["Row2"] = row2;
            ViewState["Row3"] = row3;
            ViewState["Col1"] = col1;
            ViewState["Col2"] = col2;
            ViewState["Col3"] = col3;
            ViewState["D1"] = d1;
            ViewState["D2"] = d2;

            if ((row1 == 3) || (row2 == 3) || (row3 == 3) || (col1 == 3) || (col2 == 3) || (col3 == 3) || (d1 == 3) || (d2 == 3) ||
                    (row1 == -3) || (row2 == -3) || (row3 == -3) || (col1 == -3) || (col2 == -3) || (col3 == -3) || (d1 == -3) || (d2 == -3))
            {
                if (firstPlayerTurn)
                    Status.Text = "Game is over. O is the winner!";
                else
                    Status.Text = "Game is over. X is the winner!";
                Btn11.Enabled = false;
                Btn12.Enabled = false;
                Btn13.Enabled = false;
                Btn21.Enabled = false;
                Btn22.Enabled = false;
                Btn23.Enabled = false;
                Btn31.Enabled = false;
                Btn32.Enabled = false;
                Btn33.Enabled = false;
                return;

            }



            if (moves == 9)
            {
                Status.Text = "The game is tied. Nobody wins.";
                Btn11.Enabled = false;
                Btn12.Enabled = false;
                Btn13.Enabled = false;
                Btn21.Enabled = false;
                Btn22.Enabled = false;
                Btn23.Enabled = false;
                Btn31.Enabled = false;
                Btn32.Enabled = false;
                Btn33.Enabled = false;
                return;
            }


        }


    }
}