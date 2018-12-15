#include <sates/report/reporter_factory.h>
#include <sates/report/reporter_local_json.h>

namespace sates
{
    namespace report
    {
        reporter* reporter_factory::create(REPORTER_TYPE reporter_type)
        {
            reporter* p_retval = nullptr;
            if (REPORTER_TYPE::LOCAL_JSON == reporter_type)
            {
                p_retval = new reporter_local_json();
            }
            return p_retval;
        }
    }
}
