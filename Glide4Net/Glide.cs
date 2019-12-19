using Glide4Net.Utils;
using NewLife.Caching;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glide4Net
{
    /// <summary>
    /// 图片加载框架
    /// 缓存使用框架newlife.Cache V1.0.6791.1266
    /// 使用的缓存目前默认是内存缓存
    /// 
    /// 图片处理框架是ImageMagick，来进行图片的裁剪
    /// </summary>
    public class Glide
    {
        #region 私有及程序集内部变量
        /// <summary>
        /// 要显示的控件的句柄
        /// </summary>
        internal IntPtr _handle;

        /// <summary>
        /// 照片想要显示的控件
        /// </summary>
        internal PictureBox _showPicControl;


        /// <summary>
        /// 图片的路径
        /// 可能是Ftp路径
        /// 可能是Http路径
        /// 可能是本地路径
        /// </summary>
        internal string _imgurl;

        /// <summary>
        /// 指定的宽度
        /// </summary>
        internal int _overrrideWidth = -1;

        /// <summary>
        /// 指定的高度
        /// </summary>
        internal int _overrrideHeight = -1;

        /// <summary>
        /// 用来缓存图片的key
        /// </summary>
        internal string CacheKey
        {
            get { return _imgurl + _overrrideWidth + _overrrideHeight; }
        }

        /// <summary>
        /// 展位图
        /// </summary>
        internal string _placeHolderUrl = "https://dss0.bdstatic.com/70cFuHSh_Q1YnxGkpoWK1HF6hhy/it/u=3345138084,3221952596&fm=26&gp=0.jpg";

        /// <summary>
        /// 错误图片的地址
        /// </summary>
        internal string _errorPicUrl = "https://timgsa.baidu.com/timg?image&quality=80&size=b9999_10000&sec=1576561083530&di=3499b759afd9a8424ecca0ce484b5a7d&imgtype=0&src=http%3A%2F%2Fbpic.588ku.com%2Felement_origin_min_pic%2F00%2F56%2F29%2F4556d9f8022935e.jpg";
        #endregion

        private Glide()
        {

        }

        /// <summary>
        /// 开启一个Glide任务
        /// </summary>
        /// <param name="control"></param>
        public static Glide With(IntPtr Handle)
        {
            Glide glide = new Glide();
            glide._handle = Handle;
            return glide;
        }

        /// <summary>
        /// 从一个路径或者url中加载图片文件，默认是http路径
        /// </summary>
        /// <param name="url">路径</param>
        /// <param name="sourceType">指定的图片来源</param>
        /// <returns></returns>
        public Glide Load(string url)
        {
            this._imgurl = url;
            return this;
        }

        /// <summary>
        /// 指定图片显示的大小
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public Glide Overrid(int width, int height)
        {
            this._overrrideWidth = width;
            this._overrrideHeight = height;
            return this;
        }

        /// <summary>
        /// 设置占位图
        /// </summary>
        /// <param name="holderPicUrl"></param>
        /// <returns></returns>
        public Glide PlaceHolder(string holderPicUrl)
        {
            this._placeHolderUrl = holderPicUrl;
            return this;
        }

        /// <summary>
        /// 加载错误显示图片
        /// </summary>
        /// <param name="ErrorHolder"></param>
        /// <returns></returns>
        public Glide ErrorHolder(string ErrorPicUrl)
        {
            this._errorPicUrl = ErrorPicUrl;
            return this;
        }

        /// <summary>
        /// 将照片显示到指定控件中
        /// </summary>
        /// <param name="control">照片想要显示的控件</param>
        /// <returns></returns>
        public Glide Into(PictureBox control)
        {
            this._showPicControl = control;
            //开启任务
            LocalImageLoader.Instance.LoadImageAsync(this);
            return this;
        }

        /// <summary>
        /// 是否需要缩略图
        /// true表示需要缩略图片
        /// false表示不需要
        /// </summary>
        internal bool NeedThumbnail
        {
            get
            {
                return _overrrideHeight != -1 && _overrrideHeight != -1;
            }
        }
    }
}

