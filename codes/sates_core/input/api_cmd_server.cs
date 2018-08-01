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
    |2018년 7월 28일 | 최초작성 | 김석환  |  사용자  |
     */

    /// <summary>
    /// 외부로부터 통신을 통해 api_cmd 자체를 수신하는 서버의 대표 interface
    /// </summary>
    abstract class api_cmd_server
    {
        public abstract void open(string addr1, string addr2 = null);
        public abstract void run();
        public abstract void close();
    }
}
