using System.Windows.Forms;
using Actemium.Windows.Forms.DevComponents2.Controls;

namespace Actemium.L3IC.OrderManager.Client.General
{
  partial class DetachedForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetachedForm));
            this.ribbonControlHeader = new Actemium.Windows.Forms.DevComponents2.Controls.RibbonControl(this.components);
            this.panelHeaderText = new System.Windows.Forms.Panel();
            this.noAuthorizationLabel = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.loggedOffLabel = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.headerLabel = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.panelHeaderText.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControlHeader
            // 
            this.ribbonControlHeader.AntiAlias = false;
            // 
            // 
            // 
            this.ribbonControlHeader.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonControlHeader.CanCustomize = false;
            this.ribbonControlHeader.CaptionHeight = 24;
            this.ribbonControlHeader.CaptionVisible = true;
            this.ribbonControlHeader.CategorizeMode = DevComponents.DotNetBar.eCategorizeMode.Categories;
            this.ribbonControlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbonControlHeader.EnableQatPlacement = false;
            this.ribbonControlHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbonControlHeader.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControlHeader.Location = new System.Drawing.Point(5, 1);
            this.ribbonControlHeader.MdiSystemItemVisible = false;
            this.ribbonControlHeader.Name = "ribbonControlHeader";
            this.ribbonControlHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.ribbonControlHeader.Size = new System.Drawing.Size(1270, 24);
            this.ribbonControlHeader.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonControlHeader.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.ribbonControlHeader.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.ribbonControlHeader.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.ribbonControlHeader.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.ribbonControlHeader.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.ribbonControlHeader.SystemText.QatDialogAddButton = "&Add >>";
            this.ribbonControlHeader.SystemText.QatDialogCancelButton = "Cancel";
            this.ribbonControlHeader.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.ribbonControlHeader.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.ribbonControlHeader.SystemText.QatDialogOkButton = "OK";
            this.ribbonControlHeader.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControlHeader.SystemText.QatDialogRemoveButton = "&Remove";
            this.ribbonControlHeader.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.ribbonControlHeader.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.ribbonControlHeader.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.ribbonControlHeader.TabGroupHeight = 0;
            this.ribbonControlHeader.TabIndex = 1;
            this.ribbonControlHeader.Text = "Actemium Empty Client - Client";
            this.ribbonControlHeader.UseCustomizeDialog = false;
            // 
            // panelHeaderText
            // 
            this.panelHeaderText.Controls.Add(this.noAuthorizationLabel);
            this.panelHeaderText.Controls.Add(this.loggedOffLabel);
            this.panelHeaderText.Controls.Add(this.headerLabel);
            this.panelHeaderText.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeaderText.Location = new System.Drawing.Point(5, 25);
            this.panelHeaderText.Name = "panelHeaderText";
            this.panelHeaderText.Size = new System.Drawing.Size(1270, 28);
            this.panelHeaderText.TabIndex = 2;
            // 
            // noAuthorizationLabel
            // 
            this.noAuthorizationLabel.AutoSize = true;
            this.noAuthorizationLabel.BackColor = System.Drawing.Color.SlateGray;
            // 
            // 
            // 
            this.noAuthorizationLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.noAuthorizationLabel.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.noAuthorizationLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.noAuthorizationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.noAuthorizationLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.noAuthorizationLabel.FormatMask = null;
            this.noAuthorizationLabel.Location = new System.Drawing.Point(1008, 0);
            this.noAuthorizationLabel.Name = "noAuthorizationLabel";
            this.noAuthorizationLabel.PaddingRight = 10;
            this.noAuthorizationLabel.Size = new System.Drawing.Size(157, 26);
            this.noAuthorizationLabel.TabIndex = 2;
            this.noAuthorizationLabel.Text = "No authorization";
            this.noAuthorizationLabel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.noAuthorizationLabel.Translate = true;
            this.noAuthorizationLabel.Visible = false;
            // 
            // loggedOffLabel
            // 
            this.loggedOffLabel.AutoSize = true;
            this.loggedOffLabel.BackColor = System.Drawing.Color.SlateGray;
            // 
            // 
            // 
            this.loggedOffLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.loggedOffLabel.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.loggedOffLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.loggedOffLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.loggedOffLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.loggedOffLabel.FormatMask = null;
            this.loggedOffLabel.Location = new System.Drawing.Point(1165, 0);
            this.loggedOffLabel.Name = "loggedOffLabel";
            this.loggedOffLabel.PaddingRight = 10;
            this.loggedOffLabel.Size = new System.Drawing.Size(105, 26);
            this.loggedOffLabel.TabIndex = 1;
            this.loggedOffLabel.Text = "Logged off";
            this.loggedOffLabel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.loggedOffLabel.Translate = true;
            this.loggedOffLabel.Visible = false;
            // 
            // headerLabel
            // 
            this.headerLabel.BackColor = System.Drawing.Color.SlateGray;
            // 
            // 
            // 
            this.headerLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.headerLabel.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.headerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.headerLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.headerLabel.FormatMask = null;
            this.headerLabel.Location = new System.Drawing.Point(0, 0);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(1270, 28);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Tag = "NO_TRANSLATE";
            this.headerLabel.Text = "[Header]";
            this.headerLabel.TextAlignment = System.Drawing.StringAlignment.Center;
            this.headerLabel.Translate = false;
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(5, 53);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1270, 820);
            this.mainPanel.TabIndex = 0;
            // 
            // DetachedForm
            // 
            this.AccessibleDescription = "";
            this.AccessibleName = "";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(205)))), ((int)(((byte)(214)))));
            this.ClientSize = new System.Drawing.Size(1280, 875);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.panelHeaderText);
            this.Controls.Add(this.ribbonControlHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1280, 858);
            this.Name = "DetachedForm";
            this.Text = "Actemium Empty Client - Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DetachedForm_FormClosed);
            this.Load += new System.EventHandler(this.DetachedForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DetachedForm_KeyDown);
            this.panelHeaderText.ResumeLayout(false);
            this.panelHeaderText.PerformLayout();
            this.ResumeLayout(false);

    }


    #endregion
    private RibbonControl ribbonControlHeader;
	  private System.Windows.Forms.Panel panelHeaderText;
	  private LabelX headerLabel;
    private Panel mainPanel;
    private LabelX loggedOffLabel;
    private LabelX noAuthorizationLabel;
  }
}

