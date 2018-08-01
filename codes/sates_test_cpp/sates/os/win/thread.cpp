//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#include <sates/os/thread.h>
#include <iostream>

namespace sates
{
namespace os
{
void exit_current_thread(int32_t exit_code)
{
    ExitThread((DWORD)exit_code);
}

class thread_param
{
public:
    thread::thread_func_ptr_t p_func_ptr;
    void* p_func_param;
};

static DWORD WINAPI win_api_thread_func(LPVOID p_thread_param)
{
    thread_param* p_func_param =
        reinterpret_cast<thread_param*>(p_thread_param);

    (*(p_func_param->p_func_ptr))(p_func_param->p_func_param);
    delete p_func_param;
    return 0;
}

thread::thread()
{
    m_p_thread = nullptr;
}

thread::~thread()
{

}

void thread::run(
    uint32_t core_number,
    int32_t priority,
    const char_t* p_thread_name,
    thread::thread_func_ptr_t p_func_ptr,
    void* p_param)
{
    if (nullptr == m_p_thread)
    {
        m_is_exit = false;
        thread_param* p_thread_param = new thread_param;

        p_thread_param->p_func_ptr = p_func_ptr;
        p_thread_param->p_func_param = p_param;
        DWORD retval = 0;
        m_p_thread = CreateThread(NULL,
            0,
            win_api_thread_func,
            p_thread_param,
            0,
            &retval);

        SetThreadPriority(m_p_thread, priority);
    }
    else
    {
        std::cerr << "thread::run(), thread is already created" << std::endl;
    }
}


void thread::stop_and_join()
{
    m_mutex.lock();
    bool b_is_exit = m_is_exit;
    m_mutex.unlock();
    if (!b_is_exit)
    {
        WaitForSingleObject(m_p_thread, INFINITE);
    }
    CloseHandle(m_p_thread);
    m_p_thread = nullptr;
}
}
}
