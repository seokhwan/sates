//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using sates.core;

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
    |2018년 10월 23일 | 최초작성 | 김석환  |  사용자  |
     */

    /// <summary>
    /// 일반적 문서를 생성한다.
    /// 
    /// @remark
    /// 
    /// </summary>
    class default_writer : sates.output.writer
    {
        public override void write(string root_path, doc doc)
        {
            System.IO.StreamWriter wr = write00_dir.write(root_path, doc);

            write01_namespace.write(wr, doc);
            wr.WriteLine("{");
            write02_group_begin.write(wr, doc);
            wr.WriteLine("    /**");

            write03_info.write(wr, "revision", doc);
            write03_info.write(wr, "title", doc);
            write03_info.write(wr, "author", doc);
            write03_info.write(wr, "date", doc);
            write03_info.write(wr, "desc", doc);
            write03_info.write(wr, "ret_spec", doc);
            write03_info.write(wr, "ret_code", doc);


            wr.WriteLine("    */");
            write04_class.write(wr, doc);
            write99_group_end.write(wr, doc);
            wr.WriteLine("}");
            wr.Close();
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
