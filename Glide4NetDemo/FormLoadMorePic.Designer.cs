namespace Glide4NetDemo
{
    partial class FormLoadMorePic
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnLoad = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLoadNextRow = new System.Windows.Forms.Button();
            this.flImages = new System.Windows.Forms.FlowLayoutPanel();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(3, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(87, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "加载多个图片";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnLoad);
            this.flowLayoutPanel1.Controls.Add(this.btnLoadNextRow);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(741, 32);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btnLoadNextRow
            // 
            this.btnLoadNextRow.Location = new System.Drawing.Point(96, 3);
            this.btnLoadNextRow.Name = "btnLoadNextRow";
            this.btnLoadNextRow.Size = new System.Drawing.Size(75, 23);
            this.btnLoadNextRow.TabIndex = 1;
            this.btnLoadNextRow.Text = "加载下一行";
            this.btnLoadNextRow.UseVisualStyleBackColor = true;
            this.btnLoadNextRow.Click += new System.EventHandler(this.btnLoadNextRow_Click);
            // 
            // flImages
            // 
            this.flImages.AllowDrop = true;
            this.flImages.AutoScroll = true;
            this.flImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flImages.Location = new System.Drawing.Point(0, 32);
            this.flImages.Name = "flImages";
            this.flImages.Size = new System.Drawing.Size(741, 440);
            this.flImages.TabIndex = 2;
            this.flImages.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flImages_Scroll);
            this.flImages.DragDrop += new System.Windows.Forms.DragEventHandler(this.flImages_DragDrop);
            this.flImages.DragEnter += new System.Windows.Forms.DragEventHandler(this.flImages_DragEnter);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(724, 32);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 440);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // FormLoadMorePic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 472);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.flImages);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "FormLoadMorePic";
            this.Text = "加载多张";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flImages;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Button btnLoadNextRow;
    }
}