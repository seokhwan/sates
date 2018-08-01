//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace sates.output
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
    /// 문서 생성을 담당한다.
    /// </summary>
    public class filegen
    {
        private static System.Collections.Hashtable table = new System.Collections.Hashtable();
        private static bool is_created = false;
        public static void create()
        {
            if (!is_created)
            {
                table["fmea"] = new cs.fmea_writer();
                table["spec"] = new cs.spec_writer();
                table["testcase"] = new cs.testcase_writer();
            }
        }
        public static void generate(string root_dir_path)
        {
            create();
            foreach (var doc_item in sates.core.doc_list.get_list())
            {
                if (table.ContainsKey(doc_item.doc_type))
                {
                    writer wr = (writer)table[doc_item.doc_type];
                    wr.write(root_dir_path, doc_item);
                }
                else
                {
                    throw new Exception("unknown doc type");
                }
            }
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
