//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.CompilerServices;


/** 
 * \defgroup test test
 * \defgroup cs cs
 */


namespace sates.test.cs
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup test
    *  @{
    */
    /** \addtogroup cs
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 30일 | EQ, NE 함수에 null 확인 부분 추가 | 김석환  |  사용자  |
     */

    /// <summary>
    /// 테스트에 필요한 필수적인 함수를 정의한다.
    /// </summary>
    public static class SATES
    {
        public static testcode CUR_ITEM;
        public static float FLOAT_EQ_THRESHOLD = 0.00001F;
        public static double DOUBLE_EQ_THRESHOLD = 0.00001;
        public static TEST_RESULT RESULT = TEST_RESULT.OK;

        private static bool is_warning_printed = false;

        private static void eval(bool val)
        {
            if (!val)
            {
                // DEBUG 모드에서만 출력이 잘됨.
                // RELEASE 모드에서는 출력 결과가 이상할 수 있음.
                string stack_msg = Environment.StackTrace;
                //Console.WriteLine(stack_msg);

                string[] lines = stack_msg.Split(
                    new[] { "\r\n", "\r", "\n" },
                    StringSplitOptions.None);

                int linenum = 3;

                string[] infos = lines[linenum].Split(
                    new[] { "at ", " in " },
                    StringSplitOptions.None);

                var method_name = infos[1];
                string line_spliter = ":line ";
                int index = infos[2].LastIndexOf(line_spliter);
                var filename = infos[2].Substring(0, index);
                var linenumber = infos[2].Substring(index + line_spliter.Length, infos[2].Length - (index + line_spliter.Length));

                RESULT = TEST_RESULT.NG;
#if !DEBUG
                if (!is_warning_printed)
                {
                    is_warning_printed = true;
                    Console.Write("Warning, in release build, the filaure method name and filname would be NOT correct");
                }
#endif
                string outstr = string.Format("FAIL, filename : {0}, method name : {1}, line : {2}",
                    filename, method_name, linenumber);
                CUR_ITEM.err_log.Enqueue(outstr);
                Console.WriteLine(outstr);
            }
        }

        public static bool TRUE(bool val)
        {
            eval(val);
            return val;
        }

        public static bool FALSE(bool val)
        {
            eval(!val);
            return !val;
        }

        public static bool EQ(object val1, object val2)
        {
            bool result = false;
            if (null == val1 || 
                null == val2)
            {
                if (null == val1 && 
                    null == val2)
                {
                    result = true;
                }
            }
            else
            {
                result = val1.Equals(val2);
            }
            eval(result);
            return result;
        }

        public static bool NE(object val1, object val2)
        {
            bool result = false;
            if (null == val1 ||
                null == val2)
            {
                if (val1 != val2)
                {
                    result = true;
                }
            }
            else
            {
                result = !(val1.Equals(val2));
            }

            eval(result);
            return result;
        }

        public static bool FLOAT_EQ(float val1, float val2)
        {
            bool result = (Math.Abs(val1 - val2) < FLOAT_EQ_THRESHOLD);
            eval(result);
            return result;
        }

        public static bool FLOAT_NE(float val1, float val2)
        {
            bool result = (Math.Abs(val1 - val2) < FLOAT_EQ_THRESHOLD);
            eval(!result);
            return result;
        }

        public static bool DOUBLE_EQ(double val1, double val2)
        {
            bool result = (Math.Abs(val1 - val2) < DOUBLE_EQ_THRESHOLD);
            eval(result);
            return result;
        }

        public static bool DOUBLE_NE(double val1, double val2)
        {
            bool result = (Math.Abs(val1 - val2) < DOUBLE_EQ_THRESHOLD);
            eval(!result);
            return result;
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
