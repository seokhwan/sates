using System;
using System.Collections.Generic;
using System.Text;

namespace sates
{
    class Program
    {
        public static void Main(string[] args)
        {
            sates.input.api_cmd_server server = new sates.input.api_cmd_server_json_tcpip();
            
            if (args.Length < 2)
            {
                System.Console.WriteLine("You did not input host address and port number, default setting is used: \"127.0.0.1\" and 5000");
                server.open("127.0.0.1", "5000");
            }
            else
            {
                server.open(args[0], args[1]);
            }
            server.run();
            while (server.is_running())
            {
                System.Threading.Thread.Sleep(100);
            }

            server.close();
        }
    }
}
