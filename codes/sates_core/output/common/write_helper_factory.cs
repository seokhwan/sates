using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace sates.output.common
{
    class write_helper_factory
    {
        private static bool is_created = false;
        private static Hashtable table = new Hashtable();

        private static void create()
        {
            if(!is_created)
            {
                is_created = true;
                table["cs"] = new cs.write_helper();
                table["cpp"] = new cpp.write_helper();
            }
        }
        public static write_helper get(string langname)
        {
            write_helper_factory.create();
            if (table.ContainsKey(langname))
            {
                return (write_helper)(table[langname]);
            }
            else
            {
                throw new Exception("write_helper get() no item");
            }
        }
    }
}
