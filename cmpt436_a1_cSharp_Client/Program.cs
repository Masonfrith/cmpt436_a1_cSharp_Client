using System;
using System.Net.Sockets;

namespace cmpt436_a1_cSharp_Client
{
    class Program
    {

        static ChatClient chatClient;
        static String defaultIP = "localhost";
        static int defaultPort = 40010;


        static void Main(string[] args)
        {

            Console.WriteLine("Starting up chat program...");
            chatClient = new ChatClient(defaultIP, defaultPort);

            //interaction loop will go here!

            Console.WriteLine("Chatting done, press anykey to shutdown.");

            Console.ReadKey();

            chatClient.shutDownClient();
        }
    }
}
