//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sates.core
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup core
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
    |2018년 7월 30일 | remove 함수 추가  | 김석환  |  사용자  |
     */

    /// <summary>
    /// doc 클래스의 instance 를 관리
    /// </summary>
    public class doc_list
    {
        private static Hashtable docs = new Hashtable();

        public static void add(doc doc)
        {
            if (!docs.ContainsKey(doc.uniq_id))
            {
                docs.Add(doc.uniq_id, doc);
            }
            else
            {
                throw new Exception("doc's unique id is NOT unique");
            }
        }

        public static void remove(doc doc)
        {
            if (docs.ContainsKey(doc.uniq_id))
            {
                docs.Remove(doc.uniq_id);
            }
        }
        public static void remove(string uniq_id)
        {
            if (docs.ContainsKey(uniq_id))
            {
                docs.Remove(uniq_id);
            }
        }

        public static doc get(string uniq_id)
        {
            doc retval = null;
            if (docs.ContainsKey(uniq_id))
            {
                retval = (doc)(docs[uniq_id]);
            }
            return retval;
        }

        public static List<doc> get_list()
        {
            List<doc> retval = new List<doc>();
            foreach (var item in docs.Values)
            {
                retval.Add((doc)item);
            }
            return retval;
        }

        public static void cross_ref_gen()
        {
            foreach (doc item in docs.Values)
            {
                item.cross_ref_gen1();
            }

            foreach (doc item in docs.Values)
            {
                item.cross_ref_gen2();
            }
        }
    }
    /** @} */
    /** @} */
    /** @} */
}
