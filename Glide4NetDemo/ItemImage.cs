using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Glide4Net;

namespace Glide4NetDemo
{
    public partial class ItemImage : UserControl
    {
        public ItemImage()
        {
            InitializeComponent();
        }

        public void LoadImage(string url)
        {
            Glide
                .With(this.Handle)
                .Load(url)
                //.Overrid(80, 80)
                .Into(pictureBox1);
        }
    }
}
