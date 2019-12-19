using Glide4Net;
using Glide4Net.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glide4NetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }

        /// <summary>
        /// 加载本地图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadLocalFile_Click(object sender, EventArgs e)
        {
            Glide.With(this.Handle).Load(@"D:\360MoveData\Users\zdt\Desktop\372edfeb74c3119b666237bd4af92be.jpg").Overrid(100, 100).Into(pictureBox1);
        }

        private void btnOpenMulity_Click(object sender, EventArgs e)
        {
            new FormLoadMorePic().ShowDialog();
        }

        private void btnRecycleView_Click(object sender, EventArgs e)
        {
            new FrmTestRecycleView().Show();
        }

        private void btnClearCache_Click(object sender, EventArgs e)
        {
            CacheUtils.Instance.ClearCache();
            GC.Collect();
        }
    }
}
