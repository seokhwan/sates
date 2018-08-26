package com.sates.test.java;

import java.net.Socket;
import java.nio.charset.Charset;

public class string_transfer
{
    protected static void to_byte_array_little_endian(int a, byte[] buf)
    {
        buf[3] = (byte) ((a >> 24) & 0xFF);
        buf[2] = (byte) ((a >> 16) & 0xFF);
        buf[1] = (byte) ((a >> 8) & 0xFF);
        buf[0] = (byte) (a & 0xFF);
    }

    protected static int to_int_little_endian(byte[] buf)
    {
        return (buf[3] & 0xff)<<24 | (buf[2] & 0xff)<<16 | (buf[1] & 0xff)<<8 | (buf[0] & 0xff);
    }

    public static void send(Socket sock, String send_str, String charset_name)
    {
        try
        {
            byte[] sendlenbuf = new byte[1024];
            byte[] bytes = send_str.getBytes(charset_name);
            to_byte_array_little_endian(bytes.length, sendlenbuf);

            sock.getOutputStream().write(sendlenbuf, 0, 1024);
            sock.getOutputStream().write(bytes, 0, bytes.length);
        }
        catch (Exception e)
        {
            System.out.println(e.toString());
        }
    }

    public static String receive(Socket sock, String charset_name)
    {
        String retval = null;
        try
        {
            byte[] recvlenbuf = new byte[1024];
            sock.getInputStream().read(recvlenbuf, 0, 1024);
            int recvlen = to_int_little_endian(recvlenbuf);
            byte[] bytes = new byte[recvlen];

            sock.getInputStream().read(bytes, 0, recvlen);

            retval=  new String(bytes, 0, recvlen);
        }
        catch (Exception e)
        {
            System.out.println(e.toString());
        }
        return retval;
    }
}
