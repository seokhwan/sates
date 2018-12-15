//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#ifndef __SATES_REPORT_REPORTER_H__
#define __SATES_REPORT_REPORTER_H__

#include <sates/define.h>
#include <string>
#include <vector>

namespace sates
{
    namespace report
    {
        class SATES_EXPORT reporter
        {
        public:
            virtual void report(const std::vector<std::string>& msg) = 0;
        protected:
        private:
        };
    }
}

#endif // __SATES_REPORT_REPORTER_H__
