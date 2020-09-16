using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  partial class MessageBoxForm
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
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.components = new System.ComponentModel.Container();
      this.ribbonControl = new Actemium.Windows.Forms.DevComponents2.Controls.RibbonControl(this.components);
      this.backgroundPanel = new DevComponents.DotNetBar.PanelEx();
      this.button1 = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.panel1 = new System.Windows.Forms.Panel();
      this.lblbInputText = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.tbUserInput = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
      this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
      this.messageLabel = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.button3 = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.button2 = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.backgroundPanel.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
      this.SuspendLayout();
      // 
      // ribbonControl
      // 
      // 
      // 
      // 
      this.ribbonControl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.ribbonControl.CaptionVisible = true;
      this.ribbonControl.Dock = System.Windows.Forms.DockStyle.Top;
      this.ribbonControl.EnableQatPlacement = false;
      this.ribbonControl.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ribbonControl.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
      this.ribbonControl.Location = new System.Drawing.Point(0, 0);
      this.ribbonControl.Margin = new System.Windows.Forms.Padding(4);
      this.ribbonControl.Name = "ribbonControl";
      this.ribbonControl.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
      this.ribbonControl.Size = new System.Drawing.Size(668, 30);
      this.ribbonControl.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
      this.ribbonControl.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
      this.ribbonControl.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
      this.ribbonControl.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
      this.ribbonControl.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
      this.ribbonControl.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
      this.ribbonControl.SystemText.QatDialogAddButton = "&Add >>";
      this.ribbonControl.SystemText.QatDialogCancelButton = "Cancel";
      this.ribbonControl.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
      this.ribbonControl.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
      this.ribbonControl.SystemText.QatDialogOkButton = "OK";
      this.ribbonControl.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
      this.ribbonControl.SystemText.QatDialogRemoveButton = "&Remove";
      this.ribbonControl.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
      this.ribbonControl.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
      this.ribbonControl.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
      this.ribbonControl.TabGroupHeight = 14;
      this.ribbonControl.TabIndex = 0;
      this.ribbonControl.Text = "ribbonControl1";
      // 
      // backgroundPanel
      // 
      this.backgroundPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      this.backgroundPanel.Controls.Add(this.button1);
      this.backgroundPanel.Controls.Add(this.panel1);
      this.backgroundPanel.Controls.Add(this.pictureBoxIcon);
      this.backgroundPanel.Controls.Add(this.ribbonControl);
      this.backgroundPanel.Controls.Add(this.messageLabel);
      this.backgroundPanel.Controls.Add(this.button3);
      this.backgroundPanel.Controls.Add(this.button2);
      this.backgroundPanel.DisabledBackColor = System.Drawing.Color.Empty;
      this.backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.backgroundPanel.Font = new System.Drawing.Font("Tahoma", 8F);
      this.backgroundPanel.Location = new System.Drawing.Point(0, 0);
      this.backgroundPanel.Margin = new System.Windows.Forms.Padding(4);
      this.backgroundPanel.Name = "backgroundPanel";
      this.backgroundPanel.Size = new System.Drawing.Size(668, 272);
      this.backgroundPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
      this.backgroundPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(238)))));
      this.backgroundPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(215)))), ((int)(((byte)(224)))));
      this.backgroundPanel.Style.Border = DevComponents.DotNetBar.eBorderType.Raised;
      this.backgroundPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.backgroundPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
      this.backgroundPanel.Style.GradientAngle = 90;
      this.backgroundPanel.TabIndex = 10;
      // 
      // button1
      // 
      this.button1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
      this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.button1.Font = new System.Drawing.Font("Tahoma", 12F);
      this.button1.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_OK_32;
      this.button1.ImageFixedSize = new System.Drawing.Size(35, 35);
      this.button1.Location = new System.Drawing.Point(27, 205);
      this.button1.Margin = new System.Windows.Forms.Padding(4);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(204, 54);
      this.button1.TabIndex = 8;
      this.button1.Text = " Ok";
      this.button1.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
      this.button1.Translate = true;
      this.button1.Visible = false;
      this.button1.Click += new System.EventHandler(this.RegisterUserInput);
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.lblbInputText);
      this.panel1.Controls.Add(this.tbUserInput);
      this.panel1.Location = new System.Drawing.Point(13, 171);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(623, 27);
      this.panel1.TabIndex = 7;
      // 
      // lblbInputText
      // 
      this.lblbInputText.AutoSize = true;
      // 
      // 
      // 
      this.lblbInputText.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.lblbInputText.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.lblbInputText.Dock = System.Windows.Forms.DockStyle.Right;
      this.lblbInputText.Font = new System.Drawing.Font("Tahoma", 12F);
      this.lblbInputText.FormatMask = null;
      this.lblbInputText.Location = new System.Drawing.Point(182, 0);
      this.lblbInputText.Name = "lblbInputText";
      this.lblbInputText.Size = new System.Drawing.Size(44, 22);
      this.lblbInputText.TabIndex = 6;
      this.lblbInputText.Text = "label1";
      this.lblbInputText.Translate = false;
      // 
      // tbUserInput
      // 
      // 
      // 
      // 
      this.tbUserInput.Border.Class = "TextBoxBorder";
      this.tbUserInput.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.tbUserInput.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.tbUserInput.Dock = System.Windows.Forms.DockStyle.Right;
      this.tbUserInput.Font = new System.Drawing.Font("Tahoma", 12F);
      this.tbUserInput.FormatMask = null;
      this.tbUserInput.Location = new System.Drawing.Point(226, 0);
      this.tbUserInput.Name = "tbUserInput";
      this.tbUserInput.Size = new System.Drawing.Size(397, 27);
      this.tbUserInput.TabIndex = 5;
      // 
      // pictureBoxIcon
      // 
      this.pictureBoxIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.pictureBoxIcon.Location = new System.Drawing.Point(13, 68);
      this.pictureBoxIcon.Margin = new System.Windows.Forms.Padding(4);
      this.pictureBoxIcon.Name = "pictureBoxIcon";
      this.pictureBoxIcon.Size = new System.Drawing.Size(78, 97);
      this.pictureBoxIcon.TabIndex = 4;
      this.pictureBoxIcon.TabStop = false;
      // 
      // messageLabel
      // 
      this.messageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      // 
      // 
      // 
      this.messageLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.messageLabel.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.messageLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.messageLabel.FormatMask = null;
      this.messageLabel.Location = new System.Drawing.Point(111, 32);
      this.messageLabel.Margin = new System.Windows.Forms.Padding(4);
      this.messageLabel.Name = "messageLabel";
      this.messageLabel.SingleLineColor = System.Drawing.Color.Transparent;
      this.messageLabel.Size = new System.Drawing.Size(545, 132);
      this.messageLabel.TabIndex = 0;
      this.messageLabel.Tag = "NO_TRANSLATE";
      this.messageLabel.Text = "[message]";
      this.messageLabel.Translate = false;
      this.messageLabel.WordWrap = true;
      // 
      // button3
      // 
      this.button3.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button3.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
      this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.button3.Font = new System.Drawing.Font("Tahoma", 12F);
      this.button3.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_ApplicationExit_32;
      this.button3.ImageFixedSize = new System.Drawing.Size(35, 35);
      this.button3.Location = new System.Drawing.Point(451, 205);
      this.button3.Margin = new System.Windows.Forms.Padding(4);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(204, 54);
      this.button3.TabIndex = 3;
      this.button3.Text = "Cancel";
      this.button3.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
      this.button3.Translate = true;
      this.button3.Visible = false;
      this.button3.Click += new System.EventHandler(this.RegisterUserInput);
      // 
      // button2
      // 
      this.button2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
      this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.button2.Font = new System.Drawing.Font("Tahoma", 12F);
      this.button2.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_OK_32;
      this.button2.ImageFixedSize = new System.Drawing.Size(35, 35);
      this.button2.Location = new System.Drawing.Point(239, 205);
      this.button2.Margin = new System.Windows.Forms.Padding(4);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(204, 54);
      this.button2.TabIndex = 1;
      this.button2.Text = " Ok";
      this.button2.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
      this.button2.Translate = true;
      this.button2.Visible = false;
      this.button2.Click += new System.EventHandler(this.RegisterUserInput);
      // 
      // errorProvider
      // 
      this.errorProvider.ContainerControl = this;
      // 
      // MessageBoxForm
      // 
      this.AcceptButton = this.button2;
      this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(668, 272);
      this.Controls.Add(this.backgroundPanel);
      this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "MessageBoxForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Message";
      this.Activated += new System.EventHandler(this.MessageBoxFormActivated);
      this.backgroundPanel.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
      this.ResumeLayout(false);

		}

		#endregion

		private Actemium.Windows.Forms.DevComponents2.Controls.RibbonControl ribbonControl;
		private DevComponents.DotNetBar.PanelEx backgroundPanel;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX button2;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX messageLabel;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX button3;
    private System.Windows.Forms.PictureBox pictureBoxIcon;
    private Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX tbUserInput;
    private System.Windows.Forms.Panel panel1;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblbInputText;
    private System.Windows.Forms.ErrorProvider errorProvider;
    private Windows.Forms.DevComponents2.Controls.ButtonX button1;
  }
}