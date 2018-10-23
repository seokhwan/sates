//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace sates.input.api
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup input
    *  @{
    */
    /** \addtogroup api
    *  @{
    */

    /**
    @revision
    |  Date | Log | Written by | Confirmed By | 
    |------------|------------|------------|------------|
    | 22b Aug 2018 | Drafted | Seokhwan Kim |  User |
     */

    /// <summary>
    /// It generates doxygen scripts from the given directories.
    /// </summary>
    public class generate_doxygen
    {
        protected static void common_routine(string outpath)
        {
            sates.output.filegen.generate(outpath);
        }
        protected static void set(string[] dirpath)
        {
            if (sates.core.OS_NAME.UBUNTU == sates.core.os_setting.OS)
            {
                common_routine(dirpath[1]);
                sates.output.doxy.doxyrun_gen_ubuntu.generate(
                    null,
                    dirpath[0],
                    dirpath[1],
                    dirpath[2]);
            }
            else if (sates.core.OS_NAME.WINDOWS == sates.core.os_setting.OS)
            {
                common_routine(dirpath[2]);
                sates.output.doxy.doxyrun_gen_win.generate(
                    dirpath[0],
                    dirpath[1],
                    dirpath[2],
                    dirpath[3]);
            }
        }
        public static string call(api_cmd cmd_data)
        {
            if (cmd_data.args.Length >= 2)
            {
                set(cmd_data.args);
            }
            else
            {
                // exception
            }
            return "OK";
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
