#ifndef __SATES_TESTCODE_LIST_H__
#define __SATES_TESTCODE_LIST_H__

#include <sates/testcode.h>
#include <vector>

namespace sates
{
	class SATES_EXPORT testcode_list
	{
	public:
		static void create();
		static void destroy();
		static void add_testcode(testcode* p_code);
		static testcode* get_testcode(const char_t* p_test_case_name);
		
		static void include_testcode(const char_t* p_test_case_name);
		static void exclude_testcode(const char_t* p_test_case_name);

		static void run();
		static void print_result();
	};
}

#endif // __SATES_TESTCODE_LIST_H__

