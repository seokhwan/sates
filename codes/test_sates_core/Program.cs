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
        static void test_init()
        {
            sates.input.sates_doc.dir_reader.read(common_data.DEFAULT_PATH + "/docs/SPEC", "spec");
            sates.input.sates_doc.dir_reader.read(common_data.DEFAULT_PATH + "/docs/TESTCASE", "testcase");
            sates.input.sates_doc.dir_reader.read(common_data.DEFAULT_PATH + "/docs/FMEA", "fmea");
        }

        static void test_terminate()
        {
            if (System.IO.Directory.Exists(common_data.DEFAULT_PATH + "/outfiles"))
            {
                System.IO.Directory.Delete(common_data.DEFAULT_PATH + "/outfiles", true);
            }
            sates.output.filegen.generate(common_data.DEFAULT_PATH + "/outfiles");

            sates.output.filegen.generate(common_data.DEFAULT_PATH + "/outfiles");
            sates.output.cs.code_deco_namespace_adder.add_extension("cs");
            sates.output.cs.code_deco_namespace_adder.add_exclusion_filename_pattern("AssemblyInfo");
            sates.output.cs.code_deco_namespace_adder.add_exclusion_filename_pattern("TemporaryGeneratedFile");
            sates.output.cs.code_deco_namespace_adder.decorate(common_data.DEFAULT_PATH + "/codes", common_data.DEFAULT_PATH + "/outfiles/CODE");

            if (sates.core.OS_NAME.UBUNTU == sates.core.os_setting.OS)
            {
                sates.output.doxy.doxyrun_gen_ubuntu.generate(
                    null,
                    common_data.DEFAULT_PATH + "/deps_common",
                    common_data.DEFAULT_PATH + "/outfiles",
                    common_data.DEFAULT_PATH + "/resource/doxy");
            }
            else if (sates.core.OS_NAME.WINDOWS == sates.core.os_setting.OS)
            {
                sates.output.doxy.doxyrun_gen_win.generate(
                    common_data.DEFAULT_PATH + "/deps_win",
                    common_data.DEFAULT_PATH + "/deps_common",
                    common_data.DEFAULT_PATH + "/outfiles",
                    common_data.DEFAULT_PATH + "/resource/doxy");
            }
        }

        [Fact]
        static void mytest()
        {
            sates.core.os_setting.OS = sates.core.OS_NAME.WINDOWS;
            sates.test.cs.testcode_list.reporter =
                sates.test.cs.report.reporter_factory.create(sates.test.cs.report.REPORTER_TYPE.LOCAL_JSON);

            sates.test.cs.testcode_instances.create();

            sates.test.cs.testcode_list.global_init_func = test_init;
            sates.test.cs.testcode_list.global_terminate_func = test_terminate;

            sates.test.cs.testcode_list.create();
            sates.test.cs.testcode_list.run();
            sates.test.cs.testcode_list.destroy();
        }
    }
    /** @} */
    /** @} */
}
