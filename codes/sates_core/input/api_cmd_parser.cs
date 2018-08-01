//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace sates.input
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

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 28일 | 최초 작성 | 김석환  |  사용자  |
     */

    /// <summary>
    /// 특정 파일 / 데이터 포멧을 파싱하여 command data 를 생성하는 대표 interface
    /// </summary>
    public abstract class api_cmd_parser
    {
        public abstract List<api_cmd> parse(string filepath);
        public abstract List<api_cmd> parse(string str, Encoding enc);
        public abstract List<api_cmd> parse(System.IO.MemoryStream ms);
    }
}
