package com.sates.test.java;

import java.util.LinkedList;
import java.util.List;

public class testcode_list
{
    private static List<testcode> testcode_list_var = new LinkedList<>();
    public static basic_func_interface init_func;
    public static basic_func_interface terminate_func;


    public static void create()
    {
        init_func.call();
    }

    public static void destroy()
    {
        terminate_func.call();
    }

    public static void add_testcode(testcode code)
    {
        testcode_list_var.add(code);
    }

    public static testcode get_testcode(String testcase_name)
    {
        testcode retval = null;
        for (testcode code : testcode_list_var)
        {
            if(code.test_case_name == testcase_name)
            {
                retval = code;
                break;
            }
        }
        return retval;
    }

    public static void run()
    {
        for (testcode code : testcode_list_var)
        {
            SATES.CUR_ITEM = code;
            SATES.RESULT = TEST_RESULT.OK;

            System.out.println("");
            System.out.println("======================================================================");
            System.out.println("TEST BEGIN : " + code.getClass().getName());

            code.init();
            code.run();
            code.terminate();

            code.result = SATES.RESULT;

            System.out.println("TEST END   : " + code.getClass().getName());
            System.out.println("======================================================================");
            System.out.println("");

            test_result_reporter_json.report(code);
        }
    }
}
