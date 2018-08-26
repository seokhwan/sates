//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace sates.input.api
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup input
    *  @{
    */
    /** \addtogroup api
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 31일 | 최초작성 | 김석환  |  사용자  |
     */

    /// <summary>
    /// test_result_set 함수처리
    /// </summary>
    public class test_result_set
    {
        protected static void set(string test_case_name, string result, string[] errlog)
        {
            sates.core.doc_list.get(test_case_name).set_info("test_result", result);
            sates.core.doc_list.get(test_case_name).set_info("test_fail_log", errlog);
        }
        public static string call(api_cmd cmd_data)
        {
            string[] errlog = null;
            if (cmd_data.args.Length > 2)
            {
                errlog = new string[cmd_data.args.Length - 2];
                for (int i=2; i<cmd_data.args.Length; i++)
                {
                    errlog[i - 2] = cmd_data.args[i];
                }
            }
            set(cmd_data.args[0], cmd_data.args[1], errlog);

            return "OK";
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
