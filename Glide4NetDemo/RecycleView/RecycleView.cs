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
using System.Diagnostics;

namespace Glide4NetDemo
{
    public partial class RecycleView : UserControl
    {


        #region 私有变量

        /// <summary>
        /// 监听方法的执行时间
        /// </summary>
        private Stopwatch _Stopwatch;

        private RecycleAdapter _Adapter;

        /// <summary>
        /// 每行个数
        /// </summary>
        private int _Column;

        /// <summary>
        /// 初始化
        /// </summary>
        private int _InitRow;

        /// <summary>
        /// 当前的显示行
        /// </summary>
        private int _CurrentRow;

        /// <summary>
        /// 当前数据所能显示的最大行数
        /// </summary>
        private int _MaxRow;

        /// <summary>
        /// ViewHolder集合
        /// </summary>
        private List<ViewHolder> _ViewHolderList;
        #endregion

        #region 构造函数
        public RecycleView()
        {
            InitializeComponent();
        }
        #endregion

        #region 生命周期事件
        private void RecycleView_Load(object sender, EventArgs e)
        {
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.flContent_MouseWheel);
            this.vSBar.ValueChanged += VSBar_ValueChanged;
            //初始化监听
            _Stopwatch = new Stopwatch();
        }

        #endregion

        #region 事件

        /// <summary>
        /// 内容控件的滚轮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flContent_MouseWheel(object sender, MouseEventArgs e)
        {

            if (e.Delta < 0 && vSBar.Value < vSBar.Maximum)  //向下滑动
            {
                vSBar.Value++;
            }
            else if (e.Delta > 0 && vSBar.Value > 0)
            {
                vSBar.Value--;
            }
        }


        /// <summary>
        /// 滚动条的滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VSBar_ValueChanged(object sender, EventArgs e)
        {
            int row = vSBar.Value + _InitRow;
            //Console.WriteLine($"滚动到第{row}行");

            if (row == _CurrentRow || row > _MaxRow) return;

            //滚动条向下滚动
            if (row > _CurrentRow)
            {
                Console.WriteLine("开始监听方法下滑");
                _Stopwatch.Start();



                //找到一行控件所属的ViewHolder
                List<ViewHolder> Firstholders = _ViewHolderList.GetRange(0, _Column);


                //挪除第一行
                Firstholders.ForEach(m => flContent.Controls.Remove(m.Control));

                //挪除ViewHolder
                _ViewHolderList.RemoveRange(0, _Column);

                //再将ViewHolder挪到最后一行
                _ViewHolderList.InsertRange(_ViewHolderList.Count, Firstholders);


                int First = (row - 1) * _Column;
                //将挪除的第一行加到最后一行
                for (int i = 0; i < _Column; i++)
                {
                    //找到那个ViewHolder
                    var holder = Firstholders[i];
                    //重新赋值ViewHolder字段
                    _Adapter.OnBindViewHolder(holder, First + i);
                    //重新加载该条目的图片
                    flContent.Controls.Add(Firstholders[i].Control);
                    //显示该项目
                    holder.StartLoad();
                }

                _CurrentRow = row;

                _Stopwatch.Stop();
                Console.WriteLine($"下滑加载耗时{_Stopwatch.ElapsedMilliseconds.ToString()}");
            }


            //滚动条向上滚动
            if (row < _CurrentRow)
            {
                Console.WriteLine("开始监听方法上滑");
                _Stopwatch.Start();

                //找到新要显示的一行数据
                List<ViewHolder> Lastholders = new List<ViewHolder>();
                for (int i = _Column; i > 0; i--)
                {
                    Lastholders.Add(_ViewHolderList.ElementAt(_ViewHolderList.Count - 1 - i));
                }

                Lastholders.ForEach(m => flContent.Controls.Remove(m.Control));

                //ViewHolderList中删除最后一行
                _ViewHolderList.RemoveRange(_ViewHolderList.Count - 1 - _Column, _Column);

                //将重新显示的viewholder显示到第一行
                _ViewHolderList.InsertRange(0, Lastholders);

                int First = (row - _InitRow) * _Column;

                //将挪除的最后一行加到第一行
                for (int i = 0; i < _Column; i++)
                {
                    //重新赋值           (row - y) * x,
                    _Adapter.OnBindViewHolder(_ViewHolderList[i], First + i);
                    //重新加载
                    _ViewHolderList[i].StartLoad();

                    flContent.Controls.Add(_ViewHolderList[i].Control);
                    flContent.Controls.SetChildIndex(_ViewHolderList[i].Control, i);
                }
             ;

                _CurrentRow = row;

                _Stopwatch.Stop();
                Console.WriteLine($"上滑加载耗时{_Stopwatch.ElapsedMilliseconds.ToString()}");
            }

            //滑动到指定位置
            flContent.AutoScrollPosition = new Point(0, row > _InitRow ? row * 100 : 0);
        }
        #endregion

        #region 方法

        /// <summary>
        /// 设置适配器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void SetAdapter<T>(T t) where T : RecycleAdapter
        {
            this._Adapter = t as RecycleAdapter;
        }


        /// <summary>
        /// 更新界面
        /// </summary>
        public void NotifyDataSetChanged()
        {
            if (_Adapter == null)
                throw new Exception("还未设置适配器");

            //获取当前可加载的个数
            _Column = 7;// (int)Math.Floor(flImages.Width / 100f);
            _InitRow = 7; //(int)Math.Ceiling(flImages.Height / 100f);
            _CurrentRow = _InitRow;
            int maxNum = _Column * _InitRow;
            if (maxNum > _Adapter.GetItemCount())
                maxNum = _Adapter.GetItemCount();
            _MaxRow = (int)Math.Ceiling(_Adapter.GetItemCount() * 1f / _Column);

            _ViewHolderList = new List<ViewHolder>(maxNum - 1);
            //初始化第一次显示的项目，先加载maxNum行数据
            for (int i = 0; i < maxNum; i++)
            {
                //创建要显示的项目以及
                ViewHolder viewHolder = _Adapter.OnCreateViewHolder(_Adapter.GetDataType(i));
                //将数据显示到条目中
                _Adapter.OnBindViewHolder(viewHolder, i);
                //将控件显示到流布局中
                flContent.Controls.Add(viewHolder.Control);
                //开始加载条目
                viewHolder.StartLoad();
                //将ViewHolder存入集合，循环使用
                _ViewHolderList.Add(viewHolder);
            }
            //根据最大行数，初始化滚动条的长度
            vSBar.Maximum = _MaxRow;
        }

        #endregion


        /// <summary>
        /// RecycleView的适配器
        /// </summary>
        public abstract class RecycleAdapter
        {
            /// <summary>
            /// 获取显示项总数
            /// </summary>
            /// <returns></returns>
            public abstract int GetItemCount();


            /// <summary>
            /// 创建子条目，并且创建条目数据对象
            /// </summary>
            /// <param name="ViewType">条目类型</param>
            /// <returns></returns>
            public abstract ViewHolder OnCreateViewHolder(int ViewType);


            /// <summary>
            /// 绑定数据到空间中
            /// </summary>
            /// <param name="holder"></param>
            /// <param name="position"></param>
            public abstract void OnBindViewHolder(ViewHolder holder, int position);


            public int GetDataType(int position)
            {
                return -1;
            }
        }


        //public abstract class RecycleAdapter<T> where T : ViewHolder
        //{

        //    /// <summary>
        //    /// 获取显示项总数
        //    /// </summary>
        //    /// <returns></returns>
        //    public abstract int GetItemCount();


        //    /// <summary>
        //    /// 创建子条目，并且创建条目数据对象
        //    /// </summary>
        //    /// <param name="ViewType">条目类型</param>
        //    /// <returns></returns>
        //    public abstract T OnCreateViewHolder(int ViewType);


        //    /// <summary>
        //    /// 绑定数据到空间中
        //    /// </summary>
        //    /// <param name="holder"></param>
        //    /// <param name="position"></param>
        //    public abstract void OnBindViewHolder(T holder, int position);


        //    public int GetDataType(int position)
        //    {
        //        return -1;
        //    }


        //}
        public abstract class ViewHolder
        {

            internal Control Control;

            protected ViewHolder(Control control)
            {
                Control = control;
            }


            /// <summary>
            /// 加载
            /// </summary>
            public abstract void StartLoad();
        }


    }



}
