namespace Diagnostics
{
    partial class SummaryForm
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
            this.menuRestart = new System.Windows.Forms.MenuItem();
            this.menuFinish = new System.Windows.Forms.MenuItem();
            this.titleLabel = new System.Windows.Forms.Label();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.suggestionListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.imageList2 = new System.Windows.Forms.ImageList();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.gpsListView = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuRestart);
            this.mainMenu1.MenuItems.Add(this.menuFinish);
            // 
            // menuRestart
            // 
            this.menuRestart.Text = "Scan Again";
            this.menuRestart.Click += new System.EventHandler(this.menuRestart_Click);
            // 
            // menuFinish
            // 
            this.menuFinish.Text = "&Finish";
            this.menuFinish.Click += new System.EventHandler(this.menuFinish_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(5, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(232, 23);
            this.titleLabel.Text = "...";
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.descriptionLabel.Location = new System.Drawing.Point(5, 32);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(232, 43);
            this.descriptionLabel.Text = "...";
            // 
            // suggestionListView
            // 
            this.suggestionListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.suggestionListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.suggestionListView.Columns.Add(this.columnHeader1);
            this.suggestionListView.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.suggestionListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.suggestionListView.LargeImageList = this.imageList2;
            this.suggestionListView.Location = new System.Drawing.Point(5, 164);
            this.suggestionListView.Name = "suggestionListView";
            this.suggestionListView.Size = new System.Drawing.Size(232, 101);
            this.suggestionListView.SmallImageList = this.imageList1;
            this.suggestionListView.TabIndex = 3;
            this.suggestionListView.View = System.Windows.Forms.View.Details;
            this.suggestionListView.ItemActivate += new System.EventHandler(this.suggestionListView_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Suggestions";
            this.columnHeader1.Width = 900;
            // 
            // imageList2
            // 
            this.imageList2.ImageSize = new System.Drawing.Size(32, 32);
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            // 
            // gpsListView
            // 
            this.gpsListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.gpsListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gpsListView.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.gpsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.gpsListView.LargeImageList = this.imageList2;
            this.gpsListView.Location = new System.Drawing.Point(5, 92);
            this.gpsListView.Name = "gpsListView";
            this.gpsListView.Size = new System.Drawing.Size(232, 69);
            this.gpsListView.SmallImageList = this.imageList1;
            this.gpsListView.TabIndex = 7;
            this.gpsListView.ItemActivate += new System.EventHandler(this.gpsListView_ItemActivate);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(5, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 14);
            this.label2.Text = "Confirmed GPS Devices";
            // 
            // SummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gpsListView);
            this.Controls.Add(this.suggestionListView);
            this.Controls.Add(this.descriptionLabel);
            this.Controls.Add(this.titleLabel);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "SummaryForm";
            this.Text = "GPS Devices";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.MenuItem menuRestart;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.ListView suggestionListView;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView gpsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.MenuItem menuFinish;
        private System.Windows.Forms.Label label2;
    }
}