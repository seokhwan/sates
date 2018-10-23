//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#ifndef __SATES_OS_EXEC_H__
#define __SATES_OS_EXEC_H__

#include <sates/os/exec_cmdline.h>
#include <string>

namespace sates
{
    namespace os
    {
        SATES_EXPORT void exec(
            exec_cmdline* p_cmdline,
            const char_t* p_std_out_file,
            const char_t* p_std_err_file);
    }
}

#endif // __SATES_OS_EXEC_H__