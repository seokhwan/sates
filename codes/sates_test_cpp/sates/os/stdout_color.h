//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#ifndef __SATES_OS_STDOUT_COLOR_H__
#define __SATES_OS_STDOUT_COLOR_H__

#include <sates/define.h>
#include <string>

namespace sates
{
namespace os
{
enum CONSOLE_COLOR
{
    CONSOLE_COLOR_RED,
    CONSOLE_COLOR_GREEN,
    CONSOLE_COLOR_BLUE,
    CONSOLE_COLOR_BLACK,
    CONSOLE_COLOR_WHITE,
};

SATES_EXPORT void set_stdout_color(CONSOLE_COLOR text_color, CONSOLE_COLOR background_color);
SATES_EXPORT std::string get_stdout_color();
SATES_EXPORT void clear_stdout_color();
}   
}


#endif // __SATES_OS_STDOUT_COLOR_H__