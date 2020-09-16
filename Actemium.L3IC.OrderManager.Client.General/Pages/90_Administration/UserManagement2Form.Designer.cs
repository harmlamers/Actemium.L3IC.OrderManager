using Actemium.Diagnostics;
using Actemium.Windows.Forms.SuperGrid;
using System.Drawing;
using System.Windows.Forms;
using Actemium.Windows.Forms.DevComponents2.Controls;
using DevComponents.DotNetBar;
using RibbonBar = Actemium.Windows.Forms.DevComponents2.Controls.RibbonBar;

namespace Actemium.L3IC.OrderManager.Client.General.Pages._90_Administration
{
  partial class UserManagement2Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagement2Form));
            this.topGroupPanel = new Actemium.Windows.Forms.DevComponents2.Controls.GroupPanel(this.components);
            this.bottomSuperGrid = new Actemium.Windows.Forms.SuperGrid.SuperGrid();
            this.bottomGroupPanel = new Actemium.Windows.Forms.DevComponents2.Controls.GroupPanel(this.components);
            this.splitter = new System.Windows.Forms.Splitter();
            this.screenSplitContainer = new System.Windows.Forms.SplitContainer();
            this.topPropertyGrid = new Actemium.Windows.Forms.PropertyGrid();
            this.topGroupPanelSplitter = new System.Windows.Forms.Splitter();
            this.topSupergrid = new Actemium.Windows.Forms.SuperGrid.SuperGrid();
            this.topGroupPanel.SuspendLayout();
            this.bottomGroupPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenSplitContainer)).BeginInit();
            this.screenSplitContainer.Panel1.SuspendLayout();
            this.screenSplitContainer.Panel2.SuspendLayout();
            this.screenSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // topGroupPanel
            // 
            this.topGroupPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.topGroupPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.topGroupPanel.Controls.Add(this.topSupergrid);
            this.topGroupPanel.Controls.Add(this.topGroupPanelSplitter);
            this.topGroupPanel.Controls.Add(this.topPropertyGrid);
            this.topGroupPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.topGroupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topGroupPanel.Location = new System.Drawing.Point(0, 0);
            this.topGroupPanel.Name = "topGroupPanel";
            this.topGroupPanel.Size = new System.Drawing.Size(1142, 396);
            // 
            // 
            // 
            this.topGroupPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.topGroupPanel.Style.BackColorGradientAngle = 90;
            this.topGroupPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.topGroupPanel.Style.BorderBottomWidth = 1;
            this.topGroupPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.topGroupPanel.Style.BorderLeftWidth = 1;
            this.topGroupPanel.Style.BorderRightWidth = 1;
            this.topGroupPanel.Style.BorderTopWidth = 1;
            this.topGroupPanel.Style.CornerDiameter = 4;
            this.topGroupPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.topGroupPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.topGroupPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.topGroupPanel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.topGroupPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.topGroupPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.topGroupPanel.TabIndex = 3;
            this.topGroupPanel.Translate = false;
            // 
            // bottomSuperGrid
            // 
            this.bottomSuperGrid.BackColor = System.Drawing.Color.Green;
            this.bottomSuperGrid.ClipboardCellSeparator = ',';
            this.bottomSuperGrid.ClipboardContextMenu = false;
            this.bottomSuperGrid.ClipboardDateFormat = "yyyy-MM-dd HH:mm:ss";
            this.bottomSuperGrid.ClipboardEnableDateFormat = false;
            this.bottomSuperGrid.ClipboardEnableIncludeHeaders = false;
            this.bottomSuperGrid.ClipboardEnableQuotedValues = false;
            this.bottomSuperGrid.CopyToClipboard = true;
            this.bottomSuperGrid.DataSource = null;
            this.bottomSuperGrid.DisplayNumberOfItems = false;
            this.bottomSuperGrid.DisplayNumberOfItemsFunc = null;
            this.bottomSuperGrid.DisplayNumberOfItemsTemplate = null;
            this.bottomSuperGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomSuperGrid.EditedCellBackgroundColor = System.Drawing.Color.LightPink;
            this.bottomSuperGrid.EnableHighlighter = false;
            this.bottomSuperGrid.EnableValidator = false;
            this.bottomSuperGrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.bottomSuperGrid.FooterUpdateCallback = null;
            this.bottomSuperGrid.GridContextMenu = false;
            this.bottomSuperGrid.IdentifyingColumn = null;
            this.bottomSuperGrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.bottomSuperGrid.Location = new System.Drawing.Point(0, 0);
            this.bottomSuperGrid.Name = "bottomSuperGrid";
            this.bottomSuperGrid.PersistentUserSettings = true;
            // 
            // 
            // 
            this.bottomSuperGrid.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.bottomSuperGrid.RestoreSelectionAfterSortChanged = true;
            this.bottomSuperGrid.SettingsStorageType = Actemium.Windows.Forms.SuperGrid.SuperGrid.SettingsStorageTypeEnum.ToFile;
            this.bottomSuperGrid.Size = new System.Drawing.Size(1142, 239);
            this.bottomSuperGrid.TabIndex = 0;
            this.bottomSuperGrid.Text = "categorySuperGrid";
            this.bottomSuperGrid.Translate = true;
            this.bottomSuperGrid.ValidatorColumnName = null;
            this.bottomSuperGrid.ValidatorCustomHighlightHandler = null;
            this.bottomSuperGrid.ValidatorHandler = null;
            this.bottomSuperGrid.ValidatorHighlightColor = System.Drawing.Color.Red;
            this.bottomSuperGrid.ValidatorHighlightFontStyle = System.Drawing.FontStyle.Bold;
            this.bottomSuperGrid.ValidatorHighlightType = Actemium.Windows.Forms.SuperGrid.SuperGrid.ValidatorHighlightTypes.BackgroundColor;
            this.bottomSuperGrid.CellValueChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridCellValueChangedEventArgs>(this.BottomSuperGridCellValueChanged);
            this.bottomSuperGrid.DataBindingComplete += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridDataBindingCompleteEventArgs>(this.BottomSuperGridDataBindingComplete);
            this.bottomSuperGrid.SelectionChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEventArgs>(this.BottomSuperGridSelectionChanged);
            // 
            // bottomGroupPanel
            // 
            this.bottomGroupPanel.AutoSize = true;
            this.bottomGroupPanel.CanvasColor = System.Drawing.SystemColors.Control;
            this.bottomGroupPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.bottomGroupPanel.Controls.Add(this.bottomSuperGrid);
            this.bottomGroupPanel.DisabledBackColor = System.Drawing.Color.Empty;
            this.bottomGroupPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomGroupPanel.Location = new System.Drawing.Point(0, 0);
            this.bottomGroupPanel.Name = "bottomGroupPanel";
            this.bottomGroupPanel.Size = new System.Drawing.Size(1142, 239);
            // 
            // 
            // 
            this.bottomGroupPanel.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.bottomGroupPanel.Style.BackColorGradientAngle = 90;
            this.bottomGroupPanel.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.bottomGroupPanel.Style.BorderBottomWidth = 1;
            this.bottomGroupPanel.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.bottomGroupPanel.Style.BorderLeftWidth = 1;
            this.bottomGroupPanel.Style.BorderRightWidth = 1;
            this.bottomGroupPanel.Style.BorderTopWidth = 1;
            this.bottomGroupPanel.Style.CornerDiameter = 4;
            this.bottomGroupPanel.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bottomGroupPanel.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.bottomGroupPanel.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.bottomGroupPanel.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.bottomGroupPanel.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.bottomGroupPanel.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.bottomGroupPanel.TabIndex = 3;
            this.bottomGroupPanel.Translate = false;
            // 
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point(0, 0);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(3, 3);
            this.splitter.TabIndex = 0;
            this.splitter.TabStop = false;
            // 
            // screenSplitContainer
            // 
            this.screenSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screenSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.screenSplitContainer.Name = "screenSplitContainer";
            this.screenSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // screenSplitContainer.Panel1
            // 
            this.screenSplitContainer.Panel1.Controls.Add(this.topGroupPanel);
            // 
            // screenSplitContainer.Panel2
            // 
            this.screenSplitContainer.Panel2.Controls.Add(this.bottomGroupPanel);
            this.screenSplitContainer.Size = new System.Drawing.Size(1142, 639);
            this.screenSplitContainer.SplitterDistance = 396;
            this.screenSplitContainer.TabIndex = 1;
            // 
            // topPropertyGrid
            // 
            this.topPropertyGrid.BackColor = System.Drawing.Color.LightGray;
            this.topPropertyGrid.CommandsDisabledLinkColor = System.Drawing.Color.Lime;
            this.topPropertyGrid.DisabledItemForeColor = System.Drawing.SystemColors.ControlText;
            // 
            // 
            // 
            this.topPropertyGrid.DocCommentDescription.AccessibleName = "";
            this.topPropertyGrid.DocCommentDescription.AutoEllipsis = true;
            this.topPropertyGrid.DocCommentDescription.Cursor = System.Windows.Forms.Cursors.Default;
            this.topPropertyGrid.DocCommentDescription.Location = new System.Drawing.Point(3, 18);
            this.topPropertyGrid.DocCommentDescription.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.topPropertyGrid.DocCommentDescription.Name = "";
            this.topPropertyGrid.DocCommentDescription.Size = new System.Drawing.Size(294, 37);
            this.topPropertyGrid.DocCommentDescription.TabIndex = 1;
            this.topPropertyGrid.DocCommentImage = null;
            // 
            // 
            // 
            this.topPropertyGrid.DocCommentTitle.AutoEllipsis = true;
            this.topPropertyGrid.DocCommentTitle.Cursor = System.Windows.Forms.Cursors.Default;
            this.topPropertyGrid.DocCommentTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.topPropertyGrid.DocCommentTitle.Location = new System.Drawing.Point(3, 3);
            this.topPropertyGrid.DocCommentTitle.Name = "";
            this.topPropertyGrid.DocCommentTitle.Size = new System.Drawing.Size(294, 15);
            this.topPropertyGrid.DocCommentTitle.TabIndex = 0;
            this.topPropertyGrid.DocCommentTitle.UseMnemonic = false;
            this.topPropertyGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.topPropertyGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topPropertyGrid.HelpBackColor = System.Drawing.SystemColors.ControlLight;
            this.topPropertyGrid.LineColor = System.Drawing.Color.LightGray;
            this.topPropertyGrid.Location = new System.Drawing.Point(842, 0);
            this.topPropertyGrid.MinimumSize = new System.Drawing.Size(100, 100);
            this.topPropertyGrid.Name = "topPropertyGrid";
            this.topPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.topPropertyGrid.SelectedObject = ((object)(resources.GetObject("topPropertyGrid.SelectedObject")));
            this.topPropertyGrid.ShowCustomProperties = true;
            this.topPropertyGrid.Size = new System.Drawing.Size(300, 396);
            this.topPropertyGrid.TabIndex = 0;
            // 
            // 
            // 
            this.topPropertyGrid.ToolStrip.AccessibleName = "ToolBar";
            this.topPropertyGrid.ToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ToolBar;
            this.topPropertyGrid.ToolStrip.AllowMerge = false;
            this.topPropertyGrid.ToolStrip.AutoSize = false;
            this.topPropertyGrid.ToolStrip.BackColor = System.Drawing.Color.LightGray;
            this.topPropertyGrid.ToolStrip.CanOverflow = false;
            this.topPropertyGrid.ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.topPropertyGrid.ToolStrip.Font = new System.Drawing.Font("Tahoma", 10F);
            this.topPropertyGrid.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.topPropertyGrid.ToolStrip.Location = new System.Drawing.Point(0, 1);
            this.topPropertyGrid.ToolStrip.Name = "";
            this.topPropertyGrid.ToolStrip.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.topPropertyGrid.ToolStrip.Size = new System.Drawing.Size(300, 25);
            this.topPropertyGrid.ToolStrip.TabIndex = 1;
            this.topPropertyGrid.ToolStrip.TabStop = true;
            this.topPropertyGrid.ToolStrip.Text = "PropertyGridToolBar";
            this.topPropertyGrid.ViewForeColor = System.Drawing.Color.Black;
            // 
            // OrdersPanelSplitter
            // 
            this.topGroupPanelSplitter.BackColor = System.Drawing.SystemColors.Control;
            this.topGroupPanelSplitter.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.topGroupPanelSplitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.topGroupPanelSplitter.Location = new System.Drawing.Point(832, 0);
            this.topGroupPanelSplitter.Name = "OrdersPanelSplitter";
            this.topGroupPanelSplitter.Size = new System.Drawing.Size(10, 396);
            this.topGroupPanelSplitter.TabIndex = 1;
            this.topGroupPanelSplitter.TabStop = false;
            // 
            // OrdersSupergrid
            // 
            this.topSupergrid.BackColor = System.Drawing.Color.Green;
            this.topSupergrid.ClipboardCellSeparator = ',';
            this.topSupergrid.ClipboardContextMenu = false;
            this.topSupergrid.ClipboardDateFormat = "yyyy-MM-dd HH:mm:ss";
            this.topSupergrid.ClipboardEnableDateFormat = false;
            this.topSupergrid.ClipboardEnableIncludeHeaders = false;
            this.topSupergrid.ClipboardEnableQuotedValues = false;
            this.topSupergrid.CopyToClipboard = true;
            this.topSupergrid.DataSource = null;
            this.topSupergrid.DisplayNumberOfItems = false;
            this.topSupergrid.DisplayNumberOfItemsFunc = null;
            this.topSupergrid.DisplayNumberOfItemsTemplate = null;
            this.topSupergrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topSupergrid.EditedCellBackgroundColor = System.Drawing.Color.LightPink;
            this.topSupergrid.EnableHighlighter = false;
            this.topSupergrid.EnableValidator = false;
            this.topSupergrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.topSupergrid.FooterUpdateCallback = null;
            this.topSupergrid.GridContextMenu = false;
            this.topSupergrid.IdentifyingColumn = null;
            this.topSupergrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.topSupergrid.Location = new System.Drawing.Point(0, 0);
            this.topSupergrid.Name = "OrdersSupergrid";
            this.topSupergrid.PersistentUserSettings = true;
            // 
            // 
            // 
            this.topSupergrid.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.topSupergrid.RestoreSelectionAfterSortChanged = true;
            this.topSupergrid.SettingsStorageType = Actemium.Windows.Forms.SuperGrid.SuperGrid.SettingsStorageTypeEnum.ToFile;
            this.topSupergrid.Size = new System.Drawing.Size(832, 396);
            this.topSupergrid.TabIndex = 0;
            this.topSupergrid.Text = "InstallBaseSupergrid";
            this.topSupergrid.Translate = true;
            this.topSupergrid.ValidatorColumnName = null;
            this.topSupergrid.ValidatorCustomHighlightHandler = null;
            this.topSupergrid.ValidatorHandler = null;
            this.topSupergrid.ValidatorHighlightColor = System.Drawing.Color.Red;
            this.topSupergrid.ValidatorHighlightFontStyle = System.Drawing.FontStyle.Bold;
            this.topSupergrid.ValidatorHighlightType = Actemium.Windows.Forms.SuperGrid.SuperGrid.ValidatorHighlightTypes.BackgroundColor;
            this.topSupergrid.SelectionChanged += new System.EventHandler<DevComponents.DotNetBar.SuperGrid.GridEventArgs>(this.TopSupergridSelectionChanged);
            // 
            // UserManagement2Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1142, 639);
            this.Controls.Add(this.screenSplitContainer);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KeyPreview = true;
            this.Name = "UserManagement2Form";
            this.Resize += new System.EventHandler(this.UserManagementFormResize);
            this.topGroupPanel.ResumeLayout(false);
            this.bottomGroupPanel.ResumeLayout(false);
            this.screenSplitContainer.Panel1.ResumeLayout(false);
            this.screenSplitContainer.Panel2.ResumeLayout(false);
            this.screenSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.screenSplitContainer)).EndInit();
            this.screenSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Splitter splitter;
    private Windows.Forms.DevComponents2.Controls.GroupPanel topGroupPanel;
    private Windows.Forms.DevComponents2.Controls.GroupPanel bottomGroupPanel;
    private Actemium.Windows.Forms.SuperGrid.SuperGrid bottomSuperGrid;
    private SplitContainer screenSplitContainer;
        private Windows.Forms.SuperGrid.SuperGrid topSupergrid;
        private Splitter topGroupPanelSplitter;
        private Windows.Forms.PropertyGrid topPropertyGrid;
    }
}