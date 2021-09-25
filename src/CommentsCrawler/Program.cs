using Camefor.Tools.NetCore;
using Camefor.Tools.NetCore.Util;
using Camefor.Tools.NetCore.Util.Web;
using CommentsCrawlerService.Config;
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

            //using (PerformanceTester performanceTester = new PerformanceTester())
            //{
            //    UserPlayListService playLIstService = new UserPlayListService();
            //    var result = playLIstService.GetPlayList(new CommentsCrawlerService.Models.PlayListRequestModel
            //    {
            //        uid = "346539201"
            //    });
            //    foreach (var item in result.playlist)
            //    {
            //        Console.WriteLine(item.name);
            //        Console.WriteLine();
            //    }
            //    Console.WriteLine("耗时： " + performanceTester.Result.TotalMilliseconds + "毫秒");
            //}


            UserPlayDetailService playDetailService = new UserPlayDetailService();
            var data = playDetailService.GetPlayDetail("6915994263");

            Console.WriteLine("程序结束……");
            Console.ReadKey();

        }
    }
}
