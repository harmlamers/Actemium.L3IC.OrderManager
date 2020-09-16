namespace Actemium.L3IC.OrderManager.Client.General.Pages._90_Administration
{
  partial class ComputerManagementForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComputerManagementForm));
      this.lblComputers = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.lblPermGroup = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.pnlTop = new System.Windows.Forms.Panel();
      this.dgvComputers = new Actemium.Windows.Forms.DevComponents2.Controls.DataGridViewX();
      this.dgvcHostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dgvcDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dgvcACIManaged = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
      this.panel2 = new System.Windows.Forms.Panel();
      this.gbSelectedComputer = new Actemium.Windows.Forms.DevComponents2.Controls.GroupPanel(this.components);
      this.ckbACIManaged = new Actemium.Windows.Forms.DevComponents2.Controls.CheckBoxX();
      this.lblAciManaged = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.tbDescription = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
      this.tbHostName = new Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX(this.components);
      this.lblDescription = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.lblHostName = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.pnlKmtBar = new System.Windows.Forms.Panel();
      this.pnlUpperSplit = new System.Windows.Forms.Panel();
      this.pnlBottomLeft = new System.Windows.Forms.Panel();
      this.dgvACICategories = new Actemium.Windows.Forms.DevComponents2.Controls.DataGridViewX();
      this.dgvcCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dgvcGranted = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.binConsumingPanel = new System.Windows.Forms.Panel();
      this.pnlBottomRight = new System.Windows.Forms.Panel();
      this.dgvACI = new Actemium.Windows.Forms.DevComponents2.Controls.DataGridViewX();
      this.dgvcAciGranted = new DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn();
      this.dgvcAciAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panel4 = new System.Windows.Forms.Panel();
      this.panel8 = new System.Windows.Forms.Panel();
      this.lblPermCompAndCat = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.pnlBottom = new System.Windows.Forms.Panel();
      this.pnlBottomSplit = new System.Windows.Forms.Panel();
      this.btnDeSelectAll = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.btnSelectAll = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.btnCancel = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.btnOK = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.btnProperties = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.btnModify = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.btnAdd = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      this.btnDelete = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonX(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
      this.pnlTop.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgvComputers)).BeginInit();
      this.panel2.SuspendLayout();
      this.gbSelectedComputer.SuspendLayout();
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
      // lblComputers
      // 
      this.lblComputers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblComputers.AutoSize = true;
      // 
      // 
      // 
      this.lblComputers.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.lblComputers.Location = new System.Drawing.Point(8, 5);
      this.lblComputers.Name = "lblComputers";
      this.lblComputers.Size = new System.Drawing.Size(56, 15);
      this.lblComputers.TabIndex = 18;
      this.lblComputers.Text = "Computers";
      this.lblComputers.Translate = true;
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
      this.lblPermGroup.Size = new System.Drawing.Size(219, 15);
      this.lblPermGroup.TabIndex = 24;
      this.lblPermGroup.Text = "Permission categories for selected computer";
      this.lblPermGroup.Translate = true;
      // 
      // pnlTop
      // 
      this.pnlTop.Controls.Add(this.dgvComputers);
      this.pnlTop.Controls.Add(this.panel2);
      this.pnlTop.Controls.Add(this.pnlKmtBar);
      this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.pnlTop.Location = new System.Drawing.Point(0, 0);
      this.pnlTop.Name = "pnlTop";
      this.pnlTop.Size = new System.Drawing.Size(1016, 268);
      this.pnlTop.TabIndex = 26;
      // 
      // dgvComputers
      // 
      this.dgvComputers.AllowUserToAddRows = false;
      this.dgvComputers.AllowUserToResizeRows = false;
      this.dgvComputers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgvComputers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgvComputers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcHostName,
            this.dgvcDescription,
            this.dgvcACIManaged});
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.dgvComputers.DefaultCellStyle = dataGridViewCellStyle3;
      this.dgvComputers.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgvComputers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
      this.dgvComputers.HighlightSelectedColumnHeaders = false;
      this.dgvComputers.Location = new System.Drawing.Point(0, 24);
      this.dgvComputers.MultiSelect = false;
      this.dgvComputers.Name = "dgvComputers";
      this.dgvComputers.ReadOnly = true;
      this.dgvComputers.RowHeadersVisible = false;
      this.dgvComputers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgvComputers.Size = new System.Drawing.Size(1016, 122);
      this.dgvComputers.TabIndex = 0;
      this.dgvComputers.Translate = true;
      this.dgvComputers.SelectionChanged += new System.EventHandler(this.DgvComputersSelectionChanged);
      // 
      // dgvcHostName
      // 
      this.dgvcHostName.DataPropertyName = "HostName";
      this.dgvcHostName.FillWeight = 50F;
      this.dgvcHostName.HeaderText = "Host name";
      this.dgvcHostName.Name = "dgvcHostName";
      this.dgvcHostName.ReadOnly = true;
      // 
      // dgvcDescription
      // 
      this.dgvcDescription.DataPropertyName = "Description";
      this.dgvcDescription.HeaderText = "Description";
      this.dgvcDescription.Name = "dgvcDescription";
      this.dgvcDescription.ReadOnly = true;
      // 
      // dgvcACIManaged
      // 
      this.dgvcACIManaged.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
      this.dgvcACIManaged.Checked = true;
      this.dgvcACIManaged.CheckState = System.Windows.Forms.CheckState.Indeterminate;
      this.dgvcACIManaged.CheckValue = "N";
      this.dgvcACIManaged.DataPropertyName = "ACIManaged";
      this.dgvcACIManaged.FillWeight = 40F;
      this.dgvcACIManaged.HeaderText = "ACI Managed";
      this.dgvcACIManaged.Name = "dgvcACIManaged";
      this.dgvcACIManaged.ReadOnly = true;
      this.dgvcACIManaged.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      this.dgvcACIManaged.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.gbSelectedComputer);
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
      // gbSelectedComputer
      // 
      this.gbSelectedComputer.CanvasColor = System.Drawing.SystemColors.Control;
      this.gbSelectedComputer.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
      this.gbSelectedComputer.Controls.Add(this.ckbACIManaged);
      this.gbSelectedComputer.Controls.Add(this.lblAciManaged);
      this.gbSelectedComputer.Controls.Add(this.tbDescription);
      this.gbSelectedComputer.Controls.Add(this.tbHostName);
      this.gbSelectedComputer.Controls.Add(this.lblDescription);
      this.gbSelectedComputer.Controls.Add(this.btnCancel);
      this.gbSelectedComputer.Controls.Add(this.lblHostName);
      this.gbSelectedComputer.Controls.Add(this.btnOK);
      this.gbSelectedComputer.Location = new System.Drawing.Point(8, 8);
      this.gbSelectedComputer.Name = "gbSelectedComputer";
      this.gbSelectedComputer.Size = new System.Drawing.Size(630, 103);
      // 
      // 
      // 
      this.gbSelectedComputer.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
      this.gbSelectedComputer.Style.BackColorGradientAngle = 90;
      this.gbSelectedComputer.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
      this.gbSelectedComputer.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gbSelectedComputer.Style.BorderBottomWidth = 1;
      this.gbSelectedComputer.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
      this.gbSelectedComputer.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gbSelectedComputer.Style.BorderLeftWidth = 1;
      this.gbSelectedComputer.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gbSelectedComputer.Style.BorderRightWidth = 1;
      this.gbSelectedComputer.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
      this.gbSelectedComputer.Style.BorderTopWidth = 1;
      this.gbSelectedComputer.Style.CornerDiameter = 4;
      this.gbSelectedComputer.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
      this.gbSelectedComputer.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
      this.gbSelectedComputer.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
      this.gbSelectedComputer.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
      // 
      // 
      // 
      this.gbSelectedComputer.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      // 
      // 
      // 
      this.gbSelectedComputer.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.gbSelectedComputer.TabIndex = 31;
      this.gbSelectedComputer.Text = "Selected Computer";
      this.gbSelectedComputer.Translate = true;
      // 
      // ckbACIManaged
      // 
      this.ckbACIManaged.AutoSize = true;
      this.ckbACIManaged.BackColor = System.Drawing.Color.Transparent;
      // 
      // 
      // 
      this.ckbACIManaged.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.ckbACIManaged.Location = new System.Drawing.Point(127, 61);
      this.ckbACIManaged.Name = "ckbACIManaged";
      this.ckbACIManaged.Size = new System.Drawing.Size(22, 15);
      this.ckbACIManaged.TabIndex = 2;
      this.ckbACIManaged.Text = " ";
      this.ckbACIManaged.Translate = false;
      // 
      // lblAciManaged
      // 
      this.lblAciManaged.BackColor = System.Drawing.Color.Transparent;
      // 
      // 
      // 
      this.lblAciManaged.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.lblAciManaged.Location = new System.Drawing.Point(3, 56);
      this.lblAciManaged.Name = "lblAciManaged";
      this.lblAciManaged.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.lblAciManaged.Size = new System.Drawing.Size(116, 20);
      this.lblAciManaged.TabIndex = 13;
      this.lblAciManaged.Text = "ACI Managed";
      this.lblAciManaged.Translate = true;
      // 
      // tbDescription
      // 
      // 
      // 
      // 
      this.tbDescription.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.tbDescription.Location = new System.Drawing.Point(127, 32);
      this.tbDescription.MaxLength = 255;
      this.tbDescription.Name = "tbDescription";
      this.tbDescription.Size = new System.Drawing.Size(266, 20);
      this.tbDescription.TabIndex = 1;
      // 
      // tbHostName
      // 
      // 
      // 
      // 
      this.tbHostName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.tbHostName.Location = new System.Drawing.Point(127, 6);
      this.tbHostName.MaxLength = 50;
      this.tbHostName.Name = "tbHostName";
      this.tbHostName.Size = new System.Drawing.Size(266, 20);
      this.tbHostName.TabIndex = 0;
      // 
      // lblDescription
      // 
      this.lblDescription.BackColor = System.Drawing.Color.Transparent;
      // 
      // 
      // 
      this.lblDescription.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.lblDescription.Location = new System.Drawing.Point(3, 32);
      this.lblDescription.Name = "lblDescription";
      this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.lblDescription.Size = new System.Drawing.Size(116, 18);
      this.lblDescription.TabIndex = 11;
      this.lblDescription.Text = "Description";
      this.lblDescription.Translate = true;
      // 
      // lblHostName
      // 
      this.lblHostName.BackColor = System.Drawing.Color.Transparent;
      // 
      // 
      // 
      this.lblHostName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.lblHostName.Location = new System.Drawing.Point(3, 6);
      this.lblHostName.Name = "lblHostName";
      this.lblHostName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
      this.lblHostName.Size = new System.Drawing.Size(116, 18);
      this.lblHostName.TabIndex = 12;
      this.lblHostName.Text = "Host name";
      this.lblHostName.Translate = true;
      // 
      // pnlKmtBar
      // 
      this.pnlKmtBar.Controls.Add(this.lblComputers);
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
            this.dgvcAciGranted,
            this.dgvcAciAction});
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
      // dgvcAciGranted
      // 
      this.dgvcAciGranted.CheckBoxPosition = DevComponents.DotNetBar.eCheckBoxPosition.Top;
      this.dgvcAciGranted.Checked = true;
      this.dgvcAciGranted.CheckState = System.Windows.Forms.CheckState.Indeterminate;
      this.dgvcAciGranted.CheckValue = "N";
      this.dgvcAciGranted.DataPropertyName = "Granted";
      this.dgvcAciGranted.FillWeight = 40F;
      this.dgvcAciGranted.HeaderText = "Granted";
      this.dgvcAciGranted.Name = "dgvcAciGranted";
      this.dgvcAciGranted.ReadOnly = true;
      // 
      // dgvcAciAction
      // 
      this.dgvcAciAction.DataPropertyName = "Action";
      this.dgvcAciAction.HeaderText = "Permission / Action";
      this.dgvcAciAction.Name = "dgvcAciAction";
      this.dgvcAciAction.ReadOnly = true;
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
      this.panel8.Controls.Add(this.lblPermCompAndCat);
      this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel8.Location = new System.Drawing.Point(0, 0);
      this.panel8.Name = "panel8";
      this.panel8.Size = new System.Drawing.Size(534, 20);
      this.panel8.TabIndex = 49;
      // 
      // lblPermCompAndCat
      // 
      this.lblPermCompAndCat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lblPermCompAndCat.AutoSize = true;
      // 
      // 
      // 
      this.lblPermCompAndCat.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.lblPermCompAndCat.Location = new System.Drawing.Point(6, 4);
      this.lblPermCompAndCat.Name = "lblPermCompAndCat";
      this.lblPermCompAndCat.Size = new System.Drawing.Size(237, 15);
      this.lblPermCompAndCat.TabIndex = 17;
      this.lblPermCompAndCat.Text = "Permissions for selected computer and category";
      this.lblPermCompAndCat.Translate = true;
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
      // btnCancel
      // 
      this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_ApplicationExit_16;
      this.btnCancel.Location = new System.Drawing.Point(516, 46);
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
      this.btnOK.Location = new System.Drawing.Point(516, 14);
      this.btnOK.Margin = new System.Windows.Forms.Padding(8);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(100, 25);
      this.btnOK.TabIndex = 3;
      this.btnOK.Text = "OK";
      this.btnOK.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left;
      this.btnOK.Translate = true;
      this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
      // 
      // btnProperties
      // 
      this.btnProperties.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.btnProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnProperties.Image = ((System.Drawing.Image)(resources.GetObject("btnProperties.Image")));
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
      // btnModify
      // 
      this.btnModify.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnModify.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_ComputerModify_16;
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
      this.btnAdd.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_ComputerAdd_16;
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
      // btnDelete
      // 
      this.btnDelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDelete.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_ComputerDelete_16;
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
      // ComputerManagementForm
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
      this.Name = "ComputerManagementForm";
      this.Resize += new System.EventHandler(this.GroupManagementFormResize);
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
      this.pnlTop.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgvComputers)).EndInit();
      this.panel2.ResumeLayout(false);
      this.gbSelectedComputer.ResumeLayout(false);
      this.gbSelectedComputer.PerformLayout();
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

		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnCancel;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnOK;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnDelete;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnModify;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnAdd;
    private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblComputers;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnDeSelectAll;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnSelectAll;
    private System.Windows.Forms.ErrorProvider errorProvider;
    private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblPermGroup;
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
    private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblPermCompAndCat;
		private System.Windows.Forms.Panel pnlBottomSplit;
		private Actemium.Windows.Forms.DevComponents2.Controls.ButtonX btnProperties;
		private Actemium.Windows.Forms.DevComponents2.Controls.GroupPanel gbSelectedComputer;
		private Actemium.Windows.Forms.DevComponents2.Controls.CheckBoxX ckbACIManaged;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblAciManaged;
		private Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX tbDescription;
		private Actemium.Windows.Forms.DevComponents2.Controls.TextBoxX tbHostName;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblDescription;
		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblHostName;
		private Actemium.Windows.Forms.DevComponents2.Controls.DataGridViewX dgvACI;
		private Actemium.Windows.Forms.DevComponents2.Controls.DataGridViewX dgvACICategories;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcCategory;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcGranted;
		private Actemium.Windows.Forms.DevComponents2.Controls.DataGridViewX dgvComputers;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcHostName;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcDescription;
		private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn dgvcACIManaged;
		private DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn dgvcAciGranted;
		private System.Windows.Forms.DataGridViewTextBoxColumn dgvcAciAction;





  }
}