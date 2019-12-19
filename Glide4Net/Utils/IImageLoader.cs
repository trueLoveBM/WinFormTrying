using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glide4Net.Utils
{
    /// <summary>
    /// 图片加载者统一接口
    /// </summary>
    public interface IImageLoader
    {
        /// <summary>
        /// 开始加载图片
        /// </summary>
        /// <param name="Glide"></param>
        void LoadImageAsync(Glide Glide);
    }
}
