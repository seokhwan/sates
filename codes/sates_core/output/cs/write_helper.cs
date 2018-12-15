using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using sates.core;

namespace sates.output.cs
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
    /** \addtogroup cs
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 12월 15일 | C# 지원을 위해 생성 | 김석환  |  사용자  |
     */

    /// <summary>
    /// 각 item 별 내용을 write 하는 기능을 담당한다.
    /// </summary>
    class write_helper : common.write_helper
    {
        /// <summary>
        /// 작성할 파일을 생성한다.
        /// </summary>
        public override StreamWriter w00_create_dir_and_file(string root_path, doc doc)
        {
            string cur_path = root_path;
            if (null != doc.category_info)
            {
                foreach (var dir in doc.category_info)
                {
                    cur_path += "/";
                    cur_path += dir;
                }
            }

            System.IO.Directory.CreateDirectory(cur_path);

            cur_path = cur_path + "/" + doc.uniq_id + ".cs";

            System.IO.StreamWriter wr = new System.IO.StreamWriter(cur_path);
            return wr;
        }

        /// <summary>
        /// 문서 생성 기능 중 namespace 작성을 담당한다.
        /// </summary>
        public override void w01_namespace(System.IO.StreamWriter wr, sates.core.doc doc)
        {
            wr.Write("namespace ");
            if (null != doc.category_info)
            {
                int loop_count = 0;
                foreach (var cat in doc.category_info)
                {
                    if (loop_count > 0)
                    {
                        wr.Write(".");
                    }
                    wr.Write(cat);
                    loop_count++;
                }
            }
            wr.WriteLine("");
            wr.WriteLine("{");
        }

        /// <summary>
        /// 문서 생성 기능 중 group (doxygen 의 addtogroup tag) 를 close 하는 코드를 작성한다.
        /// </summary>
        public override void w99_ground_end(System.IO.StreamWriter wr, sates.core.doc doc)
        {
            if (null != doc.category_info)
            {
                foreach (var cat in doc.category_info)
                {
                    wr.WriteLine("    /** @} */");
                }
            }
            wr.WriteLine("");
            wr.WriteLine("}");
        }

        protected override void _resolve_string_with_namespace(string input, out string newstr)
        {
            newstr = "";
            var doc = sates.core.doc_list.get(input);
            if (null != doc)
            {
                foreach (var cat in doc.category_info)
                {
                    newstr += cat;
                    newstr += ".";
                }
            }
            newstr += input;
        }
    }
}
