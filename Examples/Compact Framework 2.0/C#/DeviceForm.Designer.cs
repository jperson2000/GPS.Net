namespace Diagnostics
{
    partial class DeviceForm
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
            this.menuAnalyze = new System.Windows.Forms.MenuItem();
            this.menuClose = new System.Windows.Forms.MenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lastConnectLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.portLabelTitle = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeLabelTitle = new System.Windows.Forms.Label();
            this.devicePicture = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.isGPSLabel = new System.Windows.Forms.Label();
            this.isGPSLabelTitle = new System.Windows.Forms.Label();
            this.reliabilityLabel = new System.Windows.Forms.Label();
            this.reliabilityLabelTitle = new System.Windows.Forms.Label();
            this.sentenceListBox = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBoxSatellites = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBoxPrecision = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBoxSpeed = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBoxBearing = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBoxAltitude = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxPosition = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuAnalyze);
            this.mainMenu1.MenuItems.Add(this.menuClose);
            // 
            // menuAnalyze
            // 
            this.menuAnalyze.Text = "Analyze";
            this.menuAnalyze.Click += new System.EventHandler(this.menuAnalyze_Click);
            // 
            // menuClose
            // 
            this.menuClose.Text = "Close";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(240, 268);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lastConnectLabel);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.portLabel);
            this.tabPage1.Controls.Add(this.portLabelTitle);
            this.tabPage1.Controls.Add(this.typeLabel);
            this.tabPage1.Controls.Add(this.typeLabelTitle);
            this.tabPage1.Controls.Add(this.devicePicture);
            this.tabPage1.Controls.Add(this.titleLabel);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(240, 245);
            this.tabPage1.Text = "General";
            // 
            // lastConnectLabel
            // 
            this.lastConnectLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lastConnectLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.lastConnectLabel.Location = new System.Drawing.Point(73, 91);
            this.lastConnectLabel.Name = "lastConnectLabel";
            this.lastConnectLabel.Size = new System.Drawing.Size(124, 20);
            this.lastConnectLabel.Text = "...";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(3, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.Text = "Last Used:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // portLabel
            // 
            this.portLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.portLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.portLabel.Location = new System.Drawing.Point(73, 71);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(160, 20);
            this.portLabel.Text = "...";
            // 
            // portLabelTitle
            // 
            this.portLabelTitle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.portLabelTitle.Location = new System.Drawing.Point(8, 71);
            this.portLabelTitle.Name = "portLabelTitle";
            this.portLabelTitle.Size = new System.Drawing.Size(59, 20);
            this.portLabelTitle.Text = "Port:";
            this.portLabelTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // typeLabel
            // 
            this.typeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.typeLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.typeLabel.Location = new System.Drawing.Point(73, 51);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(160, 20);
            this.typeLabel.Text = "...";
            // 
            // typeLabelTitle
            // 
            this.typeLabelTitle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.typeLabelTitle.Location = new System.Drawing.Point(8, 51);
            this.typeLabelTitle.Name = "typeLabelTitle";
            this.typeLabelTitle.Size = new System.Drawing.Size(59, 20);
            this.typeLabelTitle.Text = "Type:";
            this.typeLabelTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // devicePicture
            // 
            this.devicePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.devicePicture.Location = new System.Drawing.Point(112, 117);
            this.devicePicture.Name = "devicePicture";
            this.devicePicture.Size = new System.Drawing.Size(128, 128);
            this.devicePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.isGPSLabel);
            this.tabPage3.Controls.Add(this.isGPSLabelTitle);
            this.tabPage3.Controls.Add(this.reliabilityLabel);
            this.tabPage3.Controls.Add(this.reliabilityLabelTitle);
            this.tabPage3.Controls.Add(this.sentenceListBox);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.pictureBoxSatellites);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.pictureBoxPrecision);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.pictureBoxSpeed);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.pictureBoxBearing);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.pictureBoxAltitude);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.pictureBoxPosition);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(232, 242);
            this.tabPage3.Text = "Supported Features";
            // 
            // isGPSLabel
            // 
            this.isGPSLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.isGPSLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.isGPSLabel.Location = new System.Drawing.Point(73, 197);
            this.isGPSLabel.Name = "isGPSLabel";
            this.isGPSLabel.Size = new System.Drawing.Size(152, 20);
            this.isGPSLabel.Text = "...";
            // 
            // isGPSLabelTitle
            // 
            this.isGPSLabelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.isGPSLabelTitle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.isGPSLabelTitle.Location = new System.Drawing.Point(8, 197);
            this.isGPSLabelTitle.Name = "isGPSLabelTitle";
            this.isGPSLabelTitle.Size = new System.Drawing.Size(59, 20);
            this.isGPSLabelTitle.Text = "GPS?";
            this.isGPSLabelTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // reliabilityLabel
            // 
            this.reliabilityLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reliabilityLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.reliabilityLabel.Location = new System.Drawing.Point(73, 217);
            this.reliabilityLabel.Name = "reliabilityLabel";
            this.reliabilityLabel.Size = new System.Drawing.Size(152, 20);
            this.reliabilityLabel.Text = "...";
            // 
            // reliabilityLabelTitle
            // 
            this.reliabilityLabelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.reliabilityLabelTitle.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.reliabilityLabelTitle.Location = new System.Drawing.Point(8, 217);
            this.reliabilityLabelTitle.Name = "reliabilityLabelTitle";
            this.reliabilityLabelTitle.Size = new System.Drawing.Size(59, 20);
            this.reliabilityLabelTitle.Text = "Reliability:";
            this.reliabilityLabelTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // sentenceListBox
            // 
            this.sentenceListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sentenceListBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.sentenceListBox.Location = new System.Drawing.Point(8, 134);
            this.sentenceListBox.Name = "sentenceListBox";
            this.sentenceListBox.Size = new System.Drawing.Size(217, 41);
            this.sentenceListBox.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label9.Location = new System.Drawing.Point(125, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 15);
            this.label9.Text = "Satellites";
            // 
            // pictureBoxSatellites
            // 
            this.pictureBoxSatellites.Location = new System.Drawing.Point(102, 77);
            this.pictureBoxSatellites.Name = "pictureBoxSatellites";
            this.pictureBoxSatellites.Size = new System.Drawing.Size(16, 16);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(8, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 17);
            this.label8.Text = "Supported NMEA Sentences";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label7.Location = new System.Drawing.Point(125, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.Text = "Precision";
            // 
            // pictureBoxPrecision
            // 
            this.pictureBoxPrecision.Location = new System.Drawing.Point(103, 54);
            this.pictureBoxPrecision.Name = "pictureBoxPrecision";
            this.pictureBoxPrecision.Size = new System.Drawing.Size(16, 16);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(125, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 15);
            this.label6.Text = "Speed";
            // 
            // pictureBoxSpeed
            // 
            this.pictureBoxSpeed.Location = new System.Drawing.Point(103, 30);
            this.pictureBoxSpeed.Name = "pictureBoxSpeed";
            this.pictureBoxSpeed.Size = new System.Drawing.Size(16, 16);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(30, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 15);
            this.label5.Text = "Bearing";
            // 
            // pictureBoxBearing
            // 
            this.pictureBoxBearing.Location = new System.Drawing.Point(7, 77);
            this.pictureBoxBearing.Name = "pictureBoxBearing";
            this.pictureBoxBearing.Size = new System.Drawing.Size(16, 16);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(30, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.Text = "Altitude";
            // 
            // pictureBoxAltitude
            // 
            this.pictureBoxAltitude.Location = new System.Drawing.Point(7, 54);
            this.pictureBoxAltitude.Name = "pictureBoxAltitude";
            this.pictureBoxAltitude.Size = new System.Drawing.Size(16, 16);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(30, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 16);
            this.label1.Text = "Position";
            // 
            // pictureBoxPosition
            // 
            this.pictureBoxPosition.Location = new System.Drawing.Point(7, 30);
            this.pictureBoxPosition.Name = "pictureBoxPosition";
            this.pictureBoxPosition.Size = new System.Drawing.Size(16, 16);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(5, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(226, 22);
            this.label4.Text = "Features";
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            // 
            // DeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.tabControl1);
            this.Menu = this.mainMenu1;
            this.MinimizeBox = false;
            this.Name = "DeviceForm";
            this.Text = "Device Information";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuAnalyze;
        private System.Windows.Forms.MenuItem menuClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.PictureBox devicePicture;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label typeLabelTitle;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label portLabelTitle;
        private System.Windows.Forms.Label lastConnectLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBoxPosition;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBoxAltitude;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBoxBearing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBoxSpeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBoxPrecision;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBoxSatellites;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox sentenceListBox;
        private System.Windows.Forms.Label isGPSLabel;
        private System.Windows.Forms.Label isGPSLabelTitle;
        private System.Windows.Forms.Label reliabilityLabel;
        private System.Windows.Forms.Label reliabilityLabelTitle;

    }
}