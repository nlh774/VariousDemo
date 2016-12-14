using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Commtools
{
    /// <summary>
    /// 有效状态
    /// </summary>
    public enum AvailableState
    {
        [Description("有效")]
        Valid = 0,

        [Description("无效")]
        InValid = 1
    }

    /// <summary>
    /// Http请求类型
    /// 主要是Get,Post
    /// </summary>
    public enum HttpMethod
    {
        [Description("Get")]
        Get = 0,

        [Description("Post")]
        Post = 1
    }
}
