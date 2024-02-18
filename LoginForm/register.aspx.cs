using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;

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


                    /* database operation starts here*/
                    string userid = " User Id = ";

                    string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(cs))
                    {
                        SqlCommand cmd = new SqlCommand("spAddUser", con);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Email", regemailInp.Value);
                        cmd.Parameters.AddWithValue("@Password", regpassInp.Value);

                        SqlParameter outputParameter = new SqlParameter();
                        outputParameter.ParameterName = "@UserId";
                        outputParameter.SqlDbType = System.Data.SqlDbType.Int;
                        outputParameter.Direction = System.Data.ParameterDirection.Output;
                        cmd.Parameters.Add(outputParameter);

                        con.Open();
                        cmd.ExecuteNonQuery();

                        string UserId = outputParameter.Value.ToString();

                         userid += UserId;

                    }


                    /*database operation ends here */



                    reglbl.Text = "successfully Registered,"+ (userid);
                    regemailInp.Value = "";


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