#ifndef __SATES_API_CALLER_H__
#define __SATES_API_CALLER_H__

#include <sates/define.h>
#include <string>
#include <vector>

namespace sates
{
	class SATES_EXPORT api_caller
	{
    public:
        static void connect(const char_t* p_ip_addr, int32_t port);
        static std::string call(const char_t* p_funcname,
            const char_t* arg1 = nullptr,
            const char_t* arg2 = nullptr,
            const char_t* arg3 = nullptr,
            const char_t* arg4 = nullptr,
            const char_t* arg5 = nullptr,
            const char_t* arg6 = nullptr,
            const char_t* arg7 = nullptr,
            const char_t* arg8 = nullptr,
            const char_t* arg9 = nullptr,
            const char_t* arg10 = nullptr);
	};
}

#endif // __SATES_API_CALLER_H__
