namespace MatrixTransform
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
            this.checkBox_x = new System.Windows.Forms.CheckBox();
            this.checkBox_y = new System.Windows.Forms.CheckBox();
            this.checkBox_z = new System.Windows.Forms.CheckBox();
            this.checkBox_isLine = new System.Windows.Forms.CheckBox();
            this.checkBox_drawCube = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // hScrollBar1
            // 
            this.hScrollBar1.Location = new System.Drawing.Point(9, 9);
            this.hScrollBar1.Maximum = 1000;
            this.hScrollBar1.Minimum = 250;
            this.hScrollBar1.Name = "hScrollBar1";
            this.hScrollBar1.Size = new System.Drawing.Size(300, 15);
            this.hScrollBar1.TabIndex = 0;
            this.hScrollBar1.Value = 250;
            this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // checkBox_x
            // 
            this.checkBox_x.AutoSize = true;
            this.checkBox_x.Location = new System.Drawing.Point(366, 9);
            this.checkBox_x.Name = "checkBox_x";
            this.checkBox_x.Size = new System.Drawing.Size(96, 16);
            this.checkBox_x.TabIndex = 1;
            this.checkBox_x.Text = "Dont RotateX";
            this.checkBox_x.UseVisualStyleBackColor = true;
            // 
            // checkBox_y
            // 
            this.checkBox_y.AutoSize = true;
            this.checkBox_y.Location = new System.Drawing.Point(366, 32);
            this.checkBox_y.Name = "checkBox_y";
            this.checkBox_y.Size = new System.Drawing.Size(96, 16);
            this.checkBox_y.TabIndex = 2;
            this.checkBox_y.Text = "Dont RotateY";
            this.checkBox_y.UseVisualStyleBackColor = true;
            // 
            // checkBox_z
            // 
            this.checkBox_z.AutoSize = true;
            this.checkBox_z.Location = new System.Drawing.Point(366, 55);
            this.checkBox_z.Name = "checkBox_z";
            this.checkBox_z.Size = new System.Drawing.Size(96, 16);
            this.checkBox_z.TabIndex = 3;
            this.checkBox_z.Text = "Dont RotateZ";
            this.checkBox_z.UseVisualStyleBackColor = true;
            // 
            // checkBox_isLine
            // 
            this.checkBox_isLine.AutoSize = true;
            this.checkBox_isLine.Location = new System.Drawing.Point(476, 9);
            this.checkBox_isLine.Name = "checkBox_isLine";
            this.checkBox_isLine.Size = new System.Drawing.Size(66, 16);
            this.checkBox_isLine.TabIndex = 4;
            this.checkBox_isLine.Text = "is Line";
            this.checkBox_isLine.UseVisualStyleBackColor = true;
            // 
            // checkBox_drawCube
            // 
            this.checkBox_drawCube.AutoSize = true;
            this.checkBox_drawCube.Checked = true;
            this.checkBox_drawCube.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_drawCube.Location = new System.Drawing.Point(476, 32);
            this.checkBox_drawCube.Name = "checkBox_drawCube";
            this.checkBox_drawCube.Size = new System.Drawing.Size(102, 16);
            this.checkBox_drawCube.TabIndex = 5;
            this.checkBox_drawCube.Text = "Cube/Triangle";
            this.checkBox_drawCube.UseVisualStyleBackColor = true;
            this.checkBox_drawCube.CheckedChanged += new System.EventHandler(this.checkBox_drawCube_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(584, 560);
            this.Controls.Add(this.checkBox_drawCube);
            this.Controls.Add(this.checkBox_isLine);
            this.Controls.Add(this.checkBox_z);
            this.Controls.Add(this.checkBox_y);
            this.Controls.Add(this.checkBox_x);
            this.Controls.Add(this.hScrollBar1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.CheckBox checkBox_x;
        private System.Windows.Forms.CheckBox checkBox_y;
        private System.Windows.Forms.CheckBox checkBox_z;
        private System.Windows.Forms.CheckBox checkBox_isLine;
        private System.Windows.Forms.CheckBox checkBox_drawCube;
    }
}

