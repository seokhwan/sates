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

namespace sates.core
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

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
     */

    /// <summary>
    /// doc 클래스의 인스턴스를 생성
    /// </summary>
    public class doc_factory
    {
        public static void create(string uniq_id, string doc_type, Queue<string> category_info = null)
        {
            doc_list.remove(uniq_id);
            doc doc_instance = new doc(uniq_id, doc_type);
            doc_instance.category_info = category_info;
            doc_list.add(doc_instance);
        }
    }
    /** @} */
    /** @} */
    /** @} */
}
