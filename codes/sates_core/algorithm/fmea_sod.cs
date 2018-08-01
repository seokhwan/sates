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
    /// fmea 문서의 severity, occurrence, detection 계산
    /// </summary>
    class fmea_sod : infogen
    {
        public fmea_sod()
        {
            doc_type = "fmea";
            info_name = "sod";
        }

        public override void gen(sates.core.doc doc)
        {
            // see https://www.iqasystem.com/news/risk-priority-number/            
            //sod (Severity, Occurrence, Detection) = 100 * severity + 10 * occurrence + detection
            
            doc.get_info("severity").get(out long severity);
            doc.get_info("occurrence").get(out long occurrence);
            doc.get_info("detection").get(out long detection);
            
            var sod = 100 * severity + 10 * occurrence + detection;

            doc.get_info("sod").set(sod);
        }
    }
    /** @} */
    /** @} */
    /** @} */
}
