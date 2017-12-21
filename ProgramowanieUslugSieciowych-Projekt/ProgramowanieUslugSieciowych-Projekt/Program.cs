//using Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramowanieUslugSieciowych_Projekt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
      

        static void Main()
        {
            
            Server s = new Server();
            ServerStarter startServer = new ServerStarter(s);
            s.ShowDialog();

        }

  
    }
}
