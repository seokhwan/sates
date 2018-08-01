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
    /// 어떤 데이터를 저장한다. name 은 sates_doc (doxygen 스타일)
    /// 에서 @으로 시작하는 tag 이며, data 는 어떤 형태의 데이터든지
    /// 멀티라인 스트링 타입으로 저장한다.
    /// </summary>
    /// @ret_spec
    /// Almost All
    class item_data
    {
        public string name;
        public Queue<string> data;

        public item_data()
        {
            name = "";
            data = new Queue<string>();
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
