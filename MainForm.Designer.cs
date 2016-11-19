﻿namespace ShowPicture
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.showPictureBox = new System.Windows.Forms.PictureBox();
            this.rigntCtMS = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToCenterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showTimer = new System.Windows.Forms.Timer(this.components);
            this.opacityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.showPictureBox)).BeginInit();
            this.rigntCtMS.SuspendLayout();
            this.SuspendLayout();
            // 
            // showPictureBox
            // 
            this.showPictureBox.Location = new System.Drawing.Point(12, 12);
            this.showPictureBox.Name = "showPictureBox";
            this.showPictureBox.Size = new System.Drawing.Size(100, 50);
            this.showPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.showPictureBox.TabIndex = 0;
            this.showPictureBox.TabStop = false;
            this.showPictureBox.SizeChanged += new System.EventHandler(this.showPictureBox_SizeChanged);
            this.showPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.showPictureBox_Paint);
            this.showPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.showPictureBox_MouseClick);
            this.showPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.showPictureBox_MouseDown);
            this.showPictureBox.MouseLeave += new System.EventHandler(this.showPictureBox_MouseLeave);
            this.showPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.showPictureBox_MouseMove);
            this.showPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.showPictureBox_MouseUp);
            // 
            // rigntCtMS
            // 
            this.rigntCtMS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.opacityToolStripMenuItem,
            this.moveToCenterToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.rigntCtMS.Name = "rigntCtMS";
            this.rigntCtMS.Size = new System.Drawing.Size(166, 114);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // moveToCenterToolStripMenuItem
            // 
            this.moveToCenterToolStripMenuItem.Name = "moveToCenterToolStripMenuItem";
            this.moveToCenterToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.moveToCenterToolStripMenuItem.Text = "Move To Center";
            this.moveToCenterToolStripMenuItem.Click += new System.EventHandler(this.moveToCenterToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // showTimer
            // 
            this.showTimer.Interval = 750;
            this.showTimer.Tick += new System.EventHandler(this.showTimer_Tick);
            // 
            // opacityToolStripMenuItem
            // 
            this.opacityToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox});
            this.opacityToolStripMenuItem.Name = "opacityToolStripMenuItem";
            this.opacityToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.opacityToolStripMenuItem.Text = "Opacity";
            // 
            // toolStripTextBox
            // 
            this.toolStripTextBox.Name = "toolStripTextBox";
            this.toolStripTextBox.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox.Text = "0.75";
            this.toolStripTextBox.TextChanged += new System.EventHandler(this.toolStripTextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.showPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.showPictureBox)).EndInit();
            this.rigntCtMS.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox showPictureBox;
        private System.Windows.Forms.ContextMenuStrip rigntCtMS;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moveToCenterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer showTimer;
        private System.Windows.Forms.ToolStripMenuItem opacityToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox;
    }
}

