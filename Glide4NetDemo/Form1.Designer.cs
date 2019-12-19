namespace Glide4NetDemo
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLoadLocalFile = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOpenMulity = new System.Windows.Forms.Button();
            this.btnRecycleView = new System.Windows.Forms.Button();
            this.btnClearCache = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pictureBox1.Location = new System.Drawing.Point(0, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 409);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnLoadLocalFile
            // 
            this.btnLoadLocalFile.Location = new System.Drawing.Point(3, 3);
            this.btnLoadLocalFile.Name = "btnLoadLocalFile";
            this.btnLoadLocalFile.Size = new System.Drawing.Size(92, 23);
            this.btnLoadLocalFile.TabIndex = 1;
            this.btnLoadLocalFile.Text = "打开本地图片";
            this.btnLoadLocalFile.UseVisualStyleBackColor = true;
            this.btnLoadLocalFile.Click += new System.EventHandler(this.btnLoadLocalFile_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnLoadLocalFile);
            this.flowLayoutPanel1.Controls.Add(this.btnOpenMulity);
            this.flowLayoutPanel1.Controls.Add(this.btnRecycleView);
            this.flowLayoutPanel1.Controls.Add(this.btnClearCache);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(800, 35);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnOpenMulity
            // 
            this.btnOpenMulity.Location = new System.Drawing.Point(101, 3);
            this.btnOpenMulity.Name = "btnOpenMulity";
            this.btnOpenMulity.Size = new System.Drawing.Size(82, 23);
            this.btnOpenMulity.TabIndex = 2;
            this.btnOpenMulity.Text = "打开多张";
            this.btnOpenMulity.UseVisualStyleBackColor = true;
            this.btnOpenMulity.Click += new System.EventHandler(this.btnOpenMulity_Click);
            // 
            // btnRecycleView
            // 
            this.btnRecycleView.Location = new System.Drawing.Point(189, 3);
            this.btnRecycleView.Name = "btnRecycleView";
            this.btnRecycleView.Size = new System.Drawing.Size(115, 23);
            this.btnRecycleView.TabIndex = 3;
            this.btnRecycleView.Text = "RecycleView演示";
            this.btnRecycleView.UseVisualStyleBackColor = true;
            this.btnRecycleView.Click += new System.EventHandler(this.btnRecycleView_Click);
            // 
            // btnClearCache
            // 
            this.btnClearCache.Location = new System.Drawing.Point(310, 3);
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.Size = new System.Drawing.Size(75, 23);
            this.btnClearCache.TabIndex = 4;
            this.btnClearCache.Text = "清除缓存";
            this.btnClearCache.UseVisualStyleBackColor = true;
            this.btnClearCache.Click += new System.EventHandler(this.btnClearCache_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLoadLocalFile;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnOpenMulity;
        private System.Windows.Forms.Button btnRecycleView;
        private System.Windows.Forms.Button btnClearCache;
    }
}

