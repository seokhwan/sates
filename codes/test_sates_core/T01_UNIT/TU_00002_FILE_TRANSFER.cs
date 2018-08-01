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

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 28일 | 기본적인 테스트 코드 작성 | 김석환  |  사용자  |
     */

    /// <summary>
    /// sates.util.string_transfer 클래스를 테스트한다.
    /// </summary>
    class TU_00002_FILE_TRANSFER : sates.test.cs.testcode
    {
        Thread th;
        private void thread_func(object param)
        {
            System.Net.Sockets.TcpListener listener
                = new System.Net.Sockets.TcpListener(System.Net.IPAddress.Parse("127.0.0.1"), 5000);
            listener.Start();
            var client = listener.AcceptTcpClient();

            sates.util.file_transfer.receive(client, "tmp2.txt");

            listener.Stop();
            client.Close();
        }
        public override void init()
        {
            System.IO.StreamWriter wr = new System.IO.StreamWriter("tmp.txt");
            wr.WriteLine("this is a test ");
            wr.WriteLine("이것은 테스트 입니다.");
            wr.WriteLine("日本語で同じような言い回しがありますか？");
            wr.WriteLine(" ㅇㄴ마ㅡㄻ날 3045ㅁㅇㄻ dsfasf )(*&^%$#@!");
            wr.WriteLine(" हज़ार भावचित्र हैं, लेकिन इन में से अधिकतर केवल ऐतिहासिक लिखाइयों में दे");
            wr.WriteLine("，遂直取漢字以記事。倭取字音，合於倭言，用日久，字形愈簡，遂");
            wr.WriteLine("也是上古时期各大文字体系中唯一传承至今的，相较而言，古埃");
            wr.WriteLine("            ");
            wr.WriteLine("                        ");
            wr.WriteLine("        ");
            wr.Close();




            th = new Thread(thread_func);
            th.Start();

            System.Threading.Thread.Sleep(100);

            
        }

        public override void run()
        {
            System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
            client.Connect("127.0.0.1", 5000);

            sates.util.file_transfer.send(client, "tmp.txt");

            System.Threading.Thread.Sleep(100);

            client.Close();

            var lines1 = System.IO.File.ReadAllLines("tmp.txt");
            var lines2 = System.IO.File.ReadAllLines("tmp2.txt");

            if (sates.test.cs.SATES.EQ(lines1.Length, lines2.Length))
            {
                for (int i = 0; i < lines1.Length; i++)
                {
                    sates.test.cs.SATES.EQ(lines1[i], lines2[i]);
                }
            }
            

            var b1 = System.IO.File.ReadAllBytes("tmp.txt");
            var b2 = System.IO.File.ReadAllBytes("tmp2.txt");

            
            if (sates.test.cs.SATES.EQ(b1.Length, b2.Length))
            {
                for (int i = 0; i < b1.Length; i++)
                {
                    sates.test.cs.SATES.EQ(b1[i], b2[i]);
                }
            }
            

            System.IO.File.Delete("tmp.txt");
            System.IO.File.Delete("tmp2.txt");
        }

        public override void terminate()
        {

        }
    }
    /** @} */
    /** @} */
    /** @} */
}
