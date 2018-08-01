//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#ifndef __SATES_OS_THREAD_H__
#define __SATES_OS_THREAD_H__

#include <sates/os/mutex.h>

namespace sates
{
namespace os
{
SATES_EXPORT void exit_current_thread(int32_t exit_code);

class SATES_EXPORT thread
{
public:
    typedef void(*thread_func_ptr_t)(void*);

    thread();
    ~thread();

    void run(
        uint32_t core_number, 
        int32_t priority, 
        const char_t* p_thread_name,
        thread_func_ptr_t p_func_ptr,
        void* p_user_param);

    void stop_and_join();

protected:
    static const size_t MAX_NAME_SIZE = 256;
    void* m_p_thread;
    bool m_is_exit;
    mutex m_mutex;
};
}
}

#endif // __SATES_OS_THREAD_H__

