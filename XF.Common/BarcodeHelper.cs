using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZXing.Common;
using System.Drawing;
using ZXing;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using System.Drawing.Imaging;

namespace XF.Common
{
    public class BarcodeHelper
    {
        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static Bitmap Generate1(string text, int width, int height)
        {
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            QrCodeEncodingOptions options = new QrCodeEncodingOptions()
            {
                DisableECI = true,//设置内容编码
                CharacterSet = "UTF-8",  //设置二维码的宽度和高度
                Width = width,
                Height = height,
                Margin = 0//设置二维码的边距,单位不是固定像素
            };

            writer.Options = options;
            Bitmap map = writer.Write(text);
            return map;
        }

        /// <summary>
        /// 生成一维条形码
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static Bitmap Generate2(string text, int width, int height)
        {
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }
            BarcodeWriter writer = new BarcodeWriter();
            //使用ITF 格式，不能被现在常用的支付宝、微信扫出来
            //如果想生成可识别的可以使用 CODE_128 格式
            //writer.Format = BarcodeFormat.ITF;
            writer.Format = BarcodeFormat.CODE_39;
            EncodingOptions options = new EncodingOptions()
            {
                Width = width,
                Height = height,
                Margin = 2
            };
            writer.Options = options;
            Bitmap map = writer.Write(text);
            return map;
        }

        /// <summary>
        /// 生成带Logo的二维码
        /// </summary>
        /// <param name="text">内容</param>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        public static Bitmap Generate3(string text, int width, int height)
        {
            //Logo 图片
            //string logoPath = System.AppDomain.CurrentDomain.BaseDirectory + @"C:\Users\夏仁望\Desktop\Doc\pic\保存.png";
            string logoPath = @"C:\Users\夏仁望\Desktop\Doc\pic\logo.ico";
            Bitmap logo = new Bitmap(logoPath);
            //构造二维码写码器
            MultiFormatWriter writer = new MultiFormatWriter();
            Dictionary<EncodeHintType, object> hint = new Dictionary<EncodeHintType, object>();
            hint.Add(EncodeHintType.CHARACTER_SET, "UTF-8");
            hint.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.H);
            //hint.Add(EncodeHintType.MARGIN, 2);//旧版本不起作用，需要手动去除白边

            //生成二维码 
            BitMatrix bm = writer.encode(text, BarcodeFormat.QR_CODE, width + 30, height + 30, hint);
            bm = deleteWhite(bm);
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            Bitmap map = barcodeWriter.Write(bm);

            //获取二维码实际尺寸（去掉二维码两边空白后的实际尺寸）
            int[] rectangle = bm.getEnclosingRectangle();

            //计算插入图片的大小和位置
            int middleW = Math.Min((int)(rectangle[2] / 3), logo.Width);
            int middleH = Math.Min((int)(rectangle[3] / 3), logo.Height);
            int middleL = (map.Width - middleW) / 2;
            int middleT = (map.Height - middleH) / 2;

            Bitmap bmpimg = new Bitmap(map.Width, map.Height, PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(bmpimg))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.DrawImage(map, 0, 0, width, height);
                //白底将二维码插入图片
                g.FillRectangle(Brushes.White, middleL, middleT, middleW, middleH);
                g.DrawImage(logo, middleL, middleT, middleW, middleH);
            }
            return bmpimg;
        }

        /// <summary>
        /// 删除默认对应的空白
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        private static BitMatrix deleteWhite(BitMatrix matrix)
        {
            int[] rec = matrix.getEnclosingRectangle();
            int resWidth = rec[2] + 1;
            int resHeight = rec[3] + 1;

            BitMatrix resMatrix = new BitMatrix(resWidth, resHeight);
            resMatrix.clear();
            for (int i = 0; i < resWidth; i++)
            {
                for (int j = 0; j < resHeight; j++)
                {
                    if (matrix[i + rec[0], j + rec[1]])
                        resMatrix[i, j] = true;
                }
            }
            return resMatrix;
        }

        /// <summary>
        /// 生成物料包装条码，后续将条码相关信息封装成条码Model
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pt"></param>
        /// <param name="barcodeText"></param>
        /// <param name="componentCode"></param>
        /// <param name="componentName"></param>
        /// <param name="supplierName"></param>
        /// <param name="componentPCS"></param>
        /// <param name="barcodeSize"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        public static void DrawComponentBarcodeImage(Graphics g, object pt,string barcodeText,string componentCode ,string componentName,string supplierName,int componentPCS,int barcodeSize,int positionX,int positionY)
        {  
            //笔画单位
            g.PageUnit = GraphicsUnit.Millimeter;
            //二维码生成
            Image barcode = BarcodeHelper.Generate1(barcodeText.Trim() + "|" + componentCode + "|" + componentPCS.ToString() + "&", barcodeSize, barcodeSize);
            //画笔设置
            Pen p = new Pen(Color.Black, 0.2f);
            //文本格式设置
            Font font = new Font("微软雅黑", 9f, FontStyle.Bold);
            //文字排版
            StringFormat fmt = new StringFormat();
            fmt.LineAlignment = StringAlignment.Near;
            fmt.FormatFlags = StringFormatFlags.LineLimit;
            //标签生成
            if ((PrintTemplet)pt == PrintTemplet.Vertical)
            {
                //绘制文本信息
                g.DrawString("条码：", font, p.Brush, positionX + 5, positionY + 2);
                g.DrawString("图号：", font, p.Brush, positionX + 5, positionY + 10);
                g.DrawString("名称：", font, p.Brush, positionX + 5, positionY + 15);
                g.DrawString("供方：", font, p.Brush, positionX + 5, positionY + 24);
                g.DrawString("数量：", font, p.Brush, positionX + 5, positionY + 33);
                Rectangle r = new Rectangle(positionX + 15, positionY + 2, 30, 18);
                g.DrawString(barcodeText, font, p.Brush, r, fmt);
                r = new Rectangle(positionX + 15, positionY + 10, 30, 18);
                g.DrawString(componentCode, font, p.Brush, r, fmt);
                r = new Rectangle(positionX + 15, positionY + 15, 30, 18);
                g.DrawString(componentName, font, p.Brush, r, fmt);
                r = new Rectangle(positionX + 15, positionY + 24, 30, 18);
                g.DrawString(supplierName, font, p.Brush, r, fmt);
                r = new Rectangle(positionX + 15, positionY + 33, 30, 18);
                g.DrawString(componentPCS.ToString(), font, p.Brush, r, fmt);
                //绘制二维码
                g.DrawImage(barcode, positionX + 10, positionY + 37);
            }
            else if ((PrintTemplet)pt == PrintTemplet.Horizontal)
            {
                //绘制文本信息
                g.DrawString("条码：", font, p.Brush, positionX + 2, positionY + 5);
                g.DrawString("图号：", font, p.Brush, positionX + 2, positionY + 10);
                g.DrawString("名称：", font, p.Brush, positionX + 2, positionY + 15);
                g.DrawString("供方：", font, p.Brush, positionX + 2, positionY + 27);
                g.DrawString("数量：", font, p.Brush, positionX + 2, positionY + 38);
                Rectangle r = new Rectangle(positionX + 12, positionY + 5, 49, 5);
                g.DrawString(barcodeText,font, p.Brush, r, fmt);
                r = new Rectangle(positionX + 12, positionY + 10, 49, 5);
                g.DrawString(componentCode, font, p.Brush, r, fmt);
                r = new Rectangle(positionX + 12, positionY + 15, 22, 13);
                g.DrawString(componentName, font, p.Brush, r, fmt);
                r = new Rectangle(positionX + 12, positionY + 27, 22, 13);
                g.DrawString(supplierName, font, p.Brush, r, fmt);
                r = new Rectangle(positionX + 12, positionY + 38, 24, 8);
                g.DrawString(componentPCS.ToString(), font, p.Brush, r, fmt);
                //绘制二维码
                g.DrawImage(barcode, positionX + 34, positionY + 15);
            }
            ////绘制边框
            //g.DrawLine(p, positionX, positionY, positionX + width, positionY);
            //g.DrawLine(p, positionX, positionY, positionX, positionY + height);
            //g.DrawLine(p, positionX + width, positionY, positionX + width, positionY + height);
            //g.DrawLine(p, positionX, positionY + height, positionX + width, positionY + height);
        }

        /// <summary>
        /// 生成物料框条码，后续将条码相关信息封装成条码Model
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pt"></param>
        /// <param name="barcodeText"></param>
        /// <param name="componentCode"></param>
        /// <param name="componentName"></param>
        /// <param name="supplierName"></param>
        /// <param name="componentPCS"></param>
        /// <param name="barcodeSize"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        public static void DrawFrameBarcodeImage(Graphics g, string barcodeText, int positionX, int positionY)
        {
            //笔画单位
            g.PageUnit = GraphicsUnit.Millimeter;
            ////图片宽高
            //int width = 65;
            //int height = 45;
            //二维码生成
            Image barcode = BarcodeHelper.Generate2(barcodeText.Trim(), 245, 100);
            //画笔设置
            Pen p = new Pen(Color.Black, 0.2f);
            //标签生成
            //绘制二维码
            g.DrawImage(barcode, positionX, positionY + 10);
            ////绘制边框
            //g.DrawLine(p, positionX, positionY, positionX + width, positionY);
            //g.DrawLine(p, positionX, positionY, positionX, positionY + height);
            //g.DrawLine(p, positionX + width, positionY, positionX + width, positionY + height);
            //g.DrawLine(p, positionX, positionY + height, positionX + width, positionY + height);
        }

        /// <summary>
        /// 生成单物料条码，后续将条码相关信息封装成条码Model
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pt"></param>
        /// <param name="barcodeText"></param>
        /// <param name="componentCode"></param>
        /// <param name="componentName"></param>
        /// <param name="supplierName"></param>
        /// <param name="componentPCS"></param>
        /// <param name="barcodeSize"></param>
        /// <param name="positionX"></param>
        /// <param name="positionY"></param>
        public static void DrawSingleBarcodeImage(Graphics g, string componentCode, string componentName, int positionX, int positionY)
        {
            int width = 65;
            int height = 45;
            int barcodeSize = 120;
            //笔画单位
            g.PageUnit = GraphicsUnit.Millimeter;
            //二维码生成
            Image barcode = BarcodeHelper.Generate1(componentCode.Trim() + "&", barcodeSize, barcodeSize);
            //画笔设置
            Pen p = new Pen(Color.Black, 0.2f);
            //文本格式设置
            Font font = new Font("微软雅黑", 9f, FontStyle.Bold,GraphicsUnit.Pixel);
            //文字排版
            StringFormat fmt = new StringFormat();
            fmt.LineAlignment = StringAlignment.Near;
            fmt.FormatFlags = StringFormatFlags.LineLimit;
            fmt.Alignment = StringAlignment.Center;
            //标签生成
            //绘制文本信息
            Rectangle r = new Rectangle(positionX, positionY + 35, 65, 5);
            g.DrawString("图号：" + componentCode, font, p.Brush, r, fmt);
            r = new Rectangle(positionX, positionY + 40, 65, 5);
            g.DrawString("名称：" + componentName, font, p.Brush, r,fmt);
            //绘制二维码
            g.DrawImage(barcode,positionX+17, positionY+2);

            //绘制边框
            g.DrawLine(p, positionX, positionY, positionX + width, positionY);
            g.DrawLine(p, positionX, positionY, positionX, positionY + height);
            g.DrawLine(p, positionX + width, positionY, positionX + width, positionY + height);
            g.DrawLine(p, positionX, positionY + height, positionX + width, positionY + height);
        }

        /// <summary>
        /// 匹配区域调整文字大小
        /// </summary>
        /// <param name="f"></param>
        /// <param name="text"></param>
        /// <param name="r"></param>
        public static Font RectangleAdapt(Font font ,string text,Rectangle r,Graphics g)
        {
            Font f = font;
            float fontSize = font.Size;
            SizeF sf = g.MeasureString(text, f);
            while(sf.Height*sf.Width>r.Width*r.Height)
            {
                fontSize -= 0.1f;
                f = new Font(font.FontFamily.Name, fontSize, font.Style, GraphicsUnit.Pixel);
                sf = g.MeasureString(text, f);
            }
            return f;
        }
    }
}
