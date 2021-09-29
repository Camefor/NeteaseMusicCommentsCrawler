using Camefor.Tools.NetCore.Util;
using CommentsCrawlerService.Models;
using CommentsCrawlerService.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentsCrawlerService.Config
{

    /// <summary>
    /// 维护全局状态数据
    /// </summary>
    public static class GlobalStateData
    {

        public static Dictionary<string, string> cookies
        {
            get
            {
                Dictionary<string, string> cookies = new Dictionary<string, string>();
                cookies.Add("__csrf", "b16b8910b9add4254c525953c8a0a445");
                cookies.Add("MUSIC_U", "d22d86d42efc00ae00155cd4b0aaebf360e413605e635cbfdc5d2d5e813f1f751e8907c67206e1edd78b6050a17a35e705925a4e6992f61d07c385928f88e8de");
                cookies.Add("NMTID", "00OrE_HuRfAMYC1Mk7qlK6skF3abOQAAAF8FvfmXw");
                return cookies;
            }
        }

        public static string uid { get; set; }

        //public static UserLoginOutModel LoginStateModel { get; set; }

        //添加需要的数据

        //public static bool IsLogin
        //{
        //    get
        //    {
        //        return !string.IsNullOrEmpty(uid);
        //    }
        //}

        ///// <summary>
        ///// 检查登陆 未登陆自动登陆
        ///// </summary>
        //public static void CheckLogin()
        //{
        //    try
        //    {
        //        if (!IsLogin)
        //        {
        //            //未登录 重新登陆
        //            UserLoginService userLoginService = new UserLoginService();
        //            var data = userLoginService.Login();
        //            LoginStateModel = data;
        //            uid = data.profile.userId.ToStr();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //}

    }
}
