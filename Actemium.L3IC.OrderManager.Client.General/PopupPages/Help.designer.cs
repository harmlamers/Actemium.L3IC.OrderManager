using Actemium.Windows.Forms.DevComponents2.Controls;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  partial class PopupHelp : Base.BasePopupForm
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
      this.pnlNotFound = new System.Windows.Forms.Panel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.label2 = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.pnlBusy = new System.Windows.Forms.Panel();
      this.label1 = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.bpBusyIcon = new System.Windows.Forms.PictureBox();
      this.pnlNotFound.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.pnlBusy.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bpBusyIcon)).BeginInit();
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
      this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.AlarmHelpBrowserDocumentCompleted);
      this.webBrowser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.AlarmHelpBrowserProgressChanged);
      // 
      // pnlNotFound
      // 
      this.pnlNotFound.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.pnlNotFound.BackColor = System.Drawing.SystemColors.Control;
      this.pnlNotFound.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlNotFound.Controls.Add(this.pictureBox1);
      this.pnlNotFound.Controls.Add(this.label2);
      this.pnlNotFound.Cursor = System.Windows.Forms.Cursors.WaitCursor;
      this.pnlNotFound.Location = new System.Drawing.Point(247, 333);
      this.pnlNotFound.Name = "pnlNotFound";
      this.pnlNotFound.Size = new System.Drawing.Size(480, 70);
      this.pnlNotFound.TabIndex = 16;
      this.pnlNotFound.Visible = false;
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
      // label2
      // 
      this.label2.AutoSize = true;
      // 
      // 
      // 
      this.label2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.label2.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.Red;
      this.label2.FormatMask = null;
      this.label2.Location = new System.Drawing.Point(123, 10);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(235, 32);
      this.label2.TabIndex = 0;
      this.label2.Text = "Helppage not found, \r\npossibly it was not configured correctly";
      this.label2.TextAlignment = System.Drawing.StringAlignment.Center;
      this.label2.Translate = true;
      // 
      // pnlBusy
      // 
      this.pnlBusy.Anchor = System.Windows.Forms.AnchorStyles.None;
      this.pnlBusy.BackColor = System.Drawing.SystemColors.ControlDark;
      this.pnlBusy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlBusy.Controls.Add(this.label1);
      this.pnlBusy.Controls.Add(this.bpBusyIcon);
      this.pnlBusy.Cursor = System.Windows.Forms.Cursors.WaitCursor;
      this.pnlBusy.Location = new System.Drawing.Point(371, 257);
      this.pnlBusy.Name = "pnlBusy";
      this.pnlBusy.Size = new System.Drawing.Size(250, 70);
      this.pnlBusy.TabIndex = 15;
      this.pnlBusy.Visible = false;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      // 
      // 
      // 
      this.label1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.label1.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.label1.FormatMask = null;
      this.label1.Location = new System.Drawing.Point(96, 29);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(68, 15);
      this.label1.TabIndex = 0;
      this.label1.Text = "Please wait...";
      this.label1.Translate = true;
      // 
      // bpBusyIcon
      // 
      this.bpBusyIcon.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources._Busy;
      this.bpBusyIcon.Location = new System.Drawing.Point(58, 20);
      this.bpBusyIcon.Name = "bpBusyIcon";
      this.bpBusyIcon.Size = new System.Drawing.Size(32, 32);
      this.bpBusyIcon.TabIndex = 0;
      this.bpBusyIcon.TabStop = false;
      // 
      // PopupHelp
      // 
      this.BackColor = System.Drawing.Color.LightGray;
      this.ClientSize = new System.Drawing.Size(1016, 734);
      this.backgroundPanel.Controls.Add(this.pnlNotFound);
      this.backgroundPanel.Controls.Add(this.pnlBusy);
      this.backgroundPanel.Controls.Add(this.webBrowser);
      this.ForeColor = System.Drawing.SystemColors.ControlText;
      this.MinimumSize = new System.Drawing.Size(720, 200);
      this.Name = "PopupHelp";
      this.Text = "Actemium Help";
      this.TitleText = "Actemium Help";
      this.Translate = true;
      this.pnlNotFound.ResumeLayout(false);
      this.pnlNotFound.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.pnlBusy.ResumeLayout(false);
      this.pnlBusy.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.bpBusyIcon)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.WebBrowser webBrowser;
    private System.Windows.Forms.Panel pnlNotFound;
    private System.Windows.Forms.PictureBox pictureBox1;
    private LabelX label2;
    private System.Windows.Forms.Panel pnlBusy;
    private LabelX label1;
    private System.Windows.Forms.PictureBox bpBusyIcon;




  }
}