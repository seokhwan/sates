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

namespace sates.algorithm
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup algorithm
    *  @{
    */

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
     */

    /// <summary>
    /// infogen 클래스의 instance 관리 메니저
    /// </summary>
    class infogen_manager
    {
        static private List<infogen> infogen_list;
        static bool is_created = false;
        static public void create()
        {
            if (!is_created)
            {
                is_created = true;
                infogen_list = new List<infogen>();
                register_or_replace_infogen(new fmea_critical_number());
                register_or_replace_infogen(new fmea_rpn());
                register_or_replace_infogen(new fmea_sod());
            }
        }

        static public void register_or_replace_infogen(infogen infogen_val)
        {
            create();
            foreach (var infogen_item in infogen_list)
            {
                if (infogen_item.doc_type == infogen_val.doc_type)
                {
                    infogen_list.Remove(infogen_item);
                }
            }
            infogen_list.Add(infogen_val);
        }

        static public void run()
        {
            create();
            foreach (var doc_item in sates.core.doc_list.get_list())
            {
                foreach(var infogen_item in infogen_list)
                {
                    if (infogen_item.doc_type == doc_item.doc_type)
                    {
                        try
                        {
                            infogen_item.gen(doc_item);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                }
            }
        }
    }
    /** @} */
    /** @} */
    /** @} */
}
