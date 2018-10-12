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

#include <sates/os/mutex.h>
#include <iostream>
#include <pthread.h>

namespace sates
{
	namespace os
	{
		mutex::mutex()
		{
			if (pthread_mutex_init(&m_mutex_obj, NULL) != 0)
			{
				std::cerr << "mutex::mutex(), pthread_mutex_init Failure" << std::endl;
			}
		}

		mutex::~mutex()
		{
			pthread_mutex_destroy(&m_mutex_obj);
		}

		void mutex::lock()
		{
			if (pthread_mutex_lock(&m_mutex_obj) != 0)
			{
				std::cerr << "mutex::lock(), pthread_mutex_lock Failure" << std::endl;
			}
		}

		bool mutex::try_lock()
		{
			bool retval = false;
			if (pthread_mutex_trylock(&m_mutex_obj) == 0)
			{
				retval = true;
			}

			return retval;
		}

		void mutex::unlock()
		{
			if (pthread_mutex_unlock(&m_mutex_obj) != 0)
			{
				std::cerr << "mutex::unlock(), pthread_mutex_unlock Failure" << std::endl;
			}
		}
	}
}
