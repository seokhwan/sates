#ifndef __SATES_UTIL_STRING_TRANSFER_H__
#define __SATES_UTIL_STRING_TRANSFER_H__

#include <sates/define.h>
#include <sates/os/tcp_client.h>
#include <string>

namespace sates
{
    namespace util
    {
        class SATES_EXPORT string_transfer
        {
        public:
            static void receive(sates::os::tcp_client* p_client, std::string& recvd_string);
            static void send(sates::os::tcp_client* p_client, const std::string& send_string);
        };
    }
}

#endif // __SATES_UTIL_STRING_TRANSFER_H__
