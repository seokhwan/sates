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

    public enum INFO_TYPE
    {
        INVALID,
        LONG,
        DOUBLE,
        SINGLE_LINE_STRING,
        MULTI_LINE_STRING
    }

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 27일 | 개정 이력 추가  | 김석환  |  사용자  |
     */

    /// <summary>
    /// doc 의 내부내용을 표현
    /// </summary>
    public class info
    {
        private Queue<string> _multiline = null;
        private string _singleline;
        long _int_data;
        double _double_data;


        public INFO_TYPE info_type { get; set; }
        public string name { get; set; }

        public info(string name, INFO_TYPE info_type)
        {
            this.name = name;
            this.info_type = info_type;
            if (info_type == INFO_TYPE.MULTI_LINE_STRING)
            {
                _multiline = new Queue<string>();
            }
            
        }

        public void set(string singleline_val)
        {
            this._singleline = singleline_val;
        }

        public void set(Queue<string> multiline_val)
        {
            this._multiline.Clear();
            for (int i=0; i<multiline_val.Count; i++)
            {
                this._multiline.Enqueue(multiline_val.ElementAt(i));
            }
        }
        public void set(string[] multiline_val)
        {
            if (null != multiline_val)
            {
                this._multiline.Clear();
                for (int i = 0; i < multiline_val.Length; i++)
                {
                    this._multiline.Enqueue(multiline_val[i]);
                }
            }
        }

        public void set(long int_val)
        {
            this._int_data = int_val;
        }

        public void set(double double_val)
        {
            this._double_data = double_val;
        }

        public void get(out string singleline_val)
        {
            singleline_val = this._singleline;
        }

        public void get(out Queue<string> multiline_val)
        {
            multiline_val = new Queue<string>();
            for (int i = 0; i < this._multiline.Count; i++)
            {
                multiline_val.Enqueue(this._multiline.ElementAt(i));
            }
        }

        public void get(out long int_val)
        {
            int_val = this._int_data;
        }

        public void get(out double double_val)
        {
            double_val = this._double_data;
        }
    }
    /** @} */
    /** @} */
    /** @} */
}
