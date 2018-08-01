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
    |2018년 8월 1일 | Cross Platform 에 공통되는 부분  | 김석환  |  사용
     */

    /// <summary>
    /// doxygen run 배치파일 생성. deps_xxx 디렉토리의 위치에 매우 의존적
    /// </summary>
    public abstract class doxyrun_gen_common
    {
        public static void doxyfilegen(string depts_common_path, string doxy_resource_path, string output_path, string out_dir)
        {
            doxy_resource_path = System.IO.Path.GetFullPath(doxy_resource_path);
            string doxyfile = doxy_resource_path + "/sates_doxy";
            var lines = System.IO.File.ReadAllLines(doxyfile);
            System.IO.StreamWriter wr = new System.IO.StreamWriter(output_path);

            wr.WriteLine("SET PLANTUML_JAR_PATH=" + depts_common_path 
                + sates.core.os_setting.DIR_SEPARATOR + "plantuml-1.2018.8"
                + sates.core.os_setting.DIR_SEPARATOR + "plantuml.jar");

            foreach (var line in lines)
            {
                wr.WriteLine(line);
            }
            wr.Close();

            System.IO.File.Copy(
                doxy_resource_path + "/sates_style.css",
                out_dir + "/sates_style.css",
                true);
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
