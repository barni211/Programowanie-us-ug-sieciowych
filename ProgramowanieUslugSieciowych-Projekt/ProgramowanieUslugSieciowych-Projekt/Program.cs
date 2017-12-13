using Logger;
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
        static TcpListener tcpListener = new TcpListener(1800);
        //static TcpListener listenerForLogger = new TcpListener(1800);
        static int clientCounter = 0;
        static Logger.Logger log;
        static Server s;

        static void Main()
        {
            FileOutputter file = new FileOutputter();
            log = new Logger.Logger();
            log.SetLoggerLevel(Level.DEBUG);
            log.SetLoggerOutput(file);


            tcpListener.Start();
            //listenerForLogger.Start();
            Thread threadForServer = new Thread(RunServer);
            threadForServer.Start();

            s = new Server();
            s.ShowDialog();

        }

  
        public static void RunServer()
        {
            for (;;)
            {
                Socket socketForClient = tcpListener.AcceptSocket();
                Thread thread = new Thread(() => ConnectedClient(socketForClient));
                thread.Start();
            }
        }

     

        static void ConnectedClient(Socket socketForClient)
        {
            //Debugger.Break();
            //Console.ReadKey();
           // Debug.Print("Client is connected, hello");
            if (socketForClient.Connected)
            {
                s.increment();
                log.WriteLog(Level.DEBUG, "Client:" + socketForClient.RemoteEndPoint + " now connected to server.");
                NetworkStream networkStream = new NetworkStream(socketForClient);
                System.IO.StreamWriter streamWriter =
                new System.IO.StreamWriter(networkStream);
                System.IO.StreamReader streamReader =
                new System.IO.StreamReader(networkStream);

                //here we recieve client's text if any.
                while (true)
                {

                    string theString = streamReader.ReadLine();
                    Debug.Print(theString);
                    //  if (theString.Length > 10)
                    //  {
                    //      //log.WriteLog(Level.ALERT, "Message recieved by client: " + socketForClient.RemoteEndPoint + ": " + theString);
                    //  }
                    //  else
                    //  {
                    //      //log.WriteLog(Level.DEBUG, "Message recieved by client: " + socketForClient.RemoteEndPoint + ": " + theString);
                    //  }
                    if (theString == "exit")
                        break;
                }
                streamReader.Close();
                networkStream.Close();
                streamWriter.Close();
                s.decrement();
            }
          
            socketForClient.Close();

            //log.WriteLog(Level.INFO, "Press any key to exit from server program");
            //Console.ReadKey();
        }
    }
}
