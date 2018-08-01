//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#include <sates/os/signal_handler.h>
#include <iostream>
namespace sates
{
namespace os
{
std::map<uint32_t, signal_handler::handler_func_t>
    signal_handler::m_handler_map;

void signal_handler::set_handler(SIGNAL_NUMBER signal_number,
    handler_func_t p_func)
{
    std::map<uint32_t, signal_handler::handler_func_t>::iterator
        iter = m_handler_map.find(signal_number);

    if (m_handler_map.end() == iter)
    {
        m_handler_map[signal_number] = p_func;
    }
    else
    {
        std::cerr << "signal_handler::set_handler()" << std::endl;
        std::cerr << "handler is duplicated" << std::endl;
    }
}

signal_handler::handler_func_t
    signal_handler::get_handler(SIGNAL_NUMBER signal_number)
{
    signal_handler::handler_func_t retval = nullptr;
    std::map<uint32_t, signal_handler::handler_func_t>::iterator
        iter = m_handler_map.find(signal_number);

    if (m_handler_map.end() != iter)
    {
        retval = iter->second;
    }
    else
    {
        std::cerr << "signal_handler::get_handler()" << std::endl;
        std::cerr << "could not find a handler for the signal number" << std::endl;
    }
    return retval;
}
}
}



