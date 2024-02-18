using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;


namespace LoginForm
{
    public partial class services : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            reglbl.Visible = false;
        }

        protected void regbtn_Click(object sender, EventArgs e)
        {
            if (regemailInp.Value != "" && regpassInp.Value != "" && regcpassinp.Value != "")
            {
                if (regpassInp.Value == regcpassinp.Value)
                {
                    reglbl.Visible = true;
                    reglbl.ForeColor = Color.Green;

                    reglbl.Text = "successfully Registered";
                }
                else
                {
                    reglbl.Visible = true;
                    reglbl.ForeColor = Color.Red;
                    reglbl.Text = "passord is not matching";
                }
            }
            else
            {
                reglbl.Visible = true;
                reglbl.ForeColor = Color.Red;
                reglbl.Text = "please fill all the details";
            }
        }

        protected void regbtncan_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}