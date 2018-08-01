//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates/sates_test_cpp_deploy.h
//------------------------------------------------------------------------------

#include <sates/os/stdout_color.h>
#include <Windows.h>

namespace sates 
{
namespace os
{

void set_stdout_color(CONSOLE_COLOR text_color, CONSOLE_COLOR background_color)
{
    HANDLE h_stdout = GetStdHandle(STD_OUTPUT_HANDLE);

    int32_t _text_color = 0;
    int32_t _back_ground = 0;
    int32_t _text_color_intensity = FOREGROUND_INTENSITY;
    int32_t _back_ground_intensity = BACKGROUND_INTENSITY;
    switch (text_color)
    {
    case CONSOLE_COLOR_RED:
        _text_color = FOREGROUND_RED;
        break;
    case CONSOLE_COLOR_GREEN:
        _text_color = FOREGROUND_GREEN;
        break;
    case CONSOLE_COLOR_BLUE:
        _text_color = FOREGROUND_BLUE;
        break;
    case CONSOLE_COLOR_WHITE:
        _text_color = FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE;
        break;
    case CONSOLE_COLOR_BLACK:
        _text_color_intensity = 0;
        break;
    default:
        _text_color = 0;
        break;
    }

    switch (background_color)
    {
    case CONSOLE_COLOR_RED:
        _back_ground = BACKGROUND_RED;
        break;
    case CONSOLE_COLOR_GREEN:
        _back_ground = BACKGROUND_GREEN;
        break;
    case CONSOLE_COLOR_BLUE:
        _back_ground = BACKGROUND_BLUE;
        break;
    case CONSOLE_COLOR_WHITE:
        _back_ground = BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE;
        break;
    case CONSOLE_COLOR_BLACK:
        _back_ground_intensity = 0;
        break;
    default:
        _back_ground = 0;
        break;
    }

    if (INVALID_HANDLE_VALUE != h_stdout)
    {
        SetConsoleTextAttribute(h_stdout, _text_color | _back_ground |
            _text_color_intensity | _back_ground_intensity);
    }
}

std::string get_stdout_color()
{
    std::string retval = "";
    return retval;
}

void clear_stdout_color()
{

}

}
} // using namespace sates