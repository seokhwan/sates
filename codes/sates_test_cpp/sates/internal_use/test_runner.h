#ifndef __SATES_INTERNAL_USE_TEST_RUNNER_H__
#define __SATES_INTERNAL_USE_TEST_RUNNER_H__

#include <sates/testcode.h>
#include <sates/report/reporter.h>
#include <vector>
#include <string>
#include <map>

namespace sates
{
	namespace internal_use
	{
		class test_runner
		{
		public:
            static void run(std::vector<std::string>* p_inc_list,
                std::vector<std::string>* p_exc_list,
                std::map<std::string, sates::testcode*>* p_map,
                sates::report::reporter* p_reporter = nullptr);
		};
	}
}

#endif // __SATES_INTERNAL_USE_TEST_RUNNER_H__

