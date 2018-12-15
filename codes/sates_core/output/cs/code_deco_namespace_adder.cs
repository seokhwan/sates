//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

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
    |2018년 12월 15일 | Revision 내용 생성 | 김석환  |  사용자  |
    */

    /// <summary>
    /// 코드 주석 내 참조하는 Unique ID 에 namespace 를 추가한다.
    /// </summary>
    public class code_deco_namespace_adder
    {
        private static Queue<string> ext_list = new Queue<string>();
        private static Queue<string> excluded_filename_pattern_list = new Queue<string>();
        private static void _resolve(string filename, string output_dir)
        {
            var fname = Path.GetFileName(filename);
            var lines = File.ReadAllLines(filename);

            string newfilename = output_dir + "/" + fname;

            StreamWriter wr = new StreamWriter(newfilename);

            foreach (var line in lines)
            {
                string writeline = line;
                var trimmed = line.Trim();
                if (trimmed.StartsWith("///"))
                {
                    var tokens = trimmed.Split(' ');
                    foreach (var token in tokens)
                    {
                        string class_name_candidate = token;
                        sates.core.doc doc_var = sates.core.doc_list.get(token);
                        string prefix = "";
                        bool need_to_fix = false;
                        if (null == doc_var)
                        {
                            // class 이름 앞에 *, -, # 등 다른 어떤 표기 / 문법 등을 위해
                            // 붙혔을 경우를 대비
                            prefix = token.Substring(0, 1);
                            class_name_candidate = token.Remove(0, 1);
                            doc_var = sates.core.doc_list.get(class_name_candidate);
                            if (null != doc_var)
                            {
                                need_to_fix = true;
                            }
                        }
                        if (null != doc_var)
                        {
                            string newstr = "";
                            foreach (var cat in doc_var.category_info)
                            {
                                newstr += cat;
                                newstr += ".";
                            }
                            newstr += class_name_candidate;
                            writeline = line.Replace(class_name_candidate, newstr);
                            if (need_to_fix)
                            {
                                writeline = writeline.Replace(prefix + newstr, prefix + " " + newstr);
                            }
                        }
                    }
                }
                wr.WriteLine(writeline);
            }
            wr.Close();
            wr.Dispose();
        }
        public static void add_extension(string ext)
        {
            ext_list.Enqueue(ext);
        }
        public static void add_exclusion_filename_pattern(string exclusion)
        {
            excluded_filename_pattern_list.Enqueue(exclusion);
        }
        public static void decorate(string root_path, string output_path)
        {
            try
            {
                if (!Directory.Exists(output_path))
                {
                    Directory.CreateDirectory(output_path);
                }
                var files = Directory.GetFiles(root_path, "*.*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    bool isrunnable = false;
                    string fileext = Path.GetExtension(file);

                    foreach (var ext in ext_list)
                    {
                        if (Path.GetExtension(file).Remove(0, 1) == ext)
                        {
                            isrunnable = true;
                            break;
                        }
                    }

                    if (isrunnable)
                    {
                        foreach (var pattern in excluded_filename_pattern_list)
                        {
                            if (file.Contains(pattern))
                            {
                                isrunnable = false;
                                break;
                            }
                        }
                    }

                    if (isrunnable)
                    {
                        _resolve(file, output_path);
                    }
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
