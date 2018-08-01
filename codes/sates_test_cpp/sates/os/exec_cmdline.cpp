//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#include <sates/os/exec_cmdline.h>

namespace sates
{
namespace os
{
exec_cmdline::exec_cmdline()
{
}

exec_cmdline::~exec_cmdline()
{
}

void exec_cmdline::set_executable_path(const char_t* p_full_exe_path)
{
    m_exec_path = p_full_exe_path;
}

void exec_cmdline::add_option(const char_t* p_option)
{
    m_options += ' ';
    m_options += '"';
    m_options += p_option;
    m_options += '"';
}

void exec_cmdline::add_optional_string(const char_t* p_string)
{
    if (nullptr != p_string)
    {
        m_str_cmd_line += p_string;
    }
}

void exec_cmdline::clear_options()
{
    m_options.clear();
}

void exec_cmdline::generate_command_line()
{
    m_str_cmd_line = m_exec_path;
    m_str_cmd_line += m_options;
}

const char_t* exec_cmdline::get_command_line()
{
    return m_str_cmd_line.c_str();
}

const std::string* exec_cmdline::get_command_clink_string()
{
    return &m_str_cmd_line;
}

}
}
