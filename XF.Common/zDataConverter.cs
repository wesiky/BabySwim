using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XF.Common
{
    public class zDataConverter
    {
        #region 格式转化
        #region byte数组与string
        #region byte数组转换为string
        /// <summary>
        /// byte数组转换为string
        /// </summary>
        /// <param name="bytRec"></param>
        /// <returns></returns>
        public static string bytearr2string(byte[] bytRec, int bytLength)
        {
            string strResult = "";
            string str = "";
            for (int i = 0; i < bytLength; i++)
            {
                if (bytRec[i] == 0)
                {
                    continue;
                }
                str = ascii2string(bytRec[i]);
                strResult = System.String.Concat(strResult, str);
            }
            //PrintToDebug("收到 长度:" + bytRec.Length.ToString() + " 数据:" + strResult);
            return strResult;
        }
        #endregion
        #region string转换为byte数组
        /// <summary>
        /// string转换为byte数组
        /// </summary>
        /// <returns>byte数组</returns>
        public static byte[] string2bytearr(string str)
        {
            return System.Text.Encoding.Default.GetBytes(str);
        }
        #endregion
        #endregion
        #region byte数组与原始string
        #region byte数组转换为原始string
        /// <summary>
        /// byte数组转换为原始string
        /// </summary>
        /// <param name="bytRec"></param>
        /// <returns></returns>
        public static string bytearr2string2(byte[] bytRec, int bytLength, char sign = ' ')
        {
            string str = "";
            for (int i = 0; i < bytLength; i++)
            {
                str += byte2string2(bytRec[i]) + sign.ToString();
            }
            //PrintToDebug("收到 原始数据:" + str);
            return str;
        }
        #endregion
        #region 原始string转换为byte数组
        /// <summary>
        /// 原始string转换为byte数组
        /// </summary>
        /// <returns>byte数组</returns>
        public static byte[] string2bytearr2(string str, char sign = ' ')
        {
            string[] sarr = str.Split(sign);
            byte[] buf = new byte[sarr.Length];
            for (int i = 0; i < sarr.Length; i++)
            {
                buf[i] = string2byte(sarr[i]);
            }
            return buf;
        }
        #endregion
        #endregion
        #region byte与原始string
        #region byte转换为原始string
        /// <summary>
        /// byte转换为原始string
        /// </summary>
        /// <returns>byte</returns>
        public static string byte2string2(byte i, int length = 2)
        {
            string s = i.ToString("X" + length);
            //if (s.Length > length)
            //    s = s.Substring(s.Length - length, length);
            //while (s.Length < length)
            //{
            //    s = "0" + s;
            //}
            return s.ToUpper();
        }
        #endregion
        #region 原始string转换为byte
        /// <summary>
        /// 原始string转换为byte
        /// </summary>
        /// <returns>byte数组</returns>
        public static byte string2byte(string str)
        {
            Int32 i = Convert.ToInt32(str, 16);
            byte b = (byte)i;
            return (byte)i;
        }
        #endregion
        #endregion
        #region string与原始string
        #region string转换为原始string
        /// <summary>
        /// string转换为原始string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public static string string2string2(string str, char sign = ' ')
        {
            if (str.Length > 2 && str.IndexOf(sign) < 0)
            {
                str = AddSpace(str, 2, sign);
            }
            byte[] buf = string2bytearr(str);
            return bytearr2string2(buf, buf.Length, sign);
        }
        #endregion
        #region 原始string转换为string
        /// <summary>
        /// 原始string转换为string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public static string string22string(string str, char sign = ' ')
        {
            if (str.Length > 2 && str.IndexOf(sign) < 0)
            {
                str = AddSpace(str, 2, sign);
            }
            byte[] buf = string2bytearr2(str, sign);
            return bytearr2string(buf, buf.Length);
        }
        #endregion
        #endregion
        #region ascii转换为字符
        /// <summary>
        /// ascii转换为字符
        /// </summary>
        /// <returns>byte</returns>
        public static string ascii2string(Int32 i)
        {
            return System.Char.ToString((char)i);
        }
        #endregion
        #region 十六进制string转换为int
        /// <summary>
        /// 十六进制string转换为int
        /// </summary>
        /// <returns>byte数组</returns>
        public static Int32 string2int2(string str)
        {
            Int32 i = Convert.ToInt32(str, 16);
            return i;
        }
        #endregion
        #region 字符串调转
        #region 原始string调转
        /// <summary>
        /// 原始string反转
        /// 例：step = 1时，01 02 03 04  返回 04 03 02 01
        /// 例：step = 2时，01 02 03 04  返回 03 04 01 02
        /// </summary>
        /// <param name="s"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static string ReverseString2(string s, char sign = ' ', int step = 1)
        {
            string[] arr = s.Split(sign);
            if (sign == ',' && arr.Length == 1 && s.Length % 2 == 0)
            {
                arr = new string[s.Length / 2];
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = s.Substring(i * 2, 2);
                }
            }
            string sResult = "";
            for (int i = arr.Length - 1; i >= step - 1; i = i - step)
            {
                for (int j = i - step + 1; j <= i; j++)
                    sResult += arr[j] + (sign == ',' ? "" : sign.ToString());
            }
            return sResult.Trim();
        }
        #endregion
        #region string调转
        /// <summary>
        /// string反转
        /// 例：step = 1时，12345678  返回 87654321
        /// 例：step = 2时，12345678  返回 78563412
        /// </summary>
        /// <param name="s"></param>
        /// <param name="step"></param>
        /// <returns></returns>
        public static string ReverseString(string s, int step = 1)
        {
            string sResult = "";
            for (int i = s.Length - 1; i >= step - 1; i = i - step)
            {
                for (int j = i - step + 1; j <= i; j++)
                    sResult += s[j];
            }
            return sResult.Trim();
        }
        #endregion
        #endregion
        #region 处理数字字符串长度
        /// <summary>
        /// 处理数字字符串长度
        /// </summary>
        /// <param name="s">原始字符串</param>
        /// <param name="length">需要的长度</param>
        /// <returns></returns>
        public static string CompleteNumberString(string s, int length)
        {
            if (s.Length > length)
            {
                return s.Substring(s.Length - length, length);
            }
            while (s.Length < length)
            {
                s = "0" + s;
            }
            return s;
        }
        #endregion
        #region 中间补空格
        /// <summary>
        /// 字符串中间补字符
        /// 例：step = 1时，A12B  返回 A 1 2 B
        /// 例：step = 2时，A12B  返回 A1 2B
        /// </summary>
        /// <param name="s">初始字符串</param>
        /// <param name="step">补空格间隔</param>
        /// <returns></returns>
        public static string AddSpace(string s, int step = 2, char sign = ' ')
        {
            try
            {
                if(s.Length < step)
                    return s;
                string sMsg = "";
                while (s.Length >= step)
                {
                    sMsg += s.Substring(0, step) + sign;
                    s = s.Substring(step, s.Length - step);
                }
                if (s != "")
                    sMsg += s;
                return sMsg.Trim();
            }
            catch
            {
                return s;
            }
        }
        #endregion
        #region 十进制与十六进制
        #region 十进制int转换为十六进制string
        /// <summary>
        /// 十进制int转换为十六进制string
        /// </summary>
        /// <returns>byte数组</returns>
        public static string Decimal2Hexadecimal(int i, int length = 2)
        {
            string s = i.ToString("X" + length);
            //if (s.Length > length)
            //    s = s.Substring(s.Length - length, length);
            //while (s.Length < length)
            //{
            //    s = "0" + s;
            //}
            return s.ToUpper();
        }
        #endregion
        #region 十进制string转换为十六进制string
        /// <summary>
        /// 十进制string转换为十六进制string
        /// </summary>
        /// <returns>byte数组</returns>
        public static string Decimal2Hexadecimal(string str, int length = 2)
        {
            if (str == "")
                str = "0";
            string s = ((int)Convert.ToDecimal(str)).ToString("X" + length);
            //if (s.Length > length)
            //    s = s.Substring(s.Length - length, length);
            //while (s.Length < length)
            //{
            //    s = "0" + s;
            //}
            return s.ToUpper();
        }
        #endregion
        #region 十六进制string转换为十进制int
        /// <summary>
        /// 十六进制string转换为十进制int
        /// </summary>
        /// <returns></returns>
        public static Int32 Hexadecimal2Decimal(string str)
        {
            Int32 i = Convert.ToInt32(str, 16);
            return i;
        }
        #endregion
        #endregion
        #region 十进制与二进制
        #region 十进制int转换为二进制string
        /// <summary>
        /// 十进制int转换为二进制string
        /// </summary>
        /// <returns></returns>
        public static string Decimal2Binary(int i)
        {
            string s = System.Convert.ToString(i, 2);
            return s;
        }
        #endregion
        #region 十进制string转换为二进制string
        /// <summary>
        /// 十进制string转换为二进制string
        /// </summary>
        /// <returns></returns>
        public static string Decimal2Binary(string str)
        {
            string s = System.Convert.ToString(Convert.ToInt32(str), 2);
            return s;
        }
        #endregion
        #region 二进制string转换为十进制int
        /// <summary>
        /// 二进制string转换为十进制int
        /// </summary>
        /// <returns></returns>
        public static int Binary2Decimal(string str)
        {
            int i = System.Convert.ToInt32(str, 2);
            return i;
        }
        #endregion
        #endregion
        #region 十六进制与二进制
        #region 十六进制string转换为二进制string
        /// <summary>
        /// 十六进制string转换为二进制string
        /// </summary>
        /// <returns></returns>
        public static string Hexadecimal2Binary(string str)
        {
            string s = System.Convert.ToString(Convert.ToInt32(str, 16), 2);
            return s;
        }
        #endregion
        #region 二进制string转换为十六进制string
        /// <summary>
        /// 二进制string转换为十六进制string
        /// </summary>
        /// <returns></returns>
        public static string Binary2Hexadecimal(string str)
        {
            string s = string.Format("{0:X}", System.Convert.ToInt32(str, 2));
            return s;
        }
        #endregion
        #endregion
        #region byte数组与单精度浮点数
        #region byte数组转换为单精度浮点数
        /// <summary>
        /// byte数组转换为单精度浮点数
        /// </summary>
        /// <param name="bytRec"></param>
        /// <returns></returns>
        public static float bytearr2float(byte[] bytRec)
        {
            float f = BitConverter.ToSingle(bytRec, 0);
            return f;
        }
        #endregion
        #region 单精度浮点数转换为byte数组
        /// <summary>
        /// 单精度浮点数转换为byte数组
        /// </summary>
        /// <returns>byte数组</returns>
        public static byte[] float2bytearr(float f)
        {
            byte[] bytes = BitConverter.GetBytes(f);
            return bytes;
        }
        #endregion
        #endregion
        #region 原始string与单精度浮点数
        #region 原始string转换为单精度浮点数
        /// <summary>
        /// 原始string转换为单精度浮点数
        /// </summary>
        /// <param name="bytRec"></param>
        /// <returns></returns>
        public static float string2float2(string s)
        {
            s = s.Trim();
            if (s.Length == 8 && s.IndexOf(" ") == -1)
                s = AddSpace(s);
            byte[] bytRec = string2bytearr2(s);
            float f = BitConverter.ToSingle(bytRec, 0);
            return f;
        }
        #endregion
        #region 单精度浮点数转换为原始string
        /// <summary>
        /// 单精度浮点数转换为原始string
        /// </summary>
        /// <returns>byte数组</returns>
        public static string float2string2(float f)
        {
            byte[] bytes = BitConverter.GetBytes(f);
            string s = bytearr2string2(bytes, bytes.Length, ' ');
            return s;
        }
        #endregion
        #endregion
        #region 十六进制字符串每两个中间加空格
        /// <summary>
        /// 十六进制字符串每两个中间加空格
        /// </summary>
        /// <param name="sMsg"></param>
        /// <returns></returns>
        public static string stringAddSpace(string sMsg)
        {
            if (sMsg.Length % 2 != 0)
            {
                return sMsg;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < sMsg.Length; i = i + 2)
            {
                sb.Append(sMsg.Substring(i, 2));
                sb.Append(" ");
            }
            return sb.ToString();
        }
        #endregion
        #region ToString
        public static string ToString(object myobj)
        {
            try
            {
                if (myobj == null)
                    return "";
                return myobj.ToString();
            }
            catch //(Exception err)
            {
                //StackTrace st = new StackTrace(new StackFrame(true));
                //StackFrame sf = st.GetFrame(0);
                //PrintToDebug(sf == null ? "" : ("方法[" + sf.GetMethod().Name + "]行[" + sf.GetFileLineNumber() + "]列[" + sf.GetFileColumnNumber() + "]") + "错误：" + err.Message);
                return "";
            }
        }
        #endregion
        #region ToInt
        public static int ToInt(object myobj)
        {
            try
            {
                if (myobj == null || myobj.ToString().Trim() == "")
                    return 0;
                return (int)ToDecimal(myobj.ToString());
            }
            catch //(Exception err)
            {
                //StackTrace st = new StackTrace(new StackFrame(true));
                //StackFrame sf = st.GetFrame(0);
                //PrintToDebug(sf == null ? "" : ("方法[" + sf.GetMethod().Name + "]行[" + sf.GetFileLineNumber() + "]列[" + sf.GetFileColumnNumber() + "]") + "错误：" + err.Message);
                return 0;
            }
        }
        #endregion
        #region ToDemical
        public static decimal ToDecimal(object myobj)
        {
            try
            {
                if (myobj == null || myobj.ToString().Trim() == "")
                    return 0;
                return decimal.Parse(myobj.ToString());
            }
            catch //(Exception err)
            {
                //StackTrace st = new StackTrace(new StackFrame(true));
                //StackFrame sf = st.GetFrame(0);
                //PrintToDebug(sf == null ? "" : ("方法[" + sf.GetMethod().Name + "]行[" + sf.GetFileLineNumber() + "]列[" + sf.GetFileColumnNumber() + "]") + "错误：" + err.Message);
                return 0;
            }
        }
        #endregion
        #region ToBool
        public static bool ToBool(object myobj)
        {
            try
            {
                if (myobj == null || myobj.ToString().Trim() == "")
                    return false;
                return Convert.ToBoolean(myobj.ToString());
            }
            catch //(Exception err)
            {
                //StackTrace st = new StackTrace(new StackFrame(true));
                //StackFrame sf = st.GetFrame(0);
                //PrintToDebug(sf == null ? "" : ("方法[" + sf.GetMethod().Name + "]行[" + sf.GetFileLineNumber() + "]列[" + sf.GetFileColumnNumber() + "]") + "错误：" + err.Message);
                return false;
            }
        }
        #endregion
        #region 时间转化
        #region 秒数转时分秒
        public static string Second2HHmmss(int duration)
        {
            try
            {
                TimeSpan ts = new TimeSpan(0, 0, duration);
                if (ts.Hours > 0)
                    return ts.Hours.ToString() + ":" + ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
                if (ts.Hours == 0 && ts.Minutes > 0)
                    return ts.Minutes.ToString() + ":" + ts.Seconds.ToString();
                if (ts.Hours == 0 && ts.Minutes == 0)
                    return ts.Seconds.ToString();
                return duration.ToString();
            }
            catch 
            {
                return duration.ToString();
            }
        }
        #endregion
        #endregion
        #region PLC地址转化
        #region 欧姆龙
        #region 欧姆龙PLC区域转换代码
        public static string OmronPLCArea2Code(string PLCArea)
        {
            string sCode = "82";
                switch (PLCArea)
                {
                    case "DM":
                        sCode = "82";
                        break;
                    case "CIO":
                        sCode = "B0";
                        break;
                    case "WR":
                        sCode = "B1";
                        break;
                    case "HR":
                        sCode = "B2";
                        break;
                    case "AR":
                        sCode = "B3";
                        break;
                }
                return sCode;
        }
        #endregion
        #endregion
        #endregion
        #endregion
        #region 校验
        #region BCC 异或
        #region 计算（BCC）异或校验值
        public static int BBC(byte[] buf)
        {
            if (buf.Length < 1)
                return 0;
            int result = buf[0];
            int i = 1;
            while (buf.Length > i)
            {
                result = result ^ buf[i];
                i++;
            }
            return result;
        }
        public static int BBC(byte[] buf, int begin, int length)
        {
            if (buf.Length < begin + length)
                return 0;
            int result = buf[begin];
            int i = begin + 1;
            while (buf.Length > i && i - begin < length)
            {
                result = result ^ buf[i];
                i++;
            }
            return result;
        }
        #endregion
        #region 加一个BBC校验和
        public static string AddBBC(string sMsg)
        {
            byte[] buf = string2bytearr2(sMsg);
            int ibbc = BBC(buf, 1, buf.Length - 1);
            return sMsg + " " + Decimal2Hexadecimal(ibbc);
        }
        #endregion
        #endregion
        #region CRC16 循环冗余
        #region 计算（CRC16）循环冗余校验值
        public static string CRC(string sMsg, byte CL = 1, byte CH = 160)
        {
            byte[] data = string2bytearr2(sMsg);

            #region 计算CRC校验值
            byte[] returnVal = new byte[2];
            byte CRC16Lo, CRC16Hi, SaveHi, SaveLo;
            int i, Flag;
            CRC16Lo = 0xFF;
            CRC16Hi = 0xFF;
            //CL = 0x86;
            //CH = 0x68;
            for (i = 0; i < data.Length; i++)
            {
                CRC16Lo = (byte)(CRC16Lo ^ data[i]);//每一个数据与CRC寄存器进行异或
                for (Flag = 0; Flag <= 7; Flag++)
                {
                    SaveHi = CRC16Hi;
                    SaveLo = CRC16Lo;
                    CRC16Hi = (byte)(CRC16Hi >> 1);//高位右移一位
                    CRC16Lo = (byte)(CRC16Lo >> 1);//低位右移一位
                    if ((SaveHi & 0x01) == 0x01)//如果高位字节最后一位为
                    {
                        CRC16Lo = (byte)(CRC16Lo | 0x80);//则低位字节右移后前面补 否则自动补0
                    }
                    if ((SaveLo & 0x01) == 0x01)//如果LSB为1，则与多项式码进行异或
                    {
                        CRC16Hi = (byte)(CRC16Hi ^ CH);
                        CRC16Lo = (byte)(CRC16Lo ^ CL);
                    }
                }
            }
            returnVal[0] = CRC16Hi;//CRC高位
            returnVal[1] = CRC16Lo;//CRC低位
            #endregion

            string sCRC = ReverseString2(bytearr2string2(returnVal, returnVal.Length));
            return sCRC;
        }
        #endregion
        #region 加一个CRC校验和
        public static string AddCRC(string sMsg, byte CL = 1, byte CH = 160)
        {
            string sCRC = CRC(sMsg.Trim(), CL, CH);
            return sMsg.Trim() + " " + sCRC;
        }
        #endregion
        #endregion
        #region 普通校验
        #region 计算普通校验值
        public static int CheckSum(byte[] buf)
        {
            if (buf.Length < 1)
                return 0;
            int result = buf[0];
            int i = 1;
            while (buf.Length > i)
            {
                result = result ^ buf[i];
                i++;
            }
            return result;
        }
        public static int CheckSum(byte[] buf, int begin, int length)
        {
            if (buf.Length < begin + length)
                return 0;
            int result = buf[begin];
            int i = begin + 1;
            while (buf.Length > i && i - begin < length)
            {
                //result = result ^ buf[i];
                result = result + buf[i];
                i++;
            }
            return result;
        }
        #endregion
        #region 加一个校验和
        public static string AddSum(string sMsg)
        {
            byte[] buf = string2bytearr2(sMsg);
            int isum = CheckSum(buf, 1, buf.Length - 1);
            return sMsg + " " + Decimal2Hexadecimal(isum);
        }
        #endregion
        #endregion
        #endregion

        /// 添加SQL条件
        /// <param name="strWhere"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string AppendSQL(string strWhere, string condition)
        {
            if (!strWhere.Equals(string.Empty))
            {
                strWhere += " and ";
            }
            strWhere += condition;
            return strWhere;
        }
    }
}
