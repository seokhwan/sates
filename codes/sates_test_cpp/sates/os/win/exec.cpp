//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#include <sates/os/exec.h>
#include <Windows.h>

namespace sates
{
namespace os
{
static HANDLE _win_api_create_file(const char_t* p_filename)
{
    SECURITY_ATTRIBUTES sa;
    sa.nLength = sizeof(sa);
    sa.lpSecurityDescriptor = NULL;
    sa.bInheritHandle = TRUE;

    HANDLE hFile = CreateFileA(p_filename,
        FILE_WRITE_DATA,
        FILE_SHARE_WRITE | FILE_SHARE_READ,
        &sa,
        OPEN_ALWAYS,
        FILE_ATTRIBUTE_NORMAL,
        NULL);

    return hFile;
}

void exec(
    exec_cmdline* p_cmdline,
    const char_t* p_std_out_file,
    const char_t* p_std_err_file)
{
    DeleteFileA(p_std_out_file);
    DeleteFileA(p_std_err_file);


    HANDLE h_file_out = _win_api_create_file(p_std_out_file);
    HANDLE h_file_err = _win_api_create_file(p_std_err_file);

    PROCESS_INFORMATION pi;
    STARTUPINFOA si;
    BOOL ret = FALSE;
    DWORD flags = CREATE_NO_WINDOW;

    ZeroMemory(&pi, sizeof(PROCESS_INFORMATION));
    ZeroMemory(&si, sizeof(STARTUPINFO));
    si.cb = sizeof(STARTUPINFO);
    si.dwFlags |= STARTF_USESTDHANDLES;
    si.hStdInput = NULL;
    si.hStdOutput = h_file_out;
    si.hStdError = h_file_err;

    p_cmdline->generate_command_line();
    const char_t* p_cmdline_str = p_cmdline->get_command_line();
    char_t* p_cmdline_no_const = new char_t[strlen(p_cmdline_str) + 1];
    strcpy_s(p_cmdline_no_const, strlen(p_cmdline_str) + 1, p_cmdline_str);;

    ret = CreateProcessA(NULL, p_cmdline_no_const, NULL, NULL, TRUE, flags, NULL, NULL, &si, &pi);

    delete[] p_cmdline_no_const;

    HANDLE hProcess = OpenProcess(SYNCHRONIZE, TRUE, pi.dwProcessId);
    WaitForSingleObject(hProcess, INFINITE);


    if (ret)
    {
        CloseHandle(pi.hProcess);
        CloseHandle(pi.hThread);
    }

    FlushFileBuffers(h_file_out);
    FlushFileBuffers(h_file_err);

    CloseHandle(h_file_out);
    CloseHandle(h_file_err);
}
}
}



