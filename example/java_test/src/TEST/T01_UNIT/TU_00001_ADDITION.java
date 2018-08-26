package TEST.T01_UNIT;

public class TU_00001_ADDITION extends com.sates.test.java.testcode
{
    private com.sates.example.add adder;

    public TU_00001_ADDITION()
    {
        super();
    }

    public void init()
    {
        try
        {
            adder = new com.sates.example.add();
        }
        catch (Exception e)
        {

        }
    }

    public void run()
    {
        float a = 234.2F;
        float b = 352.8F;
        float result = adder.run(a, b);
        com.sates.test.java.SATES.FLOAT_EQ(a + b, result);
    }

    public void terminate()
    {

    }
}
