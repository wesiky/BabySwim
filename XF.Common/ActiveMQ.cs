using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Apache.NMS;
using Apache.NMS.ActiveMQ;

namespace XF.Common
{
    public class ActiveMQ
    {
        //链接工厂
        private static IConnectionFactory factory = null;
        //链接
        private static IConnection connection = null;
        //会话
        public static ISession session = null;
        //消费者
        public static IMessageConsumer consumer = null;
        //发送者
        private static IMessageProducer prod = null;
        //消息服务器地址
        private static string address = "";

        public static string Address
        {
            get { return ActiveMQ.address; }
            set { ActiveMQ.address = value; }
        }
        
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <returns></returns>
        public static bool SendMassage(string msg, ref string _result)
        {
            if (InitSession(string.Empty, ref _result))
            {
                //通过会话创建生产者，方法里new出来MQ的Queue
                prod = session.CreateProducer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("Topic1"));
                //创建一个发送消息的对象
                ITextMessage message = prod.CreateTextMessage();
                message.Text = msg; //给这个消息对象赋实际的消息
                //设置消息对象的属性，是Queue的过滤条件也是P2P的唯一指定属性
                message.Properties.SetString("filter", "demo");
                prod.Send(message, MsgDeliveryMode.NonPersistent, MsgPriority.Normal, TimeSpan.MinValue);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 初始化订阅消息接收器(单例模式，只允许建立一个接收器)
        /// </summary>
        public static bool InitConsumer(ref string _result)
        {
            try
            {
                if (consumer == null)
                {
                    //初始化工厂
                    if (InitConnection("firstQueueListener2", ref _result))
                    {
                        //启动连接
                        connection.Start();
                        //通过连接创建对话
                        session = connection.CreateSession();
                        //通过会话创建一个消费者
                        consumer = session.CreateDurableConsumer(new Apache.NMS.ActiveMQ.Commands.ActiveMQTopic("Topic1"), "firstQueueListener2", "filter = 'demo'", false);
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                _result += "消息服务器初始化失败，请联系管理员！错误信息：" + ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 初始化工厂(单例模式)
        /// </summary>
        private static bool InitFactory(ref string _result)
        {
            if (factory == null)
            {
                try
                {
                    factory = new ConnectionFactory(address);
                }
                catch
                {
                    _result += "消息服务器链接失败，请检查配置和网络！";
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 初始化链接(单例模式)
        /// </summary>
        private static bool InitConnection(string clientId,ref string _result)
        {
            if (InitFactory(ref _result))
            {
                if (connection == null)
                {
                    try
                    {
                        connection = factory.CreateConnection();
                        if (!clientId.Equals(string.Empty))
                        {
                            connection.ClientId = clientId;
                        }
                    }
                    catch
                    {
                        _result += "消息服务器链接创建失败，请检查配置和网络！";
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 初始化会话(单例模式)
        /// </summary>
        private static bool InitSession(string clientId,ref string _result)
        {
            if (InitConnection(clientId, ref _result))
            {
                if (session == null)
                {
                    try
                    {
                        session = connection.CreateSession();
                    }
                    catch
                    {
                        _result += "消息服务器会话创建失败，请检查配置和网络！";
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
