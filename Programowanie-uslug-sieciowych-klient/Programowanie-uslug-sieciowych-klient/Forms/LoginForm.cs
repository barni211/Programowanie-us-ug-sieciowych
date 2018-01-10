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
    public partial class LoginForm : Form
    {

        private string loginString;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                StringBuilder builderRegisterString = new StringBuilder();

                builderRegisterString.Append(loginTb.Text + "#");
                builderRegisterString.Append(passwordTb.Text + "#");

                loginString = builderRegisterString.ToString();

                this.Close();
            }
            else
            {
                MessageBox.Show("Wypełnij wszystkie pola!");
            }
        }

        public string ReturnLoginString()
        {
            return this.loginString;
        }


        private bool ValidateForm()
        {
            if (loginTb.Text.Equals("") || passwordTb.Text.Equals(""))
            {
                return false;
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
