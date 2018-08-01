//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sates.input.sates_doc
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
    /** \addtogroup sates_doc
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
     */

    /// <summary>
    /// File path 를 분석하여 category 정보를 추출한다.
    /// </summary>
    /// @ret_spec
    /// SDS_004_INPUT_SATES_DOC
    /// RF_0001_ADD_DOC_BY_TEXT_FILE
    class category
    {
        public static Queue<string> extract(string root_path, string filename)
        {
            Queue<string> retval = null;
            if (filename.StartsWith(root_path))
            {
                var relpath = filename.Substring(root_path.Length);
                var ret_cat = relpath.Split(sates.core.os_setting.DIR_SEPARATOR);

                retval = new Queue<string>();
                foreach(var item in ret_cat)
                {
                    if("" != item && 
                        Path.GetFileName(filename) != item)
                    {
                        retval.Enqueue(item);
                    }
                }
            }
            return retval;
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
