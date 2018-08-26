//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TESTCODE.T01_UNIT
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup TESTCODE
    *  @{
    */
    /** \addtogroup T01_UNIT
    *  @{
    */
    public class TU_00001_STRING_TRANSFER : sates.test.cs.testcode
    {
        Thread th;
        string received_string;

        private void thread_func(object param)
        {
            System.Net.Sockets.TcpListener listener
                = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 6000);
            listener.Start();
            var client = listener.AcceptTcpClient();

            sates.util.string_transfer.receive(client, out received_string, Encoding.UTF8);

            listener.Stop();
            client.Close();
        }
        
        public override void init()
        {
            th = new Thread(thread_func);
            th.Start();

            System.Threading.Thread.Sleep(100);
        }
        
        public override void run()
        {
            System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
            client.Connect("127.0.0.1", 6000);

            string send_string = "test string 테스트 스트링  日本語、テストのストリングです。ひらがな ”";

            sates.util.string_transfer.send(client, send_string, Encoding.UTF8);

            System.Threading.Thread.Sleep(100);

            sates.test.cs.SATES.EQ(send_string, received_string);

            client.Close();
        }
        
        public override void terminate()
        {
            
        }
    }
}
