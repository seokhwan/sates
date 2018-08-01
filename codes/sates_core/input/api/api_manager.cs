//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

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
    /// sates.input.api_cmd 클래스를 파싱하여 api 함수를 실행한다.
    /// </summary>
    public class api_manager
    {
        private delegate void set_func_t(api_cmd cmd_data);
        private static Hashtable table = new Hashtable();
        private static bool is_created = false;
        public static void create()
        {
            if (!is_created)
            {
                is_created = true;
                table.Add("test_result_set", new set_func_t(test_result_set.set));
                table.Add("doc_add", new set_func_t(doc_add.set));
            }
        }

        public static void run(string api_name, api_cmd cmd_data)
        {
            create();
            if (table.ContainsKey(api_name))
            {
                set_func_t func = (set_func_t)table[api_name];
                func(cmd_data);
            }
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
