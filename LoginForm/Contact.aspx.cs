using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LoginForm
{
    public partial class Contact : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //TextBox1.Text = DropDownList1.SelectedItem.Value;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = DropDownList1.SelectedValue;

        }
    }
}