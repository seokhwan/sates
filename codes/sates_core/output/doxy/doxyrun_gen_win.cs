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
    |2018년 8월 13일 | Refactroing, 중복코드 삭제 | 김석환  |  사용자  |
     */

    /// <summary>
    /// doxygen run 배치파일 생성. Windows 환경 대응
    /// </summary>
    public abstract class doxyrun_gen_win
    {
        private static void generate_private(string deps_os_path, string deps_common_path, string out_dir, string doxy_resource_path, string file_ext)
        {
            deps_os_path = System.IO.Path.GetFullPath(deps_os_path);
            out_dir = System.IO.Path.GetFullPath(out_dir);

            System.IO.StreamWriter sw = new System.IO.StreamWriter(out_dir + "\\doxyrun_" + file_ext + ".bat");

            sw.WriteLine("SET PATH=%PATH%;" + deps_os_path + "\\graphviz-2.38\\bin");
            sw.WriteLine("SET GRAPHVIZ_DOT=" + deps_os_path + "\\graphviz-2.38\\bin\\dot.exe");
            sw.WriteLine("SET DOT_PATH=" + deps_os_path + "\\graphviz-2.38\\bin\\dot.exe");

            sw.WriteLine(deps_os_path + "\\doxygen-1.8.14\\doxygen.exe sates_doxy_" + file_ext);


            sw.Close();
        }
        public static void generate(string deps_os_path, string deps_common_path, string out_dir, string doxy_resource_path)
        {
            generate_private(deps_os_path, deps_common_path, out_dir, doxy_resource_path, "chm");
            generate_private(deps_os_path, deps_common_path, out_dir, doxy_resource_path, "html");

            doxyrun_gen_common.doxyfilegen(deps_common_path, doxy_resource_path, out_dir, "chm");
            doxyrun_gen_common.doxyfilegen(deps_common_path, doxy_resource_path, out_dir, "html");
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
