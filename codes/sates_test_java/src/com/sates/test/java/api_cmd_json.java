package com.sates.test.java;

import java.util.List;
import java.util.Queue;

public class api_cmd_json
{
    protected static String get_line_pair(String  tag, String  val)
    {
        return ("\"" + tag + "\":\"" + val + "\"");
    }

    protected static String get_multiline(String default_indent, String  tag, List<String> val)
    {
        String retval = default_indent;
        retval += "\"" + tag + "\":";

        int argsize = val.size();
        if (argsize > 0)
        {
            retval += System.lineSeparator();
            retval += (default_indent + "[");
            retval += System.lineSeparator();
            for (int i=0; i<argsize ; i++)
            {
                retval += (default_indent + "    \"" + val.get(i) + "\"");
                if ((argsize - 1) != i) {
                    retval += ",";
                }
                retval += System.lineSeparator();
            }
            retval += (default_indent + "]");
        }
        else
        {
            retval += "null";
        }

        return retval;
    }

    public static String to_json_string(List<api_cmd> cmds)
    {
        String retval = "[" + System.lineSeparator();

        int listsize = cmds.size();
        for (int i=0; i<listsize; i++)
        {
            api_cmd cmd = cmds.get(i);
            retval += ("    {" + System.lineSeparator());

            retval += ("        " + get_line_pair("api", cmd.api ));
            retval += ("," + System.lineSeparator());


            retval += get_multiline("        ","args", cmd.args);
            retval += ("," + System.lineSeparator());
            retval += get_multiline("        ","reserved1", cmd.reserved1);
            retval += ("," + System.lineSeparator());
            retval += get_multiline("        ","reserved2", cmd.reserved2);
            retval += ("," + System.lineSeparator());
            retval += get_multiline("        ","reserved3", cmd.reserved3);
            retval += System.lineSeparator();

            if ((listsize -1) == i)
            {
                retval += ("    }" + System.lineSeparator());
            }
            else
            {
                retval += ("    }," + System.lineSeparator());
            }
        }

        retval += "]";
        return retval;
    }
}
