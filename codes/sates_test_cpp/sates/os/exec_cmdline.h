//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#ifndef __SATES_OS_EXEC_CMDLINE_H__
#define __SATES_OS_EXEC_CMDLINE_H__

#include <sates/define.h>
#include <string>

namespace sates
{
namespace os
{
class SATES_EXPORT exec_cmdline
{
public:
    exec_cmdline();
    ~exec_cmdline();
    void set_executable_path(const char_t* p_full_exe_path);
    void add_option(const char_t* p_option);
    void add_optional_string(const char_t* p_string);
    void clear_options();
    void generate_command_line();
    const char_t* get_command_line();
    const std::string* get_command_clink_string();

protected:
    std::string m_exec_path;
    std::string m_options;
    std::string m_str_cmd_line;
};
}
}


#endif // __SATES_OS_EXEC_CMDLINE_H__

