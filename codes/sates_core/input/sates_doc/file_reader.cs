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
    /// category 및 file_parser 를 활용하여 하나의 파일을 읽는다.
    /// </summary>
    /// @ret_spec
    /// -SDS_004_INPUT_SATES_DOC
    /// *RF_0001_ADD_DOC_BY_TEXT_FILE
    /// - RF_0001_ADD_DOC_BY_TEXT_FILE
    class file_reader
    {
        public static void read(string root_path, string filename, string doc_type)
        {
            Queue<string> cat_info = new Queue<string>();
            cat_info.Enqueue("DOC");
            cat_info.Enqueue(doc_type.ToUpper());
            var cat_info_tmp = category.extract(root_path, filename);
            foreach(var cat_name in cat_info_tmp)
            {
                cat_info.Enqueue(cat_name);
            }
            var uniq_id = Path.GetFileNameWithoutExtension(filename);

            core.doc_factory.create(uniq_id, doc_type, cat_info);
            
            var items = file_parser.parse(filename);
            foreach(var item in items)
            {
                core.setter.setter_manager.set(uniq_id, item.name, item.data);
            }
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
