using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programowanie_uslug_sieciowych_klient
{
    public class ClientConnector
    {

        private Client clientForm;
        private NetworkStream networkStream;
        private StreamReader streamReader;
        private StreamWriter streamWriter;
        private TcpClient socketForServer;
        private bool connection = false;
        private int port;

        public ClientConnector(int port, Client textB)
        {
            this.clientForm = textB;
            this.port = port;
            // createLogger();
        }

        public void ConnectWithServer()
        {
            
            try
            {

                socketForServer = new TcpClient("localHost", port);
                connection = true;
            }
            catch
            {
                // log.WriteLog(Level.ERROR,
                //"Failed to connect to server at {0}:999" + "localhost");
                //return;
                // AppendConsoleText("Failed to connect to server at {0}:999" + "localhost");
                clientForm.SetText("Failed to connect to server at {0}:999" + "localhost");
                return;
            }

            networkStream = socketForServer.GetStream();
            System.IO.StreamReader streamReader =
            new System.IO.StreamReader(networkStream);
            streamWriter =
            new System.IO.StreamWriter(networkStream);
            // log.WriteLog(Level.INFO, "*******This is client program who is connected to localhost on port No:10*****");
            clientForm.SetText("*******This is client program who is connected to localhost on port No:10*****");
            try
            {
                string outputString;
                // read the data from the host and display it
                {
                    outputString = streamReader.ReadLine();
                    //Console.WriteLine("Message Recieved by server:" + outputString);
                    //  AppendConsoleText("Message Recieved by server:" + outputString);
                    clientForm.SetText("Message Recieved by server:" + outputString);
                    //Console.WriteLine("Type your message to be recieved by server:");
                    Console.WriteLine("type:");
                    string str = Console.ReadLine();
                    while (str != "exit")
                    {
                        streamWriter.WriteLine(str);
                        streamWriter.Flush();
                        Console.WriteLine("type:");
                        str = Console.ReadLine();
                    }
                    if (str == "exit")
                    {
                        streamWriter.WriteLine(str);
                        streamWriter.Flush();
                        connection = false;

                    }

                }
            }
            catch
            {
                //log.WriteLog(Level.ERROR, "Exception reading from Server");
                //AppendConsoleText("Excetion while reading from server");
                clientForm.SetText("Exception while reading from server");
                connection = false;
            }

            // tidy up
            networkStream.Close();
            connection = false;

            clientForm.SetText("Press any key to exit from client program");
            //Console.WriteLine("Press any key to exit from client program");
            //Console.ReadKey();
        }

        public void SendMessage(string txt)
        {
            streamWriter.WriteLine(txt);
            streamWriter.Flush();
        }


        public void SendFile(string filePath)
        {

            byte[] fileData = File.ReadAllBytes(filePath);
            streamWriter.WriteLine("/binary " + fileData.Count().ToString());
            streamWriter.Flush();

            socketForServer.Client.SendFile(filePath);
           
        }

        //public string AppendConsoleTextPrivate(string text)
        //{
          
        //}

        public ClientConnector ReturnClient()
        {
            return this;
        }



    }
}
