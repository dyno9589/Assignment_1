using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

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

            string email = emailInp.Value;

            string password = passInp.Value;

            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                if (ValidateUserCredentials(email, password))
                {
                    lbl.Visible = true;
                    lbl.ForeColor = Color.Green;
                    lbl.Text = "successfully logged in";
                    Response.Redirect("~/Home");
                }
                else
                {
                    lbl.Visible = true;
                    lbl.ForeColor = Color.Red;
                    lbl.Text = "email or passord is wrong";
                }
            }
            else
            {
                lbl.Visible = true;
                lbl.ForeColor = Color.Red;
                lbl.Text = "please fill all the details";
            }

        }


        private bool ValidateUserCredentials(string email, string password)
        {
            string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            string query = "SELECT COUNT(*) FROM tblUser WHERE Email = @Email AND Passwords = @Password";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }


        //    /* db start*/
        //    string qry = "select ProductId, ProductName, UnitPrice from tblProdInv";

        //    string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(cs)){

        //        con.Open();
        //        SqlCommand cmd = new SqlCommand(qry, con);
        //        SqlDataReader rdr = cmd.ExecuteReader();


        //    }

        //    /*db end*/






        //    if (emailInp.Value != "" && passInp.Value != "")
        //    {
        //        if (emailInp.Value == "abc@xyz.co" && passInp.Value == "password")
        //        {
        //            lbl.Visible = true;
        //            lbl.ForeColor = Color.Green;
        //            lbl.Text = "successfully logged in";
        //        }
        //        else {
        //            lbl.Visible = true;
        //            lbl.ForeColor = Color.Red;
        //            lbl.Text = "email or passord is wrong";
        //        }
        //    }
        //    else
        //    {
        //        lbl.Visible = true;
        //        lbl.ForeColor = Color.Red;
        //        lbl.Text = "please fill all the details";
        //    }
        //}
    }
}