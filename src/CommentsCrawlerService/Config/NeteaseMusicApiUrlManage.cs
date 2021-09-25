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
        /// 获取用户歌单列表api 网易云音乐官方api
        /// </summary>
        public static string PlayList
        {
            get
            {
                return "https://music.163.com/weapi/user/playlist?csrf_token=";
            }
        }


        /// <summary>
        /// 获取用户歌单详情 第三方封装api
        /// </summary>
        public static string PlayDetail
        {
            get
            {
                return "http://camefor.top:3000/playlist/detail?id=";
            }
        }
    }
}
