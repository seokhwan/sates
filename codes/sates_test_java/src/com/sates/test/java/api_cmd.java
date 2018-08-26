package com.sates.test.java;

import java.util.LinkedList;
import java.util.List;

public class api_cmd
{
    public String api;
    public List<String> args;
    public List<String> reserved1;
    public List<String> reserved2;
    public List<String> reserved3;

    public api_cmd()
    {
        api = new String();
        args = new LinkedList<String>();
        reserved1 = new LinkedList<String>();
        reserved2 = new LinkedList<String>();
        reserved3 = new LinkedList<String>();
    }
}
