package com.sates.test.java;

import java.net.InetSocketAddress;
import java.net.Socket;
import java.net.SocketAddress;
import java.util.LinkedList;

public class api_caller
{
    private static Socket sock = new java.net.Socket();

    public static void connect(String ip_addr, int port)
    {
        try
        {
            if (!sock.isConnected())
            {
                SocketAddress endpt = new InetSocketAddress(ip_addr, port);
                sock.connect(endpt);;
            }
        }
        catch (Exception e)
        {

        }
    }

    public static String call(String funcname, String ... params)
    {
        LinkedList<api_cmd> cmds = new LinkedList<>();
        api_cmd cmd = new api_cmd();

        cmd.api = funcname;

        for (String param: params)
        {
            cmd.args.add(param);
        }

        cmds.add(cmd);

        string_transfer.send(sock, api_cmd_json.to_json_string(cmds), "UTF-8");
        String recvmsg = string_transfer.receive(sock, "UTF-8");
        System.out.println(recvmsg);
        return recvmsg;
    }

    public static String call(api_cmd cmd)
    {
        LinkedList<api_cmd> cmds = new LinkedList<>();
        cmds.add(cmd);

        string_transfer.send(sock, api_cmd_json.to_json_string(cmds), "UTF-8");
        String recvmsg = string_transfer.receive(sock, "UTF-8");
        System.out.println(recvmsg);
        return recvmsg;
    }
}
