﻿//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace sates.output.common
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup common
    *  @{

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
        private const string DEFAULT_GEN_NAME = "default";
        private static System.Collections.Hashtable table = new System.Collections.Hashtable();
        private static bool is_created = false;
        public static void create()
        {
            if (!is_created)
            {
                table["fmea"] = new common.fmea_writer();
                table["spec"] = new common.spec_writer();
                table["testcase"] = new common.testcase_writer();
                table[DEFAULT_GEN_NAME] = new common.default_writer();
                is_created = true;
            }
        }
        public static void generate(string langname, string root_dir_path)
        {
            create();
            foreach (var doc_item in sates.core.doc_list.get_list())
            {
                string doc_type;
                if (table.ContainsKey(doc_item.doc_type))
                {
                    doc_type = doc_item.doc_type;
                }
                else
                {
                    doc_type = DEFAULT_GEN_NAME;
                }

                writer wr = (writer)table[doc_type];
                wr.write(root_dir_path, doc_item, langname);
            }
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
