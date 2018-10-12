#include <sates/os/tcp_client.h>

namespace sates
{
	namespace os
	{
		tcp_client::tcp_client()
		{

		}

		tcp_client::~tcp_client()
		{

		}

		bool tcp_client::connect(const char_t* p_local_ip_addr, const char_t* p_remote_ip_addr, uint16_t remote_port)
		{
			return false;
		}

		int32_t tcp_client::read(int8_t* p_buffer, int32_t read_size)
		{
			return 0;
		}

		int32_t tcp_client::write(const int8_t* p_buffer, int32_t write_size)
		{
			return 0;
		}

		void close()
		{

		}
	}
}