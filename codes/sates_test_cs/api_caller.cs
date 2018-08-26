using System;
using System.Collections.Generic;
using System.Text;

namespace sates.test.cs
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup test
    *  @{
    */
    /** \addtogroup cs
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 8월 26일 | call 함수가 결과를 리턴 하도록 수정 | 김석환  |  사용자  |
     */

    /// <summary>
    /// TCP / IP 소켓을 통해 json 커맨드를 보내 함수를 호출한다.
    /// </summary>
    public class api_caller
    {
        private static System.Net.Sockets.TcpClient client = new System.Net.Sockets.TcpClient();
        public static void connect(string ip_addr, int port)
        {
            if (!client.Connected)
            {
                client.Connect(ip_addr, port);
            }
        }
        public static string call(string funcname, params string[] args)
        {
            sates.input.api_cmd cmd = new input.api_cmd();
            cmd.api = funcname;

            cmd.args = new string[args.Length];
            for (int i=0; i<args.Length; i++)
            {
                cmd.args[i] = args[i];
            }

            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer =
                new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(List<sates.input.api_cmd>));

            List<sates.input.api_cmd> cmdlist = new List<sates.input.api_cmd>();
            cmdlist.Add(cmd);

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            serializer.WriteObject(ms, cmdlist);
            ms.Position = 0;
            System.IO.StreamReader sr = new System.IO.StreamReader(ms);

            string jsoncmd = sr.ReadToEnd();

            sates.util.string_transfer.send(client, jsoncmd, Encoding.UTF8);
            
            sates.util.string_transfer.receive(client,out string result, Encoding.UTF8);
            System.Console.WriteLine(result);
            return result;
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
