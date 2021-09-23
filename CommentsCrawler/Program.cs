using Camefor.Tools.NetCore.Util.Web;
using CommentsCrawlerService.Modules;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CommentsCrawler
{
    class Program
    {
        static void Main(string[] args)
        {

            UserPlayListService playLIstService = new UserPlayListService();
            var result = playLIstService.GetPlayList(new CommentsCrawlerService.Models.PlayListRequestModel
            {
                uid = "test"
            });

            Console.WriteLine("程序结束……");
            Console.ReadKey();

        }
    }
}
