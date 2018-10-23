#include <sates/util/string_transfer.h>

namespace sates
{
    namespace util
    {
        static const int32_t DEFAULT_PACKET_SIZE = 1024;
        void string_transfer::receive(sates::os::tcp_client* p_client, std::string& recvd_string)
        {
            static int8_t p_recv_buffer[DEFAULT_PACKET_SIZE];
            int32_t recv_size = 0;
            p_client->read(p_recv_buffer, DEFAULT_PACKET_SIZE);
            memcpy(&recv_size, p_recv_buffer, static_cast<int32_t>(sizeof(int32_t)));

            if (recv_size > 0)
            {
                int8_t* p_buffer = new int8_t[recv_size];
                p_client->read(p_buffer, recv_size);
                recvd_string.assign(reinterpret_cast<const char*>(p_buffer));
                delete[] p_buffer;
            }
        }

        void string_transfer::send(sates::os::tcp_client* p_client, const std::string& send_string)
        {
            static int8_t p_send_buffer[DEFAULT_PACKET_SIZE];
            int32_t send_size = static_cast<int32_t>(send_string.size());
            memcpy(p_send_buffer, &send_size, static_cast<int32_t>(sizeof(int32_t)));
            p_client->write(p_send_buffer, DEFAULT_PACKET_SIZE);
            p_client->write(reinterpret_cast<const int8_t*>(send_string.c_str()), send_size);
        }
    }
}
