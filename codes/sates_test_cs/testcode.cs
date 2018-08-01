//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;


namespace sates.test.cs
{
    /** \addtogroup CODE
    *  @{
    */
    /** \addtogroup sates
    *  @{
    */
    /** \addtogroup test
    *  @{
    */
    /** \addtogroup cs
    *  @{
    */
    public enum TEST_RESULT
    {
        INVALID = 1,
        OK = 20180417,
        NG = 0,
    }

    public abstract class testcode
    {
        public TEST_RESULT result { get; set; }
        public Queue<string> err_log { get; set; }
        public string test_case_name { get; set; }

        protected testcode()
        {
            test_case_name = this.GetType().Name;
            err_log = new Queue<string>();
            testcode_list.add_testcode(this);
        }
        public abstract void init();
        public abstract void run();
        public abstract void terminate();

    }
    /** @} */
    /** @} */
    /** @} */
    /** @} */
}
