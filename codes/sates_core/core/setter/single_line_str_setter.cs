﻿//------------------------------------------------------------------------------
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
    /// 데이터 타입이 한 줄 스트링인 info 데이터를 파싱
    /// </summary>
    class single_line_str_setter : setter
    {
        public override void set(string uniq_id, string info_name, Queue<string> info_data)
        {
            string singleline_str = "";
            foreach (var str in info_data)
            {
                if ("" != str)
                {
                    singleline_str = str;
                }
            }
            doc_list.get(uniq_id).set_info(info_name, singleline_str);
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}