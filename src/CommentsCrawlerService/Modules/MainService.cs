using CommentsCrawlerService.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentsCrawlerService.Modules
{
    /// <summary>
    /// 业务入口
    /// </summary> 
    public class MainService
    {

        private readonly UserPlayListService _userPlayListService = new UserPlayListService();
        private readonly UserPlayDetailService _userPlayDetailService = new UserPlayDetailService();
        private readonly MusicCommentsService _musicCommentsService = new MusicCommentsService();



        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="atargetUserId">要查询的用户id</param>
        public MainService(string atargetUserId)
        {
            GlobalStateData.uid = atargetUserId;
        }




    }
}
