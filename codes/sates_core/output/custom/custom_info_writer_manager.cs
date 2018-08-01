//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

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
    /// custom_info_writer 인스턴스의 메니저
    /// </summary>
    class custom_info_writer_manager
    {
        private static Hashtable writer_table = null;
        private static bool is_created = false;
        public static void create()
        {
            if(!is_created)
            {
                is_created = true;
                writer_table = new Hashtable();
                register_or_replace_custom_writer(new writer_uml());
                register_or_replace_custom_writer(new writer_revision());
            }
        }

        public static void register_or_replace_custom_writer(custom_info_writer custom_writer_val)
        {
            create();
            if (writer_table.ContainsKey(custom_writer_val.info_name))
            {
                writer_table.Remove(custom_writer_val.info_name);
            }
            writer_table.Add(custom_writer_val.info_name, custom_writer_val);
        }

        public static custom_info_writer get_writer(string info_name)
        {
            create();
            custom_info_writer retval = null;
            if (writer_table.ContainsKey(info_name))
            {
                retval= (custom_info_writer)writer_table[info_name];
            }
            return retval;
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
