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

namespace sates.algorithm
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup algorithm
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
     */

    /// <summary>
    /// fmea 문서의 critical number 계산
    /// </summary>
    class fmea_critical_number : infogen
    {
        public fmea_critical_number()
        {
            doc_type = "fmea";
            info_name = "critical_number";
        }

        public override void gen(sates.core.doc doc)
        {
            // see https://www.iqasystem.com/news/risk-priority-number/
            //critical_number = severity * occurrence

            doc.get_info("severity").get(out long severity);
            doc.get_info("occurrence").get(out long occurrence);

            var critical_number = severity * occurrence;

            doc.get_info(info_name).set(critical_number);
        }
    }
    /** @} */
    /** @} */
    /** @} */
}
