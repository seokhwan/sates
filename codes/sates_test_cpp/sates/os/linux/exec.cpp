
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

#include <sates/os/exec.h>
#include <string>

namespace sates
{
	namespace os
	{
		void exec(
			exec_cmdline* p_cmdline,
			const char_t* p_std_out_file,
			const char_t* p_std_err_file)
		{
			p_cmdline->generate_command_line();
			std::string str_cmd_line = p_cmdline->get_command_line();
			str_cmd_line += " > ";
			str_cmd_line += p_std_out_file;
			str_cmd_line += " 2>";
			str_cmd_line += p_std_err_file;
			system(str_cmd_line.c_str());
		}
	}
}



