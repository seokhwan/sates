//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sates.input.sates_doc
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
    /** \addtogroup sates_doc
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
     */

    /// <summary>
    /// 디렉토리 내 모든 파일에 대해서 file_reader 를 통해
    /// 모든 정보를 추출하여 저장한다.
    /// </summary>
    /// @ret_spec 
    /// SDS_004_INPUT_SATES_DOC
    /// RF_0001_ADD_DOC_BY_TEXT_FILE
    public class dir_reader
    {
        protected static void _read(string root_path, string cur_path, string doc_type)
        {
            string curdir;
            string curfile;
            try
            {
                foreach (string f in Directory.GetFiles(cur_path))
                {
                    curfile = f;
                    file_reader.read(root_path, f, doc_type);
                }

                foreach (string d in Directory.GetDirectories(cur_path))
                {
                    curdir = d;
                    dir_reader._read(root_path, d, doc_type);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
        /// <summary>
        /// root_path 의 모든 파일을 doc_type 타입의 문서로 읽는다.
        /// </summary>
        /// <param name="root_path">doc_type 에 해당하는 문서의 디렉토리 Path</param>
        /// <param name="doc_type">대소문자를 구분하지 않는다. 내부적으로 모두 소문자로 처리한다.</param>
        public static void read(string root_path, string doc_type)
        {
            string lowercase = doc_type.ToLower();
            _read(root_path, root_path, lowercase);
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
