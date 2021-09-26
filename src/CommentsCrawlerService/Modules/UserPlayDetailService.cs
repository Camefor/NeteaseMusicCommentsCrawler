using Camefor.Tools.NetCore.Util;
using Camefor.Tools.NetCore.Util.Web;
using CommentsCrawlerService.Config;
using CommentsCrawlerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentsCrawlerService.Modules
{
    /// <summary>
    /// 用户歌单详情数据
    /// </summary>
    public class UserPlayDetailService
    {

        /// <summary>
        /// 一个歌单的详情数据
        /// </summary>
        /// <param name="id">歌单id</param>
        /// <returns></returns>
        public PlayDetailOutModel GetPlayDetail(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return null;
                }

                var url = NeteaseMusicApiUrlManage.PlayDetail + id;
                //var res = HttpMethods.Get(url, TimeSpan.FromSeconds(5));

                //TODO: 从登陆接口中获取cookie 

                Dictionary<string, string> cookies = new Dictionary<string, string>();
                cookies.Add("__csrf", "xxxx");
                cookies.Add("MUSIC_U", "xxx");
                cookies.Add("NMTID", "xxxx");
                var res = HttpMethods.Get(url, cookies);
                var data = res.ToObject<PlayDetailOutModel>();

                if (data.code == 20001)
                {
                    throw new Exception("登陆过期，请重新登陆！");
                }
                return data;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("获取 一个歌单的详情数据 失败", ex);
            }

        }
    }
}
