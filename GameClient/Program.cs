using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameClient
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("kldklkdls");
            
            //init client connection to server
            clientConnection.Connect("JOIN#");          
            //init a socket for call back from the server to fetch messages
            new serverConnection().waitForConnection();
            
            Console.WriteLine("kadkada");
            clientConnection.Connect("DOWN#");
            new serverConnection().waitForConnection();

            
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


        }
    }
}
