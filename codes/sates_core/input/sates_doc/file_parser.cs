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
    /// File 로 부터 @으로 시작하는 tag 및 내용을 추출한다.
    /// </summary>
    /// @ret_spec
    /// SDS_004_INPUT_SATES_DOC
    /// RF_0001_ADD_DOC_BY_TEXT_FILE
    class file_parser
    {
        public static Queue<item_data> parse(string filename)
        {
            Queue<item_data> retval = new Queue<item_data>();
            StreamReader file = new StreamReader(filename);
            string line = "";

            do
            {
                if (!line.StartsWith("@"))
                {
                    line = file.ReadLine();
                    if (null != line)
                    {
                        line = line.Trim();
                    }
                }
                if (null != line)
                {
                    if (line.StartsWith("@"))
                    {
                        line = line.Substring(1);
                        item_data item = new item_data
                        {
                            name = line
                        };

                        while (true)
                        {
                            line = file.ReadLine();
                            if (null == line)
                            {
                                break;
                            }
                            line = line.Trim();
                            if (!line.StartsWith("@"))
                            {
                                item.data.Enqueue(line);
                            }
                            else
                            {
                                break;
                            }
                        }

                        retval.Enqueue(item);
                    }
                }
            }
            while (null != line);

            return retval;
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
