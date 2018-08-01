//------------------------------------------------------------------------------
// Copyright (C) 2018, Seokhwan Kim (kim at seokhwan.net)
// This file is part of "the SATES"
// For conditions of distribution and use, see copyright notice in 
// sates.core.doc.cs
//------------------------------------------------------------------------------

using System;

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
    public enum OS_NAME
    {
        INVALID,
        WINDOWS,
        UBUNTU
    }


    /**
    @revision
    |  날짜  | 내용  | 담당자   | 검수자  | 
    |------------|------------|------------|------------|
    |2018년 8월 1일 | 최초작성  | 김석환  |  사용자  |
     */

    /// <summary>
    /// 현재 플랫폼 정보를 저장한다.
    /// </summary>
    public class os_setting
    {
        public static OS_NAME OS = OS_NAME.INVALID;
        
        public static char DIR_SEPARATOR
        {
            get
            {
                if (OS_NAME.WINDOWS == OS)
                {
                    return '\\';
                }
                else
                {
                    return '/';
                }
            }
        }
    }
    /** @} */
    /** @} */
    /** @} */
}
