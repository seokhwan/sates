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
using System.Runtime.Serialization;

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
    |2018년 7월 31일 | api_cmd 로 클래스명 변경, 멤버를 general 한 API 디자인이 가능하도록 변경| 김석환  |  사용자  |
     */

    /// <summary>
    /// json 메시지 파싱을 하기 위한 data 클래스
    /// </summary>
    [DataContract]
    public class api_cmd
    {
        public api_cmd()
        {
        }

        //[DataMember(Name = "command")]
        [DataMember]
        public string api { get; set; }
        [DataMember]
        public string[] args { get; set; }
        [DataMember]
        public string[] reserved1 { get; set; }
        [DataMember]
        public string[] reserved2 { get; set; }
        [DataMember]
        public string[] reserved3 { get; set; }

        protected bool string_array_equals(string[] str1, string[] str2)
        {
            bool retval = true;
            if (null == str1 ||
                null == str2 )
            {
                if (str1 != str2)
                {
                    retval = false;
                }
            }
            else
            {
                if (str1.Length == str2.Length)
                {
                    for (int i=0; i<str1.Length; i++)
                    {
                        if(!str1[i].Equals(str2[i]))
                        {
                            retval = false;
                            break;
                        }
                    }
                }
                else
                {
                    retval = false;
                }
            }
            return retval;
        }

        public override bool Equals(Object rhs_obj)
        {
            api_cmd rhs = (api_cmd)(rhs_obj);
            
            if (api != rhs.api)
            {
                return false;
            }

            if (!string_array_equals(args, rhs.args))
            {
                return false;
            }

            if (!string_array_equals(reserved1, rhs.reserved1))
            {
                return false;
            }

            if (!string_array_equals(reserved2, rhs.reserved2))
            {
                return false;
            }

            if (!string_array_equals(reserved3, rhs.reserved3))
            {
                return false;
            }
            return true;
        }
    }
    /** @} */
    /** @} */
    /** @} */
}

