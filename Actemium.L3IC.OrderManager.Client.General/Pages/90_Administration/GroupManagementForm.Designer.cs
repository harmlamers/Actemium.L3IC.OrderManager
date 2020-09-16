using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.Pages._90_Administration
{
  partial class GroupManagementForm
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.tbDomainGroupIdentifier = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
			this.lblDomain = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
			this.tbDescription = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
			this.tbName = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
			this.btnCancel = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
			this.btnOK = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
			this.lblDescription = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
			this.lblName = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
			this.lblUserGroups = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
			this.btnDeSelectAll = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
			this.btnSelectAll = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
			this.btnDelete = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
			this.btnModify = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
			this.btnAdd = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.lblPermGroup = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
			this.pnlTop = new System.Windows.Forms.Panel();
			this.dgvGroups = new Actemium.Windows.Forms.DevComponents2.Controls.DataGridViewX();
			this.dgvcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvcDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvcDomainGroupIdentifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel2 = new System.Windows.Forms.Panel();
			this.gbSelectedUsergroup = new Actemium.Windows.Forms.DevComponents2.Controls.GroupPanel(this.components);
			this.btnProperties = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
			this.pnlKmtBar = new System.Windows.Forms.Panel();
			this.pnlUpperSplit = new System.Windows.Forms.Panel();
			this.pnlBottomLeft = new System.Windows.Forms.Panel();
			this.dgvACICategories = new Actemium.Windows.Forms.DevComponents2.Controls.DataGridViewX();
			this.dgvcCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dgvcGranted = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.binConsumingPanel = new System.Windows.Forms.Panel();
			this.pnlBottomRight = new System.Windows.Forms.Panel();
			this.dgvACI = new Actemium.Windows.Forms.DevComponents2.Controls.DataGridViewX();
			this.aciGranted = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
			this.aciPermissionAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.lblPermGroupAndCat = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
			this.pnlBottom = new System.Windows.Forms.Panel();
			this.pnlBottomSplit = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.pnlTop.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).BeginInit();
			this.panel2.SuspendLayout();
			this.gbSelectedUsergroup.SuspendLayout();
			this.pnlKmtBar.SuspendLayout();
			this.pnlBottomLeft.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvACICategories)).BeginInit();
			this.binConsumingPanel.SuspendLayout();
			this.pnlBottomRight.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvACI)).BeginInit();
			this.panel4.SuspendLayout();
			this.panel8.SuspendLayout();
			this.pnlBottom.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbDomainGroupIdentifier
			// 
			// 
			// 
			// 
			this.tbDomainGroupIdentifier.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.tbDomainGroupIdentifier.Location = new System.Drawing.Point(135, 55);
			this.tbDomainGroupIdentifier.MaxLength = 255;
			this.tbDomainGroupIdentifier.Name = "tbDomainGroupIdentifier";
			this.tbDomainGroupIdentifier.Size = new System.Drawing.Size(266, 20);
			this.tbDomainGroupIdentifier.TabIndex = 2;
			// 
			// lblDomain
			// 
			this.lblDomain.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.lblDomain.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lblDomain.Location = new System.Drawing.Point(3, 55);
			this.lblDomain.Name = "lblDomain";
			this.lblDomain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblDomain.Size = new System.Drawing.Size(127, 18);
			this.lblDomain.TabIndex = 7;
			this.lblDomain.Text = "Domain Group Identifier";
			this.lblDomain.Translate = true;
			// 
			// tbDescription
			// 
			// 
			// 
			// 
			this.tbDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.tbDescription.Location = new System.Drawing.Point(135, 29);
			this.tbDescription.MaxLength = 255;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.Size = new System.Drawing.Size(266, 20);
			this.tbDescription.TabIndex = 1;
			// 
			// tbName
			// 
			// 
			// 
			// 
			this.tbName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.tbName.Location = new System.Drawing.Point(135, 3);
			this.tbName.MaxLength = 50;
			this.tbName.Name = "tbName";
			this.tbName.Size = new System.Drawing.Size(266, 20);
			this.tbName.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_ApplicationExit_16;
			this.btnCancel.Location = new System.Drawing.Point(501, 46);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(8);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(100, 25);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
			this.btnCancel.Translate = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// btnOK
			// 
			this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnOK.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_OK_16;
			this.btnOK.Location = new System.Drawing.Point(501, 14);
			this.btnOK.Margin = new System.Windows.Forms.Padding(8);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(100, 25);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			this.btnOK.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
			this.btnOK.Translate = true;
			this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
			// 
			// lblDescription
			// 
			this.lblDescription.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.lblDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lblDescription.Location = new System.Drawing.Point(3, 29);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblDescription.Size = new System.Drawing.Size(124, 18);
			this.lblDescription.TabIndex = 4;
			this.lblDescription.Text = "Description";
			this.lblDescription.Translate = true;
			// 
			// lblName
			// 
			this.lblName.BackColor = System.Drawing.Color.Transparent;
			// 
			// 
			// 
			this.lblName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lblName.Location = new System.Drawing.Point(3, 3);
			this.lblName.Name = "lblName";
			this.lblName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.lblName.Size = new System.Drawing.Size(123, 18);
			this.lblName.TabIndex = 5;
			this.lblName.Text = "Name";
			this.lblName.Translate = true;
			// 
			// lblUserGroups
			// 
			this.lblUserGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblUserGroups.AutoSize = true;
			// 
			// 
			// 
			this.lblUserGroups.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lblUserGroups.Location = new System.Drawing.Point(8, 5);
			this.lblUserGroups.Name = "lblUserGroups";
			this.lblUserGroups.Size = new System.Drawing.Size(62, 15);
			this.lblUserGroups.TabIndex = 18;
			this.lblUserGroups.Text = "User groups";
			this.lblUserGroups.Translate = true;
			// 
			// btnDeSelectAll
			// 
			this.btnDeSelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnDeSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeSelectAll.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources._btnDeselectAll;
			this.btnDeSelectAll.Location = new System.Drawing.Point(426, 8);
			this.btnDeSelectAll.Margin = new System.Windows.Forms.Padding(8);
			this.btnDeSelectAll.Name = "btnDeSelectAll";
			this.btnDeSelectAll.Size = new System.Drawing.Size(100, 25);
			this.btnDeSelectAll.TabIndex = 1;
			this.btnDeSelectAll.Text = "Deselect all";
			this.btnDeSelectAll.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
			this.btnDeSelectAll.Translate = true;
			this.btnDeSelectAll.Click += new System.EventHandler(this.BtnDeSelectAllClick);
			// 
			// btnSelectAll
			// 
			this.btnSelectAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSelectAll.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources._btnSelectAll;
			this.btnSelectAll.Location = new System.Drawing.Point(310, 8);
			this.btnSelectAll.Margin = new System.Windows.Forms.Padding(8);
			this.btnSelectAll.Name = "btnSelectAll";
			this.btnSelectAll.Size = new System.Drawing.Size(100, 25);
			this.btnSelectAll.TabIndex = 0;
			this.btnSelectAll.Text = "Select alll";
			this.btnSelectAll.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
			this.btnSelectAll.Translate = true;
			this.btnSelectAll.Click += new System.EventHandler(this.BtnSelectAllClick);
			// 
			// btnDelete
			// 
			this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDelete.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_GroupDelete_16;
			this.btnDelete.Location = new System.Drawing.Point(908, 72);
			this.btnDelete.Margin = new System.Windows.Forms.Padding(8);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(100, 25);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Delete";
			this.btnDelete.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
			this.btnDelete.Translate = true;
			this.btnDelete.Click += new System.EventHandler(this.BtnDeleteClick);
			// 
			// btnModify
			// 
			this.btnModify.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnModify.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_GroupModify_16;
			this.btnModify.Location = new System.Drawing.Point(908, 40);
			this.btnModify.Margin = new System.Windows.Forms.Padding(8);
			this.btnModify.Name = "btnModify";
			this.btnModify.Size = new System.Drawing.Size(100, 25);
			this.btnModify.TabIndex = 2;
			this.btnModify.Text = "Modify";
			this.btnModify.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
			this.btnModify.Translate = true;
			this.btnModify.Click += new System.EventHandler(this.BtnModifyClick);
			// 
			// btnAdd
			// 
			this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_GroupAdd_16;
			this.btnAdd.Location = new System.Drawing.Point(908, 8);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(8);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(100, 25);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
			this.btnAdd.Translate = true;
			this.btnAdd.Click += new System.EventHandler(this.BtnAddClick);
			// 
			// errorProvider
			// 
			this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.errorProvider.ContainerControl = this;
			// 
			// lblPermGroup
			// 
			this.lblPermGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblPermGroup.AutoSize = true;
			// 
			// 
			// 
			this.lblPermGroup.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lblPermGroup.Location = new System.Drawing.Point(5, 3);
			this.lblPermGroup.Name = "lblPermGroup";
			this.lblPermGroup.Size = new System.Drawing.Size(207, 15);
			this.lblPermGroup.TabIndex = 24;
			this.lblPermGroup.Text = "Permissions categories for selected group";
			this.lblPermGroup.Translate = true;
			// 
			// pnlTop
			// 
			this.pnlTop.Controls.Add(this.dgvGroups);
			this.pnlTop.Controls.Add(this.panel2);
			this.pnlTop.Controls.Add(this.pnlKmtBar);
			this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTop.Location = new System.Drawing.Point(0, 0);
			this.pnlTop.Name = "pnlTop";
			this.pnlTop.Size = new System.Drawing.Size(1016, 268);
			this.pnlTop.TabIndex = 26;
			// 
			// dgvGroups
			// 
			this.dgvGroups.AllowUserToAddRows = false;
			this.dgvGroups.AllowUserToResizeRows = false;
			this.dgvGroups.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvGroups.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcName,
            this.dgvcDescription,
            this.dgvcDomainGroupIdentifier});
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvGroups.DefaultCellStyle = dataGridViewCellStyle3;
			this.dgvGroups.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvGroups.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
			this.dgvGroups.HighlightSelectedColumnHeaders = false;
			this.dgvGroups.Location = new System.Drawing.Point(0, 24);
			this.dgvGroups.MultiSelect = false;
			this.dgvGroups.Name = "dgvGroups";
			this.dgvGroups.ReadOnly = true;
			this.dgvGroups.RowHeadersVisible = false;
			this.dgvGroups.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvGroups.Size = new System.Drawing.Size(1016, 122);
			this.dgvGroups.TabIndex = 0;
			this.dgvGroups.Translate = true;
			this.dgvGroups.SelectionChanged += new System.EventHandler(this.GroupsGridSelectionChanged);
			// 
			// dgvcName
			// 
			this.dgvcName.DataPropertyName = "Name";
			this.dgvcName.HeaderText = "Name";
			this.dgvcName.Name = "dgvcName";
			this.dgvcName.ReadOnly = true;
			// 
			// dgvcDescription
			// 
			this.dgvcDescription.DataPropertyName = "Description";
			this.dgvcDescription.HeaderText = "Description";
			this.dgvcDescription.Name = "dgvcDescription";
			this.dgvcDescription.ReadOnly = true;
			// 
			// dgvcDomainGroupIdentifier
			// 
			this.dgvcDomainGroupIdentifier.DataPropertyName = "DomainGroupIdentifier";
			this.dgvcDomainGroupIdentifier.HeaderText = "Domain Group Identifier";
			this.dgvcDomainGroupIdentifier.Name = "dgvcDomainGroupIdentifier";
			this.dgvcDomainGroupIdentifier.ReadOnly = true;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.gbSelectedUsergroup);
			this.panel2.Controls.Add(this.btnProperties);
			this.panel2.Controls.Add(this.btnModify);
			this.panel2.Controls.Add(this.btnAdd);
			this.panel2.Controls.Add(this.btnDelete);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 146);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1016, 122);
			this.panel2.TabIndex = 28;
			// 
			// gbSelectedUsergroup
			// 
			this.gbSelectedUsergroup.CanvasColor = System.Drawing.SystemColors.Control;
			this.gbSelectedUsergroup.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
			this.gbSelectedUsergroup.Controls.Add(this.btnOK);
			this.gbSelectedUsergroup.Controls.Add(this.btnCancel);
			this.gbSelectedUsergroup.Controls.Add(this.tbDomainGroupIdentifier);
			this.gbSelectedUsergroup.Controls.Add(this.tbName);
			this.gbSelectedUsergroup.Controls.Add(this.lblDomain);
			this.gbSelectedUsergroup.Controls.Add(this.lblName);
			this.gbSelectedUsergroup.Controls.Add(this.tbDescription);
			this.gbSelectedUsergroup.Controls.Add(this.lblDescription);
			this.gbSelectedUsergroup.Location = new System.Drawing.Point(12, 8);
			this.gbSelectedUsergroup.Name = "gbSelectedUsergroup";
			this.gbSelectedUsergroup.Size = new System.Drawing.Size(615, 103);
			// 
			// 
			// 
			this.gbSelectedUsergroup.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
			this.gbSelectedUsergroup.Style.BackColorGradientAngle = 90;
			this.gbSelectedUsergroup.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
			this.gbSelectedUsergroup.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.gbSelectedUsergroup.Style.BorderBottomWidth = 1;
			this.gbSelectedUsergroup.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
			this.gbSelectedUsergroup.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.gbSelectedUsergroup.Style.BorderLeftWidth = 1;
			this.gbSelectedUsergroup.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.gbSelectedUsergroup.Style.BorderRightWidth = 1;
			this.gbSelectedUsergroup.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
			this.gbSelectedUsergroup.Style.BorderTopWidth = 1;
			this.gbSelectedUsergroup.Style.CornerDiameter = 4;
			this.gbSelectedUsergroup.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
			this.gbSelectedUsergroup.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
			this.gbSelectedUsergroup.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
			this.gbSelectedUsergroup.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
			// 
			// 
			// 
			this.gbSelectedUsergroup.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			// 
			// 
			// 
			this.gbSelectedUsergroup.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.gbSelectedUsergroup.TabIndex = 30;
			this.gbSelectedUsergroup.Text = "Selected usergroup";
			this.gbSelectedUsergroup.Translate = true;
			// 
			// btnProperties
			// 
			this.btnProperties.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.btnProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnProperties.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_Properties_16;
			this.btnProperties.Location = new System.Drawing.Point(792, 8);
			this.btnProperties.Margin = new System.Windows.Forms.Padding(8);
			this.btnProperties.Name = "btnProperties";
			this.btnProperties.Size = new System.Drawing.Size(100, 25);
			this.btnProperties.TabIndex = 0;
			this.btnProperties.Text = "Properties";
			this.btnProperties.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
			this.btnProperties.Translate = true;
			this.btnProperties.Click += new System.EventHandler(this.BtnPropertiesClick);
			// 
			// pnlKmtBar
			// 
			this.pnlKmtBar.Controls.Add(this.lblUserGroups);
			this.pnlKmtBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlKmtBar.Location = new System.Drawing.Point(0, 0);
			this.pnlKmtBar.Name = "pnlKmtBar";
			this.pnlKmtBar.Size = new System.Drawing.Size(1016, 24);
			this.pnlKmtBar.TabIndex = 27;
			// 
			// pnlUpperSplit
			// 
			this.pnlUpperSplit.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlUpperSplit.Location = new System.Drawing.Point(0, 268);
			this.pnlUpperSplit.Name = "pnlUpperSplit";
			this.pnlUpperSplit.Size = new System.Drawing.Size(1016, 20);
			this.pnlUpperSplit.TabIndex = 44;
			// 
			// pnlBottomLeft
			// 
			this.pnlBottomLeft.Controls.Add(this.dgvACICategories);
			this.pnlBottomLeft.Controls.Add(this.binConsumingPanel);
			this.pnlBottomLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlBottomLeft.Location = new System.Drawing.Point(0, 0);
			this.pnlBottomLeft.Name = "pnlBottomLeft";
			this.pnlBottomLeft.Size = new System.Drawing.Size(462, 351);
			this.pnlBottomLeft.TabIndex = 45;
			// 
			// dgvACICategories
			// 
			this.dgvACICategories.AllowUserToAddRows = false;
			this.dgvACICategories.AllowUserToResizeRows = false;
			this.dgvACICategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvACICategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvACICategories.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcCategory,
            this.dgvcGranted});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvACICategories.DefaultCellStyle = dataGridViewCellStyle2;
			this.dgvACICategories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvACICategories.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
			this.dgvACICategories.HighlightSelectedColumnHeaders = false;
			this.dgvACICategories.Location = new System.Drawing.Point(0, 20);
			this.dgvACICategories.MultiSelect = false;
			this.dgvACICategories.Name = "dgvACICategories";
			this.dgvACICategories.ReadOnly = true;
			this.dgvACICategories.RowHeadersVisible = false;
			this.dgvACICategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvACICategories.Size = new System.Drawing.Size(462, 331);
			this.dgvACICategories.TabIndex = 0;
			this.dgvACICategories.Translate = true;
			this.dgvACICategories.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DgvACICategoriesRowPrePaint);
			this.dgvACICategories.SelectionChanged += new System.EventHandler(this.DgvACICategoriesSelectionChanged);
			// 
			// dgvcCategory
			// 
			this.dgvcCategory.DataPropertyName = "Category";
			this.dgvcCategory.HeaderText = "Category";
			this.dgvcCategory.Name = "dgvcCategory";
			this.dgvcCategory.ReadOnly = true;
			// 
			// dgvcGranted
			// 
			this.dgvcGranted.DataPropertyName = "DisplayGranted";
			this.dgvcGranted.FillWeight = 40F;
			this.dgvcGranted.HeaderText = "Granted";
			this.dgvcGranted.Name = "dgvcGranted";
			this.dgvcGranted.ReadOnly = true;
			// 
			// binConsumingPanel
			// 
			this.binConsumingPanel.Controls.Add(this.lblPermGroup);
			this.binConsumingPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.binConsumingPanel.Location = new System.Drawing.Point(0, 0);
			this.binConsumingPanel.Name = "binConsumingPanel";
			this.binConsumingPanel.Size = new System.Drawing.Size(462, 20);
			this.binConsumingPanel.TabIndex = 50;
			// 
			// pnlBottomRight
			// 
			this.pnlBottomRight.Controls.Add(this.dgvACI);
			this.pnlBottomRight.Controls.Add(this.panel4);
			this.pnlBottomRight.Controls.Add(this.panel8);
			this.pnlBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBottomRight.Location = new System.Drawing.Point(482, 0);
			this.pnlBottomRight.Name = "pnlBottomRight";
			this.pnlBottomRight.Size = new System.Drawing.Size(534, 351);
			this.pnlBottomRight.TabIndex = 46;
			// 
			// dgvACI
			// 
			this.dgvACI.AllowUserToAddRows = false;
			this.dgvACI.AllowUserToResizeRows = false;
			this.dgvACI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvACI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvACI.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aciGranted,
            this.aciPermissionAction});
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dgvACI.DefaultCellStyle = dataGridViewCellStyle1;
			this.dgvACI.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvACI.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
			this.dgvACI.HighlightSelectedColumnHeaders = false;
			this.dgvACI.Location = new System.Drawing.Point(0, 20);
			this.dgvACI.MultiSelect = false;
			this.dgvACI.Name = "dgvACI";
			this.dgvACI.ReadOnly = true;
			this.dgvACI.RowHeadersVisible = false;
			this.dgvACI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvACI.Size = new System.Drawing.Size(534, 287);
			this.dgvACI.TabIndex = 0;
			this.dgvACI.Translate = true;
			this.dgvACI.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvACICellClick);
			// 
			// aciGranted
			// 
			this.aciGranted.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
			this.aciGranted.Checked = true;
			this.aciGranted.CheckState = System.Windows.Forms.CheckState.Indeterminate;
			this.aciGranted.CheckValue = "N";
			this.aciGranted.DataPropertyName = "Granted";
			this.aciGranted.FillWeight = 40F;
			this.aciGranted.HeaderText = "Granted";
			this.aciGranted.Name = "aciGranted";
			this.aciGranted.ReadOnly = true;
			this.aciGranted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.aciGranted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			// 
			// aciPermissionAction
			// 
			this.aciPermissionAction.DataPropertyName = "Action";
			this.aciPermissionAction.HeaderText = "Permission / Action";
			this.aciPermissionAction.Name = "aciPermissionAction";
			this.aciPermissionAction.ReadOnly = true;
			// 
			// panel4
			// 
			this.panel4.Controls.Add(this.btnDeSelectAll);
			this.panel4.Controls.Add(this.btnSelectAll);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel4.Location = new System.Drawing.Point(0, 307);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(534, 44);
			this.panel4.TabIndex = 50;
			// 
			// panel8
			// 
			this.panel8.Controls.Add(this.lblPermGroupAndCat);
			this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel8.Location = new System.Drawing.Point(0, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(534, 20);
			this.panel8.TabIndex = 49;
			// 
			// lblPermGroupAndCat
			// 
			this.lblPermGroupAndCat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPermGroupAndCat.AutoSize = true;
			// 
			// 
			// 
			this.lblPermGroupAndCat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
			this.lblPermGroupAndCat.Location = new System.Drawing.Point(6, 4);
			this.lblPermGroupAndCat.Name = "lblPermGroupAndCat";
			this.lblPermGroupAndCat.Size = new System.Drawing.Size(220, 15);
			this.lblPermGroupAndCat.TabIndex = 17;
			this.lblPermGroupAndCat.Text = "Permissions for selected group and category";
			this.lblPermGroupAndCat.Translate = true;
			// 
			// pnlBottom
			// 
			this.pnlBottom.Controls.Add(this.pnlBottomRight);
			this.pnlBottom.Controls.Add(this.pnlBottomSplit);
			this.pnlBottom.Controls.Add(this.pnlBottomLeft);
			this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlBottom.Location = new System.Drawing.Point(0, 288);
			this.pnlBottom.Name = "pnlBottom";
			this.pnlBottom.Size = new System.Drawing.Size(1016, 351);
			this.pnlBottom.TabIndex = 47;
			// 
			// pnlBottomSplit
			// 
			this.pnlBottomSplit.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlBottomSplit.Location = new System.Drawing.Point(462, 0);
			this.pnlBottomSplit.Name = "pnlBottomSplit";
			this.pnlBottomSplit.Size = new System.Drawing.Size(20, 351);
			this.pnlBottomSplit.TabIndex = 48;
			// 
			// GroupManagementForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.BackColor = System.Drawing.Color.LightGray;
			this.ClientSize = new System.Drawing.Size(1016, 639);
			this.Controls.Add(this.pnlBottom);
			this.Controls.Add(this.pnlUpperSplit);
			this.Controls.Add(this.pnlTop);
			this.DoubleBuffered = true;
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.KeyPreview = true;
			this.Name = "GroupManagementForm";
			this.Resize += new System.EventHandler(this.GroupManagementFormResize);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.pnlTop.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvGroups)).EndInit();
			this.panel2.ResumeLayout(false);
			this.gbSelectedUsergroup.ResumeLayout(false);
			this.pnlKmtBar.ResumeLayout(false);
			this.pnlKmtBar.PerformLayout();
			this.pnlBottomLeft.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvACICategories)).EndInit();
			this.binConsumingPanel.ResumeLayout(false);
			this.binConsumingPanel.PerformLayout();
			this.pnlBottomRight.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvACI)).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel8.ResumeLayout(false);
			this.panel8.PerformLayout();
			this.pnlBottom.ResumeLayout(false);
			this.ResumeLayout(false);

    }

    #endregion

		private Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX tbDescription;
		private Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX tbName;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnCancel;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnOK;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblDescription;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblName;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnDelete;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnModify;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnAdd;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblUserGroups;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnDeSelectAll;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnSelectAll;
    private System.Windows.Forms.ErrorProvider errorProvider;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblPermGroup;
		private Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX tbDomainGroupIdentifier;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblDomain;
    private System.Windows.Forms.Panel pnlTop;
    private System.Windows.Forms.Panel pnlKmtBar;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel pnlUpperSplit;
    private System.Windows.Forms.Panel pnlBottomLeft;
    private System.Windows.Forms.Panel pnlBottomRight;
    private System.Windows.Forms.Panel binConsumingPanel;
    private System.Windows.Forms.Panel pnlBottom;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Panel panel8;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblPermGroupAndCat;
		private System.Windows.Forms.Panel pnlBottomSplit;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnProperties;
		private Actemium.Windows.Forms.DevComponents2.Controls.GroupPanel gbSelectedUsergroup;
		private Actemium.Windows.Forms.DevComponents2.Controls.DataGridViewX dgvGroups;
		private Actemium.Windows.Forms.DevComponents2.Controls.DataGridViewX dgvACI;
		private Actemium.Windows.Forms.DevComponents2.Controls.DataGridViewX dgvACICategories;
		private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn aciGranted;
		private System.Windows.Forms.DataGridViewTextBoxColumn aciPermissionAction;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescription;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDomainGroupIdentifier;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCategory;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcGranted;

  }
}