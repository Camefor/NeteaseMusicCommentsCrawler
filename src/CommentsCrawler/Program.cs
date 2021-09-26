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
            //    Console.WriteLine("耗时： " + performanceTester.Result.TotalMilliseconds + "毫秒");
            //}

            try
            {

                MainService mainService = new MainService("346539201");
                mainService.Main();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("程序结束……");
            Console.ReadKey();

        }

    }
}
