using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
	partial class WebBrowserPopupForm
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
    /// the contents of this method met the code editor.
    /// </summary>
    private void InitializeComponent()
    {
			this.webBrowser = new System.Windows.Forms.WebBrowser();
			this.notFoundPanel = new System.Windows.Forms.Panel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblError = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
			this.busyPanel = new System.Windows.Forms.Panel();
			this.lblLoading = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
			this.busyIconPictureBox = new System.Windows.Forms.PictureBox();
			this.notFoundPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.busyPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.busyIconPictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// webBrowser
			// 
			this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser.Location = new System.Drawing.Point(0, 0);
			this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser.Name = "webBrowser";
			this.webBrowser.Size = new System.Drawing.Size(1016, 734);
			this.webBrowser.TabIndex = 0;
			this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowserDocumentCompleted);
			this.webBrowser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.WebBrowserProgressChanged);
			// 
			// notFoundPanel
			// 
			this.notFoundPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.notFoundPanel.BackColor = System.Drawing.SystemColors.Control;
			this.notFoundPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.notFoundPanel.Controls.Add(this.pictureBox1);
			this.notFoundPanel.Controls.Add(this.lblError);
			this.notFoundPanel.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.notFoundPanel.Location = new System.Drawing.Point(247, 333);
			this.notFoundPanel.Name = "notFoundPanel";
			this.notFoundPanel.Size = new System.Drawing.Size(480, 70);
			this.notFoundPanel.TabIndex = 16;
			this.notFoundPanel.Visible = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources._Exclamation;
			this.pictureBox1.Location = new System.Drawing.Point(30, 10);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(58, 48);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// lblError
			// 
			this.lblError.AutoSize = true;
			// 
			// 
			// 
			this.lblError.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblError.ForeColor = System.Drawing.Color.Red;
			this.lblError.Location = new System.Drawing.Point(123, 10);
			this.lblError.Name = "lblError";
			this.lblError.Size = new System.Drawing.Size(297, 47);
			this.lblError.TabIndex = 0;
			this.lblError.Text = "The page can not be found.\r\n\r\nThis can be caused by an incorrect configuration.";
			this.lblError.Translate = true;
			// 
			// busyPanel
			// 
			this.busyPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.busyPanel.BackColor = System.Drawing.SystemColors.ControlDark;
			this.busyPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.busyPanel.Controls.Add(this.lblLoading);
			this.busyPanel.Controls.Add(this.busyIconPictureBox);
			this.busyPanel.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			this.busyPanel.Location = new System.Drawing.Point(371, 257);
			this.busyPanel.Name = "busyPanel";
			this.busyPanel.Size = new System.Drawing.Size(250, 70);
			this.busyPanel.TabIndex = 15;
			this.busyPanel.Visible = false;
			// 
			// lblLoading
			// 
			this.lblLoading.AutoSize = true;
			// 
			// 
			// 
			this.lblLoading.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lblLoading.Location = new System.Drawing.Point(96, 29);
			this.lblLoading.Name = "lblLoading";
			this.lblLoading.Size = new System.Drawing.Size(112, 15);
			this.lblLoading.TabIndex = 0;
			this.lblLoading.Text = "Loading, please wait...";
			this.lblLoading.Translate = true;
			// 
			// busyIconPictureBox
			// 
			this.busyIconPictureBox.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources._Busy;
			this.busyIconPictureBox.Location = new System.Drawing.Point(58, 20);
			this.busyIconPictureBox.Name = "busyIconPictureBox";
			this.busyIconPictureBox.Size = new System.Drawing.Size(32, 32);
			this.busyIconPictureBox.TabIndex = 0;
			this.busyIconPictureBox.TabStop = false;
			// 
			// HelpPopupForm
			// 
			this.BackColor = System.Drawing.Color.LightGray;
			this.ClientSize = new System.Drawing.Size(1016, 734);
			this.backgroundPanel.Controls.Add(this.notFoundPanel);
			this.backgroundPanel.Controls.Add(this.busyPanel);
			this.backgroundPanel.Controls.Add(this.webBrowser);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.MinimumSize = new System.Drawing.Size(720, 200);
			this.Name = "WebBrowserPopupForm";
			this.ShowIcon = true;
			this.Text = "Help";
			this.TitleText = "Help";
			this.Translate = true;
			this.notFoundPanel.ResumeLayout(false);
			this.notFoundPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.busyPanel.ResumeLayout(false);
			this.busyPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.busyIconPictureBox)).EndInit();
			this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.WebBrowser webBrowser;
    private System.Windows.Forms.Panel notFoundPanel;
    private System.Windows.Forms.PictureBox pictureBox1;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblError;
    private System.Windows.Forms.Panel busyPanel;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblLoading;
    private System.Windows.Forms.PictureBox busyIconPictureBox;




  }
}