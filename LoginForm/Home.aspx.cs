using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

namespace LoginForm
{
    public partial class About : Page
    {
        //string defitem = "Select Id";

        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUserData();
            }

            //DropDownList1.Visible = true;
            //TextBox1.Visible = true;






            ///*show table*/

            //string showRecordQuery = "SELECT * FROM tblUser";
            //string showId = " SELECT UserId from tblUser";
            ////show
            //using (SqlConnection con = new SqlConnection(cs))
            //{

            //    using (SqlCommand cmd = new SqlCommand(showRecordQuery, con))
            //    {

            //        con.Open();
            //        SqlDataReader rdr = cmd.ExecuteReader();

            //        GridView1.DataSource = rdr;
            //        GridView1.DataBind();
            //        con.Close();
            //    }

            //    using (SqlCommand cmdidshow = new SqlCommand(showId, con))
            //    {

            //        con.Open();
            //        SqlDataReader reader = cmdidshow.ExecuteReader();

            //        // Bind the data to the DropDownList
            //        DropDownList1.DataSource = reader;
            //        DropDownList1.DataTextField = "UserId"; // Display text in the DropDownList
            //        DropDownList1.DataValueField = "UserId"; // Value associated with the displayed text
            //        DropDownList1.DataBind();

            //        con.Close();
            //    }
            //}


            ///*end show table*/


        }

        private void BindUserData()
        {
            
            string showRecordQuery = "SELECT * FROM tblUser";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(showRecordQuery, con))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();

                    // Bind GridView
                    GridView1.DataSource = rdr;
                    GridView1.DataBind();

                    rdr.Close();
                }

                // Reuse the same query for binding DropDownList
                using (SqlCommand cmd = new SqlCommand(showRecordQuery, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Bind the data to the DropDownList
                    DropDownList1.DataSource = reader;
                    DropDownList1.DataTextField = "Email"; // "Email" Display text in the DropDownList
                    DropDownList1.DataValueField = "UserId"; // Value associated with the displayed text
                    DropDownList1.DataBind();

                    reader.Close();
                }

                con.Close();
            }
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //string showRecordQuery = "SELECT * FROM tblUser";
            //string showId = " SELECT UserId from tblUser";
            ////show
            //using (SqlConnection con = new SqlConnection(cs)){

            //    using (SqlCommand cmd = new SqlCommand(showRecordQuery, con)) {

            //        con.Open();
            //        SqlDataReader rdr = cmd.ExecuteReader();

            //        GridView1.DataSource = rdr;
            //        GridView1.DataBind();
            //        con.Close();
            //    }

            //    using (SqlCommand cmdidshow = new SqlCommand(showId,con)) {

            //        con.Open();
            //        SqlDataReader reader = cmdidshow.ExecuteReader();

            //        // Bind the data to the DropDownList
            //        DropDownList1.DataSource = reader;
            //        DropDownList1.DataTextField = "UserId"; // Display text in the DropDownList
            //        DropDownList1.DataValueField = "UserId"; // Value associated with the displayed text
            //        DropDownList1.DataBind();
            //        con.Close();
            //    }
            //}



            //DropDownList1.Items.Add(defitem);

            Button1.Visible = true;
            DropDownList1.Visible= true;
            TextBox1.Visible= true;
            Label2.Visible= true;
            Label3.Visible= true;
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ////update

            //string UpdateRecordQuery = "Update tblUser set Passwords=@Password where UserId=@UserId";

            ////string selectedValue = DropDownList1.SelectedValue;





            ////if (DropDownList1.Visible==false )
            ////{
            ////    DropDownList1.Visible = true;
            ////}
            ////else if (DropDownList1.Visible == true)
            ////{
            ////    DropDownList1.Visible = false;

            ////}

            ////if (TextBox1.Visible == false) {
            ////    TextBox1.Visible = true;
            ////}
            ////else if (TextBox1.Visible == true)
            ////{
            ////    TextBox1.Visible = false;
            ////}

            ////if (DropDownList1.Visible == true && TextBox1.Visible == true) {

            //    //if (selectedValue != DropDownList1.Items[0].ToString())
            //    //{

            //        using (SqlConnection con = new SqlConnection(cs))
            //        {

            //            using (SqlCommand cmd = new SqlCommand(UpdateRecordQuery, con))
            //            {

            //                con.Open();

            //                cmd.Parameters.AddWithValue("@Password", TextBox1.Text);
            //                cmd.Parameters.AddWithValue("@UserId", DropDownList1.SelectedValue);

            //                int rowsAffected = cmd.ExecuteNonQuery();
            //                if (rowsAffected > 0)
            //                {
            //                    // Update successful
            //                    // You can provide feedback to the user or redirect to another page
            //                    Label1.Text = "Password updated successfully!";
            //                    Label1.ForeColor = Color.Green;
            //                }
            //                else
            //                {
            //                    // Update failed
            //                    Label1.Text = "Failed to update Password. Please try again.";
            //                    Label1.ForeColor = Color.Red;
            //                }

            //            }
            //        //}
            //    }

            ////}


            string updateRecordQuery = "UPDATE tblUser SET Passwords = @Password WHERE UserId = @UserId";

            if (TextBox1.Text != "")
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand(updateRecordQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Password", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@UserId", DropDownList1.SelectedValue);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Update successful
                            // You can provide feedback to the user or redirect to another page
                            Label1.Visible= true;
                            Label1.Text = "Password updated successfully!";
                            Label1.ForeColor = Color.Green;

                            Button1.Visible = false;
                            DropDownList1.Visible = false;
                            TextBox1.Visible = false;
                            Label2.Visible = false;
                            Label3.Visible = false;
                            TextBox1.Text = "";
                        }
                        else
                        {
                            // Update failed
                            Label1.Visible= true;
                            Label1.Text = "Failed to update Password. Please try again.";
                            Label1.ForeColor = Color.Red;
                        }
                    }
                }
            }
            else {
                Label1.Visible  = true;
                Label1.Text = "Please fill all fields.";
                Label1.ForeColor = Color.Red;
            }

            // Refresh the data after update
            BindUserData();

          




        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            DropDownList1.Visible = true;
            Label3.Visible = true;
            Button4.Visible = true;

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //delete

            string deleteQuery = "delete from tblUser where UserId=@UserId";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                {

                    cmd.Parameters.AddWithValue("@UserId", DropDownList1.SelectedValue);


                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Update successful
                        // You can provide feedback to the user or redirect to another page
                        Label1.Visible = true;
                        Label1.Text = "Record deleted successfully!";
                        Label1.ForeColor = Color.Green;

                        DropDownList1.Visible = false;
                        Label3.Visible = false;
                        Button4 .Visible = false;   
                        //TextBox1.Text = "";
                    }
                    else
                    {
                        // delete failed
                        Label1.Visible = true;
                        Label1.Text = "Failed to delete record. Please try again.";
                        Label1.ForeColor = Color.Red;
                    }
                }
            }

            ReorderUserIds();

            BindUserData();
        }


        private void ReorderUserIds()
        {
            // Example: Reorder the UserId values after deletion
            // This is a simple example and might not be suitable for all scenarios
            string reorderQuery = "DBCC CHECKIDENT ('tblUser', RESEED, 0)";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand(reorderQuery, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}