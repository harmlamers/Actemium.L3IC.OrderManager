using DevComponents.DotNetBar;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  partial class ChangePasswordPopupForm
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
            this.OldPasswordTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.OldPasswordLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.UsersShowPasswordCheckBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.CheckBoxX();
            this.UsersConfirmPasswordTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.UsersPasswordTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.UsersShowPasswordLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.UsersConfirmPasswordLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.UsersPasswordLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.UserEmptyPasswordLabel = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.UserEmptyPasswordCheckbox = new Actemium.Windows.Forms.DevComponents2.Controls.CheckBoxX();
            this.backgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.ButtonPanelX.SuspendLayout();
            this.UserPanelX.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.Controls.Add(this.ButtonPanelX);
            this.backgroundPanel.Controls.Add(this.UserPanelX);
            this.backgroundPanel.Size = new System.Drawing.Size(447, 222);
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
            this.CancelButtonX.Location = new System.Drawing.Point(239, 7);
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
            this.OkButtonX.Location = new System.Drawing.Point(27, 7);
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
            this.ButtonPanelX.Location = new System.Drawing.Point(0, 157);
            this.ButtonPanelX.Name = "ButtonPanelX";
            this.ButtonPanelX.Size = new System.Drawing.Size(447, 65);
            this.ButtonPanelX.TabIndex = 12;
            // 
            // UserPanelX
            // 
            this.UserPanelX.Controls.Add(this.UserEmptyPasswordCheckbox);
            this.UserPanelX.Controls.Add(this.UserEmptyPasswordLabel);
            this.UserPanelX.Controls.Add(this.OldPasswordTextBoxX);
            this.UserPanelX.Controls.Add(this.OldPasswordLabelX);
            this.UserPanelX.Controls.Add(this.UsersShowPasswordCheckBoxX);
            this.UserPanelX.Controls.Add(this.UsersConfirmPasswordTextBoxX);
            this.UserPanelX.Controls.Add(this.UsersPasswordTextBoxX);
            this.UserPanelX.Controls.Add(this.UsersShowPasswordLabelX);
            this.UserPanelX.Controls.Add(this.UsersConfirmPasswordLabelX);
            this.UserPanelX.Controls.Add(this.UsersPasswordLabelX);
            this.UserPanelX.DisabledBackColor = System.Drawing.Color.Empty;
            this.UserPanelX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserPanelX.Location = new System.Drawing.Point(0, 0);
            this.UserPanelX.Name = "UserPanelX";
            this.UserPanelX.Size = new System.Drawing.Size(447, 222);
            this.UserPanelX.TabIndex = 13;
            // 
            // OldPasswordTextBoxX
            // 
            // 
            // 
            // 
            this.OldPasswordTextBoxX.Border.Class = "TextBoxBorder";
            this.OldPasswordTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.OldPasswordTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.OldPasswordTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.OldPasswordTextBoxX.FormatMask = null;
            this.OldPasswordTextBoxX.Location = new System.Drawing.Point(192, 11);
            this.OldPasswordTextBoxX.Name = "OldPasswordTextBoxX";
            this.OldPasswordTextBoxX.Size = new System.Drawing.Size(243, 27);
            this.OldPasswordTextBoxX.TabIndex = 20;
            this.OldPasswordTextBoxX.UseSystemPasswordChar = true;
            // 
            // OldPasswordLabelX
            // 
            // 
            // 
            // 
            this.OldPasswordLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.OldPasswordLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.OldPasswordLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.OldPasswordLabelX.FormatMask = null;
            this.OldPasswordLabelX.Location = new System.Drawing.Point(12, 16);
            this.OldPasswordLabelX.Name = "OldPasswordLabelX";
            this.OldPasswordLabelX.Size = new System.Drawing.Size(174, 22);
            this.OldPasswordLabelX.TabIndex = 41;
            this.OldPasswordLabelX.Text = "Old password";
            this.OldPasswordLabelX.Translate = true;
            // 
            // UsersShowPasswordCheckBoxX
            // 
            this.UsersShowPasswordCheckBoxX.AutoSize = true;
            // 
            // 
            // 
            this.UsersShowPasswordCheckBoxX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UsersShowPasswordCheckBoxX.CheckSignSize = new System.Drawing.Size(27, 27);
            this.UsersShowPasswordCheckBoxX.Location = new System.Drawing.Point(192, 95);
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
            this.UsersConfirmPasswordTextBoxX.Location = new System.Drawing.Point(192, 67);
            this.UsersConfirmPasswordTextBoxX.Name = "UsersConfirmPasswordTextBoxX";
            this.UsersConfirmPasswordTextBoxX.Size = new System.Drawing.Size(243, 27);
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
            this.UsersPasswordTextBoxX.Location = new System.Drawing.Point(192, 39);
            this.UsersPasswordTextBoxX.Name = "UsersPasswordTextBoxX";
            this.UsersPasswordTextBoxX.Size = new System.Drawing.Size(243, 27);
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
            this.UsersShowPasswordLabelX.Location = new System.Drawing.Point(12, 100);
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
            this.UsersConfirmPasswordLabelX.Location = new System.Drawing.Point(12, 72);
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
            this.UsersPasswordLabelX.Location = new System.Drawing.Point(12, 44);
            this.UsersPasswordLabelX.Name = "UsersPasswordLabelX";
            this.UsersPasswordLabelX.Size = new System.Drawing.Size(174, 22);
            this.UsersPasswordLabelX.TabIndex = 15;
            this.UsersPasswordLabelX.Text = "New password";
            this.UsersPasswordLabelX.Translate = true;
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
            this.UserEmptyPasswordLabel.Location = new System.Drawing.Point(12, 128);
            this.UserEmptyPasswordLabel.Name = "UserEmptyPasswordLabel";
            this.UserEmptyPasswordLabel.Size = new System.Drawing.Size(174, 22);
            this.UserEmptyPasswordLabel.TabIndex = 42;
            this.UserEmptyPasswordLabel.Text = "Use empty password";
            this.UserEmptyPasswordLabel.Translate = true;
            // 
            // UserEmptyPasswordCheckbox
            // 
            this.UserEmptyPasswordCheckbox.AutoSize = true;
            // 
            // 
            // 
            this.UserEmptyPasswordCheckbox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.UserEmptyPasswordCheckbox.CheckSignSize = new System.Drawing.Size(27, 27);
            this.UserEmptyPasswordCheckbox.Location = new System.Drawing.Point(192, 123);
            this.UserEmptyPasswordCheckbox.MaximumSize = new System.Drawing.Size(27, 27);
            this.UserEmptyPasswordCheckbox.MinimumSize = new System.Drawing.Size(27, 27);
            this.UserEmptyPasswordCheckbox.Name = "UserEmptyPasswordCheckbox";
            this.UserEmptyPasswordCheckbox.Size = new System.Drawing.Size(27, 27);
            this.UserEmptyPasswordCheckbox.TabIndex = 43;
            this.UserEmptyPasswordCheckbox.Translate = false;
            this.UserEmptyPasswordCheckbox.CheckedChanged += new System.EventHandler(this.UserEmptyPasswordCheckbox_CheckedChanged);
            // 
            // ChangePasswordPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 222);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChangePasswordPopupForm";
            this.Text = "UserManagementAddModifyPopupForm";
            this.Activated += new System.EventHandler(this.UserManagement2AddModifyPopupFormActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserManagement2AddModifyPopupFormFormClosing);
            this.Controls.SetChildIndex(this.backgroundPanel, 0);
            this.backgroundPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ButtonPanelX.ResumeLayout(false);
            this.UserPanelX.ResumeLayout(false);
            this.UserPanelX.PerformLayout();
            this.ResumeLayout(false);

    }




    #endregion

    private Windows.Forms.DevComponents2.Controls.ButtonX OkButtonX;
    private Windows.Forms.DevComponents2.Controls.ButtonX CancelButtonX;
    private PanelEx UserPanelX;
    private PanelEx ButtonPanelX;
    private Windows.Forms.DevComponents2.Controls.CheckBoxX UsersShowPasswordCheckBoxX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX UsersConfirmPasswordTextBoxX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX UsersPasswordTextBoxX;
    private Windows.Forms.DevComponents2.Controls.LabelX UsersShowPasswordLabelX;
    private Windows.Forms.DevComponents2.Controls.LabelX UsersConfirmPasswordLabelX;
    private Windows.Forms.DevComponents2.Controls.LabelX UsersPasswordLabelX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX OldPasswordTextBoxX;
    private Windows.Forms.DevComponents2.Controls.LabelX OldPasswordLabelX;
    private Windows.Forms.DevComponents2.Controls.CheckBoxX UserEmptyPasswordCheckbox;
    private Windows.Forms.DevComponents2.Controls.LabelX UserEmptyPasswordLabel;
  }
}