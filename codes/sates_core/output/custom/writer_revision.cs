//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using sates.core;

namespace sates.output.custom
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup output
    *  @{
    */
    /** \addtogroup custom
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
     */

    /// <summary>
    /// revision 은 table 이기 때문에 멀티라인에 \\n 을 붙히지 않도록 한다.
    /// </summary>

    class writer_revision : custom_info_writer
    {
        public writer_revision()
        {
            info_name = "revision";
        }

        public override void write(StreamWriter wr, info info_var)
        {
            wr.Write("    @");
            wr.WriteLine("revision");
            if (sates.core.INFO_TYPE.SINGLE_LINE_STRING == info_var.info_type)
            {
                info_var.get(out string str);
                wr.Write("    ");
                wr.WriteLine(str);
            }
            else
            {
                info_var.get(out Queue<string> strs);
                foreach (var str in strs)
                {
                    wr.Write("    ");
                    wr.WriteLine(str);
                }
            }
            wr.WriteLine();
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
