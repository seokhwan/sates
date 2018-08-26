using System;
using System.Collections.Generic;
using System.Text;

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
    |2018년 7월 30일 | run 함수 내, 테스트 결과 저장 루틴 추가 | 김석환  |  사용자  |
     */

    /// <summary>
    /// TCP / IP 소켓을 통해 json 커맨드 등을 수신
    /// </summary>
    public class testcode_list
    {
        static List<testcode> testcode_list_var = new List<testcode>();
        public delegate void basic_func_t();

        public static basic_func_t global_init_func = null;
        public static basic_func_t global_terminate_func = null;

        public static sates.test.cs.report.reporter reporter {get; set;}

        public static void create()
        {
            global_init_func?.Invoke();
        }

        public static void destroy()
        {
            global_terminate_func?.Invoke();
        }

        public static void add_testcode(testcode code)
        {
            testcode_list_var.Add(code);
        }

        public static testcode get_testcode(string test_case_name)
        {
            testcode retval = null;
            foreach (var item in testcode_list_var)
            {
                if(item.test_case_name == test_case_name)
                {
                    retval = item;
                    break;
                }
            }
            return retval;
        }

        public static void run()
        {
            
            foreach (var item in testcode_list_var)
            {
                SATES.CUR_ITEM = item;
                SATES.RESULT = TEST_RESULT.OK;

                Console.WriteLine("");
                Console.WriteLine("======================================================================");
                Console.WriteLine("TEST BEGIN : " + item.GetType().ToString());

                item.init();
                item.run();
                item.terminate();

                item.result = SATES.RESULT;

                Console.WriteLine("TEST END   : " + item.GetType().ToString());
                Console.WriteLine("======================================================================");
                Console.WriteLine("");

                sates.test.cs.test_result_reporter_josn.add_result(item);
            }
            string report_str = sates.test.cs.test_result_reporter_josn.get_report_string();
            reporter.report(report_str);
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
