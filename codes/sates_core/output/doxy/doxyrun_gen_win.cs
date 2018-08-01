//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace sates.output.doxy
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup output
    *  @{
    */
    /** \addtogroup doxy
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 8월 1일 | 클래스 추가 | 김석환  |  사용자  |
     */

    /// <summary>
    /// doxygen run 배치파일 생성. Windows 환경 대응
    /// </summary>
    public abstract class doxyrun_gen_win
    {
        public static void generate(string deps_os_path, string deps_common_path, string out_dir, string doxy_resource_path)
        {
            deps_os_path = System.IO.Path.GetFullPath(deps_os_path);
            out_dir = System.IO.Path.GetFullPath(out_dir);
            string batname = out_dir + "\\doxyrun.bat";
            System.IO.StreamWriter wr = new System.IO.StreamWriter(batname);
            wr.WriteLine("SET PATH=%PATH%;" + deps_os_path + "\\graphviz-2.38\\bin");
            wr.WriteLine("SET GRAPHVIZ_DOT=" + deps_os_path + "\\graphviz-2.38\\bin\\dot.exe");
            wr.WriteLine("SET DOT_PATH=" + deps_os_path + "\\graphviz-2.38\\bin\\dot.exe");
            wr.WriteLine(deps_os_path + "\\doxygen-1.8.14\\doxygen.exe sates_doxy");
            wr.Close();

            string doxy_filename = out_dir + "\\sates_doxy";
            doxyrun_gen_common.doxyfilegen(deps_common_path, doxy_resource_path, doxy_filename, out_dir);
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
