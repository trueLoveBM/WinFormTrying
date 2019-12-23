namespace Glide4NetDemo
{
    partial class RecycleView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.vSBar = new System.Windows.Forms.VScrollBar();
            this.flContent = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // vSBar
            // 
            this.vSBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.vSBar.Location = new System.Drawing.Point(383, 0);
            this.vSBar.Name = "vSBar";
            this.vSBar.Size = new System.Drawing.Size(17, 300);
            this.vSBar.TabIndex = 0;
            this.vSBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vSbr_Scroll);
            // 
            // flContent
            // 
            this.flContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flContent.Location = new System.Drawing.Point(0, 0);
            this.flContent.Name = "flContent";
            this.flContent.Size = new System.Drawing.Size(383, 300);
            this.flContent.TabIndex = 1;
            this.flContent.SizeChanged += new System.EventHandler(this.flContent_SizeChanged);
            // 
            // RecycleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flContent);
            this.Controls.Add(this.vSBar);
            this.Name = "RecycleView";
            this.Size = new System.Drawing.Size(400, 300);
            this.Load += new System.EventHandler(this.RecycleView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.VScrollBar vSBar;
        private System.Windows.Forms.FlowLayoutPanel flContent;
    }
}
