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
    /// 문서 생성 기능 중 output directory 생성을 담당한다.
    /// </summary>
    class write00_dir
    {
        public static System.IO.StreamWriter write(string root_path, sates.core.doc doc)
        {
            string cur_path = root_path;
            if (null != doc.category_info)
            {
                foreach (var dir in doc.category_info)
                {
                    cur_path += "/";
                    cur_path += dir;
                }
            }

            System.IO.Directory.CreateDirectory(cur_path);

            cur_path = cur_path + "/" + doc.uniq_id + ".cs";

            System.IO.StreamWriter wr = new System.IO.StreamWriter(cur_path);
            return wr;
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
