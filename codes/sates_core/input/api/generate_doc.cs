//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace sates.input.api
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
    /** \addtogroup api
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 8월 22일 | 최초작성 | 김석환  |  사용자  |
    |2018년 11월 10일 | 생성 전, resolve() 호출하도록 수정 | 김석환  |  사용자  |
     */

    /// <summary>
    /// 지정된 directory 에 documents 를 생성한다.
    /// 생성전, 모든 doc 의 resolve 를 호출한다.
    /// </summary>
    public class generate_doc
    {
        public static string call(api_cmd cmd_data)
        {
            sates.core.doc_list.cross_ref_gen();
            sates.output.common.filegen.generate(cmd_data.args[0], cmd_data.args[1]);
            return "OK";
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
