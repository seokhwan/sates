//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace TESTCODE.T01_UNIT
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup TESTCODE
    *  @{
    */
    /** \addtogroup T01_UNIT
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 8월 26일 | 기본적인 테스트 코드 작성 | 김석환  |  사용자  |
     */

    /// <summary>
    /// sates.core.gateway 클래스를 테스트한다.
    /// </summary>
    class TU_00005_FINDING_OS : sates.test.cs.testcode
    {
        public override void init()
        {
        }

        public override void run()
        {
            sates.core.OS_NAME _os;

            String curpath = System.IO.Path.GetFullPath(System.Reflection.Assembly.GetEntryAssembly().Location);

            if (curpath.Contains("\\"))
            {
                _os = sates.core.OS_NAME.WINDOWS;
            }
            else
            {
                _os = sates.core.OS_NAME.UBUNTU;
            }

            sates.test.cs.SATES.EQ(_os, sates.core.os_setting.OS);
        }

        public override void terminate()
        {
        }
    }
}
