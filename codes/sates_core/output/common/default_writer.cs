﻿//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using sates.core;

namespace sates.output.common
{
    /* write 들을 하나의 클래스로 모으기 write_delegate
     * writer 는 그 write 를 모든 클래스를 호출 (생성) 해서 사용하기 
     * 
     * /

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
    |2018년 10월 23일 | 최초작성 | 김석환  |  사용자  |
     */

    /// <summary>
    /// 일반적 문서를 생성한다.
    /// 
    /// @remark
    /// 
    /// </summary>
    class default_writer : sates.output.common.writer
    {
        public override void write(string root_path, doc doc, string lang_name)
        {
            common.write_helper helper = write_helper_factory.get(lang_name);
            System.IO.StreamWriter wr = helper.w00_create_dir_and_file(root_path, doc);

            helper.w01_namespace(wr, doc);
            
            helper.w02_group_begin(wr, doc);
            wr.WriteLine("    /**");

            helper.w03_info(wr, "revision", doc);
            helper.w03_info(wr, "title", doc);
            helper.w03_info(wr, "author", doc);
            helper.w03_info(wr, "date", doc);
            helper.w03_info(wr, "desc", doc);
            helper.w03_info(wr, "ret_spec", doc);
            helper.w03_info(wr, "ret_code", doc);


            wr.WriteLine("    */");
            helper.w04_class(wr, doc);
            helper.w99_ground_end(wr, doc);
            
            wr.Close();
        }
    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
