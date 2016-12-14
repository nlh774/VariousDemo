using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Commtools
{
    /// <summary>
    /// 公共方法，不便分类的方法放在此处
    /// </summary>
    public class UtilHelper
    {
        /// <summary>
        /// 获取调用本方法的方法名称
        /// </summary>
        /// <param name="index">调用本方法的上级方法调用链深度。</param>
        /// <example>调用链关系：FunA=》FunB=》GetParentMethodName，若index = 1则返回FunB,若index = 2则返回FunA</example>
        public static string GetCallFunctionName(int index = 1)
        {
            return new StackTrace(true).GetFrame(index).GetMethod().Name;
        }
    }
}
