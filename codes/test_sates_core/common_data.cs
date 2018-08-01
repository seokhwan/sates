//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace TESTCODE
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup TESTCODE
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 28일 | DEFAULT_PATH 설정 | 김석환  |  사용자  |
    |2018년 7월 31일 | reflection 활용하여 default path 자동설정 | 김석환  |  사용자  |
     */

    /// <summary>
    /// 테스트에 필요한 일반적인 데이터를 저장한다.
    /// </summary>
    class common_data
    {
        public static string DEFAULT_PATH = System.Reflection.Assembly.GetExecutingAssembly().Location + "../../../../../";
    }
}
