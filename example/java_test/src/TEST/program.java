package TEST;

import com.sates.test.java.DEFAULT_PATH;
import com.sates.test.java.testcode_instances;
import com.sates.test.java.testcode_list;
import com.sates.test.java.api_caller;

public class program
{
    public static void main(String[] args)
    {
        testcode_list.init_func = ()->
        {
            System.out.println(DEFAULT_PATH.get());
            api_caller.connect("127.0.0.1", 5000);
            api_caller.call("read_dir", DEFAULT_PATH.get() + "/example/doc/SPEC", "spec");
            api_caller.call("read_dir", DEFAULT_PATH.get() + "/example/doc/TESTCASE", "testcase");
        };

        testcode_list.terminate_func = ()->
        {
            api_caller.call("generate_doc", DEFAULT_PATH.get() + "/example/javaout");
        };

        testcode_instances.create(program.class);

        testcode_list.create();
        testcode_list.run();
        testcode_list.destroy();
    }
}
