using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programowanie_uslug_sieciowych_klient
{
    public partial class RegisterForm : Form
    {
        private string registerString = null;
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                StringBuilder builderRegisterString = new StringBuilder();

                builderRegisterString.Append(textBox1.Text + "#");
                builderRegisterString.Append(textBox2.Text + "#");
                builderRegisterString.Append(textBox3.Text + "#");
                builderRegisterString.Append(textBox4.Text);

                registerString = builderRegisterString.ToString();

                this.Close();
            }
            else
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            }
        }

        public string ReturnRegisterString()
        {
            return this.registerString;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateForm()
        {
            if(textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") || textBox4.Text.Equals(""))
            {
                return false;
            }
            return true;
        }
    }
}
