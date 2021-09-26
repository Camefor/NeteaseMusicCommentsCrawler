using Camefor.Tools.NetCore;
using Camefor.Tools.NetCore.Util;
using Camefor.Tools.NetCore.Util.Web;
using CommentsCrawlerService.Config;
using CommentsCrawlerService.Infrastructure.Redis;
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


            //UserPlayDetailService playDetailService = new UserPlayDetailService();
            //var data = playDetailService.GetPlayDetail("530521582");
            //foreach (var item in data.playlist.trackIds)
            //{
            //    //歌曲id
            //    Console.WriteLine(item.id);
            //    Console.WriteLine();
            //}


            //GlobalStateData.uid = "346539201";


            //测试：歌曲id
            //1472703576
            MusicCommentsService musicCommentsService = new MusicCommentsService();
            musicCommentsService.GetComments("31048600");


            Console.WriteLine("程序结束……");
            Console.ReadKey();

        }

        public static DateTime UnixTimeStampToDateTime(long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }


        /// <summary>
        /// 根据时间戳timestamp（单位毫秒）计算日期
        /// </summary>
        public static DateTime NewDate(long timestamp)
        {
            DateTime dt1970 = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            long t = dt1970.Ticks + timestamp * 10000;
            return new DateTime(t).ToUniversalTime();
        }


    }
}
