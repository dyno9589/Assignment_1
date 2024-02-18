using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            lbl.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (emailInp.Value != "" && passInp.Value != "")
            {
                if (emailInp.Value == "abc@xyz.co" && passInp.Value == "password")
                {
                    lbl.Visible = true;
                    lbl.ForeColor = Color.Green;
                    lbl.Text = "successfully logged in";
                }
                else {
                    lbl.Visible = true;
                    lbl.ForeColor = Color.Red;
                    lbl.Text = "email or passord is wrong";
                }
            }
            else
            {
                lbl.Visible = true;
                lbl.ForeColor = Color.Green;
                lbl.Text = "please fill all the details";
            }
        }
    }
}