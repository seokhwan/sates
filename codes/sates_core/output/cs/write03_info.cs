//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace sates.output.cs
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
    /** \addtogroup cs
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
     */

    /// <summary>
    /// 문서 생성 기능 중 sates.core.info 의 작성을 담당한다.
    /// </summary>
    class write03_info
    {
        public static void write(System.IO.StreamWriter wr, string infoname, sates.core.doc doc)
        {
            var info_var = doc.get_info(infoname);
            if (null != info_var)
            {
                sates.output.custom.custom_info_writer writer = 
                    sates.output.custom.custom_info_writer_manager.get_writer(infoname);
                if (null == writer)
                {
                    if (sates.core.INFO_TYPE.SINGLE_LINE_STRING == info_var.info_type)
                    {
                        info_var.get(out string str);
                        wr.Write("    @");
                        wr.WriteLine(infoname);
                        wr.Write("    ");
                        wr.WriteLine(str);
                        wr.WriteLine();
                    }
                    else if (sates.core.INFO_TYPE.MULTI_LINE_STRING == info_var.info_type)
                    {
                        info_var.get(out Queue<string> strs);
                        wr.Write("    @");
                        wr.WriteLine(infoname);
                        wr.WriteLine();
                        foreach (var str in strs)
                        {
                            wr.Write("    ");
                            var tmp = str.Trim();
                            if (tmp.Length > 0)
                            {
                                wr.Write(str);
                                wr.WriteLine("\\n");
                            }
                            else
                            {
                                wr.WriteLine();
                                wr.WriteLine();
                            }
                        }
                        wr.WriteLine();
                    }
                    else if (sates.core.INFO_TYPE.DOUBLE == info_var.info_type)
                    {
                        info_var.get(out double val);
                        wr.Write("    @");
                        wr.WriteLine(infoname);
                        wr.Write("    ");
                        wr.WriteLine(val.ToString());
                        wr.WriteLine();
                    }
                    else if (sates.core.INFO_TYPE.LONG == info_var.info_type)
                    {
                        info_var.get(out long val);
                        wr.Write("    @");
                        wr.WriteLine(infoname);
                        wr.Write("    ");
                        wr.WriteLine(val.ToString());
                        wr.WriteLine();
                    }
                }
                else
                {
                    writer.write(wr, info_var);
                }
            }
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
