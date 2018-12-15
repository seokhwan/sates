//------------------------------------------------------------------------------
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
    /** \addtogroup output
    *  @{
    */
    /** \addtogroup common
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
    |2018년 12월 14일 | sates.output.common 으로 namespace 변경 | 김석환  |  사용자  |
     */

    /// <summary>
    /// sates.output.cs.spec_writer 등, 문서 작성 클래스의 대표 interface
    /// </summary>
    abstract class writer
    {
        public abstract void write(string root_path, sates.core.doc doc, string lang_name);
    }
    /** @} */
    /** @} */
    /** @} */
}
