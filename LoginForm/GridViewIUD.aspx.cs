using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace LoginForm
{
    public partial class Contact : Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateGridView();

            }
        }

        void populateGridView() {
            string query = "select * from Employee";

            DataTable dtbl = new DataTable();

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvEmployee.DataSource = dtbl;
                gvEmployee.DataBind();
            }
            else {
                dtbl.Rows.Add(dtbl.NewRow());
                gvEmployee.DataSource = dtbl;
                gvEmployee.DataBind();
                gvEmployee.Rows[0].Cells.Clear();
                gvEmployee.Rows[0].Cells.Add(new TableCell());
                gvEmployee.Rows[0].Cells[0].ColumnSpan=dtbl.Columns.Count;
                gvEmployee.Rows[0].Cells[0].Text="No Data Found ...";
                gvEmployee.Rows[0].Cells[0].HorizontalAlign=HorizontalAlign.Center;


            }
        }

        protected void gvEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {

                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();

                        string query = "Insert into Employee (FirstName, LastName, Contact, Email) values(@FirstName, @LastName, @Contact, @Email)";

                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@FirstName", (gvEmployee.FooterRow.FindControl("txtFirstNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastName", (gvEmployee.FooterRow.FindControl("txtLastNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Contact", (gvEmployee.FooterRow.FindControl("txtContactFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Email", (gvEmployee.FooterRow.FindControl("txtEmailFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        populateGridView();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";

                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvEmployee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmployee.EditIndex = e.NewEditIndex;
            populateGridView();
        }

        protected void gvEmployee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvEmployee.EditIndex = -1;
            populateGridView();
        }

        protected void gvEmployee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    string query = "UPDATE Employee SET FirstName=@FirstName, LastName=@LastName, Contact=@Contact, Email=@Email WHERE Empid=@id";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@FirstName", (gvEmployee.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", (gvEmployee.Rows[e.RowIndex].FindControl("txtLastName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Contact", (gvEmployee.Rows[e.RowIndex].FindControl("txtContact") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Email", (gvEmployee.Rows[e.RowIndex].FindControl("txtEmail") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvEmployee.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvEmployee.EditIndex = -1;
                    populateGridView();
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";

                }

            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvEmployee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();

                    string query = "DELETE FROM Employee WHERE Empid=@id";

                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvEmployee.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    populateGridView();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";

                }

            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}