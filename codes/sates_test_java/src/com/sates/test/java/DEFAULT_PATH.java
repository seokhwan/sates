package com.sates.test.java;

import java.io.File;

public class DEFAULT_PATH
{
    public static String get()
    {
        String curpath = null;
        try
        {
            curpath = DEFAULT_PATH.class.getProtectionDomain().getCodeSource().getLocation().getPath();
            int lastindex = curpath.lastIndexOf('/');
            curpath = curpath.substring(0, lastindex);

            curpath += "/../../";


            File a = new File(curpath);
            curpath = a.getCanonicalPath();
            curpath = curpath.replace('\\', '/');
        }
        catch (Exception e)
        {

        }

        return curpath;
    }
}
