//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#ifndef __SATES_OS_MUTEX_H__
#define __SATES_OS_MUTEX_H__

#include <sates/define.h>

namespace sates
{
namespace os
{
class SATES_EXPORT mutex
{
public:
    mutex();
    ~mutex();
    void lock();
    bool try_lock();
    void unlock();

protected:
    sates_mutex_t m_mutex_obj;
};
}
}

#endif // __SATES_OS_MUTEX_H__
