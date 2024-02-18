using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegisterForm
{
    public partial class Form1 : Form
    {
        string defaultcb = "Select nationality";

        public Form1()
        {
            InitializeComponent();
            output.Text = "Registration Form";
            comboBox1.Text = defaultcb;
            comboBox1.Items.Add("Indian");
            comboBox1.Items.Add("Non Indian");
        }

        private void Register_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" /*&& comboBox1.Text != defaultcb*/)
            {
                //ComboBox Validation
                if (comboBox1.Text != defaultcb)
                {
                    // Password validation start
                    if (textBox3.Text.Length >= 6)
                    {
                        if (textBox3.Text == textBox4.Text)
                        {
                            output.Text = "Welcome, " + textBox1.Text;
                        }
                        else
                        {
                            output.Text = "Password is not matching";
                        }
                    }
                    else
                    {
                        output.Text = "Password length should be 6 or more";
                    }
                    //Password validation End

                }
                else {
                    output.Text = "please select nationality";

                }

            }
            else{
                output.Text = "Please fill all details";
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            output.Text = "Registration Form";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = defaultcb;

        }
    }
}
