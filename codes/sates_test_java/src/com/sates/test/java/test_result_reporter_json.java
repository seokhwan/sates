package com.sates.test.java;


public class test_result_reporter_json
{
    public static void report(testcode tcode)
    {
        api_cmd cmd = new api_cmd();
        cmd.api = "test_result_set";

        cmd.args.add(tcode.test_case_name);

        if (TEST_RESULT.OK == tcode.result)
        {
            cmd.args.add("OK");
        }
        else
        {
            cmd.args.add("FAILURE");
        }
        for (String strerr: tcode.err_log)
        {
            cmd.args.add(strerr);
        }

        api_caller.call(cmd);
    }

}
