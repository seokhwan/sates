//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#ifndef __SATES_OS_TCP_CLIENT_H__
#define __SATES_OS_TCP_CLIENT_H__

#include <sates/define.h>

namespace sates
{
	namespace os
	{
		class SATES_EXPORT tcp_client
		{
		public:
			tcp_client();
			~tcp_client();

			bool connect(const char_t* p_local_ip_addr, const char_t* p_remote_ip_addr, uint16_t remote_port);
			int32_t read(int8_t* p_buffer, int32_t read_size);
			int32_t write(const int8_t* p_buffer, int32_t write_size);
			void close();

		protected:
			sates_sock_t m_sock;
		};
	}
}

#endif // __SATES_OS_TCP_CLIENT_H__

