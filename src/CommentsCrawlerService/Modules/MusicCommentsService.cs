using Camefor.Tools.NetCore.Util;
using Camefor.Tools.NetCore.Util.Web;
using CommentsCrawlerService.Config;
using CommentsCrawlerService.Infrastructure.Redis;
using CommentsCrawlerService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CommentsCrawlerService.Modules
{

    /// <summary>
    /// 获取歌曲评论数据
    /// </summary>
    public class MusicCommentsService
    {

        /// <summary>
        /// 获取歌曲评论
        /// </summary>
        /// <param name="trackid">歌曲id</param>
        /// <returns></returns>
        public MusicCommentsOutModel GetComments(string trackid)
        {

            try
            {
                if (string.IsNullOrEmpty(trackid))
                {
                    return null;
                }


                var id = $"R_SO_4_{trackid.Trim()}";

                //默认先请求第一页评论
                int pageNo = 1;
                int pageSize = 20;
                int offset = 0;

                var d = new MusicCommentsRequestModel
                {
                    rid = id,
                    threadId = id,
                    pageNo = pageNo.ToStr(),
                    pageSize = pageSize.ToStr(),
                    cursor = "-1",
                    offset = offset.ToStr(),
                    orderType = "1"
                };
                var data = ExecuteRequestComments(d.ToJson());

                UpdateCommntsData(data.data.comments);

                var totalCount = 0L;//评论总数

                //根据评论总数 连续翻页
                totalCount = data.data.totalCount;

                //需要的请求次数
                var reqCount = (totalCount / 20) + 1;
                //已经请求 第一页数据了
                //从第二页开始

                for (int i = 0; i < reqCount; i++)
                {
                    pageNo++;
                    offset = 40;
                    Console.WriteLine($"正在获取第 {pageNo} 页评论数据");


                    d.offset = offset.ToStr();
                    d.pageNo = pageNo.ToStr();
                    Thread.Sleep(200);
                    UpdateCommntsData(ExecuteRequestComments(d.ToJson()).data.comments);
                }

                return data;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private void UpdateCommntsData(List<CommentsItem> commentList)
        {
            //存储
            //var list = RedisHelper.StringGet<List<CommentsItem>>("list");
            //if (list == null)
            //{
            //    list = new List<CommentsItem>();
            //}

            //list.AddRange(commentList);
            //RedisHelper.Set("list", list);

            //判断 没有就丢弃

            var targetList = commentList.Where(_ => _.user.userId.ToStr() == GlobalStateData.uid)?.ToList();
            if (targetList == null)
            {
                return;
            }
            foreach (var item in targetList)
            {
                Console.WriteLine("发现了" + "\r\n" + item.content);
            }
            var tarKey = GlobalStateData.uid + "targetList";
            var res = RedisHelper.Get(tarKey);
            var listInCache = res.ToObject<List<CommentsItem>>();
            if (listInCache == null)
            {
                listInCache = new List<CommentsItem>();
            }
            listInCache.AddRange(targetList);
            RedisHelper.Set(tarKey, listInCache);

        }

        private MusicCommentsOutModel ExecuteRequestComments(string d)
        {
            var jsResult = NeteaseMusicCoreJsService.ExecuteCoreJs(d);
            var p_arams = jsResult.Item1;
            var encSecKey = jsResult.Item2;
            var postData = new Dictionary<string, string>
                     {
                            { "params", p_arams },
                            { "encSecKey", encSecKey }
                     };
            var res = HttpMethods.Post(NeteaseMusicApiUrlManage.MusicComments, postData);
            return res.ToObject<MusicCommentsOutModel>();
        }


    }


}
