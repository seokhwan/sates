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
    /// 문서 생성 기능 중 namespace 작성을 담당한다.
    /// </summary>
    class write01_namespace
    {
        public static void write(System.IO.StreamWriter wr, sates.core.doc doc)
        {
            wr.Write("namespace ");
            if (null != doc.category_info)
            {
                int loop_count = 0;
                foreach (var cat in doc.category_info)
                {
                    if (loop_count > 0)
                    {
                        wr.Write(".");
                    }
                    wr.Write(cat);
                    loop_count++;
                }
            }
            wr.WriteLine("");
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
