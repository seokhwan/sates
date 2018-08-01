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
    |2018년 8월 1일 | chm, html 을 분리. 코드 품질 좋지 않음. 향 후, refactoring 필요 | 김석환  |  사용자  |
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
            string batname_chm = out_dir + "\\doxyrun_chm.bat";
            string batname_html = out_dir + "\\doxyrun_html.bat";
            System.IO.StreamWriter wr_chm = new System.IO.StreamWriter(batname_chm);
            wr_chm.WriteLine("SET PATH=%PATH%;" + deps_os_path + "\\graphviz-2.38\\bin");
            wr_chm.WriteLine("SET GRAPHVIZ_DOT=" + deps_os_path + "\\graphviz-2.38\\bin\\dot.exe");
            wr_chm.WriteLine("SET DOT_PATH=" + deps_os_path + "\\graphviz-2.38\\bin\\dot.exe");
            wr_chm.WriteLine(deps_os_path + "\\doxygen-1.8.14\\doxygen.exe sates_doxy_chm");
            wr_chm.Close();


            System.IO.StreamWriter wr_html = new System.IO.StreamWriter(batname_html);
            wr_html.WriteLine("SET PATH=%PATH%;" + deps_os_path + "\\graphviz-2.38\\bin");
            wr_html.WriteLine("SET GRAPHVIZ_DOT=" + deps_os_path + "\\graphviz-2.38\\bin\\dot.exe");
            wr_html.WriteLine("SET DOT_PATH=" + deps_os_path + "\\graphviz-2.38\\bin\\dot.exe");
            wr_html.WriteLine(deps_os_path + "\\doxygen-1.8.14\\doxygen.exe sates_doxy_html");
            wr_html.Close();

            string doxy_filename_chm = out_dir + "\\sates_doxy_chm";
            string doxy_filename_html = out_dir + "\\sates_doxy_html";
            doxyrun_gen_common.doxyfilegen(deps_common_path, doxy_resource_path, doxy_filename_chm, doxy_filename_html, out_dir);
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
