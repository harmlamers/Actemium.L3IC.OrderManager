using DevComponents.DotNetBar;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  partial class UserManagement2AddModifyPopupForm
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
            this.CancelButtonX = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
            this.OkButtonX = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
            this.ButtonPanelX = new DevComponents.DotNetBar.PanelEx();
            this.UserPanelX = new DevComponents.DotNetBar.PanelEx();
            this.UserEmptyPasswordCheckbox = new Actemium.Windows.Forms.DevComponents2.Controls.CheckBoxX();
            this.UserEmptyPasswordLabel = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.UsersIsSuperUserCheckBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.CheckBoxX();
            this.UsersIsSuperUserLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.UsersShowPasswordCheckBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.CheckBoxX();
            this.UsersConfirmPasswordTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.UsersPasswordTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.UsersShowPasswordLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.UsersConfirmPasswordLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.UsersPasswordLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.UsersSurNameTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.UsersNameTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.UsersUsernameTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.UsersSurNameLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.UsersNameLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.UsersUsernameLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.GroupPanelX = new DevComponents.DotNetBar.PanelEx();
            this.GroupsDomainGroupIdentifierTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.GroupsDescriptionTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.GroupsNameTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.GroupsDomainGroupIdentifierLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.GroupsDescriptionLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.GroupsNameLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.ComputerPanelX = new DevComponents.DotNetBar.PanelEx();
            this.ComputersACIManagedCheckBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.CheckBoxX();
            this.ComputersDescriptionTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.ComputersHostNameTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.ComputersACIManagedLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.ComputersDescriptionLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.ComputersHostNameLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.backgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.ButtonPanelX.SuspendLayout();
            this.UserPanelX.SuspendLayout();
            this.GroupPanelX.SuspendLayout();
            this.ComputerPanelX.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.Controls.Add(this.ButtonPanelX);
            this.backgroundPanel.Controls.Add(this.UserPanelX);
            this.backgroundPanel.Controls.Add(this.GroupPanelX);
            this.backgroundPanel.Controls.Add(this.ComputerPanelX);
            this.backgroundPanel.Size = new System.Drawing.Size(820, 195);
            this.backgroundPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.backgroundPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(238)))));
            this.backgroundPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(215)))), ((int)(((byte)(224)))));
            this.backgroundPanel.Style.Border = DevComponents.DotNetBar.eBorderType.Raised;
            this.backgroundPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.backgroundPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.backgroundPanel.Style.GradientAngle = 90;
            // 
            // CancelButtonX
            // 
            this.CancelButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.CancelButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.CancelButtonX.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButtonX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.CancelButtonX.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_ApplicationExit_32;
            this.CancelButtonX.ImageFixedSize = new System.Drawing.Size(35, 35);
            this.CancelButtonX.Location = new System.Drawing.Point(612, 7);
            this.CancelButtonX.Margin = new System.Windows.Forms.Padding(4);
            this.CancelButtonX.Name = "CancelButtonX";
            this.CancelButtonX.Size = new System.Drawing.Size(204, 54);
            this.CancelButtonX.TabIndex = 105;
            this.CancelButtonX.Text = "Cancel";
            this.CancelButtonX.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.CancelButtonX.Translate = true;
            // 
            // OkButtonX
            // 
            this.OkButtonX.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.OkButtonX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButtonX.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.OkButtonX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.OkButtonX.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_OK_32;
            this.OkButtonX.ImageFixedSize = new System.Drawing.Size(35, 35);
            this.OkButtonX.Location = new System.Drawing.Point(400, 7);
            this.OkButtonX.Margin = new System.Windows.Forms.Padding(4);
            this.OkButtonX.Name = "OkButtonX";
            this.OkButtonX.Size = new System.Drawing.Size(204, 54);
            this.OkButtonX.TabIndex = 100;
            this.OkButtonX.Text = "OK";
            this.OkButtonX.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.OkButtonX.Translate = true;
            this.OkButtonX.Click += new System.EventHandler(this.OkButtonXClick);
            // 
            // ButtonPanelX
            // 
            this.ButtonPanelX.Controls.Add(this.OkButtonX);
            this.ButtonPanelX.Controls.Add(this.CancelButtonX);
            this.ButtonPanelX.DisabledBackColor = System.Drawing.Color.Empty;
            this.ButtonPanelX.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanelX.Location = new System.Drawing.Point(0, 130);
            this.ButtonPanelX.Name = "ButtonPanelX";
            this.ButtonPanelX.Size = new System.Drawing.Size(820, 65);
            this.ButtonPanelX.TabIndex = 12;
            // 
            // UserPanelX
            // 
            this.UserPanelX.Controls.Add(this.UserEmptyPasswordCheckbox);
            this.UserPanelX.Controls.Add(this.UserEmptyPasswordLabel);
            this.UserPanelX.Controls.Add(this.UsersIsSuperUserCheckBoxX);
            this.UserPanelX.Controls.Add(this.UsersIsSuperUserLabelX);
            this.UserPanelX.Controls.Add(this.UsersShowPasswordCheckBoxX);
            this.UserPanelX.Controls.Add(this.UsersConfirmPasswordTextBoxX);
            this.UserPanelX.Controls.Add(this.UsersPasswordTextBoxX);
            this.UserPanelX.Controls.Add(this.UsersShowPasswordLabelX);
            this.UserPanelX.Controls.Add(this.UsersConfirmPasswordLabelX);
            this.UserPanelX.Controls.Add(this.UsersPasswordLabelX);
            this.UserPanelX.Controls.Add(this.UsersSurNameTextBoxX);
            this.UserPanelX.Controls.Add(this.UsersNameTextBoxX);
            this.UserPanelX.Controls.Add(this.UsersUsernameTextBoxX);
            this.UserPanelX.Controls.Add(this.UsersSurNameLabelX);
            this.UserPanelX.Controls.Add(this.UsersNameLabelX);
            this.UserPanelX.Controls.Add(this.UsersUsernameLabelX);
            this.UserPanelX.DisabledBackColor = System.Drawing.Color.Empty;
            this.UserPanelX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPanelX.Location = new System.Drawing.Point(0, 0);
            this.UserPanelX.Name = "UserPanelX";
            this.UserPanelX.Size = new System.Drawing.Size(820, 195);
            this.UserPanelX.TabIndex = 13;
            // 
            // UserEmptyPasswordCheckbox
            // 
            this.UserEmptyPasswordCheckbox.AutoSize = true;
            // 
            // 
            // 
            this.UserEmptyPasswordCheckbox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UserEmptyPasswordCheckbox.CheckSignSize = new System.Drawing.Size(27, 27);
            this.UserEmptyPasswordCheckbox.Location = new System.Drawing.Point(601, 97);
            this.UserEmptyPasswordCheckbox.MaximumSize = new System.Drawing.Size(27, 27);
            this.UserEmptyPasswordCheckbox.MinimumSize = new System.Drawing.Size(27, 27);
            this.UserEmptyPasswordCheckbox.Name = "UserEmptyPasswordCheckbox";
            this.UserEmptyPasswordCheckbox.Size = new System.Drawing.Size(27, 27);
            this.UserEmptyPasswordCheckbox.TabIndex = 45;
            this.UserEmptyPasswordCheckbox.Translate = false;
            this.UserEmptyPasswordCheckbox.CheckedChanged += new System.EventHandler(this.UserEmptyPasswordCheckbox_CheckedChanged);
            // 
            // UserEmptyPasswordLabel
            // 
            // 
            // 
            // 
            this.UserEmptyPasswordLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UserEmptyPasswordLabel.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UserEmptyPasswordLabel.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UserEmptyPasswordLabel.FormatMask = null;
            this.UserEmptyPasswordLabel.Location = new System.Drawing.Point(421, 96);
            this.UserEmptyPasswordLabel.Name = "UserEmptyPasswordLabel";
            this.UserEmptyPasswordLabel.Size = new System.Drawing.Size(174, 22);
            this.UserEmptyPasswordLabel.TabIndex = 41;
            this.UserEmptyPasswordLabel.Text = "Use empty password";
            this.UserEmptyPasswordLabel.Translate = true;
            // 
            // UsersIsSuperUserCheckBoxX
            // 
            this.UsersIsSuperUserCheckBoxX.AutoSize = true;
            // 
            // 
            // 
            this.UsersIsSuperUserCheckBoxX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersIsSuperUserCheckBoxX.CheckSignSize = new System.Drawing.Size(27, 27);
            this.UsersIsSuperUserCheckBoxX.Location = new System.Drawing.Point(204, 96);
            this.UsersIsSuperUserCheckBoxX.MaximumSize = new System.Drawing.Size(27, 27);
            this.UsersIsSuperUserCheckBoxX.MinimumSize = new System.Drawing.Size(27, 27);
            this.UsersIsSuperUserCheckBoxX.Name = "UsersIsSuperUserCheckBoxX";
            this.UsersIsSuperUserCheckBoxX.Size = new System.Drawing.Size(27, 27);
            this.UsersIsSuperUserCheckBoxX.TabIndex = 20;
            this.UsersIsSuperUserCheckBoxX.Translate = false;
            // 
            // UsersIsSuperUserLabelX
            // 
            // 
            // 
            // 
            this.UsersIsSuperUserLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersIsSuperUserLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UsersIsSuperUserLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UsersIsSuperUserLabelX.FormatMask = null;
            this.UsersIsSuperUserLabelX.Location = new System.Drawing.Point(12, 96);
            this.UsersIsSuperUserLabelX.Name = "UsersIsSuperUserLabelX";
            this.UsersIsSuperUserLabelX.Size = new System.Drawing.Size(186, 22);
            this.UsersIsSuperUserLabelX.TabIndex = 23;
            this.UsersIsSuperUserLabelX.Text = "Superuser";
            this.UsersIsSuperUserLabelX.Translate = true;
            // 
            // UsersShowPasswordCheckBoxX
            // 
            this.UsersShowPasswordCheckBoxX.AutoSize = true;
            // 
            // 
            // 
            this.UsersShowPasswordCheckBoxX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersShowPasswordCheckBoxX.CheckSignSize = new System.Drawing.Size(27, 27);
            this.UsersShowPasswordCheckBoxX.Location = new System.Drawing.Point(601, 68);
            this.UsersShowPasswordCheckBoxX.MaximumSize = new System.Drawing.Size(27, 27);
            this.UsersShowPasswordCheckBoxX.MinimumSize = new System.Drawing.Size(27, 27);
            this.UsersShowPasswordCheckBoxX.Name = "UsersShowPasswordCheckBoxX";
            this.UsersShowPasswordCheckBoxX.Size = new System.Drawing.Size(27, 27);
            this.UsersShowPasswordCheckBoxX.TabIndex = 40;
            this.UsersShowPasswordCheckBoxX.Translate = false;
            this.UsersShowPasswordCheckBoxX.CheckedChanged += new System.EventHandler(this.UsersShowPasswordCheckBoxXCheckedChanged);
            // 
            // UsersConfirmPasswordTextBoxX
            // 
            // 
            // 
            // 
            this.UsersConfirmPasswordTextBoxX.Border.Class = "TextBoxBorder";
            this.UsersConfirmPasswordTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersConfirmPasswordTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UsersConfirmPasswordTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UsersConfirmPasswordTextBoxX.FormatMask = null;
            this.UsersConfirmPasswordTextBoxX.Location = new System.Drawing.Point(601, 40);
            this.UsersConfirmPasswordTextBoxX.Name = "UsersConfirmPasswordTextBoxX";
            this.UsersConfirmPasswordTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.UsersConfirmPasswordTextBoxX.TabIndex = 35;
            this.UsersConfirmPasswordTextBoxX.UseSystemPasswordChar = true;
            // 
            // UsersPasswordTextBoxX
            // 
            // 
            // 
            // 
            this.UsersPasswordTextBoxX.Border.Class = "TextBoxBorder";
            this.UsersPasswordTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersPasswordTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UsersPasswordTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UsersPasswordTextBoxX.FormatMask = null;
            this.UsersPasswordTextBoxX.Location = new System.Drawing.Point(601, 12);
            this.UsersPasswordTextBoxX.Name = "UsersPasswordTextBoxX";
            this.UsersPasswordTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.UsersPasswordTextBoxX.TabIndex = 30;
            this.UsersPasswordTextBoxX.UseSystemPasswordChar = true;
            // 
            // UsersShowPasswordLabelX
            // 
            // 
            // 
            // 
            this.UsersShowPasswordLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersShowPasswordLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UsersShowPasswordLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UsersShowPasswordLabelX.FormatMask = null;
            this.UsersShowPasswordLabelX.Location = new System.Drawing.Point(421, 68);
            this.UsersShowPasswordLabelX.Name = "UsersShowPasswordLabelX";
            this.UsersShowPasswordLabelX.Size = new System.Drawing.Size(174, 22);
            this.UsersShowPasswordLabelX.TabIndex = 17;
            this.UsersShowPasswordLabelX.Text = "Show password";
            this.UsersShowPasswordLabelX.Translate = true;
            // 
            // UsersConfirmPasswordLabelX
            // 
            // 
            // 
            // 
            this.UsersConfirmPasswordLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersConfirmPasswordLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UsersConfirmPasswordLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UsersConfirmPasswordLabelX.FormatMask = null;
            this.UsersConfirmPasswordLabelX.Location = new System.Drawing.Point(421, 40);
            this.UsersConfirmPasswordLabelX.Name = "UsersConfirmPasswordLabelX";
            this.UsersConfirmPasswordLabelX.Size = new System.Drawing.Size(174, 22);
            this.UsersConfirmPasswordLabelX.TabIndex = 16;
            this.UsersConfirmPasswordLabelX.Text = "Confirm password";
            this.UsersConfirmPasswordLabelX.Translate = true;
            // 
            // UsersPasswordLabelX
            // 
            // 
            // 
            // 
            this.UsersPasswordLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersPasswordLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UsersPasswordLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UsersPasswordLabelX.FormatMask = null;
            this.UsersPasswordLabelX.Location = new System.Drawing.Point(421, 12);
            this.UsersPasswordLabelX.Name = "UsersPasswordLabelX";
            this.UsersPasswordLabelX.Size = new System.Drawing.Size(174, 22);
            this.UsersPasswordLabelX.TabIndex = 15;
            this.UsersPasswordLabelX.Text = "Password";
            this.UsersPasswordLabelX.Translate = true;
            // 
            // UsersSurNameTextBoxX
            // 
            // 
            // 
            // 
            this.UsersSurNameTextBoxX.Border.Class = "TextBoxBorder";
            this.UsersSurNameTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersSurNameTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UsersSurNameTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UsersSurNameTextBoxX.FormatMask = null;
            this.UsersSurNameTextBoxX.Location = new System.Drawing.Point(204, 68);
            this.UsersSurNameTextBoxX.Name = "UsersSurNameTextBoxX";
            this.UsersSurNameTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.UsersSurNameTextBoxX.TabIndex = 10;
            // 
            // UsersNameTextBoxX
            // 
            // 
            // 
            // 
            this.UsersNameTextBoxX.Border.Class = "TextBoxBorder";
            this.UsersNameTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersNameTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UsersNameTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UsersNameTextBoxX.FormatMask = null;
            this.UsersNameTextBoxX.Location = new System.Drawing.Point(204, 40);
            this.UsersNameTextBoxX.Name = "UsersNameTextBoxX";
            this.UsersNameTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.UsersNameTextBoxX.TabIndex = 5;
            // 
            // UsersUsernameTextBoxX
            // 
            // 
            // 
            // 
            this.UsersUsernameTextBoxX.Border.Class = "TextBoxBorder";
            this.UsersUsernameTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersUsernameTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UsersUsernameTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UsersUsernameTextBoxX.FormatMask = null;
            this.UsersUsernameTextBoxX.Location = new System.Drawing.Point(204, 12);
            this.UsersUsernameTextBoxX.Name = "UsersUsernameTextBoxX";
            this.UsersUsernameTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.UsersUsernameTextBoxX.TabIndex = 0;
            // 
            // UsersSurNameLabelX
            // 
            // 
            // 
            // 
            this.UsersSurNameLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersSurNameLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UsersSurNameLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UsersSurNameLabelX.FormatMask = null;
            this.UsersSurNameLabelX.Location = new System.Drawing.Point(12, 68);
            this.UsersSurNameLabelX.Name = "UsersSurNameLabelX";
            this.UsersSurNameLabelX.Size = new System.Drawing.Size(186, 22);
            this.UsersSurNameLabelX.TabIndex = 9;
            this.UsersSurNameLabelX.Text = "Surname";
            this.UsersSurNameLabelX.Translate = true;
            // 
            // UsersNameLabelX
            // 
            // 
            // 
            // 
            this.UsersNameLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersNameLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UsersNameLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UsersNameLabelX.FormatMask = null;
            this.UsersNameLabelX.Location = new System.Drawing.Point(12, 40);
            this.UsersNameLabelX.Name = "UsersNameLabelX";
            this.UsersNameLabelX.Size = new System.Drawing.Size(186, 22);
            this.UsersNameLabelX.TabIndex = 8;
            this.UsersNameLabelX.Text = "Name";
            this.UsersNameLabelX.Translate = true;
            // 
            // UsersUsernameLabelX
            // 
            // 
            // 
            // 
            this.UsersUsernameLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersUsernameLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.UsersUsernameLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.UsersUsernameLabelX.FormatMask = null;
            this.UsersUsernameLabelX.Location = new System.Drawing.Point(12, 12);
            this.UsersUsernameLabelX.Name = "UsersUsernameLabelX";
            this.UsersUsernameLabelX.Size = new System.Drawing.Size(186, 22);
            this.UsersUsernameLabelX.TabIndex = 7;
            this.UsersUsernameLabelX.Text = "Username";
            this.UsersUsernameLabelX.Translate = true;
            // 
            // GroupPanelX
            // 
            this.GroupPanelX.Controls.Add(this.GroupsDomainGroupIdentifierTextBoxX);
            this.GroupPanelX.Controls.Add(this.GroupsDescriptionTextBoxX);
            this.GroupPanelX.Controls.Add(this.GroupsNameTextBoxX);
            this.GroupPanelX.Controls.Add(this.GroupsDomainGroupIdentifierLabelX);
            this.GroupPanelX.Controls.Add(this.GroupsDescriptionLabelX);
            this.GroupPanelX.Controls.Add(this.GroupsNameLabelX);
            this.GroupPanelX.DisabledBackColor = System.Drawing.Color.Empty;
            this.GroupPanelX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GroupPanelX.Location = new System.Drawing.Point(0, 0);
            this.GroupPanelX.Name = "GroupPanelX";
            this.GroupPanelX.Size = new System.Drawing.Size(820, 195);
            this.GroupPanelX.TabIndex = 13;
            // 
            // GroupsDomainGroupIdentifierTextBoxX
            // 
            // 
            // 
            // 
            this.GroupsDomainGroupIdentifierTextBoxX.Border.Class = "TextBoxBorder";
            this.GroupsDomainGroupIdentifierTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GroupsDomainGroupIdentifierTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.GroupsDomainGroupIdentifierTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.GroupsDomainGroupIdentifierTextBoxX.FormatMask = null;
            this.GroupsDomainGroupIdentifierTextBoxX.Location = new System.Drawing.Point(204, 68);
            this.GroupsDomainGroupIdentifierTextBoxX.Name = "GroupsDomainGroupIdentifierTextBoxX";
            this.GroupsDomainGroupIdentifierTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.GroupsDomainGroupIdentifierTextBoxX.TabIndex = 10;
            // 
            // GroupsDescriptionTextBoxX
            // 
            // 
            // 
            // 
            this.GroupsDescriptionTextBoxX.Border.Class = "TextBoxBorder";
            this.GroupsDescriptionTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GroupsDescriptionTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.GroupsDescriptionTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.GroupsDescriptionTextBoxX.FormatMask = null;
            this.GroupsDescriptionTextBoxX.Location = new System.Drawing.Point(204, 40);
            this.GroupsDescriptionTextBoxX.Name = "GroupsDescriptionTextBoxX";
            this.GroupsDescriptionTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.GroupsDescriptionTextBoxX.TabIndex = 5;
            // 
            // GroupsNameTextBoxX
            // 
            // 
            // 
            // 
            this.GroupsNameTextBoxX.Border.Class = "TextBoxBorder";
            this.GroupsNameTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GroupsNameTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.GroupsNameTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.GroupsNameTextBoxX.FormatMask = null;
            this.GroupsNameTextBoxX.Location = new System.Drawing.Point(204, 12);
            this.GroupsNameTextBoxX.Name = "GroupsNameTextBoxX";
            this.GroupsNameTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.GroupsNameTextBoxX.TabIndex = 0;
            // 
            // GroupsDomainGroupIdentifierLabelX
            // 
            // 
            // 
            // 
            this.GroupsDomainGroupIdentifierLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GroupsDomainGroupIdentifierLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.GroupsDomainGroupIdentifierLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.GroupsDomainGroupIdentifierLabelX.FormatMask = null;
            this.GroupsDomainGroupIdentifierLabelX.Location = new System.Drawing.Point(12, 68);
            this.GroupsDomainGroupIdentifierLabelX.Name = "GroupsDomainGroupIdentifierLabelX";
            this.GroupsDomainGroupIdentifierLabelX.Size = new System.Drawing.Size(186, 22);
            this.GroupsDomainGroupIdentifierLabelX.TabIndex = 15;
            this.GroupsDomainGroupIdentifierLabelX.Text = "Domain Group Identifier";
            this.GroupsDomainGroupIdentifierLabelX.Translate = true;
            // 
            // GroupsDescriptionLabelX
            // 
            // 
            // 
            // 
            this.GroupsDescriptionLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GroupsDescriptionLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.GroupsDescriptionLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.GroupsDescriptionLabelX.FormatMask = null;
            this.GroupsDescriptionLabelX.Location = new System.Drawing.Point(12, 40);
            this.GroupsDescriptionLabelX.Name = "GroupsDescriptionLabelX";
            this.GroupsDescriptionLabelX.Size = new System.Drawing.Size(153, 22);
            this.GroupsDescriptionLabelX.TabIndex = 14;
            this.GroupsDescriptionLabelX.Text = "Description";
            this.GroupsDescriptionLabelX.Translate = true;
            // 
            // GroupsNameLabelX
            // 
            // 
            // 
            // 
            this.GroupsNameLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.GroupsNameLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.GroupsNameLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.GroupsNameLabelX.FormatMask = null;
            this.GroupsNameLabelX.Location = new System.Drawing.Point(12, 12);
            this.GroupsNameLabelX.Name = "GroupsNameLabelX";
            this.GroupsNameLabelX.Size = new System.Drawing.Size(153, 22);
            this.GroupsNameLabelX.TabIndex = 13;
            this.GroupsNameLabelX.Text = "Name";
            this.GroupsNameLabelX.Translate = true;
            // 
            // ComputerPanelX
            // 
            this.ComputerPanelX.Controls.Add(this.ComputersACIManagedCheckBoxX);
            this.ComputerPanelX.Controls.Add(this.ComputersDescriptionTextBoxX);
            this.ComputerPanelX.Controls.Add(this.ComputersHostNameTextBoxX);
            this.ComputerPanelX.Controls.Add(this.ComputersACIManagedLabelX);
            this.ComputerPanelX.Controls.Add(this.ComputersDescriptionLabelX);
            this.ComputerPanelX.Controls.Add(this.ComputersHostNameLabelX);
            this.ComputerPanelX.DisabledBackColor = System.Drawing.Color.Empty;
            this.ComputerPanelX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComputerPanelX.Location = new System.Drawing.Point(0, 0);
            this.ComputerPanelX.Name = "ComputerPanelX";
            this.ComputerPanelX.Size = new System.Drawing.Size(820, 195);
            this.ComputerPanelX.TabIndex = 13;
            // 
            // ComputersACIManagedCheckBoxX
            // 
            this.ComputersACIManagedCheckBoxX.AutoSize = true;
            // 
            // 
            // 
            this.ComputersACIManagedCheckBoxX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ComputersACIManagedCheckBoxX.CheckSignSize = new System.Drawing.Size(27, 27);
            this.ComputersACIManagedCheckBoxX.Location = new System.Drawing.Point(204, 68);
            this.ComputersACIManagedCheckBoxX.MaximumSize = new System.Drawing.Size(27, 27);
            this.ComputersACIManagedCheckBoxX.MinimumSize = new System.Drawing.Size(27, 27);
            this.ComputersACIManagedCheckBoxX.Name = "ComputersACIManagedCheckBoxX";
            this.ComputersACIManagedCheckBoxX.Size = new System.Drawing.Size(27, 27);
            this.ComputersACIManagedCheckBoxX.TabIndex = 21;
            this.ComputersACIManagedCheckBoxX.Translate = false;
            // 
            // ComputersDescriptionTextBoxX
            // 
            // 
            // 
            // 
            this.ComputersDescriptionTextBoxX.Border.Class = "TextBoxBorder";
            this.ComputersDescriptionTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ComputersDescriptionTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.ComputersDescriptionTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ComputersDescriptionTextBoxX.FormatMask = null;
            this.ComputersDescriptionTextBoxX.Location = new System.Drawing.Point(204, 40);
            this.ComputersDescriptionTextBoxX.Name = "ComputersDescriptionTextBoxX";
            this.ComputersDescriptionTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.ComputersDescriptionTextBoxX.TabIndex = 12;
            // 
            // ComputersHostNameTextBoxX
            // 
            // 
            // 
            // 
            this.ComputersHostNameTextBoxX.Border.Class = "TextBoxBorder";
            this.ComputersHostNameTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ComputersHostNameTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.ComputersHostNameTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ComputersHostNameTextBoxX.FormatMask = null;
            this.ComputersHostNameTextBoxX.Location = new System.Drawing.Point(204, 12);
            this.ComputersHostNameTextBoxX.Name = "ComputersHostNameTextBoxX";
            this.ComputersHostNameTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.ComputersHostNameTextBoxX.TabIndex = 11;
            // 
            // ComputersACIManagedLabelX
            // 
            // 
            // 
            // 
            this.ComputersACIManagedLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ComputersACIManagedLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.ComputersACIManagedLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ComputersACIManagedLabelX.FormatMask = null;
            this.ComputersACIManagedLabelX.Location = new System.Drawing.Point(12, 68);
            this.ComputersACIManagedLabelX.Name = "ComputersACIManagedLabelX";
            this.ComputersACIManagedLabelX.Size = new System.Drawing.Size(186, 22);
            this.ComputersACIManagedLabelX.TabIndex = 15;
            this.ComputersACIManagedLabelX.Text = "ACI Managed";
            this.ComputersACIManagedLabelX.Translate = true;
            // 
            // ComputersDescriptionLabelX
            // 
            // 
            // 
            // 
            this.ComputersDescriptionLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ComputersDescriptionLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.ComputersDescriptionLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ComputersDescriptionLabelX.FormatMask = null;
            this.ComputersDescriptionLabelX.Location = new System.Drawing.Point(12, 40);
            this.ComputersDescriptionLabelX.Name = "ComputersDescriptionLabelX";
            this.ComputersDescriptionLabelX.Size = new System.Drawing.Size(186, 22);
            this.ComputersDescriptionLabelX.TabIndex = 14;
            this.ComputersDescriptionLabelX.Text = "Description";
            this.ComputersDescriptionLabelX.Translate = true;
            // 
            // ComputersHostNameLabelX
            // 
            // 
            // 
            // 
            this.ComputersHostNameLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ComputersHostNameLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.ComputersHostNameLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.ComputersHostNameLabelX.FormatMask = null;
            this.ComputersHostNameLabelX.Location = new System.Drawing.Point(12, 12);
            this.ComputersHostNameLabelX.Name = "ComputersHostNameLabelX";
            this.ComputersHostNameLabelX.Size = new System.Drawing.Size(186, 22);
            this.ComputersHostNameLabelX.TabIndex = 13;
            this.ComputersHostNameLabelX.Text = "Host name";
            this.ComputersHostNameLabelX.Translate = true;
            // 
            // UserManagement2AddModifyPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 195);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UserManagement2AddModifyPopupForm";
            this.Text = "UserManagementAddModifyPopupForm";
            this.Activated += new System.EventHandler(this.UserManagement2AddModifyPopupFormActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserManagement2AddModifyPopupFormFormClosing);
            this.Controls.SetChildIndex(this.backgroundPanel, 0);
            this.backgroundPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ButtonPanelX.ResumeLayout(false);
            this.UserPanelX.ResumeLayout(false);
            this.UserPanelX.PerformLayout();
            this.GroupPanelX.ResumeLayout(false);
            this.ComputerPanelX.ResumeLayout(false);
            this.ComputerPanelX.PerformLayout();
            this.ResumeLayout(false);

    }




    #endregion

    private Windows.Forms.DevComponents2.Controls.ButtonX OkButtonX;
    private Windows.Forms.DevComponents2.Controls.ButtonX CancelButtonX;
    private PanelEx UserPanelX;
    private PanelEx GroupPanelX;
    private PanelEx ComputerPanelX;
    private PanelEx ButtonPanelX;
    private Windows.Forms.DevComponents2.Controls.LabelX UsersSurNameLabelX;
    private Windows.Forms.DevComponents2.Controls.LabelX UsersNameLabelX;
    private Windows.Forms.DevComponents2.Controls.LabelX UsersUsernameLabelX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX UsersNameTextBoxX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX UsersUsernameTextBoxX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX UsersSurNameTextBoxX;
    private Windows.Forms.DevComponents2.Controls.CheckBoxX UsersShowPasswordCheckBoxX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX UsersConfirmPasswordTextBoxX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX UsersPasswordTextBoxX;
    private Windows.Forms.DevComponents2.Controls.LabelX UsersShowPasswordLabelX;
    private Windows.Forms.DevComponents2.Controls.LabelX UsersConfirmPasswordLabelX;
    private Windows.Forms.DevComponents2.Controls.LabelX UsersPasswordLabelX;
    private Windows.Forms.DevComponents2.Controls.CheckBoxX UsersIsSuperUserCheckBoxX;
    private Windows.Forms.DevComponents2.Controls.LabelX UsersIsSuperUserLabelX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX GroupsDomainGroupIdentifierTextBoxX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX GroupsDescriptionTextBoxX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX GroupsNameTextBoxX;
    private Windows.Forms.DevComponents2.Controls.LabelX GroupsDomainGroupIdentifierLabelX;
    private Windows.Forms.DevComponents2.Controls.LabelX GroupsDescriptionLabelX;
    private Windows.Forms.DevComponents2.Controls.LabelX GroupsNameLabelX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX ComputersDescriptionTextBoxX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX ComputersHostNameTextBoxX;
    private Windows.Forms.DevComponents2.Controls.LabelX ComputersACIManagedLabelX;
    private Windows.Forms.DevComponents2.Controls.LabelX ComputersDescriptionLabelX;
    private Windows.Forms.DevComponents2.Controls.LabelX ComputersHostNameLabelX;
    private Windows.Forms.DevComponents2.Controls.CheckBoxX ComputersACIManagedCheckBoxX;
    private Windows.Forms.DevComponents2.Controls.CheckBoxX UserEmptyPasswordCheckbox;
    private Windows.Forms.DevComponents2.Controls.LabelX UserEmptyPasswordLabel;
  }
}