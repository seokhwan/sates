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
    |2018년 7월 28일 | api_cmd_server 상속으로 구조 변경,   | 김석환  |  사용자  |
     */

    /// <summary>
    /// TCP / IP 소켓을 통해 json 커맨드 등을 수신
    /// </summary>
    class api_cmd_server_json_tcpip : api_cmd_server
    {
        private bool is_stopped = false;
        private List<System.ComponentModel.BackgroundWorker> worker_list 
            = new List<System.ComponentModel.BackgroundWorker>();

        System.Net.IPAddress local_ip;
        private int port = -1;
        
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
        }

        public override async void run()
        {
            System.Net.Sockets.TcpListener listener = new System.Net.Sockets.TcpListener(local_ip, port);
            listener.Start();
            while (!is_stopped)
            {
                var client = await listener.AcceptTcpClientAsync();
                System.ComponentModel.BackgroundWorker worker = new System.ComponentModel.BackgroundWorker();
                worker.DoWork += client_run;
                worker.RunWorkerAsync(client);
                worker_list.Add(worker);
            }
        }

        private void client_run(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var client = (System.Net.Sockets.TcpClient)e.Argument;
            api_cmd_json_parser parser = new api_cmd_json_parser();
            while (!is_stopped)
            {
                util.string_transfer.receive(client, out string msg, Encoding.UTF8);
                var cmds = parser.parse(msg);
            }
        }

        public override void close()
        {
            is_stopped = true;

            foreach (var worker in worker_list)
            {
                worker.CancelAsync();
            }
        }
    }
    /** @} */
    /** @} */
    /** @} */
}
