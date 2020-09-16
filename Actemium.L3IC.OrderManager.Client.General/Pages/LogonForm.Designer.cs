using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.Pages
{
  partial class LogonForm
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
            this.components = new System.ComponentModel.Container();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.autorisationGroupBox = new Actemium.Windows.Forms.DevComponents2.Controls.GroupPanel(this.components);
            this.logonButton = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
            this.passwordTextBox = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.usersComboBox = new Actemium.Windows.Forms.DevComponents2.Controls.ComboBoxEx(this.components);
            this.logonDefaultButton = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
            this.logoffButton = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
            this.lblPassword = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.lblUsername = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.autorisationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.RefreshTimerTick);
            // 
            // autorisationGroupBox
            // 
            this.autorisationGroupBox.CanvasColor = System.Drawing.SystemColors.Control;
            this.autorisationGroupBox.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.autorisationGroupBox.Controls.Add(this.logonButton);
            this.autorisationGroupBox.Controls.Add(this.passwordTextBox);
            this.autorisationGroupBox.Controls.Add(this.usersComboBox);
            this.autorisationGroupBox.Controls.Add(this.logonDefaultButton);
            this.autorisationGroupBox.Controls.Add(this.logoffButton);
            this.autorisationGroupBox.Controls.Add(this.lblPassword);
            this.autorisationGroupBox.Controls.Add(this.lblUsername);
            this.autorisationGroupBox.DisabledBackColor = System.Drawing.Color.Empty;
            this.autorisationGroupBox.Location = new System.Drawing.Point(283, 349);
            this.autorisationGroupBox.Name = "autorisationGroupBox";
            this.autorisationGroupBox.Size = new System.Drawing.Size(410, 155);
            // 
            // 
            // 
            this.autorisationGroupBox.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.autorisationGroupBox.Style.BackColorGradientAngle = 90;
            this.autorisationGroupBox.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.autorisationGroupBox.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.autorisationGroupBox.Style.BorderBottomWidth = 1;
            this.autorisationGroupBox.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.autorisationGroupBox.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.autorisationGroupBox.Style.BorderLeftWidth = 1;
            this.autorisationGroupBox.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.autorisationGroupBox.Style.BorderRightWidth = 1;
            this.autorisationGroupBox.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.autorisationGroupBox.Style.BorderTopWidth = 1;
            this.autorisationGroupBox.Style.CornerDiameter = 4;
            this.autorisationGroupBox.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.autorisationGroupBox.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.autorisationGroupBox.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.autorisationGroupBox.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.autorisationGroupBox.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.autorisationGroupBox.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.autorisationGroupBox.TabIndex = 7;
            this.autorisationGroupBox.Text = "Logon";
            this.autorisationGroupBox.Translate = true;
            // 
            // logonButton
            // 
            this.logonButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.logonButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.logonButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_Login_16;
            this.logonButton.Location = new System.Drawing.Point(290, 64);
            this.logonButton.Name = "logonButton";
            this.logonButton.Size = new System.Drawing.Size(100, 25);
            this.logonButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.logonButton.TabIndex = 6;
            this.logonButton.Text = "Logon";
            this.logonButton.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.logonButton.Translate = true;
            this.logonButton.Click += new System.EventHandler(this.LogonButtonClick);
            // 
            // passwordTextBox
            // 
            // 
            // 
            // 
            this.passwordTextBox.Border.Class = "TextBoxBorder";
            this.passwordTextBox.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.passwordTextBox.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.passwordTextBox.FormatMask = null;
            this.passwordTextBox.Location = new System.Drawing.Point(148, 38);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PreventEnterBeep = true;
            this.passwordTextBox.Size = new System.Drawing.Size(242, 20);
            this.passwordTextBox.TabIndex = 5;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // usersComboBox
            // 
            this.usersComboBox.DisplayMember = "Text";
            this.usersComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.usersComboBox.FormattingEnabled = true;
            this.usersComboBox.ItemHeight = 14;
            this.usersComboBox.Location = new System.Drawing.Point(148, 12);
            this.usersComboBox.Name = "usersComboBox";
            this.usersComboBox.Size = new System.Drawing.Size(242, 20);
            this.usersComboBox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.usersComboBox.TabIndex = 4;
            this.usersComboBox.SelectedIndexChanged += new System.EventHandler(this.UsersComboBoxSelectedIndexChanged);
            // 
            // logonDefaultButton
            // 
            this.logonDefaultButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.logonDefaultButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.logonDefaultButton.Enabled = false;
            this.logonDefaultButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_UserModify_16;
            this.logonDefaultButton.Location = new System.Drawing.Point(290, 95);
            this.logonDefaultButton.Name = "logonDefaultButton";
            this.logonDefaultButton.Size = new System.Drawing.Size(100, 25);
            this.logonDefaultButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.logonDefaultButton.TabIndex = 2;
            this.logonDefaultButton.Text = "Default User";
            this.logonDefaultButton.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.logonDefaultButton.Translate = true;
            this.logonDefaultButton.Click += new System.EventHandler(this.LogonDefaultButtonClick);
            // 
            // logoffButton
            // 
            this.logoffButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.logoffButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.logoffButton.Enabled = false;
            this.logoffButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_UserDelete_16;
            this.logoffButton.Location = new System.Drawing.Point(290, 64);
            this.logoffButton.Name = "logoffButton";
            this.logoffButton.Size = new System.Drawing.Size(100, 25);
            this.logoffButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.logoffButton.TabIndex = 2;
            this.logoffButton.Text = "Logoff";
            this.logoffButton.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.logoffButton.Translate = true;
            this.logoffButton.Click += new System.EventHandler(this.LogoffButtonClick);
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblPassword.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblPassword.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.lblPassword.FormatMask = null;
            this.lblPassword.Location = new System.Drawing.Point(13, 35);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(129, 23);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblPassword.Translate = true;
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblUsername.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUsername.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.lblUsername.FormatMask = null;
            this.lblUsername.Location = new System.Drawing.Point(13, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(129, 23);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "User";
            this.lblUsername.TextAlignment = System.Drawing.StringAlignment.Far;
            this.lblUsername.Translate = true;
            // 
            // OrdersStopOrderButtonX
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Location = new System.Drawing.Point(0, 0);
            this.buttonX1.Name = "OrdersStopOrderButtonX";
            this.buttonX1.Size = new System.Drawing.Size(0, 0);
            this.buttonX1.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackgroundImage = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources._ActemiumLogo;
            this.logoPictureBox.Location = new System.Drawing.Point(264, 110);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(452, 106);
            this.logoPictureBox.TabIndex = 8;
            this.logoPictureBox.TabStop = false;
            // 
            // LogonForm
            // 
            this.AcceptButton = this.logonButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1016, 639);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.autorisationGroupBox);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KeyPreview = true;
            this.Name = "LogonForm";
            this.Resize += new System.EventHandler(this.LogonFormResize);
            this.autorisationGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

		private System.Windows.Forms.Timer refreshTimer;
		private Actemium.Windows.Forms.DevComponents2.Controls.GroupPanel autorisationGroupBox;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX logoffButton;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblPassword;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblUsername;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX logonDefaultButton;
		private Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX passwordTextBox;
		private Actemium.Windows.Forms.DevComponents2.Controls.ComboBoxEx usersComboBox;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX logonButton;
		private System.Windows.Forms.PictureBox logoPictureBox;
		private DevComponents.DotNetBar.ButtonX buttonX1;
  }
}
