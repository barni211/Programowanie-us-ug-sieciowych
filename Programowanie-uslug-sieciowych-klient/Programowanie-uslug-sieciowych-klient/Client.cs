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
        }

        private RichTextBox ReturnTextBox()
        {
            return this.richTextBox1;
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
            if (this.richTextBox1.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.richTextBox1.Text += text;
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            client.SendMessage(richTextBox2.Text.ToString());
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
    } 
}
