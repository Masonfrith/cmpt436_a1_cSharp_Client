using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

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

            //lets test a first automatic communication without user input.
            this.sout.AutoFlush = true;
            this.sout.WriteLine("Hi I am from cSharp! wut up?");
            this.fromServer = this.sin.ReadLine();
            Console.WriteLine("Server: " + this.fromServer);
            this.sout.WriteLine("hah");
            this.fromServer = this.sin.ReadLine();
            Console.WriteLine("Server: " + this.fromServer);
            this.sout.WriteLine("QUIT");
            this.fromServer = this.sin.ReadLine();
        }

    }
}
