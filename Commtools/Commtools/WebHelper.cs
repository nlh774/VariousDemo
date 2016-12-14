using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Commtools
{
    /// <summary>
    /// 网络帮助类
    /// 需引入Newtonsoft.Json.9.0.1用于对象反序列化
    /// </summary>
    public class WebHelper
    {
        #region 属性
        /// <summary>
        /// 请求地址
        /// </summary>
        public string RequestUrl { get; set; }

        /// <summary>
        /// 请求数据
        /// 强烈建议Post请求必须有参数，标准http服务器会返回411，虽然本帮助类避免了这个问题
        /// </summary>
        public string RequestParam { get; set; }

        private string _requestEncoding = "utf-8";
        /// <summary>
        /// 请求编码，默认UTF-8
        /// </summary>
        public string RequestEncoding
        {
            get { return _requestEncoding; }
            set { _requestEncoding = value; }
        }

        private string _responseEncoding = "utf-8";
        /// <summary>
        /// 响应编码，默认UTF-8
        /// </summary>
        public string ResponseEncoding
        {
            get { return _responseEncoding; }
            set { _responseEncoding = value; }
        }

        private HttpMethod _method = HttpMethod.Post;
        /// <summary>
        /// 请求的方式，默认Post方式
        /// 强烈建议Post请求必须有参数，标准http服务器会返回411，虽然本帮助类避免了这个问题
        /// </summary>
        public HttpMethod Method
        {
            get { return _method; }
            set { _method = value; }
        }

        private string _contentType = "application/x-www-form-urlencoded";
        /// <summary>
        /// 发送数据的类型，默认application/x-www-form-urlencoded
        /// </summary>
        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        private int _timeout = 10000;
        /// <summary>
        /// 超时设置，单位为毫秒，默认10秒
        /// </summary>
        public int Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        } 
        #endregion


        public WebHelper() { }

        public WebHelper(string requestUrl, HttpMethod httpMethod)
        {
            RequestUrl = requestUrl;
            Method = httpMethod;
        } 

        /// <summary>
        /// 获取响应并转成Json对象返回
        /// 出错会直接抛出异常
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T GetResponse<T>()
        {
            return JsonConvert.DeserializeObject<T>(GetResponse());
        }

        /// <summary>
        /// 获取响应
        /// 出错会直接抛出异常
        /// </summary>
        public string GetResponse()
        {
            string result = string.Empty;
            //强烈建议Post请求必须有参数，标准http服务器会返回411，但本方法不存在这个问题,因为写入空数组requestStream.Write(data, 0, data.Length);
            //if (Method == HttpMethod.Post && RequestParam.IsNullOrWhiteSpace()) return result;  

            HttpWebRequest request = WebRequest.Create(RequestUrl) as HttpWebRequest;
            request.Method = Method.ToString();
            request.ContentType = ContentType;
            request.Timeout = Timeout;
            //封装请求参数
            if (Method == HttpMethod.Get)
            {
                if (RequestParam.IsNotNullOrWhiteSpace())
                {
                    RequestUrl += "?" + RequestParam;
                    request = WebRequest.Create(RequestUrl) as HttpWebRequest;  //request.RequestUri只读，所以只能重新创建
                }
            }
            else
            {
                byte[] data = Encoding.GetEncoding(_requestEncoding).GetBytes(RequestParam);
                request.ContentLength = data.Length;
                using (var requestStream = request.GetRequestStream())
                {
                    requestStream.Write(data, 0, data.Length);
                }
            }
            //请求远程服务器处理相应
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (var streamReader = new StreamReader(responseStream, Encoding.GetEncoding(ResponseEncoding)))
                        {
                            result = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return result;
        }
    }
}
