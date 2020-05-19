namespace AlwaysTopWindow
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.processComboBox = new System.Windows.Forms.ComboBox();
            this.processListLabel = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.releaseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // processComboBox
            // 
            this.processComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processComboBox.FormattingEnabled = true;
            this.processComboBox.Location = new System.Drawing.Point(98, 13);
            this.processComboBox.Name = "processComboBox";
            this.processComboBox.Size = new System.Drawing.Size(572, 21);
            this.processComboBox.TabIndex = 0;
            // 
            // processListLabel
            // 
            this.processListLabel.AutoSize = true;
            this.processListLabel.Location = new System.Drawing.Point(14, 16);
            this.processListLabel.Name = "processListLabel";
            this.processListLabel.Size = new System.Drawing.Size(78, 14);
            this.processListLabel.TabIndex = 1;
            this.processListLabel.Text = "プロセス一覧";
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(682, 11);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(87, 25);
            this.refreshButton.TabIndex = 2;
            this.refreshButton.Text = "再検索";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(17, 50);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(653, 59);
            this.applyButton.TabIndex = 3;
            this.applyButton.Text = "最前面化";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // releaseButton
            // 
            this.releaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.releaseButton.Location = new System.Drawing.Point(682, 50);
            this.releaseButton.Name = "releaseButton";
            this.releaseButton.Size = new System.Drawing.Size(88, 59);
            this.releaseButton.TabIndex = 6;
            this.releaseButton.Text = "解除";
            this.releaseButton.UseVisualStyleBackColor = true;
            this.releaseButton.Click += new System.EventHandler(this.releaseButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 121);
            this.Controls.Add(this.releaseButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.processListLabel);
            this.Controls.Add(this.processComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "AlwaysTopWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox processComboBox;
        private System.Windows.Forms.Label processListLabel;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button releaseButton;
    }
}

