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
    public partial class FriendsForm : Form
    {
        private ClientConnector client;
        public FriendsForm()
        {
            InitializeComponent();

        }

        public void FillGridWithFriends(string friendString)
        {
            //string fomrat looks like /showFriends@friendId@friendLogin@active#
            //where # is treated as enter
            int flagForFirstRow = 0;
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("LOGIN");
            dt.Columns.Add("READED");
            dt.Columns.Add("ACTIVE");

           // friendsGrid.Rows.Remove(friendsGrid.Rows[0]);
            friendsGrid.Columns[0].DataPropertyName = "ID";
            friendsGrid.Columns[1].DataPropertyName = "LOGIN";
            friendsGrid.Columns[2].DataPropertyName = "READED";
            friendsGrid.Columns[3].DataPropertyName = "ACTIVE";


            string[] lines = friendString.Split('#');
            foreach(string line in lines)
            {
                if(flagForFirstRow==0)
                {
                    flagForFirstRow = 1;
                    continue;
                }
          
                string[] paramList = line.Split('@');
                if(paramList.Count() <= 1)
                {
                    break;
                }
                DataRow r = dt.NewRow();
                string userId = paramList[0];
                string userLogin = paramList[1];
                string userActive = paramList[2];
                bool activeBit = false;
                if(userActive.Equals("active"))
                {
                    activeBit = true;
                }
                r[0] = userId.ToString();
                r[1] = userLogin.ToString();
                r[2] = false;
                r[3] = activeBit;
                dt.Rows.Add(r);
            }
            friendsGrid.DataSource = dt;
            friendsGrid.Refresh();
        }

        public void ColorGrid()
        {
            DataTable dt = (DataTable)friendsGrid.DataSource;
            for (int i = 0; i < friendsGrid.Rows.Count; i++)
            {
                if (friendsGrid[3,i].Value.ToString() == "True")
                {
                    friendsGrid.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    friendsGrid.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
            }
            friendsGrid.Refresh();
        }

        private void friendsGrid_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ColorGrid();
        }

        public void SetClientConnector(ClientConnector client)
        {
            this.client = client;
        }

        public void UnsetClientConnector()
        {
            this.client = null;
        }

        private void btnAddFriend_Click(object sender, EventArgs e)
        {
            AddFriendForm addFriend = new AddFriendForm();
            addFriend.ShowDialog();
            string friendName = addFriend.GetFriendName();
            client.SendMessage("/addFriend" + "@" + friendName);
            this.Close();
        }
    }
}
