//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#ifndef __SATES_OS_SIGNAL_HANDLER_H__
#define __SATES_OS_SIGNAL_HANDLER_H__

#include <sates/define.h>
#include <map>

namespace sates
{
namespace os
{

enum SIGNAL_NUMBER
{
    CTRL_C,
    SEG_FAULT
};

class SATES_EXPORT signal_handler
{
public:
    typedef void(*handler_func_t)(void);

    static void initialize();

    static void set_handler(SIGNAL_NUMBER signal_number,
        handler_func_t p_func);

    static handler_func_t get_handler(SIGNAL_NUMBER signal_number);

private:
    static std::map<uint32_t, handler_func_t> m_handler_map;
    static const uint32_t MAX_MAP_SIZE = 128;
};
}
}

#endif // __SATES_OS_SIGNAL_HANDLER_H__