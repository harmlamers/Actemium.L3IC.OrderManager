namespace Actemium.L3IC.OrderManager.Client.General.Pages._90_Administration
{
  partial class HistoryKeyManagementForm
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
      this.HistoryKeysSupergrid = new Actemium.Windows.Forms.SuperGrid.SuperGrid();
      this.SuspendLayout();
      // 
      // HistoryKeysSupergrid
      // 
      this.HistoryKeysSupergrid.BackColor = System.Drawing.Color.Green;
      this.HistoryKeysSupergrid.ClipboardCellSeparator = ',';
      this.HistoryKeysSupergrid.ClipboardContextMenu = false;
      this.HistoryKeysSupergrid.ClipboardDateFormat = "yyyy-MM-dd HH:mm:ss";
      this.HistoryKeysSupergrid.ClipboardEnableDateFormat = false;
      this.HistoryKeysSupergrid.ClipboardEnableIncludeHeaders = false;
      this.HistoryKeysSupergrid.ClipboardEnableQuotedValues = false;
      this.HistoryKeysSupergrid.CopyToClipboard = false;
      this.HistoryKeysSupergrid.DataSource = null;
      this.HistoryKeysSupergrid.DisplayNumberOfItems = false;
      this.HistoryKeysSupergrid.DisplayNumberOfItemsFunc = null;
      this.HistoryKeysSupergrid.DisplayNumberOfItemsTemplate = null;
      this.HistoryKeysSupergrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.HistoryKeysSupergrid.EditedCellBackgroundColor = System.Drawing.Color.LightPink;
      this.HistoryKeysSupergrid.EnableHighlighter = false;
      this.HistoryKeysSupergrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
      this.HistoryKeysSupergrid.IdentifyingColumn = null;
      this.HistoryKeysSupergrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
      this.HistoryKeysSupergrid.Location = new System.Drawing.Point(0, 0);
      this.HistoryKeysSupergrid.Name = "HistoryKeysSupergrid";
      this.HistoryKeysSupergrid.PersistentUserSettings = true;
      // 
      // 
      // 
      this.HistoryKeysSupergrid.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
      // 
      // 
      // 
      this.HistoryKeysSupergrid.PrimaryGrid.Filter.ShowPanelFilterExpr = true;
      this.HistoryKeysSupergrid.PrimaryGrid.Filter.Visible = true;
      this.HistoryKeysSupergrid.PrimaryGrid.MultiSelect = false;
      this.HistoryKeysSupergrid.RestoreSelectionAfterSortChanged = true;
      this.HistoryKeysSupergrid.SettingsStorageType = Actemium.Windows.Forms.SuperGrid.SuperGrid.SettingsStorageTypeEnum.ToFile;
      this.HistoryKeysSupergrid.Size = new System.Drawing.Size(292, 273);
      this.HistoryKeysSupergrid.TabIndex = 0;
      this.HistoryKeysSupergrid.Text = "HistoryKeysSupergrid";
      this.HistoryKeysSupergrid.Translate = true;
      // 
      // HistoryKeyManagementForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 273);
      this.Controls.Add(this.HistoryKeysSupergrid);
      this.Name = "HistoryKeyManagementForm";
      this.Text = "ServerSideSettingsAdministrationForm";
      this.ResumeLayout(false);

    }

    

    private Actemium.Windows.Forms.SuperGrid.SuperGrid HistoryKeysSupergrid;

    #endregion
  }
}
