using System;
using System.Linq;
using SmtpProtocol.Properties.client;
using SmtpProtocol.Properties.server;

namespace SmtpProtocol
{
    /// <summary>
    /// Main Class.
    /// <<remarks> if sender's mail is gmail, protocol will not work
    /// ( server will not be able to authorize sender ) </remarks>
    /// </summary>
    internal class Program
    {
        public static void Main(string[] args)
        {
            var server = new Server(25, new AuthorizedClient("email", "password"));
            const string command = "/change_receiver";
            const string exit = "/exit";
            
            Console.WriteLine("Put user-receiver: ");
            Client receiver = new Client(Console.ReadLine());
            Console.WriteLine(String.Join(" ","If you want change receiver put",command));
            Console.WriteLine(String.Join(" ","If you want exit program/ put",exit));
            for (;;)
            {

                Console.WriteLine("Put message : ");
                var text = Console.ReadLine();
                
                switch (text)
                {
                    case command:
                    {
                        Console.WriteLine("Put user-receiver: ");
                        receiver = new Client(Console.ReadLine());
                        break;
                    }
                    case exit: return;
                    default:
                    {
                        server.SendMessage(receiver, text);
                        break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
