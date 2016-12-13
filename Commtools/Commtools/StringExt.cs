using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Commtools
{
    /// <summary>
    /// 字符串扩展方法
    /// </summary>
    public static class StringExt
    {
        /// <summary>
        /// 去除指定子串
        /// 会将子串全部去除，例如"xxxyyy".RemoveSubString("yy")，返回xxx
        /// </summary>
        /// <param name="str">待操作的字符串</param>
        /// <param name="substring">指定的子串</param>
        public static string RemoveSubString(this string str, string substring)
        {
            if (str.IsNullOrWhiteSpace()) return string.Empty;
            return str.Replace(substring, "");
        }

        /// <summary>
        /// 计算字符串中特定子串的个数
        /// 例如原串"aaa",子串"aa",函数返回1；原串"aaa",子串"a",函数返回3
        /// </summary>
        /// <param name="str">待操作的字符串</param>
        /// <param name="substring">待计数的子串</param>
        public static int CountSubString(this string str, string substring)
        {
            if (str.IsNullOrWhiteSpace()) return 0;
            return Regex.Matches(str, substring).Count;
        }

        /// <summary>
        /// 获取字符串两标志之间的的字符值
        /// 若无标志则返回string.Empty
        /// </summary>
        /// <param name="str">原字符串</param>
        /// <param name="beginMark">开始标志</param>
        /// <param name="endMark">结束标志</param>
        /// <returns>字符值，若不存在标志则为null</returns>
        public static string GetValueBetweenMarks(this string str, string beginMark, string endMark)
        {
            if (str.IsNullOrWhiteSpace()) return string.Empty;

            if (str.Contains(beginMark) && str.Contains(endMark))
            {
                int beginIndex = str.IndexOf(beginMark) + beginMark.Length;
                int length = str.IndexOf(endMark) - beginIndex;
                return str.Substring(beginIndex, length);
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 判断字符串是否全部包含特定关键字.
        /// </summary>
        /// <param name="str">父字符串</param>
        /// <param name="keys">关键字</param>
        /// <returns>含有所有关键字则返回true，不含一个或全部不含则返回false</returns>
        public static bool ContainsKeys(this string str, params string[] keys)
        {
            if (str.IsNullOrWhiteSpace()) return false;

            foreach (var key in keys)
            {
                if (!str.Contains(key)) return false;
            }
            return true;
        }

        /// <summary>
        /// 判断字符串是否为空串或NULL或只含空白符
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        /// <summary>
        /// 判断字符串是否不为空串或NULL或不只含空白符
        /// </summary>
        public static bool IsNotNullOrWhiteSpace(this string str)
        {
            return !str.IsNullOrWhiteSpace();
        }

        /// <summary>
        /// 将字符串转为int型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int ToInt32(this string str, int defaultValue)
        {
            if (str.IsNullOrWhiteSpace()) return defaultValue;

            int result = 0;
            return int.TryParse(str, out result) ? result : defaultValue;
        }

        /// <summary>
        /// 将字符串转为long型数字
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static long ToInt64(this string str, long defaultValue)
        {
            if (str.IsNullOrWhiteSpace()) return defaultValue;

            long result = 0;
            return long.TryParse(str, out result) ? result : defaultValue;
        }
    }
}
