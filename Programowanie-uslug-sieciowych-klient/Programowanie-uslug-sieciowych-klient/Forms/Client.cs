using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programowanie_uslug_sieciowych_klient
{
    public partial class Client : Form
    {
        private ClientConnector client;
        delegate void StringArgReturningVoidDelegate(string text);
        public Client()
        {
            InitializeComponent();
            Thread clientConnectionThread;
            clientConnectionThread = new Thread(ConnectWithClient);
            clientConnectionThread.Start();
            btnDownloadFile.Enabled = false;
            btnSendFile.Enabled = false;
            btnSendMessage.Enabled = false;
        }

        private RichTextBox ReturnTextBox()
        {
            return this.consoleBox;
        }

        private void ConnectWithClient()
        {
            client = new ClientConnector(1800, this).ReturnClient();//ReturnTextBox());
            client.ConnectWithServer();
        }

      

        public void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the  
            // calling thread to the thread ID of the creating thread.  
            // If these threads are different, it returns true.  
            if (this.consoleBox.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.consoleBox.Text += text;
            }
        }

        public void ActiveForm(string text)
        {
            if (this.consoleBox.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(ActiveForm);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.consoleBox.Text += text;
                EnableButtons();
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            client.SendMessage(msgTextBox.Text.ToString());
            msgTextBox.Clear();
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if(fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                client.SendFile(filePath);
            }
            
        }

        private void btnDownloadFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                client.SendMessage("/download@" + filePath);
            }
        }

        private void msgTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Enter)
            {
                client.SendMessage(msgTextBox.Text.ToString().Replace('\n', ' '));
                msgTextBox.Clear();
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.ShowDialog();
            string registerString = register.ReturnRegisterString();
            if(registerString!=null)
            {
                client.SendMessage("/register #" +  registerString);
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm register = new LoginForm();
            register.ShowDialog();
            string registerString = register.ReturnLoginString();
            if (registerString != null)
            {
                client.SendMessage("/login #" + registerString);
            }
        }

        private void EnableButtons()
        {
            btnDownloadFile.Enabled = true;
            btnSendFile.Enabled = true;
            btnSendMessage.Enabled = true;
        }
    } 
}
