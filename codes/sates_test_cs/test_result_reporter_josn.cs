//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace sates.test.cs
{
    public class test_result_reporter_josn
    {
        private static List<sates.input.api_cmd> cmdlist = new List<input.api_cmd>();
        public static void add_result(testcode tcode)
        {
            sates.input.api_cmd cmd = new input.api_cmd();
            cmd.api = "test_result_set";

            cmd.args = new string[2 + tcode.err_log.Count];

            // 첫번째 파라메터, 테스트 케이스 이름 설정
            cmd.args[0] = tcode.test_case_name;
            

            // 두번째 파라메터, 테스트 결과 설정
            if (TEST_RESULT.OK == tcode.result)
            {
                cmd.args[1] = "OK";
            }
            else
            {
                cmd.args[1] = "FAILURE";
            }

            // 세번째 이후 에러로그 복사
            tcode.err_log.CopyTo(cmd.args, 2);
            
            cmdlist.Add(cmd);
        }

        public static string get_report_string()
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializer serializer =
                new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(List<sates.input.api_cmd>));

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            serializer.WriteObject(ms, cmdlist);
            ms.Position = 0;
            System.IO.StreamReader sr = new System.IO.StreamReader(ms);
            return sr.ReadToEnd();
        }
    }
}
