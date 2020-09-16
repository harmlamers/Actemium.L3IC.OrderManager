using System;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  partial class MDPropertiesPopupForm
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
            this.MaterialPropertyValueSaveButtonX1 = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
            this.MaterialPropertiesListBoxX = new System.Windows.Forms.ListBox();
            this.MaterialPropertyValueTextBoxX = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
            this.MaterialPropertiesLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.MaterialPropertyValueLabelX = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
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
            this.backgroundPanel.Size = new System.Drawing.Size(820, 499);
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
            this.ButtonPanelX.Location = new System.Drawing.Point(0, 434);
            this.ButtonPanelX.Name = "ButtonPanelX";
            this.ButtonPanelX.Size = new System.Drawing.Size(820, 65);
            this.ButtonPanelX.TabIndex = 12;
            // 
            // MaterialPanelX
            // 
            this.MaterialPanelX.Controls.Add(this.MaterialPropertyValueSaveButtonX1);
            this.MaterialPanelX.Controls.Add(this.MaterialPropertiesListBoxX);
            this.MaterialPanelX.Controls.Add(this.MaterialPropertyValueTextBoxX);
            this.MaterialPanelX.Controls.Add(this.MaterialPropertiesLabelX);
            this.MaterialPanelX.Controls.Add(this.MaterialPropertyValueLabelX);
            this.MaterialPanelX.DisabledBackColor = System.Drawing.Color.Empty;
            this.MaterialPanelX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MaterialPanelX.Location = new System.Drawing.Point(0, 0);
            this.MaterialPanelX.Name = "MaterialPanelX";
            this.MaterialPanelX.Size = new System.Drawing.Size(820, 499);
            this.MaterialPanelX.TabIndex = 13;
            // 
            // MaterialPropertyValueSaveButtonX1
            // 
            this.MaterialPropertyValueSaveButtonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.MaterialPropertyValueSaveButtonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.MaterialPropertyValueSaveButtonX1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.MaterialPropertyValueSaveButtonX1.Location = new System.Drawing.Point(705, 73);
            this.MaterialPropertyValueSaveButtonX1.Name = "MaterialPropertyValueSaveButtonX1";
            this.MaterialPropertyValueSaveButtonX1.Size = new System.Drawing.Size(103, 33);
            this.MaterialPropertyValueSaveButtonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.MaterialPropertyValueSaveButtonX1.TabIndex = 10;
            this.MaterialPropertyValueSaveButtonX1.Text = "Save";
            this.MaterialPropertyValueSaveButtonX1.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
            this.MaterialPropertyValueSaveButtonX1.Translate = false;
            this.MaterialPropertyValueSaveButtonX1.Click += new System.EventHandler(this.SaveButtonClicked);
            
            // 
            // MaterialPropertiesListBoxX
            // 
            this.MaterialPropertiesListBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.MaterialPropertiesListBoxX.FormattingEnabled = true;
            this.MaterialPropertiesListBoxX.ItemHeight = 19;
            this.MaterialPropertiesListBoxX.Location = new System.Drawing.Point(12, 40);
            this.MaterialPropertiesListBoxX.Name = "MaterialPropertiesListBoxX";
            this.MaterialPropertiesListBoxX.Size = new System.Drawing.Size(374, 365);
            this.MaterialPropertiesListBoxX.TabIndex = 9;
            this.MaterialPropertiesListBoxX.SelectedIndexChanged += new System.EventHandler(this.ListboxSelectionChanged);
            // 
            // MaterialPropertyValueTextBoxX
            // 
            // 
            // 
            // 
            this.MaterialPropertyValueTextBoxX.Border.Class = "TextBoxBorder";
            this.MaterialPropertyValueTextBoxX.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MaterialPropertyValueTextBoxX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.MaterialPropertyValueTextBoxX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.MaterialPropertyValueTextBoxX.FormatMask = null;
            this.MaterialPropertyValueTextBoxX.Location = new System.Drawing.Point(626, 40);
            this.MaterialPropertyValueTextBoxX.Name = "MaterialPropertyValueTextBoxX";
            this.MaterialPropertyValueTextBoxX.Size = new System.Drawing.Size(182, 27);
            this.MaterialPropertyValueTextBoxX.TabIndex = 0;
            this.MaterialPropertyValueTextBoxX.TextChanged += new System.EventHandler(this.MaterialPropertyValueTextBoxX_TextChanged);
            // 
            // MaterialPropertiesLabelX
            // 
            // 
            // 
            // 
            this.MaterialPropertiesLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MaterialPropertiesLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.MaterialPropertiesLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.MaterialPropertiesLabelX.FormatMask = null;
            this.MaterialPropertiesLabelX.Location = new System.Drawing.Point(12, 12);
            this.MaterialPropertiesLabelX.Name = "MaterialPropertiesLabelX";
            this.MaterialPropertiesLabelX.Size = new System.Drawing.Size(186, 22);
            this.MaterialPropertiesLabelX.TabIndex = 8;
            this.MaterialPropertiesLabelX.Text = "Properties";
            this.MaterialPropertiesLabelX.Translate = true;
            // 
            // MaterialPropertyValueLabelX
            // 
            // 
            // 
            // 
            this.MaterialPropertyValueLabelX.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.MaterialPropertyValueLabelX.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.MaterialPropertyValueLabelX.Font = new System.Drawing.Font("Tahoma", 12F);
            this.MaterialPropertyValueLabelX.FormatMask = null;
            this.MaterialPropertyValueLabelX.Location = new System.Drawing.Point(434, 40);
            this.MaterialPropertyValueLabelX.Name = "MaterialPropertyValueLabelX";
            this.MaterialPropertyValueLabelX.Size = new System.Drawing.Size(186, 22);
            this.MaterialPropertyValueLabelX.TabIndex = 7;
            this.MaterialPropertyValueLabelX.Text = "Value";
            this.MaterialPropertyValueLabelX.Translate = true;
            // 
            // MDPropertiesPopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 499);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MDPropertiesPopupForm";
            this.Text = "MDPropertiesPopupForm";
            this.Activated += new System.EventHandler(this.MDPropertiesPopupFormActivated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDPropertiesPopupFormClosing);
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
    private Windows.Forms.DevComponents2.Controls.LabelX MaterialPropertiesLabelX;
    private Windows.Forms.DevComponents2.Controls.LabelX MaterialPropertyValueLabelX;
    private Windows.Forms.DevComponents2.Controls.TextBoxX MaterialPropertyValueTextBoxX;
        private ListBox MaterialPropertiesListBoxX;
        private Windows.Forms.DevComponents2.Controls.ButtonX MaterialPropertyValueSaveButtonX1;
    }
}