//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#include <sates/os/mutex.h>
#include <iostream>

namespace sates
{
namespace os
{
mutex::mutex()
{
    m_mutex_obj = CreateMutex(NULL, FALSE, NULL);
}

mutex::~mutex()
{
    CloseHandle(m_mutex_obj);
}

void mutex::lock()
{
    DWORD result = WaitForSingleObject(m_mutex_obj, INFINITE);
    if (WAIT_OBJECT_0 != result)
    {
        std::cerr << "mutex::lock(), WaitForSingleObject Failure" << std::endl;
    }
}

bool mutex::try_lock()
{
    DWORD result = WaitForSingleObject(m_mutex_obj, 0);
    bool retval;
    if (WAIT_OBJECT_0 == result)
    {
        retval = true;
    }
    else
    {
        retval = false;
    }
    return retval;
}

void mutex::unlock()
{
    BOOL retval = ReleaseMutex(m_mutex_obj);
    if (!retval)
    {
        std::cerr << "mutex::unlock(), ReleaseMutex Failure" << std::endl;
    }
}
}
}
