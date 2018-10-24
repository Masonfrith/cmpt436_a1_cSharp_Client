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
        Stream stream;
        StreamReader sin;
        StreamWriter sout;


        public ChatClient(String ip, int portNumber)
        {
            Console.WriteLine("Client attempting to connect to " + ip + " on port # " + portNumber);
            this.clientConnection = new TcpClient(ip, portNumber);
            this.stream = clientConnection.GetStream();
            this.sin = new StreamReader(this.stream);
            this.sout = new StreamWriter(this.stream);
            Console.WriteLine("Now connected to the server!");
        }

    }
}
