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
using static Glide4NetDemo.RecycleView;

namespace Glide4NetDemo
{
    public partial class FrmTestRecycleView : Form
    {
        public FrmTestRecycleView()
        {
            InitializeComponent();
        }

        private void FrmTestRecycleView_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        /// <summary>
        /// 设置数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            ImageAdapter adapter = new ImageAdapter(GetImageList());
            recycleView1.SetAdapter(adapter);
            recycleView1.NotifyDataSetChanged();
        }

        /// <summary>
        /// 图片适配器的holder
        /// </summary>
        public class ImageViewHolder : RecycleView.ViewHolder
        {
            public int Index { set; get; }

            public string ImageUrl { set; get; }

            public ImageViewHolder(Control control) : base(control)
            {

            }

            public override void StartLoad()
            {
                if (this.Control is ItemImage itemImage)
                {
                    itemImage.LoadImage(ImageUrl);
                }
            }
        }

        /// <summary>
        ///  图片的适配器
        /// </summary>
        public class ImageAdapter : RecycleView.RecycleAdapter
        {
            private int index = 0;

            /// <summary>
            /// 图片的地址集合
            /// </summary>
            private List<string> imageUrls;

            public ImageAdapter(List<string> imageUrls)
            {
                this.imageUrls = imageUrls;
            }

            public override int GetItemCount()
            {
                return imageUrls.Count;
            }

            public override void OnBindViewHolder(ViewHolder holder, int position)
            {
                if (holder is ImageViewHolder imageViewHolder)
                {
                    (holder as ImageViewHolder).ImageUrl = imageUrls.ElementAt(position);
                }
            }

            public override ViewHolder OnCreateViewHolder(int ViewType)
            {
                ItemImage item = new ItemImage();
                ImageViewHolder holder = new ImageViewHolder(item);
                holder.Index = index++;
                return holder;
            }
        }


        #region 获取图形的集合列表

        /// <summary>
        /// 获取图形的集合列表
        /// </summary>
        /// <returns></returns>
        private List<string> GetImageList()
        {
            List<string> datas = new List<string>();

            //string familyName, float emSize, GraphicsUnit unit
            //Font font = new Font("宋体", 32, GraphicsUnit.Pixel);

            //string path = @"D:\360downloads\Resource";
            //for (int i = 0; i < 600; i++)
            //{
            //    string realPath = string.Concat(path, @"\", i.ToString(), ".png");

            //    if (!File.Exists(realPath))
            //    {
            //        Bitmap bitmap = TextToBitmap(i.ToString(), font, Rectangle.Empty, Color.Black, Color.White);
            //        bitmap.Save(realPath);
            //        bitmap.Dispose();
            //    }

            //    datas.Add(realPath);
            //}

            for (int i = 0; i < 10000; i++)
            {
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992528&di=b34dfa71c6414bbd84abdd45b072f6c0&imgtype=0&src=http%3A%2F%2Fhbimg.b0.upaiyun.com%2F9fe6ebfd6c663506af064cdc2f6c9e842cc5cc6768ff0-nKHkhV_fw658");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992527&di=b486b1b79505dec7c18116e57ca267c0&imgtype=0&src=http%3A%2F%2Fpic1.win4000.com%2Fwallpaper%2Fe%2F57bff123d2e05.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992527&di=78a36c2c4d990fa9d71d07aa1825f9f2&imgtype=0&src=http%3A%2F%2Fpic1.win4000.com%2Fwallpaper%2F4%2F54740e3b7cc5f.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992527&di=dbe0adf14ea5617c53538c48e618c0cc&imgtype=0&src=http%3A%2F%2Fpic21.nipic.com%2F20120525%2F8956325_100544942000_2.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992527&di=0a3b0d630eae01ace6566fe69c57e248&imgtype=0&src=http%3A%2F%2Fwx2.sinaimg.cn%2Fcrop.0.0.800.449.1000%2Fee36c639gy1fh321yui3pj20m80engvf.jpg");

                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992527&di=01e38620ebdf3314127c0c565b6c6373&imgtype=0&src=http%3A%2F%2F01.minipic.eastday.com%2F20171011%2F20171011095832_49d23dd458b7446249d84fda3d4ea1c1_7.jpeg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992527&di=f0046c99005128be6b99fdc896c8c828&imgtype=0&src=http%3A%2F%2Fpic1.win4000.com%2Fwallpaper%2F0%2F59c1dab039d7f.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992527&di=6467b85d0de8e529d555486781d64d76&imgtype=0&src=http%3A%2F%2Fpic16.nipic.com%2F20110911%2F6106165_160202658152_2.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992526&di=4e956d4b224e933a44f1ec7f3027a798&imgtype=0&src=http%3A%2F%2Fimg.taopic.com%2Fuploads%2Fallimg%2F130603%2F240490-1306030T61248.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992526&di=a95eedef342b2c4506b447a299e00235&imgtype=0&src=http%3A%2F%2Fimg.pconline.com.cn%2Fimages%2Fupload%2Fupc%2Ftx%2Fwallpaper%2F1205%2F18%2Fc1%2F11665832_1337331427403_800x600.jpg");


                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992526&di=38a365bb30b201548a97c72f1390ca8a&imgtype=0&src=http%3A%2F%2Fwww.boruisz.com%2Fimages%2Forygsyzonbxw2zjonzsxo4zomnxa%2FxhBlog%2Fxhpic001%2FM07%2F67%2F30%2FwKhTg1J3QfoEAAAAAAAAAAAAAAA911.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992526&di=e902f765318a0f74484cfc1d8f4af3a1&imgtype=0&src=http%3A%2F%2Fpic27.nipic.com%2F20130128%2F11668207_175147437000_2.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992525&di=340369bec23cf86977e4358b951b2335&imgtype=0&src=http%3A%2F%2Fpic21.nipic.com%2F20120531%2F8297304_192139423131_2.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992525&di=9969dd895593e13e8e12d8bae98bf71a&imgtype=0&src=http%3A%2F%2Fpic75.nipic.com%2Ffile%2F20150816%2F9448607_094939507000_2.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992525&di=af9dc4598bcf9d3e245aaa6f9a2b1eeb&imgtype=0&src=http%3A%2F%2Fpic27.nipic.com%2F20130225%2F8092962_121610670339_2.jpg");


                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992525&di=a1f83ef4b37481064c00f28403036512&imgtype=0&src=http%3A%2F%2Fimg02.tooopen.com%2Fimages%2F20150613%2Ftooopen_sy_130104869369.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992525&di=13b2d105f9647d0c467c7299e6ae2a20&imgtype=0&src=http%3A%2F%2Fpic31.nipic.com%2F20130725%2F1729271_113012262324_2.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992524&di=1a22cc519875f017bb68ac1d125e8249&imgtype=0&src=http%3A%2F%2Fpic54.nipic.com%2Ffile%2F20141201%2F3822951_190204573000_2.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992524&di=3c50ab2b6c85bca727b2e96e0f2d4b92&imgtype=0&src=http%3A%2F%2Fpic32.nipic.com%2F20130823%2F13384934_110129302133_2.jpg");
                datas.Add(@"https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576759992524&di=8bb317d5c60f0b4e5da10338cacbf9e6&imgtype=0&src=http%3A%2F%2Fpic41.nipic.com%2F20140511%2F14735567_151210323144_2.jpg");
            }

            return datas;

        }

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
        #endregion

       
    }
}
