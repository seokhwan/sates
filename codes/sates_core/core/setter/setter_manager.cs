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
using System.Collections;

namespace sates.core.setter
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup core
    *  @{
    */
    /** \addtogroup setter
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
     */

    /// <summary>
    /// setter 관리 메니저
    /// </summary>
    class setter_manager
    {
        static Hashtable table = new Hashtable();
        static bool is_created = false;

        public static void set(string uniq_id, string info_name, Queue<string> info_data)
        {
            create();
            var setter_insance = (setter)table[guess.what(info_data)];
            setter_insance.set(uniq_id, info_name, info_data);
        }
        public static void create()
        {
            if (!is_created)
            {
                is_created = true;

                table.Add(INFO_TYPE.DOUBLE, new double_setter());
                table.Add(INFO_TYPE.LONG, new long_setter());
                table.Add(INFO_TYPE.MULTI_LINE_STRING, new mul_line_str_setter());
            }
        }
        public static void register_setter(setter setter_instance)
        {
            
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
