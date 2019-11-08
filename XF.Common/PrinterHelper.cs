using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace XF.Common
{
    public class PrinterHelper
    {
        //生成二维码图片代码
        public static void GetPrintPicture(Image image, Graphics g)
        {
            //int height = 5;
            Font font = new Font("宋体", 10f);
            Brush brush = new SolidBrush(Color.Black);
            g.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle destRect = new Rectangle(50, 40, image.Width, image.Height);
            g.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

            //int interval = 15;
            //int pointX = 5;
            //Rectangle destRect = new Rectangle(200, 40, image.Width, image.Height);
            //g.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);

            //height += 8;
            //RectangleF layoutRectangle = new RectangleF(pointX, height, 260f, 85f);
            //g.DrawString("条码号:", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("物料图号:", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("型号规格:", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("物料名称:", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("数量:", font, brush, layoutRectangle);


            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("生产批号:", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("生产日期:", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("检验:", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("供应商:", font, brush, layoutRectangle);

            //pointX = 50;
            //height = 13;
            //layoutRectangle = new RectangleF(pointX, height, 260f, 85f);
            //g.DrawString("180514044104187|8ZTD.282.353.8|1500|D015772680", new Font("宋体", 8f), brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("8ZTD.282.353.8", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("NM1-63S/3P", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("弹簧1.3N", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("1500", font, brush, layoutRectangle);


            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("180514044", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("2018-5-24", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("WZ 001", font, brush, layoutRectangle);

            //height += interval;
            //layoutRectangle = new RectangleF(pointX, height, 230f, 85f);
            //g.DrawString("温州天力弹簧有限公司", font, brush, layoutRectangle);
        }
    }
}
