//using Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramowanieUslugSieciowych_Projekt
{
    public partial class Server : Form
    {
        static int clientCounter = 0;
        delegate void StringArgReturningVoidDelegate(string text);
        public Server()
        {
            InitializeComponent();
        }

        private void SetCounterView()
        {
            threadCounter.Text = clientCounter.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SetCounterView();
        }

        public void increment()
        {
            clientCounter++;
        }

        public void decrement()
        {
            clientCounter--;
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
                this.richTextBox1.Text += text + "\n";
            }
        }
    }


}
