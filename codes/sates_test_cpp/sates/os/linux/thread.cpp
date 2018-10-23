//------------------------------------------------------------------------------
//
// Copyright 2018, SATES
// All rights reserved.
//
// Author: kim at seokhwan.net (Seokhwan Kim)
//
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met :
//
// 1. Redistributions of source code must retain the above copyright notice, 
// this list of conditions and the following disclaimer.
//
// 2. Redistributions in binary form must reproduce the above copyright notice, 
// this list of conditions and the following disclaimer in the documentation 
// and / or other materials provided with the distribution.
//
// 3. Neither the name of SATES nor the names of its 
// contributors may be used to endorse or promote products derived from this 
// software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
// IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE 
// ARE DISCLAIMED.IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE 
// LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR 
// CONSEQUENTIAL DAMAGES(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT(INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE 
// POSSIBILITY OF SUCH DAMAGE.
//
//------------------------------------------------------------------------------

#include <sates/os/thread.h>
#include <iostream>
#include <pthread.h>
#ifdef SATES_BSD
#include <pthread_np.h>
#endif
#include <sched.h>

namespace sates
{
	namespace os
	{

		struct posix_thread_param
		{
			uint32_t core_number;
			int32_t priority;
			thread::thread_func_ptr_t function_ptr;
			bool*   is_running;
			void*   p_user_param;
		};


		void* posix_thread_func(void* ptr)
		{
			// Thread 의 파라메터 가져오기.
			posix_thread_param* p_param = reinterpret_cast<posix_thread_param*>(ptr);

			// Priority 셋팅
			struct sched_param priority_params;
			priority_params.sched_priority = p_param->priority;
			pthread_setschedparam(pthread_self(), SCHED_FIFO, &priority_params);

			// Core 번호 셋팅
#ifdef SATES_BSD
			cpuset_t cpuset;
#else
			cpu_set_t cpuset;
#endif
			CPU_ZERO(&cpuset);
			CPU_SET(p_param->core_number, &cpuset);
			pthread_setaffinity_np(pthread_self(), sizeof(cpuset), &cpuset);

			p_param->function_ptr(p_param->p_user_param);

			delete p_param;
			return (NULL);
		}

		void exit_current_thread(int32_t exit_code)
		{
			void* retval = nullptr;
			pthread_exit(retval);
		}

		thread::thread()
		{
			m_p_thread = nullptr;
		}

		thread::~thread()
		{
			if (nullptr != m_p_thread)
			{
				pthread_t* pthread_ptr = (pthread_t*)m_p_thread;
				m_p_thread = nullptr;
				delete pthread_ptr;
			}
		}

		void thread::run(
			uint32_t core_number,
			int32_t priority,
			const char_t* p_thread_name,
			thread::thread_func_ptr_t p_func_ptr,
			void* p_user_param)
		{
			if (nullptr == m_p_thread)
			{
				m_p_thread = new pthread_t;
				posix_thread_param* p_thread_p_param = new posix_thread_param;
				p_thread_p_param->core_number = core_number;
				p_thread_p_param->priority = priority;
				p_thread_p_param->function_ptr = p_func_ptr;
				p_thread_p_param->p_user_param = p_user_param;

				pthread_create((pthread_t*)m_p_thread, NULL, posix_thread_func, p_thread_p_param);
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

			void* retval;
			pthread_join((*((pthread_t*)m_p_thread)), &retval);

			pthread_t* pthread_ptr = (pthread_t*)m_p_thread;
			m_p_thread = nullptr;
			delete pthread_ptr;
		}
	}
}
