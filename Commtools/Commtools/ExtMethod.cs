using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Commtools
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ExtMethod
    {
        /// <summary>
        /// 获取枚举的描述信息，若无描述信息则直接返回枚举常量
        /// </summary>
        /// <param name="e">枚举值</param>
        /// <returns>枚举值上定义的Description属性，若无描述信息则直接返回枚举常量</returns>
        public static string GetEnumDesc(this Enum e)
        {
            try
            {
                var enumInfo = e.GetType().GetField(e.ToString());
                var enumAttributes = (DescriptionAttribute[])enumInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return enumAttributes.Length > 0 ? enumAttributes[0].Description : e.ToString();
            }
            catch
            {
                return e.ToString();
            }
        }
    }
}
