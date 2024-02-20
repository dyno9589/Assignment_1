using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace SearchControl
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                string query = "select * from tblproductInventry where ProductName like @ProductName";

                //string sp = "spGetProductByName";

                SqlCommand cmd = new SqlCommand(query, con);

                //SqlCommand cmd = new SqlCommand(sp, con);
                //cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProductName", TextBox1.Text +"%");


                con.Open();
                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();



                }

            }
    }
}