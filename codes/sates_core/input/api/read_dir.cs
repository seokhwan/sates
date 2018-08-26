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
    |2018년 8월 15일 | 최초작성 | 김석환  |  사용자  |
     */

    /// <summary>
    /// 지정된 디렉토리를 읽어드린다.
    /// </summary>
    public class read_dir
    {
        protected static void set(string directory_path, string doc_name)
        {
            sates.input.sates_doc.dir_reader.read(directory_path, doc_name);
        }
        public static string call(api_cmd cmd_data)
        {
            if (cmd_data.args.Length >= 2)
            {
                set(cmd_data.args[0], cmd_data.args[1]);
            }
            else
            {
                // exception
            }
            return "OK";
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
