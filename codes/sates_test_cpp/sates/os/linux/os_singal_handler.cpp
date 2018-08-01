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

#include <sates/os_signal_handler.h>
#include <sates/os_constant.h>
#include <string.h>

#include <ucontext.h>
#include <execinfo.h>
#include <atomic>
#include <cxxabi.h>
#include <signal.h>

#include <iostream>

namespace sates {

void crit_err_hdlr(int sig_num, siginfo_t * info, void * ucontext)
{
    static int CallCnt = 0;
	static const int MAX_CALL_COUNT = 5;
	static const int MAX_ARRAY_SIZE = 50;

	static std::atomic_bool bNotFinish(false);

	while(bNotFinish == true);
	
	if(CallCnt < MAX_CALL_COUNT)
	{
		bNotFinish = true; 
		CallCnt++;
		std::cerr << "----------------------------------------\n" << std::endl;
		std::cerr << CallCnt << ") Segmentation Violation - Backtrace\n" << std::endl;
		std::cerr << "----------------------------------------\n" << std::endl;	
		void * array[MAX_ARRAY_SIZE];
		int size = backtrace(array, MAX_ARRAY_SIZE);

		char ** messages = backtrace_symbols(array, size);

		for (int i = 1; i < size && messages != NULL; ++i)
		{
			char *mangled_name = 0, *offset_begin = 0, *offset_end = 0;

			for (char *p = messages[i]; *p; ++p)
			{
				if (*p == '(')
				{
					mangled_name = p;
				}
				else if (*p == '+')
				{
					offset_begin = p;
				}
				else if (*p == ')')
				{
					offset_end = p;
					break;
				}
			}

			if (mangled_name && offset_begin && offset_end &&
				mangled_name < offset_begin)
			{
				*mangled_name++ = '\0';
				*offset_begin++ = '\0';
				*offset_end++ = '\0';

				int status;
				char * real_name = abi::__cxa_demangle(mangled_name, 0, 0, &status);

				if (status == 0)
				{
					std::cerr << "[bt]: (" << i << ") " << messages[i] << " : "
							  << real_name << "+" << offset_begin << offset_end
							  << std::endl;

				}
				else
				{
					std::cerr << "[bt]: (" << i << ") " << messages[i] << " : "
							  << mangled_name << "+" << offset_begin << offset_end
							  << std::endl;
				}
				free(real_name);
			}
			else
			{
				std::cerr << "[bt]: (" << i << ") ERROR" << messages[i] << std::endl;
			}
		}
		std::cerr << std::endl;

		free(messages);
		bNotFinish = false;
	}

	os_signal_handler::get_handler(
                sates::OS_SIGNAL::SEG_FAULT)();
}

void  ctrl_c_handler(int sig)
{
    os_signal_handler::get_handler(
            sates::OS_SIGNAL::CTRL_C)();
}

void os_signal_handler::initialize()
{
    signal(SIGINT, ctrl_c_handler);

    struct sigaction sigact;
    memset(&sigact, 0, sizeof(struct sigaction));

    sigact.sa_sigaction = crit_err_hdlr;
    sigact.sa_flags = SA_RESTART | SA_SIGINFO;

    sigaction(SIGSEGV, &sigact, (struct sigaction *)NULL);
}

}



