package TEST.T01_UNIT;

public class TU_00003_MULTIPLICATION extends com.sates.test.java.testcode
{
    private com.sates.example.mul muler;

    public TU_00003_MULTIPLICATION()
    {
        super();
    }

    public void init()
    {
        try
        {
            muler = new com.sates.example.mul();
        }
        catch (Exception e)
        {

        }
    }

    public void run()
    {
        float a = 234.2F;
        float b = 352.8F;
        float result = muler.run(a, b);
        com.sates.test.java.SATES.FLOAT_NE(a * b, result);
    }

    public void terminate()
    {

    }
}
