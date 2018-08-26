//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using Xunit;

namespace TESTCODE
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup TESTCODE
    *  @{
    */
    public class Program
    {
        static sates.input.api_cmd_server server;
        static void test_init()
        {
            server = new sates.input.api_cmd_server_json_tcpip();
            server.open("127.0.0.1", "50000");
            server.run();
            System.Threading.Thread.Sleep(1000);

            sates.test.cs.api_caller.connect("127.0.0.1", 50000);
            sates.test.cs.api_caller.call("read_dir", common_data.DEFAULT_PATH + "/docs/SPEC", "spec");
            sates.test.cs.api_caller.call("read_dir", common_data.DEFAULT_PATH + "/docs/TESTCASE", "testcase");
        }

        static void test_terminate()
        {
            if (System.IO.Directory.Exists(common_data.DEFAULT_PATH + "/outfiles"))
            {
                System.IO.Directory.Delete(common_data.DEFAULT_PATH + "/outfiles", true);
            }
            sates.test.cs.api_caller.call("generate_doc", common_data.DEFAULT_PATH + "/outfiles");
            sates.test.cs.api_caller.call("source_copy_csharp", common_data.DEFAULT_PATH + "/codes", common_data.DEFAULT_PATH + "/outfiles/CODE");


            if (sates.core.OS_NAME.UBUNTU == sates.core.os_setting.OS)
            {
                sates.test.cs.api_caller.call("generate_doxygen",
                    common_data.DEFAULT_PATH + "/deps_common",
                    common_data.DEFAULT_PATH + "/outfiles",
                    common_data.DEFAULT_PATH + "/resource/doxy");
            }
            else if (sates.core.OS_NAME.WINDOWS == sates.core.os_setting.OS)
            {
                sates.test.cs.api_caller.call("generate_doxygen",
                    common_data.DEFAULT_PATH + "/deps_win",
                    common_data.DEFAULT_PATH + "/deps_common",
                    common_data.DEFAULT_PATH + "/outfiles",
                    common_data.DEFAULT_PATH + "/resource/doxy");
            }
        }

        [Fact]
        static void mytest()
        {
            try
            {
                sates.test.cs.testcode_list.reporter =
                    sates.test.cs.report.reporter_factory.create(sates.test.cs.report.REPORTER_TYPE.LOCAL_JSON);

                sates.test.cs.testcode_instances.create();

                sates.test.cs.testcode_list.global_init_func = test_init;
                sates.test.cs.testcode_list.global_terminate_func = test_terminate;

                sates.test.cs.testcode_list.create();
                sates.test.cs.testcode_list.run();
                sates.test.cs.testcode_list.destroy();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }
    }
    /** @} */
    /** @} */
}
