using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace AdoWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string showProd = "select * from tblProduct";
            string TotalRows = "select Count(ProductId) from tblProduct";
            string InsertRows = "INSERT INTO tblProduct VALUES((select Count(ProductId) from tblProduct)+1 ,'item', 512, 63 )";
            string DeleteRows = "Delete from tblProduct where ProductId = (select Count(ProductId) from tblProduct)";

            string cs =ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            //if 'using' is used before connection then there is no need to close connection it will automatically closed.
            SqlConnection con = new SqlConnection(cs);
                
                    SqlCommand cmd = new SqlCommand(showProd, con);
                SqlCommand cmd1 = new SqlCommand(InsertRows, con);
            SqlCommand cmd2 = new SqlCommand(TotalRows, con);


            con.Open();
            int Totalrows = (int)cmd2.ExecuteScalar();
            Response.Write("Total rows in table are: " + Totalrows.ToString());
            con.Close();

            Response.Write("<br/> <br/>");

            con.Open();
                int totalRowIns = cmd1.ExecuteNonQuery();
                Response.Write("\n\nTotal rows inserted are: " + totalRowIns.ToString()+"\n\n");
            con.Close();

            con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                GridView1.DataSource = rdr;
                GridView1.DataBind();
            con.Close();
              
            }

        protected void Button1_Click(object sender, EventArgs e)
        {

                string qry = "select ProductId, ProductName, UnitPrice from tblProdInv";

                string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cs))
                {

                    con.Open();
                    SqlCommand cmd = new SqlCommand(qry, con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    GridView2.DataSource = rdr;
                    GridView2.DataBind();
                }
                };


        }
    }
    }
