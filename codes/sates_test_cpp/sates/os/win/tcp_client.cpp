#include <sates/os/tcp_client.h>
#include <iostream>

#pragma comment(lib, "ws2_32")

namespace sates
{
namespace os
{

static void net_init()
{
	static bool is_init = false;
	if (!is_init)
	{
		is_init = true;
		WSADATA wsa_data;
		WORD ver_req = MAKEWORD(2, 2);
		int err = WSAStartup(ver_req, &wsa_data);
		if (0 != err)
		{
			WSACleanup();
			// exception
		}
	}
}

tcp_client::tcp_client()
{
	net_init();
	m_sock = INVALID_SOCKET;
}

tcp_client::~tcp_client()
{

}

bool tcp_client::connect(const char_t* p_local_ip_addr, const char_t* p_remote_ip_addr, uint16_t remote_port)
{
	bool retval = true;

	if (nullptr == p_local_ip_addr ||
		nullptr == p_remote_ip_addr)
	{
		retval = false;
	}

	if (INVALID_SOCKET == m_sock && retval)
	{
		addrinfo *result = nullptr;
		addrinfo hints;

		int iresult = 0;

		ZeroMemory(&hints, sizeof(hints));
		hints.ai_family = AF_UNSPEC;
		hints.ai_socktype = SOCK_STREAM;
		hints.ai_protocol = IPPROTO_TCP;

		char str_port_num[100];
		_itoa_s((int)remote_port, str_port_num, 100, 10);

		iresult = getaddrinfo(p_remote_ip_addr, str_port_num, &hints, &result);

		if (0 != iresult) 
		{
			// exception
			retval = false;
		}

		if (retval)
		{
			m_sock = socket(result->ai_family, result->ai_socktype, result->ai_protocol);
			if (INVALID_SOCKET == m_sock)
			{
				// exception
				retval = false;
			}
		}

		if (retval)
		{
			char tmp = 1;
			int32_t sockErr = setsockopt(m_sock, IPPROTO_TCP, TCP_NODELAY, &tmp, sizeof(int));
			if (0 != sockErr)
			{
				// exception
				retval = false;
			}
		}
		
		if (retval)
		{
			sockaddr_in my_addr;

			my_addr.sin_family = AF_INET;
			my_addr.sin_port = 0;
			my_addr.sin_addr.s_addr = inet_addr(p_local_ip_addr);

			iresult = bind(m_sock, (struct sockaddr *)&my_addr, sizeof(my_addr));
			if (0 != iresult)
			{
				// exception
				retval = false;
			}
		}
		
		if (retval)
		{
			iresult = ::connect(m_sock, result->ai_addr, (int)result->ai_addrlen);
			if (SOCKET_ERROR == iresult)
			{
				// exception
				retval = false;
			}
		}
	}
	else
	{
		retval = false;
	}
	return retval;
}

int32_t tcp_client::read(int8_t* p_buffer, int32_t read_size)
{
	int32_t accum_size = 0;

	if (read_size > 0)
	{
		do
		{
			int32_t cur_read_size = 0;
			cur_read_size = recv(
				m_sock, 
				reinterpret_cast<char*>(p_buffer + accum_size), 
				read_size - accum_size, 
				MSG_WAITALL);

			int sock_err_code = WSAGetLastError();
			if (0 == sock_err_code && cur_read_size > 0)
			{
				accum_size += cur_read_size;
			}
			else
			{
				if (sock_err_code != WSAETIMEDOUT)
				{
					if (SOCKET_ERROR == cur_read_size)
					{
						std::cout << "tcpClient::tcp_read : failed with error : " << sock_err_code << std::endl;
					}
					else
					{
						std::cout << "tcpClient::tcp_read : gracefully socket closed, error code : " << sock_err_code << std::endl;
					}
					accum_size = -1;
				}
			}
		} while (accum_size > 0 && accum_size != read_size);
	}
	return accum_size;
}

int32_t tcp_client::write(const int8_t* p_buffer, int32_t write_size)
{
	char tmp = 1;
	int32_t sockErr = setsockopt(m_sock, IPPROTO_TCP, TCP_NODELAY, &tmp, sizeof(int));
	if (0 != sockErr)
	{
		std::cout << "tcp_write, setsockopt failed with error : " << WSAGetLastError() << std::endl;
	}

	int32_t retVal = send(m_sock, reinterpret_cast<const char*>(p_buffer), write_size, 0);

	if (SOCKET_ERROR == retVal)
	{
		std::cout << "tcp_write failed with error : " << WSAGetLastError() << std::endl;
	}
	return retVal;
}

void tcp_client::close()
{
	if (INVALID_SOCKET != m_sock)
	{
		std::cout << "tcpClient::close_socket()" << std::endl;
		closesocket(m_sock);
		m_sock = INVALID_SOCKET;
	}
}

}
}

