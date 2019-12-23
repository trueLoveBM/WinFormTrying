using ImageMagick;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Glide4Net.Utils
{
    /// <summary>
    /// 本地图片加载者
    /// </summary>
    internal class LocalImageLoader : IImageLoader
    {
        #region 单例
        private static Lazy<LocalImageLoader> lazy = new Lazy<LocalImageLoader>(() => { return new LocalImageLoader(); });

        public static LocalImageLoader Instance { get { return lazy.Value; } }

        private LocalImageLoader() { }
        #endregion
        /// <summary>
        /// 开始加载图片
        /// </summary>
        /// <param name="Glide"></param>
        public async void LoadImageAsync(Glide Glide)
        {
            //将图片的原始地址放到tag中进行保存
            Glide._showPicControl.Tag = Glide._imgurl;
            //加载占位图
            Bitmap placeHolderBitmap = null;
            if (CacheUtils.Instance.HadBitmapCache(Glide._placeHolderUrl))
            {
                XTrace.Log.Write(LogLevel.Debug, $"从缓存中读取到占位图对象,占位图路径为{Glide._placeHolderUrl},宽为{Glide._overrrideWidth},高为{Glide._overrrideHeight}");
                placeHolderBitmap = CacheUtils.Instance.GetBitmapFromCache(Glide._placeHolderUrl);
            }
            else
            {
                placeHolderBitmap = await Task.Factory.StartNew<Bitmap>(() =>
                 {
                     MagickImage magick = new MagickImage(Glide._placeHolderUrl);
                     if (Glide.NeedThumbnail)
                     {
                         //进行压缩
                         magick.Quality = 50;
                         //进行尺寸调整
                         //magick.Resize(Glide._overrrideWidth, Glide._overrrideHeight);
                         //将图片进行裁剪
                         //magick.Crop(Glide._overrrideWidth, Glide._overrrideHeight);
                         //将图片进行缩放
                         magick.Scale(Glide._overrrideWidth, Glide._overrrideHeight);

                     }
                     Bitmap Bitmap = magick.ToBitmap();
                     //将图片加入缓存
                     CacheUtils.Instance.SaveBitmapCache(Glide._placeHolderUrl + Glide._overrrideWidth + Glide._overrrideHeight, Bitmap);
                     return Bitmap;
                 });

                //判断当前的图片要加载的地址与将要加载的地址是否一致
                if (Glide._showPicControl.Tag.ToString() != Glide._imgurl)
                {
                    //Console.WriteLine("目标图与想要加载图不一致,已经返回,");
                    return;
                }
            }
            Glide._showPicControl.Image = placeHolderBitmap;


            //加载图片
            Bitmap image = null;
            if (CacheUtils.Instance.HadBitmapCache(Glide.CacheKey))
            {
                XTrace.Log.Write(LogLevel.Debug, $"从缓存中读取到Bitmap对象,原路径为{Glide._imgurl},宽为{Glide._overrrideWidth},高为{Glide._overrrideHeight}");
                image = CacheUtils.Instance.GetBitmapFromCache(Glide.CacheKey);
            }
            else
            {
                image = await Task.Factory.StartNew<Bitmap>(() =>
               {
                   try
                   {
                       if (CacheUtils.Instance.HadBitmapCache(Glide.CacheKey))
                       {
                           XTrace.Log.Write(LogLevel.Debug, $"从缓存中读取到Bitmap对象,原路径为{Glide._imgurl},宽为{Glide._overrrideWidth},高为{Glide._overrrideHeight}");
                           return CacheUtils.Instance.GetBitmapFromCache(Glide.CacheKey);
                       }
                       else
                       {
                           MagickImageInfo info = new MagickImageInfo(Glide._imgurl);
                           MagickImage magick = new MagickImage(Glide._imgurl);
                           if (Glide.NeedThumbnail)
                           {
                               //进行压缩
                               magick.Quality = 75;
                               //进行尺寸调整
                               //magick.Resize(Glide._overrrideWidth, Glide._overrrideHeight);
                               //将图片进行裁剪
                               //magick.Crop(Glide._overrrideWidth, Glide._overrrideHeight);
                               //将图片进行缩放
                               magick.Scale(Glide._overrrideWidth, Glide._overrrideHeight);

                           }
                           Bitmap Bitmap = magick.ToBitmap();
                           //将图片加入缓存
                           CacheUtils.Instance.SaveBitmapCache(Glide.CacheKey, Bitmap);
                           return Bitmap;
                       }

                   }
                   catch (Exception ex)
                   {
                       XTrace.Log.Write(LogLevel.Error, "加载图片出错,原因:" + ex.Message);
                       return null;
                   }
               });
            }

            //判断当前的图片要加载的地址与将要加载的地址是否一致
            if (Glide._showPicControl.Tag.ToString() != Glide._imgurl)
            {
                //Console.WriteLine("目标图与想要加载图不一致,已经返回,");
                return;
            }

            if (image == null)  //加载图片出错，则显示错误占位图
            {
                Bitmap errorImage = null;
                if (CacheUtils.Instance.HadBitmapCache(Glide._errorPicUrl))
                {
                    XTrace.Log.Write(LogLevel.Debug, $"从缓存中读取到错误图对象,占位图路径为{Glide._errorPicUrl},宽为{Glide._overrrideWidth},高为{Glide._overrrideHeight}");
                    errorImage = CacheUtils.Instance.GetBitmapFromCache(Glide._errorPicUrl);
                }
                {
                    errorImage = await Task.Factory.StartNew<Bitmap>(() =>
                    {
                        MagickImage magick = new MagickImage(Glide._errorPicUrl);
                        if (Glide.NeedThumbnail)
                        {
                            //进行压缩
                            magick.Quality = 75;
                            //进行尺寸调整
                            //magick.Resize(Glide._overrrideWidth, Glide._overrrideHeight);
                            //将图片进行裁剪
                            //magick.Crop(Glide._overrrideWidth, Glide._overrrideHeight);
                            //将图片进行缩放
                            magick.Scale(Glide._overrrideWidth, Glide._overrrideHeight);

                        }
                        Bitmap Bitmap = magick.ToBitmap();
                        //将图片加入缓存
                        CacheUtils.Instance.SaveBitmapCache(Glide._errorPicUrl + Glide._overrrideWidth + Glide._overrrideHeight, Bitmap);
                        return Bitmap;
                    });
                }

                //判断当前的图片要加载的地址与将要加载的地址是否一致
                if (Glide._showPicControl.Tag.ToString() != Glide._imgurl)
                {
                    //Console.WriteLine("目标图与想要加载图不一致,已经返回");
                    return;
                }
                Glide._showPicControl.Image = errorImage;
            }
            else
                Glide._showPicControl.Image = image;
        }
    }
}
