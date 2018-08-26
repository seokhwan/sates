package com.sates.test.java;

public class SATES
{
    public static testcode CUR_ITEM;
    public static float FLOAT_EQ_THRESHOLD = 0.00001F;
    public static double DOUBLE_EQ_THRESHOLD = 0.00001;
    public static TEST_RESULT RESULT = TEST_RESULT.OK;

    private static void eval(Boolean val)
    {
        if (!val)
        {
            String errlog = String.format("FAIL, filename : %s, method name : %s, line : %d",
                    Thread.currentThread().getStackTrace()[3].getFileName(),
                    Thread.currentThread().getStackTrace()[3].getMethodName(),
                    Thread.currentThread().getStackTrace()[3].getLineNumber());

            CUR_ITEM.err_log.add(errlog);
            System.out.println(errlog);
            RESULT = TEST_RESULT.NG;
        }
    }


    public static Boolean TRUE(Boolean val)
    {
        eval(val);
        return val;
    }

    public static Boolean FALSE(Boolean val)
    {
        eval(!val);
        return !val;
    }

    public static Boolean EQ(Object val1, Object val2)
    {
        Boolean result = false;
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
            result = val1.equals(val2);
        }
        eval(result);
        return result;
    }

    public static Boolean NE(Object val1, Object val2)
    {
        Boolean result = false;
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
            result = !(val1.equals(val2));
        }

        eval(result);
        return result;
    }

    public static Boolean FLOAT_EQ(float val1, float val2)
    {
        Boolean result = (Math.abs(val1 - val2) < FLOAT_EQ_THRESHOLD);
        eval(result);
        return result;
    }

    public static Boolean FLOAT_NE(float val1, float val2)
    {
        Boolean result = (Math.abs(val1 - val2) < FLOAT_EQ_THRESHOLD);
        eval(!result);
        return result;
    }

    public static Boolean DOUBLE_EQ(double val1, double val2)
    {
        Boolean result = (Math.abs(val1 - val2) < DOUBLE_EQ_THRESHOLD);
        eval(result);
        return result;
    }

    public static Boolean DOUBLE_NE(double val1, double val2)
    {
        Boolean result = (Math.abs(val1 - val2) < DOUBLE_EQ_THRESHOLD);
        eval(!result);
        return result;
    }
}
