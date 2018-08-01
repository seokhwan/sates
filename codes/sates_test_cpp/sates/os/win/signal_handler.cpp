//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#include <sates/os/signal_handler.h>
#include <sates/os/constant.h>
#include <Windows.h>

namespace sates
{
namespace os
{
static PVOID g_win_api_vec_exception_handler = nullptr;
static bool b_is_os_signal_handler_init = false;

LONG WINAPI _win_api_vectored_exception_handler(
    EXCEPTION_POINTERS *ExceptionInfo)
{
    switch (ExceptionInfo->ExceptionRecord->ExceptionCode)
    {
    case EXCEPTION_ACCESS_VIOLATION:
        signal_handler::get_handler(
            sates::os::SIGNAL_NUMBER::SEG_FAULT)();
        break;
    case CONTROL_C_EXIT:
        signal_handler::get_handler(
            sates::os::SIGNAL_NUMBER::CTRL_C)();
        break;
    default:
        break;
    }

    return 0;
}

void signal_handler::initialize()
{
    if (!b_is_os_signal_handler_init)
    {
        b_is_os_signal_handler_init = true;
        g_win_api_vec_exception_handler = AddVectoredExceptionHandler(1,
            _win_api_vectored_exception_handler);
    }
}
}
}



