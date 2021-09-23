using Camefor.Tools.NetCore;
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
                var p_arams = string.Empty;
                var encSecKey = string.Empty;
                try
                {
                    using (ScriptEngine engine = new ScriptEngine("jscript"))
                    {
                        var parsed = engine.Parse(DecryptCoreJsCodeString.Content);
                        var d = req.ToJson();
                        dynamic jsResult = parsed.CallMethod("start", d);
                        p_arams = jsResult.p_arams as string;
                        encSecKey = jsResult.encSecKey as string;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("执行js代码失败", ex);
                }


                var postData = new Dictionary<string, string>();
                postData.Add("params", p_arams);
                postData.Add("encSecKey", encSecKey);
                var res = HttpMethods.Post(NeteaseMusicApiUrlManage.PlayList, postData);
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
