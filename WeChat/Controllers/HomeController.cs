using System;
using System.IO;

using Microsoft.AspNetCore.Mvc;
using Senparc.Weixin.MP.Entities.Request;
using Microsoft.AspNetCore.Http;
using Senparc.CO2NET.HttpUtility;
using Senparc.CO2NET.Utilities;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.MvcExtension;
using Senparc.Weixin.MP.Containers;
using Senparc.Weixin.MP.Entities.Menu;
using Senparc.NeuChar;
using Senparc.Weixin.MP.CommonAPIs;
using Senparc.Weixin;
using NewsWeb.CustomerMessageHandler;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.CO2NET.Extensions;
using WeChat.MessageTemplate;
using System.Threading.Tasks;
using WeChat.Models;
using WeChat.IServices;
using WeChat.Models.Result;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace WeChat.Controllers
{
    public class HomeController : Controller
    {
        public static readonly string Token = Config.SenparcWeixinSetting.Token ?? CheckSignature.Token;//与微信公众账号后台的Token设置保持一致，区分大小写。
        public static readonly string EncodingAESKey = Config.SenparcWeixinSetting.EncodingAESKey;//与微信公众账号后台的EncodingAESKey设置保持一致，区分大小写。
        public static readonly string AppId = Config.SenparcWeixinSetting.WeixinAppId;//与微信公众账号后台的AppId设置保持一致，区分大小写。
        public static readonly string AppSecret = Config.SenparcWeixinSetting.WeixinAppSecret;

        readonly Func<string> _getRandomFileName = () => SystemTime.Now.ToString("yyyyMMdd-HHmmss") + "_Async_" + Guid.NewGuid().ToString("n").Substring(0, 6);

        public IWeChatService _weChatService;

        private readonly ILogger<HomeController> _logger;


        public HomeController(IWeChatService weChatService, ILogger<HomeController> logger)
        {
            _weChatService = weChatService;
            _logger = logger;
        }

        /// <summary>
        /// 微信后台验证地址（使用Get），微信后台的“接口配置信息”的Url填写如：http://weixin.senparc.com/weixin
        /// </summary>
        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                _logger.LogInformation("微信验证通过");
                return Content(echostr); //返回随机字符串则表示验证通过
            }
            else
            {
                _logger.LogInformation("微信验证未通过");
                return Content("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce, Token) + "。" +
                    "如果你在浏览器中看到这句话，说明此地址可以被作为微信公众账号后台的Url，请注意保持Token一致。");
            }
        }

        /// <summary>
        /// 【异步方法】用户发送消息后，微信平台自动Post一个请求到这里，并等待响应XML。
        /// PS：此方法为简化方法，效果与OldPost一致。
        /// v0.8之后的版本可以结合Senparc.Weixin.MP.MvcExtension扩展包，使用WeixinResult，见MiniPost方法。
        /// </summary>
        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(string signature, string timestamp, string nonce)
        {
            _logger.LogInformation("微信请求");
            /* 异步请求请见 WeixinAsyncController（推荐） */

            if (!CheckSignature.Check(signature, timestamp, nonce, Token))
            {
                return Content("参数错误！");
            }

            #region 打包 PostModel 信息
            PostModel postModel = new PostModel();
            postModel.Signature = signature;
            postModel.Timestamp = timestamp;
            postModel.Nonce = nonce;

            postModel.Token = Token;//根据自己后台的设置保持一致
            postModel.EncodingAESKey = EncodingAESKey;//根据自己后台的设置保持一致
            postModel.AppId = AppId;//根据自己后台的设置保持一致（必须提供）

            #endregion

            //v4.2.2之后的版本，可以设置每个人上下文消息储存的最大数量，防止内存占用过多，如果该参数小于等于0，则不限制（实际最大限制 99999）
            //注意：如果使用分布式缓存，不建议此值设置过大，如果需要储存历史信息，请使用数据库储存
            var maxRecordCount = 10;

            //自定义MessageHandler，对微信请求的详细判断操作都在这里面。
            var messageHandler = new CustomMessageHandler(Request.GetRequestMemoryStream(), postModel, maxRecordCount);

            #region 设置消息去重设置

            /* 如果需要添加消息去重功能，只需打开OmitRepeatedMessage功能，SDK会自动处理。
             * 收到重复消息通常是因为微信服务器没有及时收到响应，会持续发送2-5条不等的相同内容的 RequestMessage */
            messageHandler.OmitRepeatedMessage = true;//默认已经是开启状态，此处仅作为演示，也可以设置为 false 在本次请求中停用此功能

            #endregion

            try
            {
                messageHandler.SaveRequestMessageLog();//记录 Request 日志（可选）

                messageHandler.Execute();//执行微信处理过程（关键）

                messageHandler.SaveResponseMessageLog();//记录 Response 日志（可选）

                //return Content(messageHandler.ResponseDocument.ToString());//v0.7-
                //return new WeixinResult(messageHandler);//v0.8+
                return new FixWeixinBugWeixinResult(messageHandler);//为了解决官方微信5.0软件换行bug暂时添加的方法，平时用下面一个方法即可
            }
            catch (Exception ex)
            {
                #region 异常处理
                WeixinTrace.Log("MessageHandler错误：{0}", ex.Message);

                using (TextWriter tw = new StreamWriter(ServerUtility.ContentRootMapPath("~/App_Data/Error_" + _getRandomFileName() + ".txt")))
                {
                    tw.WriteLine("ExecptionMessage:" + ex.Message);
                    tw.WriteLine(ex.Source);
                    tw.WriteLine(ex.StackTrace);
                    //tw.WriteLine("InnerExecptionMessage:" + ex.InnerException.Message);

                    if (messageHandler.ResponseDocument != null)
                    {
                        tw.WriteLine(messageHandler.ResponseDocument.ToString());
                    }

                    if (ex.InnerException != null)
                    {
                        tw.WriteLine("========= InnerException =========");
                        tw.WriteLine(ex.InnerException.Message);
                        tw.WriteLine(ex.InnerException.Source);
                        tw.WriteLine(ex.InnerException.StackTrace);
                    }

                    tw.Flush();
                    tw.Close();
                }
                return Content("");
                #endregion
            }
        }

        //[Route("InitMenu")]
        //public ActionResult InitMenu()
        //{
        //    var accessToken = AccessTokenContainer.GetAccessTokenAsync(AppId);
        //    ButtonGroup bg = new ButtonGroup();
        //    bg.button.Add(new SingleViewButton
        //    {
        //        name = "会员绑定",
        //        url = "http://www.yqhaba.com/Jump?returnUrl=" + "BindUser".UrlDecode(),
        //        type = MenuButtonType.view.ToString()
        //    }); 
        //    bg.button.Add(new SingleViewButton
        //    {
        //        name = "课程请假",
        //        url = "http://www.yqhaba.com/Jump?returnUrl=" + "LeaveNote".UrlDecode(),
        //        type = MenuButtonType.view.ToString()
        //    });
        //    var result = CommonApi.CreateMenu(accessToken.Result, bg);
        //    return Content(result.ToString());
        //}

        #region 评价推送
        [Route("SendEvaluate")]
        public JsonResult SendEvaluate(string openId, int selectionStudentId)
        {
            _logger.LogInformation("发送课程评价");
            BaseResult result = new BaseResult();
            CourseSelectionStudent selectionStudent = _weChatService.GetSelectionStudent(selectionStudentId);
            if (selectionStudent == null)
            {
                //选课记录不存在
                result.ResultCode = (int)CommonTips.UNKNOW_SELECTIONSTUDENT;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return Json(result);
            }
            if (selectionStudent.StudentInfo == null)
            {
                //学员信息不存在
                result.ResultCode = (int)CommonTips.UNKNOW_STUDENTINFO;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return Json(result);
            }
            if (selectionStudent.StudentInfo.Family == null)
            {
                //家长信息不存在
                result.ResultCode = (int)CommonTips.UNKNOW_FAMILY;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return Json(result);
            }
            if (selectionStudent.Selection == null)
            {
                //排课记录不存在
                result.ResultCode = (int)CommonTips.UNKNOW_SELECTION;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return Json(result);
            }
            //openid不一致，说明为异常请求，不执行删除
            if (string.IsNullOrEmpty(selectionStudent.StudentInfo.Family.OpenId))
            {
                result.ResultCode = (int)CommonTips.FAMILY_UNBIND;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return Json(result);
            }
            if (!openId.Equals(selectionStudent.StudentInfo.Family.OpenId))
            {
                result.ResultCode = (int)CommonTips.UNKNOW_OPTION;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return Json(result);
            }
            var data = new CourseEvaluateMessage(
                "课程评价", selectionStudent.StudentInfo.Student.StudentName, selectionStudent.Selection.Course.CourseName, selectionStudent.Selection.Teacher.TeacherName,
                "更详细信息，请咨询HABA乐清中心", "http://www.yqhaba.com/Evaluate?selectionStudentId=" + selectionStudent.SelectionStudentID);

            var resultApi = TemplateApi.SendTemplateMessageAsync(AppId, openId, data);
            
            return Json(new BaseResult((int)resultApi.Result.errcode, resultApi.Result.errmsg));
        }

        [Route("Evaluate")]
        public ActionResult Evaluate(int selectionStudentId)
        {
            _logger.LogInformation("查看课程评价");
            BaseResult result = new BaseResult();
            CourseSelectionStudent selectionStudent = _weChatService.GetSelectionStudent(selectionStudentId);
            if (selectionStudent == null)
            {
                //选课记录不存在
                result.ResultCode = (int)CommonTips.UNKNOW_SELECTIONSTUDENT;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return Json(result);
            }
            if (selectionStudent.StudentInfo == null)
            {
                //学员信息不存在
                result.ResultCode = (int)CommonTips.UNKNOW_STUDENTINFO;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return Json(result);
            }
            if (selectionStudent.StudentInfo.Family == null)
            {
                //家长信息不存在
                result.ResultCode = (int)CommonTips.UNKNOW_FAMILY;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return Json(result);
            }
            if (selectionStudent.Selection == null)
            {
                //排课记录不存在
                result.ResultCode = (int)CommonTips.UNKNOW_SELECTION;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return Json(result);
            }
            //openid不一致，说明为异常请求，不执行删除
            if (string.IsNullOrEmpty(selectionStudent.StudentInfo.Family.OpenId))
            {
                result.ResultCode = (int)CommonTips.FAMILY_UNBIND;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
                return Json(result);
            }
            return View("Evaluate", selectionStudent);
        }

        #endregion

        [Route("Jump")]
        public ActionResult Jump(string returnUrl)
        {
            _logger.LogInformation("微信跳转：" + returnUrl);
            var state = "XFramework-" + SystemTime.Now.Millisecond;//随机数，用于识别请求可靠性
            HttpContext.Session.SetString("State", state);//储存随机数到Session
            string url = string.Empty;
            switch(returnUrl)
            {
                case "BindUser":
                    url = OAuthApi.GetAuthorizeUrl(AppId, "http://www.yqhaba.com/BindUser", state, OAuthScope.snsapi_base);
                    break;
                case "LeaveNote":
                    url = OAuthApi.GetAuthorizeUrl(AppId, "http://www.yqhaba.com/LeaveNote", state, OAuthScope.snsapi_base);
                    break;
            }
            
            return Redirect(url);
        }

        #region 用户绑定
        [Route("BindUser")]
        public ActionResult BindUser(string code, string state, string returnUrl)
        {
            _logger.LogInformation("微信用户绑定");
            try
            {
                if (string.IsNullOrEmpty(code))
                {
                    return Content("您拒绝了授权！");
                }

                if (state != HttpContext.Session.GetString("State"))
                {
                    //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下，
                    //建议用完之后就清空，将其一次性使用
                    //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                    return Content("验证失败！请从正规途径进入！");
                }

                //通过，用code换取access_token
                var result = OAuthApi.GetAccessToken(AppId, AppSecret, code);
                if (result.errcode != ReturnCode.请求成功)
                {
                    return Content("错误：" + result.errmsg);
                }
                HttpContext.Session.SetString("OpenId", result.openid);
                return View("BindUser");
            }
            catch (Exception ex)
            {
                WeixinTrace.SendCustomLog("BaseCallback 发生错误", ex.ToString());
                return Content("发生错误：" + ex.ToString());
            }
        }



        [HttpPost, Route("Bind")]
        public async Task<JsonResult> BindAsync(string familyCode, string familyName)
        {
            _logger.LogInformation("微信用户绑定处理");
            BaseResult result = new BaseResult();
            BaseFamily family = _weChatService.GetFamily(familyCode, familyName);
            if (family == null)
            {
                result.ResultCode = (int)CommonTips.FAMILY_UNEXIST;
                result.ResultMsg = result.ResultCode.ToEnumDescriptionString(typeof(CommonTips));
            }
            else
            {
                family.OpenId = HttpContext.Session.GetString("OpenId");
                _weChatService.Bind(family);
            }
            return Json(result);
        }

        [Route("BindSuccess")]
        public ActionResult BindSuccess()
        {
            _logger.LogInformation("微信用户绑定成功");
            return View("BindSuccess");
        }
        #endregion

        #region 课程请假
        [Route("LeaveNote")]
        public ActionResult LeaveNote(string code, string state, string returnUrl)
        {
            _logger.LogInformation("课程请假");
            try
            {
                if (string.IsNullOrEmpty(code))
                {
                    return Content("您拒绝了授权！");
                }

                if (state != HttpContext.Session.GetString("State"))
                {
                    //这里的state其实是会暴露给客户端的，验证能力很弱，这里只是演示一下，
                    //建议用完之后就清空，将其一次性使用
                    //实际上可以存任何想传递的数据，比如用户ID，并且需要结合例如下面的Session["OAuthAccessToken"]进行验证
                    return Content("验证失败！请从正规途径进入！");
                }

                //通过，用code换取access_token
                var result = OAuthApi.GetAccessToken(AppId, AppSecret, code);
                if (result.errcode != ReturnCode.请求成功)
                {
                    return Content("错误：" + result.errmsg);
                }
                HttpContext.Session.SetString("OpenId", result.openid);
                List<CourseSelectionStudent> models = _weChatService.GetSelectionStudent(result.openid);
                return View("LeaveNote", models);
            }
            catch (Exception ex)
            {
                WeixinTrace.SendCustomLog("BaseCallback 发生错误", ex.ToString());
                return Content("发生错误：" + ex.ToString());
            }
        }

        public IActionResult Leave(int id)
        {
            _logger.LogInformation("微信用户请假处理");
            string openId = HttpContext.Session.GetString("OpenId");
            if (string.IsNullOrEmpty(openId))
            {
                return Content("非法操作");
            }

            BaseResult result = _weChatService.CancelSelectionStudent(id, openId);
            if (result.ResultCode != 0)
            {
                return Content(result.ResultMsg);
            }
            return Redirect("http://www.yqhaba.com/Jump?returnUrl=" + "LeaveNote".UrlDecode());
        }
        #endregion

        ///// <summary>
        ///// 最简化的处理流程（不加密）
        ///// </summary>
        //[HttpPost]
        //[ActionName("MiniPost")]
        //public ActionResult MiniPost(PostModel postModel)
        //{
        //    if (!CheckSignature.Check(postModel.Signature, postModel.Timestamp, postModel.Nonce, Token))
        //    {
        //        //return Content("参数错误！");//v0.7-
        //        return new WeixinResult("参数错误！");//v0.8+
        //    }

        //    postModel.Token = Token;
        //    postModel.EncodingAESKey = EncodingAESKey;//根据自己后台的设置保持一致
        //    postModel.AppId = AppId;//根据自己后台的设置保持一致

        //    var messageHandler = new CustomMessageHandler(Request.GetRequestMemoryStream(), postModel, 10);

        //    messageHandler.Execute();//执行微信处理过程

        //    //return Content(messageHandler.ResponseDocument.ToString());//v0.7-
        //    //return new WeixinResult(messageHandler);//v0.8+
        //    return new FixWeixinBugWeixinResult(messageHandler);//v0.8+
        //}
    }
}
