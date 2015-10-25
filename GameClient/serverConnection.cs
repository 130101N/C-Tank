using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace GameClient
{
    class serverConnection
  
    {
        bool errorOcurred = false;
        Socket connection = null; //The socket that is listened to     
        TcpListener listener = null;

        public void waitForConnection()
        {
            try
            {
                //Creating listening Socket
                this.listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7000);

                Console.WriteLine("waiting for server response");

                //Starts listening
                this.listener.Start();

                
                //Establish connection upon server request
                while (true)
                {
                    connection = listener.AcceptSocket();   //connection is connected socket

                    Console.WriteLine("Connetion is established");

                    //Fetch the messages from the server
                    int asw = 0;
                    //create a network stream using connecion
                    NetworkStream serverStream = new NetworkStream(connection);
                    List<Byte> inputStr = new List<byte>();

                    //fetch messages from  server
                    while (asw != -1)
                    {
                        asw = serverStream.ReadByte();
                        inputStr.Add((Byte)asw);
                    }

                    String messageFromServer = Encoding.UTF8.GetString(inputStr.ToArray());

                    serverResponce msg = new serverResponce();
                    Console.Write("Response from server \n" + messageFromServer);
                    if (msg.serverJoinReply(messageFromServer) == 0)
                    {
                        //Console.WriteLine();
                        msg.acceptance(messageFromServer);
                    }
                    else
                    {
                        msg.serverJoinReply(messageFromServer);
                    }
                    /*
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        Console.WriteLine("kadkada");
                        clientConnection.Connect("UP#");
                        new serverConnection().waitForConnection();
                    }
                    else if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        clientConnection.Connect("DOWN#");
                        new serverConnection().waitForConnection();
                    }
                    else if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        clientConnection.Connect("RIGHT#");
                        new serverConnection().waitForConnection();
                    }
                    else if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        clientConnection.Connect("LEFT#");
                        new serverConnection().waitForConnection();
                    }
                    */
                    serverStream.Close();       //close the netork stream

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Communication (RECEIVING) Failed! \n " + e.StackTrace);
                errorOcurred = true;
            }
            finally
            {
                if (connection != null)
                    if (connection.Connected)
                        connection.Close();
                if (errorOcurred)
                    this.waitForConnection();
            }
        }

    }
}
