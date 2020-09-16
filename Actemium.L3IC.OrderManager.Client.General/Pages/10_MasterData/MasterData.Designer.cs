using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.Pages._10_MasterData
{
  partial class MasterData {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterData));
            this.topSupergrid = new Actemium.Windows.Forms.SuperGrid.SuperGrid();
            this.topGroupPanelSplitter = new System.Windows.Forms.Splitter();
            this.topPropertyGrid = new Actemium.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
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
            this.topSupergrid.Size = new System.Drawing.Size(706, 639);
            this.topSupergrid.TabIndex = 2;
            this.topSupergrid.Text = "InstallBaseSupergrid";
            this.topSupergrid.Translate = true;
            this.topSupergrid.ValidatorColumnName = null;
            this.topSupergrid.ValidatorCustomHighlightHandler = null;
            this.topSupergrid.ValidatorHandler = null;
            this.topSupergrid.ValidatorHighlightColor = System.Drawing.Color.Red;
            this.topSupergrid.ValidatorHighlightFontStyle = System.Drawing.FontStyle.Bold;
            this.topSupergrid.ValidatorHighlightType = Actemium.Windows.Forms.SuperGrid.SuperGrid.ValidatorHighlightTypes.BackgroundColor;
            this.topSupergrid.SelectionChanged += TopSupergridSelectionChanged;
            // 
            // OrdersPanelSplitter
            // 
            this.topGroupPanelSplitter.BackColor = System.Drawing.SystemColors.Control;
            this.topGroupPanelSplitter.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.topGroupPanelSplitter.Dock = System.Windows.Forms.DockStyle.Right;
            this.topGroupPanelSplitter.Location = new System.Drawing.Point(706, 0);
            this.topGroupPanelSplitter.Name = "OrdersPanelSplitter";
            this.topGroupPanelSplitter.Size = new System.Drawing.Size(10, 639);
            this.topGroupPanelSplitter.TabIndex = 4;
            this.topGroupPanelSplitter.TabStop = false;
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
            this.topPropertyGrid.Location = new System.Drawing.Point(716, 0);
            this.topPropertyGrid.MinimumSize = new System.Drawing.Size(100, 100);
            this.topPropertyGrid.Name = "topPropertyGrid";
            this.topPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.topPropertyGrid.SelectedObject = ((object)(resources.GetObject("topPropertyGrid.SelectedObject")));
            this.topPropertyGrid.ShowCustomProperties = true;
            this.topPropertyGrid.Size = new System.Drawing.Size(300, 639);
            this.topPropertyGrid.TabIndex = 3;
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
            // MasterData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1016, 639);
            this.Controls.Add(this.topSupergrid);
            this.Controls.Add(this.topGroupPanelSplitter);
            this.Controls.Add(this.topPropertyGrid);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KeyPreview = true;
            this.Name = "MasterData";
            this.Resize += new System.EventHandler(this.MasterDataResize);
            this.ResumeLayout(false);

    }

        #endregion

        private Windows.Forms.SuperGrid.SuperGrid topSupergrid;
        private System.Windows.Forms.Splitter topGroupPanelSplitter;
        private Windows.Forms.PropertyGrid topPropertyGrid;
    }
}
