using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Camefor.Tools.NetCore.Util.Web
{
    /// <summary>
    /// 描   述  ： Http请求方法                         
    /// 版   本  ： V1.0.0                            
    /// 创 建 人 ： rhyswang                                  
    /// 日    期 ：                         
    /// 创 建 人 ：                                   
    /// 创建时间 ：                                  
    /// 修 改 人 ：                                   
    /// 修改时间 ：                                   
    /// 修改描述 ：                                   
    /// </summary> 

    public class HttpMethods
    {

        #region GET

        /// <summary>
        /// Get 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static string Get(string url)
        {
            HttpClient httpClient = CreateHttpClient(url);
            Task<string> result = httpClient.GetAsync(url).Result.Content.ReadAsStringAsync();
            return result.Result;
        }

        #endregion 

        #region POST


        /// <summary>
        /// post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="jsonData">请求参数</param>
        /// <returns></returns>
        public static string Post(string url, string jsonData)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var postData = new StringContent(jsonData);
            postData.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            Task<string> result = httpClient.PostAsync(url, postData).Result.Content.ReadAsStringAsync();
            return result.Result;
        }
        /// <summary>
        /// post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <returns></returns>
        public static string Post(string url)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var postData = new StringContent("");
            postData.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            Task<string> result = httpClient.PostAsync(url, postData).Result.Content.ReadAsStringAsync();
            return result.Result;
        }

        /// <summary>
        /// post 请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="req">请求参数</param>
        /// <returns></returns>
        public static string Post(string url, byte[] req)
        {
            HttpClient httpClient = CreateHttpClient(url);
            var postData = new ByteArrayContent(req);
            Task<string> result = httpClient.PostAsync(url, postData).Result.Content.ReadAsStringAsync();
            return result.Result;
        }


        /// <summary>
        /// post 请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="dict">提交的数据</param>
        /// <returns></returns>
        public static async Task<string> PostAsync(string url, Dictionary<string, string> dict)
        {
            //var dict = new Dictionary<string, string>();
            //dict.Add("Input1", "TEST2");
            //dict.Add("Input2", "TEST2");
            HttpClient client = CreateHttpClient(url);
            var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(dict) };
            var res = await client.SendAsync(req);
            return await res.Content.ReadAsStringAsync();
        }

        public static string Post(string url, Dictionary<string, string> dict)
        {
            //var dict = new Dictionary<string, string>();
            //dict.Add("Input1", "TEST2");
            //dict.Add("Input2", "TEST2");
            HttpClient client = CreateHttpClient(url);
            var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(dict) };
            var res = client.Send(req);
            return res.Content.ReadAsStringAsync().Result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="nvc"></param>
        /// <returns></returns>
        public static async Task<string> PostAsync(string url, List<KeyValuePair<string, string>> nvc)
        {
            //var nvc = new List<KeyValuePair<string, string>>();
            //nvc.Add(new KeyValuePair<string, string>("Input1", "TEST2"));
            //nvc.Add(new KeyValuePair<string, string>("Input2", "TEST2"));
            var client = new HttpClient();
            var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(nvc) };
            var res = await client.SendAsync(req);
            return await res.Content.ReadAsStringAsync();
        }

        [Obsolete]
        public static string PostUseRestClient(string url)
        {
            var client = new RestClient(url);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Cookie", "NMTID=00OHpTtwZ-6TOCCLUyVi4AxrT2T5JwAAAF8DYR0GQ");
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(
                new Parameter("params",
                "fcP2s8qNzXjCEHXKk8MaBQP9TmZac4qyvKg1BbQ0qWATkIDPQMUXTviDT7TzkGMcoOhO4lfQAxCB88UHl5fCML3tLQY/xSXkUPeVpkFnkm2rNXrPfEFkYVqflUqgEZXlIWTmnFb7OfO1JdhFaUCFMeNfKz3DRV3DEyyuS9sL+zSazDzc1AA3fKLIKOJHSRrW"
                    , ParameterType.RequestBody)
                );

            request.AddParameter("params", "fcP2s8qNzXjCEHXKk8MaBQP9TmZac4qyvKg1BbQ0qWATkIDPQMUXTviDT7TzkGMcoOhO4lfQAxCB88UHl5fCML3tLQY/xSXkUPeVpkFnkm2rNXrPfEFkYVqflUqgEZXlIWTmnFb7OfO1JdhFaUCFMeNfKz3DRV3DEyyuS9sL+zSazDzc1AA3fKLIKOJHSRrW");
            request.AddParameter("encSecKey", "ab8af6344334422b3640a45234ebd29e94f390109059dc4aafe71783d842e1941ba4fd9f17af37a5dd92dbc5b5d465b0afcfe379017446ed70ffa144b1e9528353fb240c0eba309ace16486a9ec7fb7afce900725c9360e96d080cbf4459a5e027ec8e8834674c5dd9ddcde111ed8a2faf2c9f1d8069c7a81507caf069665b95");
            IRestResponse response = client.Execute(request);
            return response.Content;
        }


        #endregion


        /// <summary>
        /// 创建HttpClient
        /// </summary>
        /// <returns></returns>
        public static HttpClient CreateHttpClient(string url, IDictionary<string, string> cookies = null)
        {
            HttpClient httpclient;
            HttpClientHandler handler = new HttpClientHandler();
            var uri = new Uri(url);
            if (cookies != null)
            {
                foreach (var key in cookies.Keys)
                {
                    string one = key + "=" + cookies[key];
                    handler.CookieContainer.SetCookies(uri, one);
                }
            }
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                httpclient = new HttpClient(handler);
            }
            else
            {
                httpclient = new HttpClient(handler);
            }
            return httpclient;
        }



    }
}
