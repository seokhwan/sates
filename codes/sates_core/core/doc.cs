//------------------------------------------------------------------------------
//
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// 
// The SATES, New BSD License (or Modified BSD Licnese)
//
// Redistribution and use in source and binary forms, with or without 
// modification, are permitted provided that the following conditions are met :
//
// 1. Redistributions of source code must retain the above copyright notice, 
// this list of conditions and the following disclaimer.
//
// 2. Redistributions in binary form must reproduce the above copyright notice, 
// this list of conditions and the following disclaimer in the documentation 
// and / or other materials provided with the distribution.
//
// 3. Neither the name of the copyright holder nor the names of its contributors 
// may be used to endorse or promote products derived from this software without 
// specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED.IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS 
// BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES(INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF 
// SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
// INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN 
// CONTRACT, STRICT LIABILITY, OR TORT(INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF 
// THE POSSIBILITY OF SUCH DAMAGE.
//
//------------------------------------------------------------------------------


/** 
 * \defgroup sates sates
 * \defgroup core core
 * \defgroup input input
 * \defgroup setter setter
 * \defgroup algorithm algorithm
 * \defgroup output output
 * \defgroup cs cs
 * \defgroup custom custom
 * \defgroup doxy doxy
 * \defgroup sates_doc sates_doc
 * \defgroup util util
 */


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
     */

    /// <summary>
    /// SATES 의 모든 문서는 이 doc 클래스를 통해서 관리된다.
    /// </summary>
    public class doc
    {
        private Hashtable _info_table;
        public string doc_type { get; set; }
        public string uniq_id { get; set; }
        public Queue<string> category_info { get; set; }

        public doc(string uniq_id, string doc_type)
        {
            this.uniq_id = uniq_id;
            this.doc_type = doc_type;
            this._info_table = new Hashtable();
        }

        public info get_info(string info_name)
        {
            info retval = null;
            if (_info_table.ContainsKey(info_name))
            {
                retval = (info)_info_table[info_name];
            }
            return retval;
        }

        public void set_info(string info_name, string val)
        {
            add_info(info_name, INFO_TYPE.MULTI_LINE_STRING);
            info infovar = (info)_info_table[info_name];
            infovar.set(val);
        }

        public void set_info(string info_name, long val)
        {
            add_info(info_name, INFO_TYPE.LONG);
            info infovar = (info)_info_table[info_name];
            infovar.set(val);
        }

        public void set_info(string info_name, double val)
        {
            add_info(info_name, INFO_TYPE.DOUBLE);
            info infovar = (info)_info_table[info_name];
            infovar.set(val);
        }

        public void set_info(string info_name, Queue<string> val)
        {
            add_info(info_name, INFO_TYPE.MULTI_LINE_STRING);
            info infovar = (info)_info_table[info_name];
            infovar.set(val);
        }
        public void set_info(string info_name, string[] val)
        {
            add_info(info_name, INFO_TYPE.MULTI_LINE_STRING);
            info infovar = (info)_info_table[info_name];
            infovar.set(val);
        }

        protected void add_info(string info_name, INFO_TYPE info_type)
        {
            if (!_info_table.ContainsKey(info_name))
            {
                _info_table.Add(info_name, new info(info_name, info_type));
            }
        }

        public virtual void cross_ref_gen1()
        {}

        public virtual void cross_ref_gen2()
        { }
    }
    /** @} */
    /** @} */
    /** @} */
}
