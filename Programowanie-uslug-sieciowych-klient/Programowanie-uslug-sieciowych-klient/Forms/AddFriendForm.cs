using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programowanie_uslug_sieciowych_klient.Forms
{
    public partial class AddFriendForm : Form
    {
        private string friendName = null;
        private ClientConnector connector = null;
        public AddFriendForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnAnuluj_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public string GetFriendName()
        {
            return friendName;
        }

        public void SetClientConnector(ClientConnector conn)
        {
            //this.connector = conn;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                friendName = textBox1.Text;
                //connector.SendMessage("/showFriend");
                this.Close();
                
            }
            else
            {
                MessageBox.Show("Musisz podać nazwe użytkownika");
            }
        }
    }
}
