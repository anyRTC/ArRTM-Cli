﻿namespace ArCliDemo
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
            this.btnJoinChannel = new System.Windows.Forms.Button();
            this.txtVendorkey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.localVideo = new System.Windows.Forms.PictureBox();
            this.btnStartPreview = new System.Windows.Forms.Button();
            this.remoteVideo = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.localVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnJoinChannel
            // 
            this.btnJoinChannel.Location = new System.Drawing.Point(140, 651);
            this.btnJoinChannel.Margin = new System.Windows.Forms.Padding(4);
            this.btnJoinChannel.Name = "btnJoinChannel";
            this.btnJoinChannel.Size = new System.Drawing.Size(112, 34);
            this.btnJoinChannel.TabIndex = 0;
            this.btnJoinChannel.Text = "登录";
            this.btnJoinChannel.UseVisualStyleBackColor = true;
            this.btnJoinChannel.Click += new System.EventHandler(this.btnJoinChannel_Click);
            // 
            // txtVendorkey
            // 
            this.txtVendorkey.Location = new System.Drawing.Point(159, 52);
            this.txtVendorkey.Margin = new System.Windows.Forms.Padding(4);
            this.txtVendorkey.Name = "txtVendorkey";
            this.txtVendorkey.Size = new System.Drawing.Size(494, 28);
            this.txtVendorkey.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "AppId:";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(159, 158);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(494, 138);
            this.txtResult.TabIndex = 5;
            this.txtResult.TextChanged += new System.EventHandler(this.txtResult_TextChanged);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(15, 158);
            this.lblResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(80, 18);
            this.lblResult.TabIndex = 6;
            this.lblResult.Text = "调用结果";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 128);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "User Id :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(159, 123);
            this.txtUserId.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(494, 28);
            this.txtUserId.TabIndex = 7;
            this.txtUserId.Text = "666";
            this.txtUserId.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // localVideo
            // 
            this.localVideo.Location = new System.Drawing.Point(18, 345);
            this.localVideo.Margin = new System.Windows.Forms.Padding(4);
            this.localVideo.Name = "localVideo";
            this.localVideo.Size = new System.Drawing.Size(346, 252);
            this.localVideo.TabIndex = 9;
            this.localVideo.TabStop = false;
            // 
            // btnStartPreview
            // 
            this.btnStartPreview.Location = new System.Drawing.Point(18, 651);
            this.btnStartPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartPreview.Name = "btnStartPreview";
            this.btnStartPreview.Size = new System.Drawing.Size(112, 34);
            this.btnStartPreview.TabIndex = 10;
            this.btnStartPreview.Text = "打开本地视频";
            this.btnStartPreview.UseVisualStyleBackColor = true;
            this.btnStartPreview.Click += new System.EventHandler(this.btnStartPreview_Click);
            // 
            // remoteVideo
            // 
            this.remoteVideo.Location = new System.Drawing.Point(387, 345);
            this.remoteVideo.Margin = new System.Windows.Forms.Padding(4);
            this.remoteVideo.Name = "remoteVideo";
            this.remoteVideo.Size = new System.Drawing.Size(346, 252);
            this.remoteVideo.TabIndex = 11;
            this.remoteVideo.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 651);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 12;
            this.button1.Text = "测试";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 92);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "Vendor Key:";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(159, 88);
            this.txtToken.Margin = new System.Windows.Forms.Padding(4);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(494, 28);
            this.txtToken.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 718);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.remoteVideo);
            this.Controls.Add(this.btnStartPreview);
            this.Controls.Add(this.localVideo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVendorkey);
            this.Controls.Add(this.btnJoinChannel);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.localVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remoteVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnJoinChannel;
        private System.Windows.Forms.TextBox txtVendorkey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.PictureBox localVideo;
        private System.Windows.Forms.Button btnStartPreview;
        private System.Windows.Forms.PictureBox remoteVideo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtToken;
    }
}
