//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace sates.util
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup util
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 28일 | 최초작성  | 김석환  |  사용자  |
     */

    /// <summary>
    /// file 을 네트워크를 통해 교환하는 기능을 제공
    /// </summary>
    public class file_transfer
    {
        const int PACKET_SIZE = 1024;
        public static void receive(System.Net.Sockets.TcpClient client, string filepath)
        {
            var fs = System.IO.File.Create(filepath);
            
            byte[] buffer = new byte[PACKET_SIZE];
            int curtimeout = client.GetStream().ReadTimeout;
            // 타임아웃 10초 설정
            client.GetStream().ReadTimeout = 10 * 1000;

            client.GetStream().Read(buffer, 0, PACKET_SIZE);

            var filesize = BitConverter.ToInt32(buffer, 0);

            int remained_size = filesize;
            while(remained_size > 0)
            {
                if (remained_size > PACKET_SIZE)
                {
                    client.GetStream().Read(buffer, 0, PACKET_SIZE);
                    fs.Write(buffer, 0, PACKET_SIZE);
                }
                else
                {
                    client.GetStream().Read(buffer, 0, remained_size);
                    fs.Write(buffer, 0, remained_size);
                }

                remained_size = remained_size - PACKET_SIZE;
            }

            client.GetStream().ReadTimeout = curtimeout;
            fs.Close();
        }
        public static void send(System.Net.Sockets.TcpClient client, string filepath)
        {
            int curtimeout = client.GetStream().WriteTimeout;
            client.GetStream().WriteTimeout = 10 * 1000;

            byte[] packet_size_buffer = new byte[PACKET_SIZE];
            var sendbuf = System.IO.File.ReadAllBytes(filepath);
            var filesize = sendbuf.Length;
            
            
            BitConverter.GetBytes(filesize).CopyTo(packet_size_buffer, 0);
            
            client.GetStream().Write(packet_size_buffer, 0, PACKET_SIZE);
            client.GetStream().Write(sendbuf, 0, sendbuf.Length);

            client.GetStream().WriteTimeout = curtimeout;
        }
    }
    /** @} */
    /** @} */
    /** @} */
}
