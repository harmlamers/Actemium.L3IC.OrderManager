using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  partial class MDAddModifyPopupForm
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
            this.MaterialPanelX = new DevComponents.DotNetBar.PanelEx();
            this.MaterialGroupLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.MaterialGroupDropDown = new System.Windows.Forms.ComboBox();
            this.MaterialCodeTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.MaterialDescriptionTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.MaterialCodeLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.MaterialDescriptionLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.backgroundPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.ButtonPanelX.SuspendLayout();
            this.MaterialPanelX.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundPanel
            // 
            this.backgroundPanel.Controls.Add(this.ButtonPanelX);
            this.backgroundPanel.Controls.Add(this.MaterialPanelX);
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
            // MaterialPanelX
            // 
            this.MaterialPanelX.Controls.Add(this.MaterialGroupLabelX);
            this.MaterialPanelX.Controls.Add(this.MaterialGroupDropDown);
            this.MaterialPanelX.Controls.Add(this.MaterialCodeTextBoxX);
            this.MaterialPanelX.Controls.Add(this.MaterialDescriptionTextBoxX);
            this.MaterialPanelX.Controls.Add(this.MaterialCodeLabelX);
            this.MaterialPanelX.Controls.Add(this.MaterialDescriptionLabelX);
            this.MaterialPanelX.DisabledBackColor = System.Drawing.Color.Empty;
            this.MaterialPanelX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaterialPanelX.Location = new System.Drawing.Point(0, 0);
            this.MaterialPanelX.Name = "MaterialPanelX";
            this.MaterialPanelX.Size = new System.Drawing.Size(820, 195);
            this.MaterialPanelX.TabIndex = 13;
            // 
            // MaterialGroupLabelX
            // 
            // 
            // 
            // 
            this.MaterialGroupLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MaterialGroupLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.MaterialGroupLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.MaterialGroupLabelX.FormatMask = null;
            this.MaterialGroupLabelX.Location = new System.Drawing.Point(12, 45);
            this.MaterialGroupLabelX.Name = "MaterialGroupLabelX";
            this.MaterialGroupLabelX.Size = new System.Drawing.Size(186, 22);
            this.MaterialGroupLabelX.TabIndex = 10;
            this.MaterialGroupLabelX.Text = "Group";
            this.MaterialGroupLabelX.Translate = true;
            // 
            // OrdersPredefinedFilterDropdownX
            // 
            this.MaterialGroupDropDown.Font = new System.Drawing.Font("Tahoma", 12F);
            this.MaterialGroupDropDown.Location = new System.Drawing.Point(204, 45);
            this.MaterialGroupDropDown.Name = "OrdersPredefinedFilterDropdownX";
            this.MaterialGroupDropDown.Size = new System.Drawing.Size(182, 27);
            this.MaterialGroupDropDown.TabIndex = 9;
            // 
            // MaterialCodeTextBoxX
            // 
            // 
            // 
            // 
            this.MaterialCodeTextBoxX.Border.Class = "TextBoxBorder";
            this.MaterialCodeTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MaterialCodeTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.MaterialCodeTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.MaterialCodeTextBoxX.FormatMask = null;
            this.MaterialCodeTextBoxX.Location = new System.Drawing.Point(204, 12);
            this.MaterialCodeTextBoxX.Name = "MaterialCodeTextBoxX";
            this.MaterialCodeTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.MaterialCodeTextBoxX.TabIndex = 5;
            // 
            // MaterialDescriptionTextBoxX
            // 
            // 
            // 
            // 
            this.MaterialDescriptionTextBoxX.Border.Class = "TextBoxBorder";
            this.MaterialDescriptionTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MaterialDescriptionTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.MaterialDescriptionTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.MaterialDescriptionTextBoxX.FormatMask = null;
            this.MaterialDescriptionTextBoxX.Location = new System.Drawing.Point(626, 12);
            this.MaterialDescriptionTextBoxX.Name = "MaterialDescriptionTextBoxX";
            this.MaterialDescriptionTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.MaterialDescriptionTextBoxX.TabIndex = 0;
            // 
            // MaterialCodeLabelX
            // 
            // 
            // 
            // 
            this.MaterialCodeLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MaterialCodeLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.MaterialCodeLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.MaterialCodeLabelX.FormatMask = null;
            this.MaterialCodeLabelX.Location = new System.Drawing.Point(12, 12);
            this.MaterialCodeLabelX.Name = "MaterialCodeLabelX";
            this.MaterialCodeLabelX.Size = new System.Drawing.Size(186, 22);
            this.MaterialCodeLabelX.TabIndex = 8;
            this.MaterialCodeLabelX.Text = "Code";
            this.MaterialCodeLabelX.Translate = true;
            // 
            // MaterialDescriptionLabelX
            // 
            // 
            // 
            // 
            this.MaterialDescriptionLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MaterialDescriptionLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.MaterialDescriptionLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.MaterialDescriptionLabelX.FormatMask = null;
            this.MaterialDescriptionLabelX.Location = new System.Drawing.Point(434, 12);
            this.MaterialDescriptionLabelX.Name = "MaterialDescriptionLabelX";
            this.MaterialDescriptionLabelX.Size = new System.Drawing.Size(186, 22);
            this.MaterialDescriptionLabelX.TabIndex = 7;
            this.MaterialDescriptionLabelX.Text = "Description";
            this.MaterialDescriptionLabelX.Translate = true;
            // 
            // MDAddModifyPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 195);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MDAddModifyPopupForm";
            this.Text = "MDAddModifyPopupForm";
            this.Activated += new System.EventHandler(this.MDAddModifyPopupFormActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDAddModifyPopupFormClosing);
            this.Controls.SetChildIndex(this.backgroundPanel, 0);
            this.backgroundPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ButtonPanelX.ResumeLayout(false);
            this.MaterialPanelX.ResumeLayout(false);
            this.ResumeLayout(false);

    }




        #endregion

        private Windows.Forms.DevComponents2.Controls.ButtonX OkButtonX;
    private Windows.Forms.DevComponents2.Controls.ButtonX CancelButtonX;
    private PanelEx MaterialPanelX;
    private PanelEx ButtonPanelX;
    private Windows.Forms.DevComponents2.Controls.LabelX MaterialCodeLabelX;
    private Windows.Forms.DevComponents2.Controls.LabelX MaterialDescriptionLabelX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX MaterialCodeTextBoxX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX MaterialDescriptionTextBoxX;
        //private Actemium.Windows.Forms.DevComponents2.Controls.ComboBoxEx OrdersPredefinedFilterDropdownX;
        private System.Windows.Forms.ComboBox MaterialGroupDropDown;
        private Windows.Forms.DevComponents2.Controls.LabelX MaterialGroupLabelX;
    }
}