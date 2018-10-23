//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#ifndef __SATES_OS_SLEEP_H__
#define __SATES_OS_SLEEP_H__

#include <sates/define.h>

namespace sates
{
namespace os
{
    SATES_EXPORT void sleep(uint32_t micro_seconds);
}
}


#endif // __SATES_OS_SLEEP_H__