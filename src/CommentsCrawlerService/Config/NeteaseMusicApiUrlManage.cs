using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentsCrawlerService.Config
{
    /// <summary>
    /// 统一维护 api 地址
    /// </summary>
    public static class NeteaseMusicApiUrlManage
    {

        /// <summary>
        /// 获取用户歌单列表api
        /// </summary>
        public static string PlayList
        {
            get
            {
                return "https://music.163.com/weapi/user/playlist?csrf_token=";
            }
        }


        public static string PlayListUrl
        {
            get
            {
                return "";
            }
        }
    }
}
