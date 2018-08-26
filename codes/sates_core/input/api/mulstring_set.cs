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
    /// mulstring_set 함수처리. 일반적인 multiline string 을 셋팅
    /// </summary>
    class mulstring_set
    {
        protected static void set(string uniqid, string infoname, string[] mulstring)
        {
            sates.core.doc_list.get(uniqid).set_info(infoname, mulstring);
        }
        public static string call (api_cmd cmd_data)
        {
            string[] mulstring = null;
            if (cmd_data.args.Length > 2)
            {
                mulstring = new string[cmd_data.args.Length - 2];
                for (int i = 2; i < cmd_data.args.Length; i++)
                {
                    mulstring[i - 2] = cmd_data.args[i];
                }
            }
            set(cmd_data.args[0], cmd_data.args[1], mulstring);
            return "OK";
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
