//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace sates.core.setter
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
    /** \addtogroup setter
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
     */

    /// <summary>
    /// 데이터 타입이 명시적으로 지정되지 않은 경우, 이의 타입을 판단
    /// </summary>
    class guess
    {
        public static INFO_TYPE what(Queue<string> val)
        {
            INFO_TYPE retval = INFO_TYPE.INVALID;
            int string_line_cnt = 0;
            foreach (var line in val)
            {
                string trimmed_line = line.Trim();
                if (trimmed_line.Length > 0)
                {
                    string_line_cnt++;
                }
            }

            // if the string with more than one valid lines,
            // it shall be a multiline string
            if (string_line_cnt > 1)
            {
                retval = INFO_TYPE.MULTI_LINE_STRING;
            }

            if (INFO_TYPE.INVALID == retval)
            {
                string_line_cnt = 0;
                string trimmed_line = "";
                foreach (var line in val)
                {
                    trimmed_line = line.Trim();
                    if (trimmed_line.Length > 0)
                    {
                        break;
                    }
                }

                // double.TryParse can parse both long and double.
                // Thus, it tries long type first.
                if (long.TryParse(trimmed_line, out long long_result))
                {
                    retval = INFO_TYPE.LONG;
                }
                // and then, it tries double
                else if (double.TryParse(trimmed_line, out double double_result))
                {
                    retval = INFO_TYPE.DOUBLE;
                }
                // otherwise, it shall be a string
                else
                {
                    retval = INFO_TYPE.SINGLE_LINE_STRING;
                }
            }

            return retval;
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
