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
    /// string 을 네트워크를 통해 교환하는 기능을 제공
    /// </summary>
    public class string_transfer
    {
        const int PACKET_SIZE = 1024;
        public static void receive(System.Net.Sockets.TcpClient client, out string recvd_string, Encoding enc)
        {
            recvd_string = "";
            byte[] buffer = new byte[PACKET_SIZE];
            int curtimeout = client.GetStream().ReadTimeout;
            // 타임아웃 10초 설정
            //client.GetStream().ReadTimeout = 10 * 1000;

            int recvsize = client.GetStream().Read(buffer, 0, PACKET_SIZE);
            if (PACKET_SIZE != recvsize)
            {
                throw new Exception("sates.util.string_transfer.receive(), packet recv failure");
            }

            var remained_size = BitConverter.ToInt32(buffer, 0);
            while (remained_size > 0)
            {
                if (remained_size > PACKET_SIZE)
                {
                    client.GetStream().Read(buffer, 0, PACKET_SIZE);
                    recvd_string += enc.GetString(buffer, 0, PACKET_SIZE);
                }
                else
                {
                    client.GetStream().Read(buffer, 0, remained_size);
                    recvd_string += enc.GetString(buffer, 0, remained_size);
                }

                remained_size = remained_size - PACKET_SIZE;
            }
        }
        public static void send(System.Net.Sockets.TcpClient client, string send_string, Encoding enc)
        {
            byte[] buffer = new byte[PACKET_SIZE];
            byte[] str_buffer = enc.GetBytes(send_string);

            BitConverter.GetBytes(str_buffer.Length).CopyTo(buffer, 0);
            int curtimeout = client.GetStream().WriteTimeout;

            client.GetStream().WriteTimeout = 10 * 1000;
            client.GetStream().Write(buffer, 0, PACKET_SIZE);

            client.GetStream().Write(str_buffer, 0, str_buffer.Length);

            client.GetStream().WriteTimeout = curtimeout;
        }
    }
}

