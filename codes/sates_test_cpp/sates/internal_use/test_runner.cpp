
#include <sates/internal_use/test_runner.h>
#include <sates/internal_use/common_func.h>
#include <sates/internal_use/test_log.h>
#include <sates/sates_test_cpp_deploy.h>
#include <algorithm>

namespace sates
{
	namespace internal_use
	{
        static sates::report::reporter* g_p_reporter = nullptr;

        static void report(testcode* p_code)
        {
            if (nullptr != g_p_reporter)
            {
                std::vector<std::string> func_call_vec;
                func_call_vec.push_back("test_result_set");
                func_call_vec.push_back(p_code->get_test_case_name());
                if (test_log::is_err_occurred())
                {
                    func_call_vec.push_back("FAILURE");
                    for (auto iter : p_code->get_err_log())
                    {
                        std::replace(iter.begin(), iter.end(), '\\', '/');
                        func_call_vec.push_back(iter);
                    }
                }
                else
                {
                    func_call_vec.push_back("OK");
                }

                g_p_reporter->report(func_call_vec);
            }
        }

		static void run_one_test_case(testcode* p_code)
		{
			test_log::start_new_test();

			p_code->init();
			p_code->run();
			p_code->terminate();
			if (test_log::is_err_occurred())
			{
				p_code->set_result(sates::TEST_RESULT::NG);
				// old syntax
				//for (std::vector<std::string>::iterator iter = test_log::get_accumulated_logs()->begin();
				//	iter != test_log::get_accumulated_logs()->end();
				//	iter++)
				//{
				//	p_code->add_err_log((*iter));
				//}

				for (auto iter : (*(test_log::get_accumulated_logs())))
				{
					p_code->add_err_log(iter);
				}
			}
			else
			{
				p_code->set_result(sates::TEST_RESULT::OK);
			}
            report(p_code);
		}

		static void run_inc_test(
			std::vector<std::string>* p_inc_list,
			std::map<std::string, sates::testcode*>* p_map)
		{
			// old syntax
			//for (std::vector<std::string>::iterator iter = p_inc_list->begin();
			//	iter != p_inc_list->end();
			//	iter++)
			//{
			//	run_one_test_case(p_map->find((*iter))->second);
			//}

			// new syntax
			for (auto iter : (*p_inc_list))
			{
				run_one_test_case(p_map->find(iter)->second);
			}
		}

		static void run_test_excpet_exc(
			std::vector<std::string>* p_exc_list,
			std::map<std::string, sates::testcode*>* p_map)
		{
			// old syntax
			//for (std::map<std::string, sates::testcode*>::iterator iter = p_map->begin();
			//	iter != p_map->end();
			//	iter++)
			//{
			//	if (!is_in_the_list(iter->first.c_str(), p_exc_list))
			//	{
			//		run_one_test_case(iter->second);
			//	}
			//}

			// new syntax
			for (auto iter : (*p_map))
			{
				if (!is_in_the_list(iter.first.c_str(), p_exc_list))
				{
					run_one_test_case(iter.second);
				}
			}
		}

		static void run_all_test(std::map<std::string, sates::testcode*>* p_map)
		{
			// old syntax
			//for (std::map<std::string, sates::testcode*>::iterator iter = p_map->begin();
			//	iter != p_map->end();
			//	iter++)
			//{
			//	run_one_test_case(iter->second);
			//}

			// new syntax
			for (auto iter : (*p_map))
			{
				run_one_test_case(iter.second);
			}
		}

		void test_runner::run(std::vector<std::string>* p_inc_list,
			std::vector<std::string>* p_exc_list,
			std::map<std::string, sates::testcode*>* p_map,
            sates::report::reporter* p_reporter)
		{
            g_p_reporter = p_reporter;

			if (p_inc_list->size() > 0U)
			{
				run_inc_test(p_inc_list, p_map);
			}
			else if (p_exc_list->size() > 0U)
			{
				run_test_excpet_exc(p_exc_list, p_map);
			}
			else
			{
				run_all_test(p_map);
			}
		}
	}
}



