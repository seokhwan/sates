package TEST.T01_UNIT;

public class TU_00002_SUBTRACTION extends com.sates.test.java.testcode
{
    private com.sates.example.sub suber;

    public TU_00002_SUBTRACTION()
    {
        super();
    }

    public void init()
    {
        try
        {
            suber = new com.sates.example.sub();
        }
        catch (Exception e)
        {

        }
    }

    public void run()
    {
        float a = 234.2F;
        float b = 352.8F;
        float result = suber.run(a, b);
        com.sates.test.java.SATES.FLOAT_EQ(a - b, result);
    }

    public void terminate()
    {

    }
}
