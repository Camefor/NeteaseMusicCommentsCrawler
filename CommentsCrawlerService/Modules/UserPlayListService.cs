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
    /// 获取用户歌单列表
    /// </summary>
    public class UserPlayListService
    {

        /// <summary>
        /// 获取用户歌单列表
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public PlayListOutModel GetPlayList(PlayListRequestModel req)
        {

            try
            {
                if (string.IsNullOrEmpty(req.uid))
                {
                    return null;
                }

                //执行js加密方法所需参数
                var d = req.ToJson();

                var test = new Dictionary<string, string>();
                test.Add("params", "fcP2s8qNzXjCEHXKk8MaBQP9TmZac4qyvKg1BbQ0qWATkIDPQMUXTviDT7TzkGMcoOhO4lfQAxCB88UHl5fCML3tLQY/xSXkUPeVpkFnkm2rNXrPfEFkYVqflUqgEZXlIWTmnFb7OfO1JdhFaUCFMeNfKz3DRV3DEyyuS9sL+zSazDzc1AA3fKLIKOJHSRrW");
                test.Add("encSecKey", "ab8af6344334422b3640a45234ebd29e94f390109059dc4aafe71783d842e1941ba4fd9f17af37a5dd92dbc5b5d465b0afcfe379017446ed70ffa144b1e9528353fb240c0eba309ace16486a9ec7fb7afce900725c9360e96d080cbf4459a5e027ec8e8834674c5dd9ddcde111ed8a2faf2c9f1d8069c7a81507caf069665b95");

                var postData = test.ToJson();

                var res = HttpMethods.Post(NeteaseMusicApiUrlManage.PlayList, test);
                var data = res.ToObject<PlayListOutModel>();
                return data;
            }

            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
