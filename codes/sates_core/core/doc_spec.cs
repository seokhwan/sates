using System;
using System.Collections.Generic;
using System.Text;

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
    |2018년 11월 10일 | 클래스 생성 | 김석환  |  사용자  |
     */

    /// <summary>
    /// doc 중 spec 에 대한 정리를 담당한다. 
    /// 주로, parent / children spec 을 정리한다.
    /// </summary>
    class doc_spec : doc
    {
        protected List<doc> parents;
        protected List<doc> children;
        protected List<doc> test_cases;

        protected void no_duplicate_add(ref List<doc> list, doc item)
        {
            if (null != item)
            {
                bool is_found = false;
                foreach (var v in list)
                {
                    if (v.uniq_id == item.uniq_id)
                    {
                        is_found = true;
                        break;
                    }
                }
                if (!is_found)
                {
                    list.Add(item);
                }
            }
        }
        
        protected void resolve_help(string listname)
        {
            var info = this.get_info(listname);
            if (null != info)
            {
                info.get(out Queue<string> name_list);
                foreach (var name in name_list)
                {
                    doc_spec item = (doc_spec)(doc_list.get(name));
                    if (null != item)
                    {
                        if ("parent_spec" == listname)
                        {
                            no_duplicate_add(ref this.parents, item);
                            no_duplicate_add(ref item.children, this);
                        }
                        else if ("child_spec" == listname)
                        {
                            no_duplicate_add(ref this.children, item);
                            no_duplicate_add(ref item.parents, this);
                        }
                    }
                }
            }
        }

        protected void resolve_help(ref Queue<string> val, List<doc> list, string list_name)
        {
            val.Clear();
            foreach (var item in list)
            {
                val.Enqueue(item.uniq_id);
            }
            this.set_info(list_name, val);
        }


        public doc_spec(string uniq_id, string doc_type) : base(uniq_id, doc_type)
        {
            parents = new List<doc>();
            children = new List<doc>();
            test_cases = new List<doc>();
        }

        public override void cross_ref_gen1()
        {
            resolve_help("parent_spec");
            resolve_help("child_spec");
            var tcase = this.get_info("test_case");
            if (null != tcase)
            {
                tcase.get(out Queue<string> name_list);
                foreach (var name in name_list)
                {
                    doc item = (doc)(doc_list.get(name));
                    if (null != item)
                    {
                        no_duplicate_add(ref test_cases, item);
                    }
                }
            }
        }

        public override void cross_ref_gen2()
        {
            Queue<string> val = new Queue<string>();
            resolve_help(ref val, parents, "parent_spec");
            resolve_help(ref val, children, "child_spec");
            resolve_help(ref val, test_cases, "test_case");
        }
    }

    /** @} */
    /** @} */
    /** @} */
}
