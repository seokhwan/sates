#include <sates/api_caller.h>
#include <sates/os/tcp_client.h>
#include <sates/util/string_transfer.h>

#include <iostream>

namespace sates
{
    static os::tcp_client client;
    static std::string build_simple_json(const std::vector<std::string>& funcvec)
    {
        std::string retval;
        retval = "[\n";
        retval += "  {\n";
        retval += "    \"api\":\"";
        retval += funcvec[0U];
        retval += "\",\n";
        retval += "    \"args\":\n";
        retval += "    [\n";
        for (size_t i = 1U; i < funcvec.size(); ++i)
        {
            retval += "        \"";
            retval += funcvec[i];
            retval += "\"";

            if ((funcvec.size() - 1U) != i)
            {
                retval += ", ";
            }
            retval += "\n";
        }
        retval += "    ]\n";
        retval += "  }\n";
        retval += "]\n";

        std::cout << retval << std::endl;

        return retval;
    }
    static void puch_func_info(std::vector<std::string>& funcvec, const char_t* p_data)
    {
        if (nullptr != p_data)
        {
            funcvec.push_back(p_data);
        }
    }

    void api_caller::connect(const char_t* p_ip_addr, int32_t port)
    {
        if (!(client.is_connected()))
        {
            client.connect("127.0.0.1", p_ip_addr, (uint16_t)port);
        }
    }

    std::string api_caller::call(const char_t* p_funcname,
        const char_t* arg1,
        const char_t* arg2,
        const char_t* arg3,
        const char_t* arg4,
        const char_t* arg5,
        const char_t* arg6,
        const char_t* arg7,
        const char_t* arg8,
        const char_t* arg9,
        const char_t* arg10)
    {
        std::string retval = "OK";
        std::vector<std::string> funcvec;
        puch_func_info(funcvec, p_funcname);
        puch_func_info(funcvec, arg1);
        puch_func_info(funcvec, arg2);
        puch_func_info(funcvec, arg3);
        puch_func_info(funcvec, arg4);
        puch_func_info(funcvec, arg5);
        puch_func_info(funcvec, arg6);
        puch_func_info(funcvec, arg7);
        puch_func_info(funcvec, arg8);
        puch_func_info(funcvec, arg9);
        puch_func_info(funcvec, arg10);

        if (funcvec.size() == 0U)
        {
            retval = "Function name is not given";
        }

        auto cmd_string = build_simple_json(funcvec);

        sates::util::string_transfer::send(&client, cmd_string);
        sates::util::string_transfer::receive(&client, retval);

        return retval;
    }

    std::string api_caller::call(const std::vector<std::string>& call_info)
    {
        std::string retval = "OK";

        auto cmd_string = build_simple_json(call_info);

        sates::util::string_transfer::send(&client, cmd_string);
        sates::util::string_transfer::receive(&client, retval);

        return retval;
    }
}

