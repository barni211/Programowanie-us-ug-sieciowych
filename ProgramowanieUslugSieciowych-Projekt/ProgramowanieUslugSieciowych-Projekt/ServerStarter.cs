//using Logger;
using System;
using System.Collections.Generic;
using System.Data;
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

        private DataBase dbConnection;
        private Dictionary<User, Socket> loggedUsers = new Dictionary<User, Socket>();

        public ServerStarter(Server serv)
        {
            dbConnection = new DataBase();
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
                int flag = 0;
                s.increment();
                //log.WriteLog(Level.DEBUG, "Client:" + socketForClient.RemoteEndPoint + " now connected to server.");
                NetworkStream networkStream = new NetworkStream(socketForClient);
                System.IO.StreamWriter streamWriter =
                new System.IO.StreamWriter(networkStream);
                System.IO.StreamReader streamReader =
                new System.IO.StreamReader(networkStream);

                //here we recieve client's text if any.
                while (flag == 0)
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
                    {
                        //loggedUsers
                        //foreach(Socket sock in loggedUsers.Values)
                        //{
                        //    if(socketForClient.Equals(sock))
                        //    {

                        //        loggedUsers.Remove(sock);
                        //    }
                        //}
                        streamWriter.WriteLine("exit");
                        streamWriter.Flush();
                        var item = loggedUsers.First(kvp => kvp.Value == socketForClient);
                        loggedUsers.Remove(item.Key);
                        flag = 1;

                        break;
                    } 
                    else if(theString.Count() > 8 && theString.Substring(0,7) == "/binary")
                    {
                        string[] tmpStr = theString.Split(' ');
                        int allBytesToRead = Int32.Parse(tmpStr[1]);
                        int totalBytesRead = 0;
                        //FileStream myDownload = new FileStream(@"E:\.NET workspace\Programowanie usług sieciowych\FileLocation\" + "DownloadedFile" + Guid.NewGuid() + ".jpg", FileMode.Create);
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
                    else if(theString.Count() > 10 && theString.Substring(0,10)== "/register ")
                    {

                        string[] userData = theString.Split('#');
                        dbConnection.RegisterNewUserInDb(userData[1], userData[2], userData[4]);
                        streamWriter.WriteLine("New user succesfully registered! You're welcome, " + userData[1] + ".");
                        streamWriter.Flush();
                    }
                    else if(theString.Count() > 10 && theString.Substring(0,6)=="/login")
                    {
                        string[] userData = theString.Split('#');
                        string IdAndUsername = dbConnection.LoginIntoApplication(userData[1], userData[2]);
                        if(IdAndUsername!=null)
                        {
                            //string[] tmpUserString = IdAndUsername.Split('@');
                            User tmpUser = new User(IdAndUsername, userData[2]);
                            loggedUsers.Add(tmpUser, socketForClient);
                            streamWriter.WriteLine("/loginSuccess " + IdAndUsername);
                            streamWriter.Flush();
                        }
                        else
                        {
                            streamWriter.WriteLine("/loginFailed");
                            streamWriter.Flush();
                        }
                        
                    }
                    else if (theString.Count() > 7 && theString.Substring(0, 6) == "/sendTo")
                    {
                        //string format is look like this: /sendTo@sender@receiver@message
                        string[] tmpStr = theString.Split('@');
                        User tmpSender = FindUserByKey(tmpStr[1]);
                        User tmpReceiver = FindUserByKey(tmpStr[2]);
                        dbConnection.SendMessageToUser(tmpStr[3], tmpSender.GetUserLogin(), tmpStr[2]);
                        if(tmpReceiver!=null)
                        {
                            SendMessageFromClientToClient(tmpSender, tmpReceiver, "/refreshConversation");
                        }

                    }
                    else if(theString.Count() > 7 && theString.Substring(0, 10) == "/addFriend")
                    {
                        //string format is look like this: /addFriend@friend
                        string[] tmpStr = theString.Split('@');
                        var item = loggedUsers.First(kvp => kvp.Value == socketForClient);
                        User tmpSender = item.Key;
                        //User tmpSender = FindUserByKey(tmpStr[1]);
                        User tmpReceiver = FindUserByKey(tmpStr[1]);
                        dbConnection.AddNewFriend(tmpSender.GetUserLogin(), tmpStr[1]);
                        if (tmpReceiver != null)
                        {
                            string msgToReceiver = "/newFriend @" + tmpSender.GetUserLogin();
                            SendMessageFromClientToClient(tmpSender, tmpReceiver, msgToReceiver);
                        }
                    }
                    else if (theString.Count() > 7 && theString.Substring(0, 11) == "/showFriend")
                    {
                        //string format is look like this: /showFriend@owner
                        var item = loggedUsers.First(kvp => kvp.Value == socketForClient);
                        User tmpSender = item.Key;

                       // string[] tmpStr = theString.Split('@');
                       // User tmpSender = FindUserByKey(tmpStr[1]);
                        //User tmpReceiver = FindUserByKey(tmpStr[2]);
                        System.Data.DataTable friends = dbConnection.ShowFriendList(tmpSender.GetUserLogin());
                        StringBuilder stringFriendsList = new StringBuilder();
                        stringFriendsList.Append("/showFriends#");
                        foreach(DataRow row in friends.Rows)
                        {
                            int friendId = Int16.Parse(row[0].ToString());
                            string friendLogin = row[1].ToString();
                            string active = "inactive";
                            foreach(User user in loggedUsers.Keys)
                            {
                                if(user.GetUserLogin().Equals(friendLogin))
                                {
                                    active = "active";
                                }
                            }
                            stringFriendsList.Append(friendId + "@" + friendLogin + "@" + active + "#");
                        }

                        string stringToSend = stringFriendsList.ToString();
                        streamWriter.WriteLine(stringToSend);
                        streamWriter.Flush();

                    }
                    else
                    {
                        s.SetText("Message recieved by client: " + socketForClient.RemoteEndPoint + ": " + theString);
                        //break;
                    }
                      
                     
                    
                }
                //streamReader.Close();
                //networkStream.Close();
                //streamWriter.Close();
                //socketForClient.Close();
                s.decrement();
            }

            

            //log.WriteLog(Level.INFO, "Press any key to exit from server program");
            //Console.ReadKey();
        }

        private User FindUserByKey(string username)
        {
            foreach(User tmpVal in loggedUsers.Keys)
            {
                if(tmpVal.GetUserLogin().Equals(username))
                {
                    return tmpVal;
                }
            }
            return null;
        }

        private void SendMessageFromClientToClient(User sender, User receiver, string message)
        {
            Socket socketForClient = loggedUsers[receiver];

            NetworkStream networkStream = new NetworkStream(socketForClient);
            System.IO.StreamWriter streamWriter =
            new System.IO.StreamWriter(networkStream);
            System.IO.StreamReader streamReader =
            new System.IO.StreamReader(networkStream);

            streamWriter.WriteLine(message + sender.GetUserLogin());
        }



    //private Socket FindUserSocket(User user)
    //{

    //    return null;
    //}
}
}
