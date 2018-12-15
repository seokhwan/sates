//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#ifndef __SATES_REPORT_REPORTER_LOCAL_JSON_H__
#define __SATES_REPORT_REPORTER_LOCAL_JSON_H__

#include <sates/report/reporter.h>
namespace sates
{
    namespace report
    {
        class SATES_EXPORT reporter_local_json : public reporter
        {
        public:
            virtual void report(const std::vector<std::string>& msg);
        protected:
        private:
        };
    }
}

#endif // __SATES_REPORT_REPORTER_LOCAL_JSON_H__
