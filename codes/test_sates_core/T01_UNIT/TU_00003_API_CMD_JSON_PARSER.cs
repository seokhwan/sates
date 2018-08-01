//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

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
    |2018년 7월 31일 | sates.input.api_cmd 변경 대응 | 김석환  |  사용자  |
     */

    /// <summary>
    /// sates.input.api_cmd_json_parser 클래스를 테스트한다.
    /// </summary>
    class TU_00003_API_CMD_JSON_PARSER : sates.test.cs.testcode
    {
        public override void init()
        {
        }

        public override void run()
        {
            sates.input.api_cmd_json_parser parser = new sates.input.api_cmd_json_parser();
            var cmd = parser.parse(common_data.DEFAULT_PATH + "/resource/example/json_command/add_doc.json");

            sates.test.cs.SATES.EQ(cmd[0].api, "doc_add");
            sates.test.cs.SATES.EQ(cmd[0].args[0], "TEST_SPEC01");
            sates.test.cs.SATES.EQ(cmd[0].args[1], "spec");
            sates.test.cs.SATES.EQ(cmd[0].args[2], "cat1");
            sates.test.cs.SATES.EQ(cmd[0].args[3], "cat2");
            

            cmd = parser.parse(common_data.DEFAULT_PATH + "/resource/example/json_command/add_doc_multi.json");
            sates.test.cs.SATES.EQ(cmd[1].api, "doc_add");
            sates.test.cs.SATES.EQ(cmd[1].args[0], "TEST_SPEC02");
            sates.test.cs.SATES.EQ(cmd[1].args[1], "fmea");
            sates.test.cs.SATES.EQ(cmd[1].args[2], "cat01");
            sates.test.cs.SATES.EQ(cmd[1].args[3], "cat02");

            cmd = parser.parse(common_data.DEFAULT_PATH + "/resource/example/json_command/add_doc_multi.json");
            sates.test.cs.SATES.EQ(cmd[2].api, "doc_add");
            sates.test.cs.SATES.EQ(cmd[2].args[0], "TEST_SPEC03");
            sates.test.cs.SATES.EQ(cmd[2].args[1], "testcase");
            sates.test.cs.SATES.EQ(cmd[2].args[2], "cat001");
            sates.test.cs.SATES.EQ(cmd[2].args[3], "cat002");
        }

        public override void terminate()
        {
        }
    }
}
