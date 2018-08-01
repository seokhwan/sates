//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#include <sates/os/sleep.h>
#include <Windows.h>

namespace sates
{
namespace os
{
void sleep(uint32_t micro_seconds)
{
    uint32_t millisec = 1;
    if (micro_seconds > 1000)
    {
        millisec = micro_seconds / 1000;
    }
    Sleep(millisec);
}
}
}

