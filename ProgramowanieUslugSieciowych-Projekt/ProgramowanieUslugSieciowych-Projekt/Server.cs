using Logger;
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
    }


}
