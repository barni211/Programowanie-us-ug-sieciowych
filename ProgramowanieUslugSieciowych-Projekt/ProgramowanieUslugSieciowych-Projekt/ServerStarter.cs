//using Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProgramowanieUslugSieciowych_Projekt
{
    public class ServerStarter
    {

        private static TcpListener tcpListener = new TcpListener(1800);
        //private //static TcpListener listenerForLogger = new TcpListener(1800);
        private static int clientCounter = 0;
        //private static Logger.Logger log;
        private Server s;

        public ServerStarter(Server serv)
        {
            this.s = serv;
            //FileOutputter file = new FileOutputter();
            //log = new Logger.Logger();
            //log.SetLoggerLevel(Level.DEBUG);
            //log.SetLoggerOutput(file);


            tcpListener.Start();
            //listenerForLogger.Start();
            Thread threadForServer = new Thread(RunServer);
            threadForServer.Start();
        }


        public void RunServer()
        {
            for (;;)
            {
                Socket socketForClient = tcpListener.AcceptSocket();
                Thread thread = new Thread(() => ConnectedClient(socketForClient));
                thread.Start();
            }
        }



        void ConnectedClient(Socket socketForClient)
        {
            //Debugger.Break();
            //Console.ReadKey();
            // Debug.Print("Client is connected, hello");
            if (socketForClient.Connected)
            {
                s.increment();
                //log.WriteLog(Level.DEBUG, "Client:" + socketForClient.RemoteEndPoint + " now connected to server.");
                NetworkStream networkStream = new NetworkStream(socketForClient);
                System.IO.StreamWriter streamWriter =
                new System.IO.StreamWriter(networkStream);
                System.IO.StreamReader streamReader =
                new System.IO.StreamReader(networkStream);

                //here we recieve client's text if any.
                while (true)
                {
                    string theString = "";
                    try {
                        theString = streamReader.ReadLine();
                    }
                    catch(IOException ex)
                    {
                        s.SetText("Error while reading file");
                        break;
                    }

                    if(theString==null)
                    {
                        continue;
                    }
                  
                                     
                    if (theString == "exit")
                        break;
                    else if(theString.Count() > 8 && theString.Substring(0,7) == "/binary")
                    {
                        string[] tmpStr = theString.Split(' ');
                        int allBytesToRead = Int32.Parse(tmpStr[1]);
                        int totalBytesRead = 0;
                        FileStream myDownload = new FileStream(@"E:\.NET workspace\Programowanie usług sieciowych\FileLocation\" + "DownloadedFile" + Guid.NewGuid() + ".jpg", FileMode.Create);
                        byte[] Buffer = new Byte[1024];
                        int bytesRead;
                        while ((bytesRead = socketForClient.Receive(Buffer)) > 0)
                        {
                            totalBytesRead += bytesRead;
                            s.SetText("Readed " + totalBytesRead + " bytes.\n");
                            myDownload.Write(Buffer, 0, bytesRead);
                            if(totalBytesRead==allBytesToRead)
                            {
                                break;
                            }
                        }
                        myDownload.Flush();
                        //myDownload.EndWrite();
                        myDownload.Close();
                        
                        //break;
                    }
                    else if(theString.Count() > 8 && theString.Substring(0, 9) == "/download")
                    {
                        string[] tmpStr = theString.Split('@');
                        string filePath = tmpStr[1];
                        byte[] fileData = File.ReadAllBytes(filePath);
                        streamWriter.WriteLine("/download " + fileData.Count().ToString());
                        streamWriter.Flush();

                        socketForClient.Send(fileData); //'.SendFile(filePath);
                    }
                    else
                    {
                        s.SetText("Message recieved by client: " + socketForClient.RemoteEndPoint + ": " + theString);
                        //break;
                    }
                      
                     
                    
                }
                streamReader.Close();
                networkStream.Close();
                streamWriter.Close();
                socketForClient.Close();
                s.decrement();
            }

            

            //log.WriteLog(Level.INFO, "Press any key to exit from server program");
            //Console.ReadKey();
        }
    }
}
