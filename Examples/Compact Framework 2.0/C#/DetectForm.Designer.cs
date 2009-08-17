using System;
using GeoFramework.Gps;
using GeoFramework.Gps.IO;

namespace Diagnostics
{
    partial class DetectForm
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

            Devices.DeviceDetectionStarted -= new EventHandler(Devices_DeviceDetectionStarted);
            Devices.DeviceDetectionCompleted -= new EventHandler(Devices_DeviceDetectionCompleted);
            Devices.DeviceDetected -= new EventHandler<DeviceEventArgs>(Devices_DeviceDetected);
            Devices.DeviceDetectionAttempted -= new EventHandler<DeviceEventArgs>(Devices_DeviceDetectionAttempted);
            Devices.DeviceDetectionAttemptFailed -= new EventHandler<DeviceDetectionExceptionEventArgs>(Devices_DeviceDetectionAttemptFailed);

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
            this.menuCancel = new System.Windows.Forms.MenuItem();
            this.menuNext = new System.Windows.Forms.MenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.devicesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.logBox = new System.Windows.Forms.ListBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuCancel);
            this.mainMenu1.MenuItems.Add(this.menuNext);
            // 
            // menuCancel
            // 
            this.menuCancel.Enabled = false;
            this.menuCancel.Text = "&Cancel";
            this.menuCancel.Click += new System.EventHandler(this.menuCancel_Click);
            // 
            // menuNext
            // 
            this.menuNext.Enabled = false;
            this.menuNext.Text = "&Next";
            this.menuNext.Click += new System.EventHandler(this.menuNext_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            // 
            // devicesListView
            // 
            this.devicesListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.devicesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.devicesListView.Columns.Add(this.columnHeader1);
            this.devicesListView.Columns.Add(this.columnHeader2);
            this.devicesListView.Columns.Add(this.columnHeader3);
            this.devicesListView.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.devicesListView.FullRowSelect = true;
            this.devicesListView.LargeImageList = this.imageList1;
            this.devicesListView.Location = new System.Drawing.Point(0, 65);
            this.devicesListView.Name = "devicesListView";
            this.devicesListView.Size = new System.Drawing.Size(240, 123);
            this.devicesListView.SmallImageList = this.imageList1;
            this.devicesListView.TabIndex = 1;
            this.devicesListView.View = System.Windows.Forms.View.Details;
            this.devicesListView.ItemActivate += new System.EventHandler(this.devicesListView_ItemActivate);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Device";
            this.columnHeader1.Width = 127;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            this.columnHeader2.Width = 137;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 349;
            // 
            // logBox
            // 
            this.logBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.logBox.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.logBox.Location = new System.Drawing.Point(0, 188);
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(240, 80);
            this.logBox.TabIndex = 2;
            // 
            // titleLabel
            // 
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(5, 5);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(234, 23);
            this.titleLabel.Text = "Search In Progress...";
            // 
            // description
            // 
            this.description.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.description.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.description.Location = new System.Drawing.Point(4, 32);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(233, 27);
            this.description.Text = "Please wait a moment while devices are tested...";
            // 
            // DetectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.ControlBox = false;
            this.Controls.Add(this.description);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.devicesListView);
            this.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.Menu = this.mainMenu1;
            this.Name = "DetectForm";
            this.Text = "GPS Device Search";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.MenuItem menuCancel;
        private System.Windows.Forms.ListView devicesListView;
        private System.Windows.Forms.ListBox logBox;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.MenuItem menuNext;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label description;
    }
}