using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using sates.core;

namespace sates.output.common
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
    /** \addtogroup common
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 12월 15일 | writer_helper 의 interface | 김석환  |  사용자  |
     */

    /// <summary>
    /// 각 item 별 내용을 write 하는 기능을 담당한다.
    /// </summary>
    class write_helper
    {
        /// <summary>
        /// 작성할 파일을 생성한다.
        /// </summary>
        public virtual StreamWriter w00_create_dir_and_file(string root_path, doc doc)
        {
            throw new NotImplementedException(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        /// <summary>
        /// 문서 생성 기능 중 namespace 작성을 담당한다.
        /// </summary>
        public virtual void w01_namespace(System.IO.StreamWriter wr, sates.core.doc doc)
        {
            throw new NotImplementedException(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// 문서 생성 group (doxygen 의 addtogroup 태그) 작성을 담당한다.
        /// </summary>
        public virtual void w02_group_begin(System.IO.StreamWriter wr, sates.core.doc doc)
        {
            if (null != doc.category_info)
            {
                foreach (var cat in doc.category_info)
                {
                    wr.Write("    /** \\addtogroup ");
                    wr.WriteLine(cat);
                    wr.WriteLine("    *  @{");
                    wr.WriteLine("    */");
                }
            }
            wr.WriteLine("");
        }
        /// <summary>
        /// 문서 생성 기능 중 sates.core.info 의 작성을 담당한다.
        /// </summary>
        public virtual void w03_info(System.IO.StreamWriter wr, string infoname, sates.core.doc doc)
        {
            var info_var = doc.get_info(infoname);
            if (null != info_var)
            {
                sates.output.custom.custom_info_writer writer =
                    sates.output.custom.custom_info_writer_manager.get_writer(infoname);
                if (null == writer)
                {
                    if (sates.core.INFO_TYPE.MULTI_LINE_STRING == info_var.info_type)
                    {
                        info_var.get(out Queue<string> strs);
                        wr.Write("    @");
                        wr.WriteLine(infoname);
                        wr.WriteLine();
                        foreach (var str in strs)
                        {
                            wr.Write("    ");
                            var tmp = str.Trim();
                            if (tmp.Length > 0)
                            {
                                _resolve_string_with_namespace(str, out string newval);
                                wr.Write(newval);
                                wr.WriteLine("\\n");
                            }
                            else
                            {
                                wr.WriteLine();
                                wr.WriteLine();
                            }
                        }
                        wr.WriteLine();
                    }
                    else if (sates.core.INFO_TYPE.DOUBLE == info_var.info_type)
                    {
                        info_var.get(out double val);
                        wr.Write("    @");
                        wr.WriteLine(infoname);
                        wr.Write("    ");
                        wr.WriteLine(val.ToString());
                        wr.WriteLine();
                    }
                    else if (sates.core.INFO_TYPE.LONG == info_var.info_type)
                    {
                        info_var.get(out long val);
                        wr.Write("    @");
                        wr.WriteLine(infoname);
                        wr.Write("    ");
                        wr.WriteLine(val.ToString());
                        wr.WriteLine();
                    }
                }
                else
                {
                    writer.write(wr, info_var);
                }
            }
        }

        /// <summary>
        /// 문서 생성 기능 중 클래스 작성을 담당한다.
        /// </summary>
        public virtual void w04_class(System.IO.StreamWriter wr, sates.core.doc doc)
        {
            wr.Write("    class ");
            wr.Write(doc.uniq_id);
            wr.WriteLine("{}");
        }

        /// <summary>
        /// 문서 생성 기능 중 group (doxygen 의 addtogroup tag) 를 close 하는 코드를 작성한다.
        /// </summary>
        public virtual void w99_ground_end(System.IO.StreamWriter wr, sates.core.doc doc)
        {
            throw new NotImplementedException(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
        
        protected virtual void _resolve_string_with_namespace(string input, out string newstr)
        {
            throw new NotImplementedException(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }
    }
}
