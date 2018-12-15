//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#include <sates/testcode.h>
#include <iostream>
#include <cstring>

namespace sates
{
    testcode::testcode()
    {
        m_test_case_name = "";
        m_result = TEST_RESULT::INVALID;
    }

    testcode::~testcode() {}
    void testcode::init() {}
    void testcode::run() {}
    void testcode::terminate() {}

    void testcode::set_result(TEST_RESULT test_result)
    {
        m_result = test_result;
    }

    void testcode::add_err_log(const std::string& err_msg)
    {
        m_err_logs.push_back(err_msg);
    }

    const std::vector<std::string>& testcode::get_err_log() const
    {
        return m_err_logs;
    }

	TEST_RESULT testcode::get_result() const
	{
		return m_result;
	}

	const char_t* testcode::get_test_case_name() const
	{
		return m_test_case_name.c_str();
	}

	void testcode::print()
	{
		std::cout << std::endl;
		std::cout << std::endl;
		std::cout << "################################################################################" << std::endl;
		std::cout << "Test Case Name : " << m_test_case_name << std::endl;
		std::cout << "================================================================================" << std::endl;
		std::cout << "Test Result : ";
		if (TEST_RESULT::OK == m_result)
		{
			std::cout << "OK" << std::endl;
		}
		else if (TEST_RESULT::NG == m_result)
		{
			std::cout << "NG" << std::endl;
		}
		else
		{
			std::cout << "Not Tested" << std::endl;
		}
		if (TEST_RESULT::NG == m_result)
		{
			std::cout << "================================================================================" << std::endl;
			std::cout << "Failure Info : " << std::endl;
			for (auto iter : m_err_logs)
			{
				std::cout << iter << std::endl;
			}
		}
		std::cout << "################################################################################" << std::endl;
		
		std::cout << std::endl;
		std::cout << std::endl;
	}
}

