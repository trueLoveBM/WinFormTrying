using NewLife.Caching;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glide4Net.Utils
{
    public class CacheUtils
    {
        #region 私有成员变量

        /// <summary>
        /// 默认缓存
        /// </summary>
        internal ICache _cache;

        #endregion

        #region 单例
        private static Lazy<CacheUtils> lazy = new Lazy<CacheUtils>(() => { return new CacheUtils(); });
        private CacheUtils()
        {
            _cache = Cache.Default;
            _cache.Expire = 30;
        }
        public static CacheUtils Instance { get { return lazy.Value; } }
        #endregion


        /// <summary>
        /// 添加缓存
        /// 没有则添加，有则更新
        /// </summary>
        public bool SaveBitmapCache(string key, Bitmap bitmap)
        {
            return _cache.Add<Bitmap>(key, bitmap);
        }


        /// <summary>
        /// 尝试从缓存中读取对象
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Bitmap GetBitmapFromCache(string key)
        {
            return _cache.Get<Bitmap>(key);
        }


        /// <summary>
        /// 判断是否存在图片缓存
        /// </summary>
        /// <returns></returns>
        public bool HadBitmapCache(string key)
        {
            return _cache.Keys.Contains(key);
        }


        /// <summary>
        /// 清除缓存
        /// </summary>
        public void ClearCache()
        {
            _cache.Remove(_cache.Keys.ToArray());
        }
    }
}
