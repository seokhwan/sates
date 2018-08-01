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

    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 7월 31일 | testcode 인스턴스 자동 생성 기능, 최초작성 | 김석환  |  사용자  |
     */

    /// <summary>
    /// reflection 을 이용하여, testcode 를 상속받은 모든 클래스의 인스턴스를 생성한다.
    /// </summary>
    public class testcode_instances
    {
        /// <summary>
        /// create 함수는 반드시, testcode 를 작성한 assembly 가 호출해야 한다.
        /// 그렇지 않은 경우, 올바른 assembly 를 호출할 수 없다. 
        /// System.Reflection.Assembly.GetCallingAssembly().Location 를 활용.
        /// </summary>
        public static void create()
        {
            var dll = System.Reflection.Assembly.LoadFile(System.Reflection.Assembly.GetCallingAssembly().Location);
                

            foreach (Type type in dll.GetTypes())
            {
                if ("testcode" == type.BaseType.Name)
                {
                    Activator.CreateInstance(type);
                }
            }
        }
    }
}
