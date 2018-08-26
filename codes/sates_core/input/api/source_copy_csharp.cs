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
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 8월 22일 | 최초작성 | 김석환  |  사용자  |
     */

    /// <summary>
    /// 지정된 directory 에 source 를 copy
    /// </summary>
    public class source_copy_csharp
    {
        public static string call(api_cmd cmd_data)
        {
            sates.output.cs.code_deco_namespace_adder.add_extension("cs");
            sates.output.cs.code_deco_namespace_adder.add_exclusion_filename_pattern("AssemblyInfo");
            sates.output.cs.code_deco_namespace_adder.add_exclusion_filename_pattern("TemporaryGeneratedFile");
            sates.output.cs.code_deco_namespace_adder.decorate(cmd_data.args[0], cmd_data.args[1]);

            return "OK";
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
