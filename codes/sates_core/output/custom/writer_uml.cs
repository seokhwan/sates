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
    /// plantuml 지원을 위해 \@startuml, \@enduml 태그를 작성한다.
    /// </summary>
    class writer_uml : custom_info_writer
    {
        public writer_uml()
        {
            info_name = "uml";
        }

        public override void write(StreamWriter wr, info info_var)
        {
            wr.WriteLine("    @diag");
            wr.WriteLine("");
            wr.WriteLine("    @startuml");
            info_var.get(out Queue<string> strs);
            foreach (var str in strs)
            {
                wr.Write("    ");
                wr.WriteLine(str);
            }

            wr.WriteLine("    @enduml");
            wr.WriteLine();
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
