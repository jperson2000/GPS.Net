namespace Diagnostics
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.menuSendLog = new System.Windows.Forms.MenuItem();
            this.menuClose = new System.Windows.Forms.MenuItem();
            this.logBody = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuSendLog);
            this.mainMenu1.MenuItems.Add(this.menuClose);
            // 
            // menuSendLog
            // 
            this.menuSendLog.Text = "Send Log";
            this.menuSendLog.Click += new System.EventHandler(this.menuSendLog_Click);
            // 
            // menuClose
            // 
            this.menuClose.Text = "Close";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // logBody
            // 
            this.logBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.logBody.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular);
            this.logBody.Location = new System.Drawing.Point(0, 54);
            this.logBody.Multiline = true;
            this.logBody.Name = "logBody";
            this.logBody.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logBody.Size = new System.Drawing.Size(240, 214);
            this.logBody.TabIndex = 0;
            this.logBody.WordWrap = false;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(5, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(234, 46);
            this.titleLabel.Text = "...";
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.logBody);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "LogForm";
            this.Text = "View Log";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox logBody;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.MenuItem menuSendLog;
        private System.Windows.Forms.MenuItem menuClose;
    }
}