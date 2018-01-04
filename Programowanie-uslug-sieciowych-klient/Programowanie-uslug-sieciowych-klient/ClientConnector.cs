using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
        private IPAddress[] ipAddress;
        private Socket clientSock;
        private IPEndPoint ipEnd;
        private bool connection = false;
        private int port;

        public ClientConnector(int port, Client textB)
        {
            this.clientForm = textB;
            this.port = port;
            // createLogger();

            ipAddress = Dns.GetHostAddresses("localhost");

            ipEnd = new IPEndPoint(ipAddress[0], port);

            Socket clientSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
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
                string outputString = "";
                // read the data from the host and display it
                {
                
                    string str = outputString;
                    while (str != "exit")
                    {
                        outputString = streamReader.ReadLine();
                        clientForm.SetText("Message Recieved by server:" + outputString);
                        if (outputString == null)
                        {
                            continue;
                        }
                        if (outputString.Count() > 8 && outputString.Substring(0, 9) == "/download")
                        {
                            string[] tmpStr = outputString.Split(' ');
                            int allBytesToRead = Int32.Parse(tmpStr[1]);
                            DownloadFile(allBytesToRead);
                            outputString = "";
                            str = "";
                        }
                        else
                        {
                            streamWriter.WriteLine(str);
                            streamWriter.Flush();
                        }

                    }
                    if (str == "exit")
                    {
                        streamWriter.WriteLine(str);
                        streamWriter.Flush();
                        connection = false;
                    }                

                }
            }
            catch(Exception ex)
            {
                clientForm.SetText("Exception while reading from server");
                connection = false;
            }

            // tidy up
            networkStream.Close();
            connection = false;

            clientForm.SetText("Press any key to exit from client program");
        }

        public void DownloadFile(int allBytesToRead)
        {


            while (connection)
            {
                bool downloadingFinished = false;
        
                    //int allBytesToRead = Int32.Parse(tmpStr[1]);
                int totalBytesRead = 0;
                //string newFilePath = @"C:\Users\bartosz.fijalkowski\Desktop\Jarocki\Programowanie-us-ug-sieciowych\ClientLocation\" + "DownloadedFile" + Guid.NewGuid() + ".jpg";
                string newFilePath = @"E:\.NET workspace\Programowanie usług sieciowych\ClientLocation" + "DownloadedFile" + Guid.NewGuid() + ".jpg";
                FileStream myDownload = new FileStream(newFilePath, FileMode.Create);
                byte[] Buffer = new Byte[1024];
                int bytesRead;
                while ((bytesRead = socketForServer.Client.Receive(Buffer)) > 0)
                {
                    totalBytesRead += bytesRead;
                    clientForm.SetText("Readed " + totalBytesRead + " bytes.\n");
                    myDownload.Write(Buffer, 0, bytesRead);
                    if (totalBytesRead == allBytesToRead)
                    {
                        downloadingFinished = true;
                        break;
                    }
                }
                myDownload.Flush();
                myDownload.Close();
                if(downloadingFinished==true)
                {
                    Bitmap b = new Bitmap(newFilePath);
                    ShowImage s = new ShowImage(b);
                    s.Height = b.Height;
                    s.Width = b.Width;
                    s.ShowDialog();
                    break;
                }
                            
            }

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

        public ClientConnector ReturnClient()
        {
            return this;
        }



    }
}
