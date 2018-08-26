//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sates.input
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup input
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
    |2018년 7월 28일 | api_cmd_server 상속으로 구조 변경   | 김석환  |  사용자  |
    |2018년 8월 22일 | run() 함수의 loop 삭제, 해당 thread 가 종료되지 않아 프로세스가 종료되지 안는 문제 해결   | 김석환  |  사용자  |
    |2018년 8월 23일 | run() 함수의 loop 를 복원, stop 메소드에서 listener.stop 호출. exception 을 catch 하여 시스템 종료가 되게끔 수정.  | 김석환  |  사용자  |
     */

    /// <summary>
    /// TCP / IP 소켓을 통해 json 커맨드 등을 수신
    /// </summary>
    public class api_cmd_server_json_tcpip : api_cmd_server
    {
        public bool b_is_running = false;
        private List<System.ComponentModel.BackgroundWorker> worker_list 
            = new List<System.ComponentModel.BackgroundWorker>();

        System.Net.IPAddress local_ip;
        private int port = -1;
        private System.Net.Sockets.TcpListener listener;

        /// <summary>
        /// TCP/IP 서버 open 의 준비를 한다. 
        /// </summary>
        /// <param name="addr1">Local PC 의 IP 주소</param>
        /// <param name="addr2">서버를 open할 포트번호</param>
        /// <remarks>일반적이라면 open 함수에서 client 의 accept 를 하지만, 
        /// 여기서는 실행하지 않고 단순히 ip 및 port 번호만을 확보한다. 
        /// 이는 run 함수가 async 로 동작하기 때문에 가능하다.
        /// 즉, 따라서 이 server 의 run 함수를 실행한 이후, client 사이드에서
        /// 접속이 가능하다.
        /// </remarks>
        public override void open(string addr1, string addr2 = null)
        {
            local_ip = System.Net.IPAddress.Parse(addr1);
            port = Int32.Parse(addr2);
            listener = new System.Net.Sockets.TcpListener(local_ip, port);
            listener.Start();
        }

        public override async void run()
        {
            b_is_running = true;
            
            System.Console.WriteLine("Server {0}:{1} is now opened ",
                ((System.Net.IPEndPoint)listener.Server.LocalEndPoint).Address.ToString(),
                ((System.Net.IPEndPoint)listener.Server.LocalEndPoint).Port.ToString());

            //while (b_is_running)
            {
                try
                {
                    var client = await listener.AcceptTcpClientAsync();
                    System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
                    worker.DoWork += client_run;
                    worker.RunWorkerAsync(client);
                    worker_list.Add(worker);
                }
                catch (Exception e)
                {
                    if (!b_is_running)
                    {
                        System.Console.WriteLine("Server Closed, listener is stopped");
                    }
                }
            }
        }

        public override bool is_running()
        {
            return b_is_running;
        }

        private void client_run(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var client = (System.Net.Sockets.TcpClient)e.Argument;
            api_cmd_json_parser parser = new api_cmd_json_parser();

            System.Console.WriteLine("Local {0}:{2} and Remote {1}:{3} is now connected",
                ((System.Net.IPEndPoint)client.Client.LocalEndPoint).Address.ToString(),
                ((System.Net.IPEndPoint)client.Client.RemoteEndPoint).Address.ToString(),
                ((System.Net.IPEndPoint)client.Client.LocalEndPoint).Port.ToString(),
                ((System.Net.IPEndPoint)client.Client.RemoteEndPoint).Port.ToString());

            while (b_is_running)
            {
                try
                {
                    util.string_transfer.receive(client, out string msg, Encoding.UTF8);
                    var cmds = parser.parse(msg);
                    foreach (var cmd in cmds)
                    {
                        string result = sates.input.api.api_manager.call(cmd);
                        util.string_transfer.send(client, result, Encoding.UTF8);
                    }
                }
                catch (Exception excep)
                {
                    System.Console.WriteLine(excep.ToString());
                    b_is_running = false;
                }
            }
            e.Cancel = true;
        }

        public override void close()
        {
            b_is_running = false;
            listener.Stop();
        }
    }
    /** @} */
    /** @} */
    /** @} */
}
