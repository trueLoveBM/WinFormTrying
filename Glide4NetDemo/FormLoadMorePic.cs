using Glide4Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glide4NetDemo
{
    public partial class FormLoadMorePic : Form
    {
        private List<string> datas;

        public FormLoadMorePic()
        {
            InitializeComponent();

            flImages.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.flImages_MouseWheel);
            vScrollBar1.ValueChanged += VScrollBar1_ValueChanged;

        }

        private void flImages_MouseWheel(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"x={e.X}  y={e.Y}  Delta={e.Delta}  Height={flImages.Height}  e.Location.X={e.Location.X}  e.Location.y={e.Location.Y}");


            if (e.Delta < 0 && vScrollBar1.Value < vScrollBar1.Maximum)  //向下滑动
            {
                vScrollBar1.Value++;
            }
            else if (e.Delta > 0 && vScrollBar1.Value > 0)
            {
                vScrollBar1.Value--;
            }


            Console.WriteLine($"当前滚动条的Value值={vScrollBar1.Value}");
        }

        private void VScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            int row = vScrollBar1.Value + y;
            Console.WriteLine($"滚动到第{row}行");

            if (row == currentRow || row > MaxRow) return;

            //滚动条向下滚动
            if (row > currentRow)
            {
                Console.WriteLine($"使用消失的第一行控件");
                //找到当前第一行控件
                List<Control> FirstControl = new List<Control>();
                for (int i = 0; i < x; i++)
                {
                    FirstControl.Add(flImages.Controls[i]);
                }


                //找到新要显示的一行数据
                var nextDatas = datas.GetRange((row - 1) * x, x);


                //挪除第一行
                foreach (var item in FirstControl)
                {
                    flImages.Controls.Remove(item);
                }



                //将挪除的第一行加到最后一行
                for (int i = 0; i < FirstControl.Count; i++)
                {
                    var item = FirstControl[i];
                    Glide.With(this.Handle).Load(nextDatas[i]).Into(item as PictureBox);
                    flImages.Controls.Add(item);
                }


                ////继续加载图片
                //for (int i = 0; i < x; i++)
                //{
                //    var item = datas.ElementAt(x * y + i);
                //    //重复获取控件   TODO
                //    int index = (row / y + i);
                //    PictureBox pictureBox = flImages.Controls[index] as PictureBox;

                //    //将这个放到最后一个
                //    flImages.Controls.SetChildIndex(pictureBox, x * y);

                //    //加载图片
                //    Glide.With(this.Handle).Load(item).Into(pictureBox);
                //}
                currentRow = row;
            }


            //滚动条向上滚动
            if (row < currentRow)
            {
                Console.WriteLine($"使用消失的第一行控件");

                //找到当前最后一行控件
                List<Control> LastControl = new List<Control>();
                for (int i = flImages.Controls.Count - 1; i > flImages.Controls.Count - 1 - x; i--)
                {
                    LastControl.Add(flImages.Controls[i]);
                }

                //找到新要显示的一行数据
                var preDatas = datas.GetRange((row - y) * x, x);

                //挪除最后一行
                foreach (var item in LastControl)
                {
                    flImages.Controls.Remove(item);
                }

                //将挪除的最后一行加到第一行
                for (int i = 0; i < x; i++)
                {
                    var control = LastControl[i];
                    Glide.With(this.Handle).Load(preDatas[i]).Into(control as PictureBox);
                    flImages.Controls.Add(control);
                    flImages.Controls.SetChildIndex(control, i);
                }
                currentRow = row;
            }

            //滑动到指定位置
            flImages.AutoScrollPosition = new Point(0, row > y ? row * 100 : 0);
        }

        int x;// (int)Math.Floor(flImages.Width / 100f);
        int y; //(int)Math.Ceiling(flImages.Height / 100f);
        int currentRow;
        int MaxRow;

        private void btnLoad_Click(object sender, EventArgs e)
        {
            datas = getImageList();

            int i = 0;
            //获取当前可加载的个数
            x = 6;// (int)Math.Floor(flImages.Width / 100f);
            y = 6; //(int)Math.Ceiling(flImages.Height / 100f);
            currentRow = y;
            int maxNum = x * y;
            MaxRow = (int)Math.Ceiling(datas.Count * 1f / x);
            foreach (var item in datas)
            {
                if (i == maxNum)
                {
                    //vScrollBar1.Maximum = 100 * ((int)Math.Ceiling(datas.Count / x * 1f) - y);
                    //vScrollBar1.Minimum = 100;

                    vScrollBar1.Maximum = MaxRow;
                    break;
                }

                PictureBox image = new PictureBox();
                image.Width = 100;
                image.Height = 100;
                image.SizeMode = PictureBoxSizeMode.StretchImage;
                flImages.Controls.Add(image);
                image.MouseDown += Image_MouseDown;
                image.MouseMove += Image_MouseMove;
                image.MouseUp += Image_MouseUp;
                i++;
                //加载图片
                Glide.With(this.Handle).Load(item).Into(image);
            }

        }



        #region 图片拖动换位实现
        bool leftButtomDown = false;
        bool leftButtonMove = false;

        /// <summary>
        /// 图片的鼠标落下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                leftButtomDown = true;
            }
        }

        /// <summary>
        /// 图片的拖动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                leftButtonMove = true;
            }
        }

        /// <summary>
        /// 鼠标抬起
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                //如果拖动照片并抬起，触发拖动事件，完成换位
                if (leftButtomDown && leftButtonMove)
                {
                    flImages.DoDragDrop(sender, DragDropEffects.All);
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                leftButtomDown = false;
                leftButtonMove = false;
            }
        }

        /// <summary>
        /// 完成图片的换位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flImages_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox picture = (PictureBox)e.Data.GetData(typeof(PictureBox));

            Point p = flImages.PointToClient(new Point(e.X, e.Y));
            Control control = flImages.GetChildAtPoint(p);
            int index = flImages.Controls.GetChildIndex(control, false);
            flImages.Controls.SetChildIndex(picture, index);
        }

        /// <summary>
        /// 注册换位事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flImages_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
        #endregion

        private List<string> getImageList()
        {
            List<string> datas = new List<string>();

            //string familyName, float emSize, GraphicsUnit unit
            Font font = new Font("宋体", 32, GraphicsUnit.Pixel);

            string path = @"D:\360downloads\Resource";
            for (int i = 0; i < 600; i++)
            {
                string realPath = string.Concat(path, @"\", i.ToString(), ".png");

                if (!File.Exists(realPath))
                {
                    Bitmap bitmap = TextToBitmap(i.ToString(), font, Rectangle.Empty, Color.Black, Color.White);
                    bitmap.Save(realPath);
                    bitmap.Dispose();
                }

                datas.Add(realPath);
            }
            return datas;

        }


        /// <summary>
        /// 图片的滑动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flImages_Scroll(object sender, ScrollEventArgs e)
        {
            //Point p = flImages.PointToClient(new Point(0, 0));  //起始子view的下标
            //Control control = flImages.GetChildAtPoint(p);
            //int index = flImages.Controls.GetChildIndex(control, false);



            //Point p2 = flImages.PointToClient(new Point(flImages.Width, flImages.Height));  //终止子view的下标
            //Control controlEng = flImages.GetChildAtPoint(p2);
            //int indexEng = flImages.Controls.GetChildIndex(controlEng, false);

        }


        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {


        }

        private void btnLoadNextRow_Click(object sender, EventArgs e)
        {
            int row = currentRow + 1;
            if (row > currentRow)
            {
                //继续加载图片
                for (int i = 0; i < x; i++)
                {
                    var item = datas.ElementAt(x * y + i);
                    //重复获取控件   TODO
                    int index = (row / y + i);
                    PictureBox pictureBox = flImages.Controls[index] as PictureBox;

                    //将这个放到最后一个
                    flImages.Controls.SetChildIndex(pictureBox, x * y);

                    //加载图片
                    Glide.With(this.Handle).Load(item).Into(pictureBox);
                }
                currentRow = row;
            }

            //滑动到指定位置
            flImages.AutoScrollPosition = new Point(0, row * 100);
        }

        //定义一个方法
        /// <summary>
        /// 把文字转换才Bitmap
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="rect">用于输出的矩形，文字在这个矩形内显示，为空时自动计算</param>
        /// <param name="fontcolor">字体颜色</param>
        /// <param name="backColor">背景颜色</param>
        /// <returns></returns>
        private Bitmap TextToBitmap(string text, Font font, Rectangle rect, Color fontcolor, Color backColor)
        {
            Graphics g;
            Bitmap bmp;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            if (rect == Rectangle.Empty)
            {
                bmp = new Bitmap(1, 1);
                g = Graphics.FromImage(bmp);
                //计算绘制文字所需的区域大小（根据宽度计算长度），重新创建矩形区域绘图
                SizeF sizef = g.MeasureString(text, font, PointF.Empty, format);

                int width = (int)(sizef.Width + 1);
                int height = (int)(sizef.Height + 1);
                rect = new Rectangle(0, 0, width, height);
                bmp.Dispose();

                bmp = new Bitmap(width, height);
            }
            else
            {
                bmp = new Bitmap(rect.Width, rect.Height);
            }

            g = Graphics.FromImage(bmp);

            //使用ClearType字体功能
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.FillRectangle(new SolidBrush(backColor), rect);
            g.DrawString(text, font, Brushes.Black, rect, format);
            return bmp;
        }

        private void btnRecycleView_Click(object sender, EventArgs e)
        {

        }
    }

}
