using Senparc.CO2NET.Extensions;
using Senparc.CO2NET.Utilities;
using Senparc.NeuChar.Agents;
using Senparc.NeuChar.Entities;
using Senparc.NeuChar.Entities.Request;
using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Entities;
using Senparc.Weixin.MP.Entities.Request;
using Senparc.Weixin.MP.MessageContexts;
using Senparc.Weixin.MP.MessageHandlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace NewsWeb.CustomerMessageHandler
{
    public class CustomMessageHandler : MessageHandler<DefaultMpMessageContext>
    {
        string agentUrl = "http://localhost:12222/App/Weixin/4";
        string agentToken = "27C455F496044A87";

        private string appId = Config.SenparcWeixinSetting.WeixinAppId;

        public CustomMessageHandler(Stream inputStream, PostModel postModel, int maxRecordCount = 0, bool onlyAllowEcryptMessage = false)
            : base(inputStream, postModel, maxRecordCount, onlyAllowEcryptMessage)
        {
            //这里设置仅用于测试，实际开发可以在外部更全局的地方设置，
            //比如MessageHandler<MessageContext>.GlobalGlobalMessageContext.ExpireMinutes = 3。
            GlobalMessageContext.ExpireMinutes = 3;

            OnlyAllowEcryptMessage = true;//是否只允许接收加密消息，默认为 false

            if (!string.IsNullOrEmpty(postModel.AppId))
            {
                appId = postModel.AppId;//通过第三方开放平台发送过来的请求
            }

            //在指定条件下，不使用消息去重
            base.OmitRepeatedMessageFunc = requestMessage =>
            {
                var textRequestMessage = requestMessage as RequestMessageText;
                if (textRequestMessage != null && textRequestMessage.Content == "容错")
                {
                    return false;
                }
                return true;
            };
        }


        private string GetWelcomeInfo()
        {
            return @"欢迎关注HABA乐清中心。";
        }




        #region ResponseMessage
        public override IResponseMessageBase DefaultResponseMessage(IRequestMessageBase requestMessage)
        {
            var responseMessage = base.CreateResponseMessage<ResponseMessageText>(); //ResponseMessageText也可以是News等其他类型
            responseMessage.Content = "这条消息来自DefaultResponseMessage。";
            return responseMessage;
        }
        #endregion

        #region Request
        /// <summary>
        /// 处理事件请求（这个方法一般不用重写，这里仅作为示例出现。除非需要在判断具体Event类型以外对Event信息进行统一操作
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnEventRequestAsync(IRequestMessageEventBase requestMessage)
        {
            var eventResponseMessage = await base.OnEventRequestAsync(requestMessage);//对于Event下属分类的重写方法，见：CustomerMessageHandler_Events.cs
            return eventResponseMessage;//TODO: 对Event信息进行统一操作
        }

        /// <summary>
        /// 处理文字请求
        /// </summary>
        /// <param name="requestMessage">请求消息</param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnTextRequestAsync(RequestMessageText requestMessage)
        {
            //说明：实际项目中这里的逻辑可以交给Service处理具体信息，参考OnLocationRequest方法或/Service/LocationSercice.cs

            var defaultResponseMessage = base.CreateResponseMessage<ResponseMessageText>();

            var requestHandler = await requestMessage.StartHandler()
                //当 Default 使用异步方法时，需要写在最后一个，且 requestMessage.StartHandler() 前需要使用 await 等待异步方法执行；
                //当 Default 使用同步方法，不一定要在最后一个,并且不需要使用 await
                .Default(async () =>
                {
                    var result = new StringBuilder();
                    result.AppendFormat("您刚才发送了文字信息：{0}\r\n\r\n", requestMessage.Content);

                    var currentMessageContext = await base.GetCurrentMessageContext();
                    if (currentMessageContext.RequestMessages.Count > 1)
                    {
                        result.AppendFormat("您刚才还发送了如下消息（{0}/{1}）：\r\n", currentMessageContext.RequestMessages.Count,
                            currentMessageContext.StorageData);
                        for (int i = currentMessageContext.RequestMessages.Count - 2; i >= 0; i--)
                        {
                            var historyMessage = currentMessageContext.RequestMessages[i];
                            result.AppendFormat("{0} 【{1}】{2}\r\n",
                                historyMessage.CreateTime.ToString("HH:mm:ss"),
                                historyMessage.MsgType.ToString(),
                                (historyMessage is RequestMessageText)
                                    ? (historyMessage as RequestMessageText).Content
                                    : "[非文字类型]"
                                );
                        }
                        result.AppendLine("\r\n");
                    }

                    result.AppendFormat("如果您在{0}分钟内连续发送消息，记录将被自动保留（当前设置：最多记录{1}条）。过期后记录将会自动清除。\r\n",
                        GlobalMessageContext.ExpireMinutes, GlobalMessageContext.MaxRecordCount);
                    result.AppendLine("\r\n");
                    result.AppendLine(
                        "您还可以发送【位置】【图片】【语音】【视频】等类型的信息（注意是这几种类型，不是这几个文字），查看不同格式的回复。\r\nSDK官方地址：https://sdk.weixin.senparc.com");

                    defaultResponseMessage.Content = result.ToString();

                    return defaultResponseMessage;
                });

            return requestHandler.GetResponseMessage() as IResponseMessageBase;
        }


        /// <summary>
        /// 处理链接消息请求
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override async Task<IResponseMessageBase> OnLinkRequestAsync(RequestMessageLink requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = string.Format(@"您发送了一条连接信息：
Title：{0}
Description:{1}
Url:{2}", requestMessage.Title, requestMessage.Description, requestMessage.Url);
            return responseMessage;
        }


        public override async Task<IResponseMessageBase> OnUnknownTypeRequestAsync(RequestMessageUnknownType requestMessage)
        {
            /*
             * 此方法用于应急处理SDK没有提供的消息类型，
             * 原始XML可以通过requestMessage.RequestDocument（或this.RequestDocument）获取到。
             * 如果不重写此方法，遇到未知的请求类型将会抛出异常（v14.8.3 之前的版本就是这么做的）
             */
            var msgType = Senparc.NeuChar.Helpers.MsgTypeHelper.GetRequestMsgTypeString(requestMessage.RequestDocument);
            var responseMessage = this.CreateResponseMessage<ResponseMessageText>();
            responseMessage.Content = "未知消息类型：" + msgType;

            WeixinTrace.SendCustomLog("未知请求消息类型", requestMessage.RequestDocument.ToString());//记录到日志中

            return responseMessage;
        }

        #endregion

        #region Event
        #region 异步

        ///// <summary>
        /////【异步方法】Event事件类型请求之CLICK
        ///// </summary>
        ///// <param name="requestMessage"></param>
        ///// <returns></returns>
        public override Task<IResponseMessageBase> OnEvent_ClickRequestAsync(RequestMessageEvent_Click requestMessage)
        {
            return Task.Factory.StartNew<IResponseMessageBase>(() =>
            {
                return OnEvent_ClickRequest(requestMessage);//这里为了保持Demo的连贯性，结果先从同步方法获取，实际使用过程中可以在 OnEvent_ClickRequestAsync 中全部直接定义异步方法
            });
        }

        public override Task<IResponseMessageBase> OnEvent_EnterRequestAsync(RequestMessageEvent_Enter requestMessage)
        {
            return Task.Factory.StartNew<IResponseMessageBase>(() =>
            {
                return OnEvent_EnterRequest(requestMessage);//这里为了保持Demo的连贯性，结果先从同步方法获取，实际使用过程中可以在 OnEvent_ClickRequestAsync 中全部直接定义异步方法
            });
        }

        public override Task<IResponseMessageBase> OnEvent_ViewRequestAsync(RequestMessageEvent_View requestMessage)
        {
            return Task.Factory.StartNew<IResponseMessageBase>(() =>
            {
                return OnEvent_ViewRequest(requestMessage);//这里为了保持Demo的连贯性，结果先从同步方法获取，实际使用过程中可以在 OnEvent_ClickRequestAsync 中全部直接定义异步方法
            });
        }

        public override Task<IResponseMessageBase> OnEvent_SubscribeRequestAsync(RequestMessageEvent_Subscribe requestMessage)
        {
            return Task.Factory.StartNew<IResponseMessageBase>(() =>
            {
                return OnEvent_SubscribeRequest(requestMessage);//这里为了保持Demo的连贯性，结果先从同步方法获取，实际使用过程中可以在 OnEvent_ClickRequestAsync 中全部直接定义异步方法
            });
        }

        public override Task<IResponseMessageBase> OnEvent_UnsubscribeRequestAsync(RequestMessageEvent_Unsubscribe requestMessage)
        {
            return Task.Factory.StartNew<IResponseMessageBase>(() =>
            {
                return OnEvent_UnsubscribeRequest(requestMessage);//这里为了保持Demo的连贯性，结果先从同步方法获取，实际使用过程中可以在 OnEvent_ClickRequestAsync 中全部直接定义异步方法
            });
        }
        #endregion

        #region 同步

        /// <summary>
        /// 点击事件
        /// </summary>
        /// <param name="requestMessage">请求消息</param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ClickRequest(RequestMessageEvent_Click requestMessage)
        {
            IResponseMessageBase reponseMessage = null;
            //菜单点击，需要跟创建菜单时的Key匹配

            switch (requestMessage.EventKey)
            {
                case "BindUser":
                    {
                        //这个过程实际已经在OnTextOrEventRequest中命中“OneClick”关键字，并完成回复，这里不会执行到。
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了底部按钮。\r\n为了测试微信软件换行bug的应对措施，这里做了一个——\r\n换行";
                    }
                    break;
                case "LeaveNote":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了子菜单按钮。";
                    }
                    break;
                case "SubClickRoot_News":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Articles.Add(new Article()
                        {
                            Title = "您点击了子菜单图文按钮",
                            Description = "您点击了子菜单图文按钮，这是一条图文信息。这个区域是Description内容\r\n可以使用\\r\\n进行换行。",
                            PicUrl = "https://sdk.weixin.senparc.com/Images/qrcode.jpg",
                            Url = "https://sdk.weixin.senparc.com"
                        });

                        //随机添加一条图文，或只输出一条图文信息
                        if (SystemTime.Now.Second % 2 == 0)
                        {
                            strongResponseMessage.Articles.Add(new Article()
                            {
                                Title = "这是随机产生的第二条图文信息，用于测试多条图文的样式",
                                Description = "这是随机产生的第二条图文信息，用于测试多条图文的样式",
                                PicUrl = "https://sdk.weixin.senparc.com/Images/qrcode.jpg",
                                Url = "https://sdk.weixin.senparc.com"
                            });
                        }
                    }
                    break;
                case "SubClickRoot_Music":
                    {
                        //上传缩略图

#if NET45
                        var filePath = "~/Images/Logo.thumb.jpg";
#else   
                        var filePath = "~/wwwroot/Images/Logo.thumb.jpg";
#endif

                        var uploadResult = MediaApi.UploadTemporaryMedia(appId, UploadMediaFileType.thumb,
                                                                    ServerUtility.ContentRootMapPath(filePath));
                        //PS：缩略图官方没有特别提示文件大小限制，实际测试哪怕114K也会返回文件过大的错误，因此尽量控制在小一点（当前图片39K）

                        //设置音乐信息
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageMusic>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Music.Title = "天籁之音";
                        strongResponseMessage.Music.Description = "真的是天籁之音";
                        strongResponseMessage.Music.MusicUrl = "https://sdk.weixin.senparc.com/Content/music1.mp3";
                        strongResponseMessage.Music.HQMusicUrl = "https://sdk.weixin.senparc.com/Content/music1.mp3";
                        strongResponseMessage.Music.ThumbMediaId = uploadResult.thumb_media_id;
                    }
                    break;
                case "SubClickRoot_Image":
                    {
                        //上传图片
#if NET45
                        var filePath = "~/Images/Logo.jpg";
#else
                        var filePath = "~/wwwroot/Images/Logo.jpg";
#endif

                        var uploadResult = MediaApi.UploadTemporaryMedia(appId, UploadMediaFileType.image,
                                                                     ServerUtility.ContentRootMapPath(filePath));
                        //设置图片信息
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageImage>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Image.MediaId = uploadResult.media_id;
                    }
                    break;
                case "SendMenu"://菜单消息
                    {
                        //注意：
                        //1、此接口可以在任意地方调用（包括后台线程），此处演示为通过
                        //2、一下"s:"前缀只是 Senparc.Weixin 的内部约定，可以使用 OnTextRequest事件中的 requestHandler.SelectMenuKeyword() 方法自动匹配到后缀（如101）

                        var menuContentList = new List<SendMenuContent>(){
                            new SendMenuContent("101","满意"),
                            new SendMenuContent("102","一般"),
                            new SendMenuContent("103","不满意")
                        };
                        //使用异步接口
                        CustomApi.SendMenuAsync(appId, OpenId, "请对 Senparc.Weixin SDK 给出您的评价", menuContentList, "感谢您的参与！");

                        reponseMessage = new ResponseMessageNoResponse();//不返回任何消息
                    }
                    break;
                case "SubClickRoot_Agent"://代理消息
                    {
                        //获取返回的XML
                        var dt1 = SystemTime.Now;
                        reponseMessage = MessageAgent.RequestResponseMessage(this, agentUrl, agentToken, RequestDocument.ToString());
                        //上面的方法也可以使用扩展方法：this.RequestResponseMessage(this,agentUrl, agentToken, RequestDocument.ToString());

                        var dt2 = SystemTime.Now;

                        if (reponseMessage is ResponseMessageNews)
                        {
                            (reponseMessage as ResponseMessageNews)
                                .Articles[0]
                                .Description += string.Format("\r\n\r\n代理过程总耗时：{0}毫秒", (dt2 - dt1).Milliseconds);
                        }
                    }
                    break;
                case "Member"://托管代理会员信息
                    {
                        //原始方法为：MessageAgent.RequestXml(this,agentUrl, agentToken, RequestDocument.ToString());//获取返回的XML
                        reponseMessage = this.RequestResponseMessage(agentUrl, agentToken, RequestDocument.ToString());
                    }
                    break;
                case "OAuth"://OAuth授权测试
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageNews>();

                        strongResponseMessage.Articles.Add(new Article()
                        {
                            Title = "OAuth2.0测试",
                            Description = "选择下面两种不同的方式进行测试，区别在于授权成功后，最后停留的页面。",
                            //Url = "https://sdk.weixin.senparc.com/oauth2",
                            //PicUrl = "https://sdk.weixin.senparc.com/Images/qrcode.jpg"
                        });

                        strongResponseMessage.Articles.Add(new Article()
                        {
                            Title = "OAuth2.0测试（不带returnUrl），测试环境可使用",
                            Description = "OAuth2.0测试（不带returnUrl）",
                            Url = "https://sdk.weixin.senparc.com/oauth2",
                            PicUrl = "https://sdk.weixin.senparc.com/Images/qrcode.jpg"
                        });

                        var returnUrl = "/OAuth2/TestReturnUrl";
                        strongResponseMessage.Articles.Add(new Article()
                        {
                            Title = "OAuth2.0测试（带returnUrl），生产环境强烈推荐使用",
                            Description = "OAuth2.0测试（带returnUrl）",
                            Url = "https://sdk.weixin.senparc.com/oauth2?returnUrl=" + returnUrl.UrlEncode(),
                            PicUrl = "https://sdk.weixin.senparc.com/Images/qrcode.jpg"
                        });

                        reponseMessage = strongResponseMessage;

                    }
                    break;
                case "Description":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        strongResponseMessage.Content = GetWelcomeInfo();
                        reponseMessage = strongResponseMessage;
                    }
                    break;
                case "SubClickRoot_PicPhotoOrAlbum":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了【微信拍照】按钮。系统将会弹出拍照或者相册发图。";
                    }
                    break;
                case "SubClickRoot_ScancodePush":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了【微信扫码】按钮。";
                    }
                    break;
                case "ConditionalMenu_Male":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了个性化菜单按钮，您的微信性别设置为：男。";
                    }
                    break;
                case "ConditionalMenu_Femle":
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        reponseMessage = strongResponseMessage;
                        strongResponseMessage.Content = "您点击了个性化菜单按钮，您的微信性别设置为：女。";
                    }
                    break;
                case "GetNewMediaId"://获取新的MediaId
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        try
                        {
                            var result = MediaApi.UploadForeverMedia(appId, ServerUtility.ContentRootMapPath("~/Images/logo.jpg"));
                            strongResponseMessage.Content = result.media_id;
                        }
                        catch (Exception e)
                        {
                            strongResponseMessage.Content = "发生错误：" + e.Message;
                            WeixinTrace.SendCustomLog("调用UploadForeverMedia()接口发生异常", e.Message);
                        }
                    }
                    break;
                default:
                    {
                        var strongResponseMessage = CreateResponseMessage<ResponseMessageText>();
                        strongResponseMessage.Content = "您点击了按钮，EventKey：" + requestMessage.EventKey;
                        reponseMessage = strongResponseMessage;
                    }
                    break;
            }

            return reponseMessage;
        }

        /// <summary>
        /// 进入事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_EnterRequest(RequestMessageEvent_Enter requestMessage)
        {
            return ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
        }

        /// <summary>
        /// 打开网页事件
        /// </summary>
        /// <param name="requestMessage"></param>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_ViewRequest(RequestMessageEvent_View requestMessage)
        {
            return CreateResponseMessage<ResponseMessageText>();
        }

        /// <summary>
        /// 订阅（关注）事件
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_SubscribeRequest(RequestMessageEvent_Subscribe requestMessage)
        {
            var responseMessage = ResponseMessageBase.CreateFromRequestMessage<ResponseMessageText>(requestMessage);
            responseMessage.Content = GetWelcomeInfo();
            return responseMessage;
        }

        /// <summary>
        /// 退订
        /// 实际上用户无法收到非订阅账号的消息，所以这里可以随便写。
        /// unsubscribe事件的意义在于及时删除网站应用中已经记录的OpenID绑定，消除冗余数据。并且关注用户流失的情况。
        /// </summary>
        /// <returns></returns>
        public override IResponseMessageBase OnEvent_UnsubscribeRequest(RequestMessageEvent_Unsubscribe requestMessage)
        {
            return base.CreateResponseMessage<ResponseMessageText>();
        }

        #endregion
        #endregion
    }
}
