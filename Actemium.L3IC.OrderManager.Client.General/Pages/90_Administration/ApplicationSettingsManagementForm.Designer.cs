using System.Drawing;
using Actemium.Windows.Forms.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.Pages._90_Administration
{
  partial class ApplicationSettingsManagementForm
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
            this.ApplicationSettingsSupergrid = new Actemium.Windows.Forms.SuperGrid.SuperGrid();
            this.applicationSettingColumn = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.applicationSettingCategoryColumn = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.nameColumn = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.descriptionColumn = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.datatypeColumn = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.valueColumn = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.SuspendLayout();
            // 
            // ApplicationSettingsSupergrid
            // 
            this.ApplicationSettingsSupergrid.BackColor = System.Drawing.Color.Green;
            this.ApplicationSettingsSupergrid.ClipboardCellSeparator = ',';
            this.ApplicationSettingsSupergrid.ClipboardContextMenu = false;
            this.ApplicationSettingsSupergrid.ClipboardDateFormat = "yyyy-MM-dd HH:mm:ss";
            this.ApplicationSettingsSupergrid.ClipboardEnableDateFormat = false;
            this.ApplicationSettingsSupergrid.ClipboardEnableIncludeHeaders = false;
            this.ApplicationSettingsSupergrid.ClipboardEnableQuotedValues = false;
            this.ApplicationSettingsSupergrid.CopyToClipboard = false;
            this.ApplicationSettingsSupergrid.DataSource = null;
            this.ApplicationSettingsSupergrid.DisplayNumberOfItems = false;
            this.ApplicationSettingsSupergrid.DisplayNumberOfItemsFunc = null;
            this.ApplicationSettingsSupergrid.DisplayNumberOfItemsTemplate = null;
            this.ApplicationSettingsSupergrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApplicationSettingsSupergrid.EditedCellBackgroundColor = System.Drawing.Color.LightPink;
            this.ApplicationSettingsSupergrid.EnableHighlighter = false;
            this.ApplicationSettingsSupergrid.EnableValidator = false;
            this.ApplicationSettingsSupergrid.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.ApplicationSettingsSupergrid.FooterUpdateCallback = null;
            this.ApplicationSettingsSupergrid.IdentifyingColumn = null;
            this.ApplicationSettingsSupergrid.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ApplicationSettingsSupergrid.Location = new System.Drawing.Point(0, 0);
            this.ApplicationSettingsSupergrid.Name = "ApplicationSettingsSupergrid";
            this.ApplicationSettingsSupergrid.PersistentUserSettings = true;
            // 
            // 
            // 
            this.ApplicationSettingsSupergrid.PrimaryGrid.ColumnAutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.ApplicationSettingsSupergrid.PrimaryGrid.Columns.Add(this.applicationSettingColumn);
            this.ApplicationSettingsSupergrid.PrimaryGrid.Columns.Add(this.applicationSettingCategoryColumn);
            this.ApplicationSettingsSupergrid.PrimaryGrid.Columns.Add(this.nameColumn);
            this.ApplicationSettingsSupergrid.PrimaryGrid.Columns.Add(this.descriptionColumn);
            this.ApplicationSettingsSupergrid.PrimaryGrid.Columns.Add(this.datatypeColumn);
            this.ApplicationSettingsSupergrid.PrimaryGrid.Columns.Add(this.valueColumn);
            // 
            // 
            // 
            this.ApplicationSettingsSupergrid.PrimaryGrid.Filter.ShowPanelFilterExpr = true;
            this.ApplicationSettingsSupergrid.PrimaryGrid.Filter.Visible = true;
            this.ApplicationSettingsSupergrid.RestoreSelectionAfterSortChanged = true;
            this.ApplicationSettingsSupergrid.SettingsStorageType = Actemium.Windows.Forms.SuperGrid.SuperGrid.SettingsStorageTypeEnum.ToFile;
            this.ApplicationSettingsSupergrid.Size = new System.Drawing.Size(613, 479);
            this.ApplicationSettingsSupergrid.TabIndex = 0;
            this.ApplicationSettingsSupergrid.Text = "ApplicationSettingsSupergrid";
            this.ApplicationSettingsSupergrid.Translate = true;
            this.ApplicationSettingsSupergrid.ValidatorColumnName = null;
            this.ApplicationSettingsSupergrid.ValidatorCustomHighlightHandler = null;
            this.ApplicationSettingsSupergrid.ValidatorHandler = null;
            this.ApplicationSettingsSupergrid.ValidatorHighlightColor = System.Drawing.Color.Red;
            this.ApplicationSettingsSupergrid.ValidatorHighlightFontStyle = System.Drawing.FontStyle.Bold;
            this.ApplicationSettingsSupergrid.ValidatorHighlightType = Actemium.Windows.Forms.SuperGrid.SuperGrid.ValidatorHighlightTypes.BackgroundColor;
            // 
            // applicationSettingColumn
            // 
            this.applicationSettingColumn.Name = "ApplicationSetting";
            this.applicationSettingColumn.Visible = false;
            // 
            // applicationSettingCategoryColumn
            // 
            this.applicationSettingCategoryColumn.DataPropertyName = "";
            this.applicationSettingCategoryColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.applicationSettingCategoryColumn.HeaderText = "Application Setting Category";
            this.applicationSettingCategoryColumn.Name = "ApplicationSettingCategory";
            // 
            // nameColumn
            // 
            this.nameColumn.DataPropertyName = "";
            this.nameColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.nameColumn.HeaderText = "Name";
            this.nameColumn.Name = "Name";
            // 
            // descriptionColumn
            // 
            this.descriptionColumn.DataPropertyName = "";
            this.descriptionColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.descriptionColumn.HeaderText = "Description";
            this.descriptionColumn.Name = "Description";
            // 
            // datatypeColumn
            // 
            this.datatypeColumn.DataPropertyName = "";
            this.datatypeColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.datatypeColumn.HeaderText = "Datatype";
            this.datatypeColumn.Name = "Datatype";
            // 
            // valueColumn
            // 
            this.valueColumn.DataPropertyName = "Value";
            this.valueColumn.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridLabelXEditControl);
            this.valueColumn.HeaderText = "Value";
            this.valueColumn.Name = "Value";
            // 
            // ApplicationSettingsManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 479);
            this.Controls.Add(this.ApplicationSettingsSupergrid);
            this.DoubleBuffered = true;
            this.Name = "ApplicationSettingsManagementForm";
            this.Text = "ServerSideSettingsAdministrationForm";
            this.ResumeLayout(false);

    }

    

    private Actemium.Windows.Forms.SuperGrid.SuperGrid ApplicationSettingsSupergrid;

    #endregion

    private DevComponents.DotNetBar.SuperGrid.GridColumn applicationSettingColumn;
    private DevComponents.DotNetBar.SuperGrid.GridColumn applicationSettingCategoryColumn;
    private DevComponents.DotNetBar.SuperGrid.GridColumn nameColumn;
    private DevComponents.DotNetBar.SuperGrid.GridColumn descriptionColumn;
    private DevComponents.DotNetBar.SuperGrid.GridColumn datatypeColumn;
    private DevComponents.DotNetBar.SuperGrid.GridColumn valueColumn;
  }
}