//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#ifndef __SATES_REPORT_REPORTER_FACTORY_H__
#define __SATES_REPORT_REPORTER_FACTORY_H__

#include <sates/report/reporter.h>

namespace sates
{
    namespace report
    {
        enum REPORTER_TYPE
        {
            LOCAL_JSON
        };
        class SATES_EXPORT reporter_factory
        {
        public:
            static reporter* create(REPORTER_TYPE reporter_type);
        };
    }
}

#endif // __SATES_REPORT_REPORTER_FACTORY_H__
