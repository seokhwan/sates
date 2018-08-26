package com.sates.test.java;

public abstract class testcode
{
    public TEST_RESULT result;
    public java.util.Queue<String> err_log;
    public String test_case_name;

    protected  testcode()
    {
        test_case_name = this.getClass().getName();
        int lastdot = test_case_name.lastIndexOf(".");
        int lastindex = test_case_name.length();
        test_case_name = test_case_name.substring(lastdot + 1,  lastindex);
        err_log = new java.util.ArrayDeque<>();
    }

    public abstract void init();
    public abstract void run();
    public abstract void terminate();
}
