package TEST.T01_UNIT;

public class TU_00004_DIVISION extends com.sates.test.java.testcode
{
    private com.sates.example.div diver;

    public TU_00004_DIVISION()
    {
        super();
    }

    public void init()
    {
        try
        {
            diver = new com.sates.example.div();
        }
        catch (Exception e)
        {

        }
    }

    public void run()
    {
        float a = 234.2F;
        float b = 352.8F;
        float result = diver.run(a, b);
        com.sates.test.java.SATES.FLOAT_EQ(a / b, result);
    }

    public void terminate()
    {

    }
}
