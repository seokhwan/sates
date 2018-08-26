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

namespace sates.input
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

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
     */

    /// <summary>
    /// api_cmd_parser 의 interface 를 따르며 json 파일을 파싱
    /// </summary>
    public class api_cmd_json_parser : api_cmd_parser
    {
        public override List<api_cmd> parse(System.IO.MemoryStream ms)
        {
            System.Runtime.Serialization.Json.DataContractJsonSerializer deserializer =
                new System.Runtime.Serialization.Json.DataContractJsonSerializer(typeof(List<api_cmd>));
            
            return (List<api_cmd>)deserializer.ReadObject(ms);
        }

        public override List<api_cmd> parse(string str)
        {
            List<api_cmd> retval = null;
            if (System.IO.File.Exists(str))
            {
                string filelines = System.IO.File.ReadAllText(str);
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Encoding.UTF8.GetBytes(filelines));
                retval = this.parse(ms);
                ms.Close();
            }
            else
            {
                retval = parse(new System.IO.MemoryStream(Encoding.UTF8.GetBytes(str)));
            }
            return retval;
        }
    }
    /** @} */
    /** @} */
    /** @} */
}
