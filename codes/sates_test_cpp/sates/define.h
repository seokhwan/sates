//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#ifndef __SATES_DEFINE_H__
#define __SATES_DEFINE_H__

#ifdef _MSC_VER
#include <winsock2.h>
#include <ws2tcpip.h>
#include <Windows.h>
#define SATES_EXPORT __declspec(dllexport)
#pragma warning( disable : 4251 4996 )
typedef HANDLE           sates_mutex_t;
typedef SOCKET			 sates_sock_t;
#else
#include <ctime>
#include <fcntl.h>
#include <pthread.h>
#include <signal.h>
#include <unistd.h>
#include <sys/socket.h>
#include <sys/stat.h>
#include <sys/time.h>
#include <sys/types.h>
#include <sys/wait.h>

#define SATES_EXPORT
typedef pthread_mutex_t  sates_mutex_t;
typedef int			     sates_sock_t;

#endif

#include <cstddef>
#include <stdint.h>

#ifndef CHAR_T_DEFINED
typedef char               char_t;
#define CHAR_T_DEFINED
#endif

#ifndef UCHAR_T_DEFINED
typedef unsigned char      uchar_t;
#define UCHAR_T_DEFINED
#endif

#ifndef FLOAT32_T_DEFINED
typedef float              float32_t;
#define FLOAT32_T_DEFINED
#endif

#ifndef FLOAT64_T_DEFINED
typedef double             float64_t;
#define FLOAT64_T_DEFINED
#endif

#ifndef SATES_SAFE_DELETE
#define SATES_SAFE_DELETE(ptr) if (nullptr != ptr) {delete ptr;}
#endif 

#endif // __SATES_DEFINE_H__
