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
                var res = HttpMethods.Get(url);
                var data = res.ToObject<PlayDetailOutModel>();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
