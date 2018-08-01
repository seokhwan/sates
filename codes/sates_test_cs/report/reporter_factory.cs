using System;
using System.Collections.Generic;
using System.Text;

namespace sates.test.cs.report
{
    public enum REPORTER_TYPE
    {
        LOCAL_JSON
    }
    public class reporter_factory
    {
        public static reporter create(REPORTER_TYPE reporter_type)
        {
            reporter retval = null;
            if (REPORTER_TYPE.LOCAL_JSON == reporter_type)
            {
                retval = new reporter_local_json();
            }

            return retval;
        }
    }
}
