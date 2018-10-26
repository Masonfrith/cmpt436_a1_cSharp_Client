using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace cmpt436_a1_cSharp_Client
{
    class ChatClient
    {
        TcpClient clientConnection;
        String userInput;
        String fromServer;
        Stream stream;
        StreamReader sin;
        StreamWriter sout;
        


        public ChatClient(String ip, int portNumber)
        {
            this.fromServer = "";
            this.userInput = "";

            Console.WriteLine("Client attempting to connect to " + ip + " on port # " + portNumber);
            this.clientConnection = new TcpClient(ip, portNumber);
            this.stream = clientConnection.GetStream();
            this.sin = new StreamReader(this.stream);
            this.sout = new StreamWriter(this.stream);
            Console.WriteLine("Now connected to the server!");

            this.sout.AutoFlush = true; // seems to be needed to make it work, not sure why, needs reading

            Console.WriteLine("Press ENTER key to start chatting, any other to AutoChat.");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key.Equals(ConsoleKey.Enter)){
                this.userChat(); // start user interact chat
            }
            else {
                //lets test a first automatic communication without user input.
                this.autoChat();
            }
        }

        private void userChat()
        {
            Console.WriteLine("Ready for user to start chatting!");
        }

        private void autoChat()
        {
            Console.WriteLine("Starting autochat...");

            Random randomWait = new Random();

            Thread.Sleep(randomWait.Next(0, 10000)); // pause for 0-10s
            Console.WriteLine("Me: Hi I am from cSharp! wut up?");
            this.sout.WriteLine("Hi I am from cSharp! wut up?");
            this.fromServer = this.sin.ReadLine();
            Console.WriteLine("Server: " + this.fromServer);
            Thread.Sleep(randomWait.Next(0, 10000)); // pause for 0-10s
            Console.WriteLine("Me: hah");
            this.sout.WriteLine("hah");
            this.fromServer = this.sin.ReadLine();
            Console.WriteLine("Server: " + this.fromServer);
            Thread.Sleep(randomWait.Next(0, 10000)); // pause for 0-10s
            Console.WriteLine("Me: QUIT");
            this.sout.WriteLine("QUIT");
            this.fromServer = this.sin.ReadLine();
            Console.WriteLine("Server: " + this.fromServer);

            
        }

        internal void shutDownClient()
        {
            this.sin.Close();
            this.sout.Close();
            this.stream.Close();
            this.clientConnection.Close();
            Console.WriteLine("Connections closed, ready to shutdown.");
        }

    }
}
