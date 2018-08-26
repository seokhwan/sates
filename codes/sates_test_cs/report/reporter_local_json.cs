using System;
using System.Collections.Generic;
using System.Text;

namespace sates.test.cs.report
{
    public class reporter_local_json : reporter
    {
        private sates.input.api_cmd_json_parser parer = new input.api_cmd_json_parser();
        public override void report(string report_msg)
        {
            var cmdlist = parer.parse(report_msg);
            foreach (var cmd in cmdlist)
            {
                string result = sates.input.api.api_manager.call(cmd);
            }
        }
    }
}
