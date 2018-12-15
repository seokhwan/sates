#include <sates/report/reporter_local_json.h>
#include <sates/api_caller.h>

namespace sates
{
    namespace report
    {
        void reporter_local_json::report(const std::vector<std::string>& msg)
        {
            sates::api_caller::call(msg);
        }
    }
}
