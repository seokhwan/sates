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
    /// doc_add 커맨드 처리
    /// </summary>
    public class doc_add
    {
        protected static void set(string uniq_id, string doc_type, Queue<string> category_info)
        {
            sates.core.doc_factory.create(uniq_id, doc_type, category_info);
        }
        public static void set(api_cmd cmd_data)
        {
            Queue<string> category_info = null;
            if (cmd_data.args.Length > 2)
            {
                category_info = new Queue<string>();
                for (int i = 2; i < cmd_data.args.Length; i++)
                {
                    category_info.Enqueue(cmd_data.args[i]);
                }
            }
            set(cmd_data.args[0], cmd_data.args[1], category_info);
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
