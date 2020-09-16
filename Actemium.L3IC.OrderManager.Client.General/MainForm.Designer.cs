using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace Actemium.L3IC.OrderManager.Client.General
{
  sealed partial class MainForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.statusStrip = new Actemium.Windows.Forms.DevComponents2.Controls.StatusStrip();
      this.userStatusStripLabel = new Actemium.Windows.Forms.DevComponents2.Controls.ToolStripStatusLabel();
      this.userValueStatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.actionsStatusStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
      this.navigationLocationStatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.timeStatusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
      this.btnLanguage = new System.Windows.Forms.ToolStripSplitButton();
      this.nederlandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.refreshTimer = new System.Windows.Forms.Timer(this.components);
      this.dasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ribbonControlHeader = new Actemium.Windows.Forms.DevComponents2.Controls.RibbonControl(this.components);
      this.startButton = new DevComponents.DotNetBar.Office2007StartButton();
      this.itemContainer1 = new DevComponents.DotNetBar.ItemContainer();
      this.itemContainer2 = new DevComponents.DotNetBar.ItemContainer();
      this.itemContainer3 = new DevComponents.DotNetBar.ItemContainer();
      this.quickLogoffButton = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem(this.components);
      this.logonLogoffButton = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem(this.components);
      this.logonAsButton = new DevComponents.DotNetBar.ButtonItem();
      this.userProfileButton = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem(this.components);
      this.checkForUpdateButton = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem(this.components);
      this.programFolderButton = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem(this.components);
      this.aboutButton = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem(this.components);
      this.exitButton = new Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem(this.components);
      this.homeQuickButton = new DevComponents.DotNetBar.ButtonItem();
      this.previousQuickButton = new DevComponents.DotNetBar.ButtonItem();
      this.nextQuickButton = new DevComponents.DotNetBar.ButtonItem();
      this.refreshButtonItem = new DevComponents.DotNetBar.ButtonItem();
      this.helpQuickButtonItem = new DevComponents.DotNetBar.ButtonItem();
      this.ProductionTabItemGroup = new DevComponents.DotNetBar.RibbonTabItemGroup();
      this.screenManagerPanel = new Actemium.L3IC.OrderManager.Client.General.ScreenManagerPanel();
      this.pnlBusy = new System.Windows.Forms.Panel();
      this.lblLoading = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.mainPanel = new Actemium.L3IC.OrderManager.Client.General.ScreenManagerPanel();
      this.panelHeaderText = new System.Windows.Forms.Panel();
      this.buttonDetach = new DevComponents.DotNetBar.ButtonX();
      this.headerLabel = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
      this.generalRibbonTabItem = new DevComponents.DotNetBar.RibbonTabItem();
      this.nextButtonItem = new DevComponents.DotNetBar.ButtonItem();
      this.previousButtonItem = new DevComponents.DotNetBar.ButtonItem();
      this.startScreenButtonItem = new DevComponents.DotNetBar.ButtonItem();
      this.loginLogoutButtonItem = new DevComponents.DotNetBar.ButtonItem();
      this.statusStrip.SuspendLayout();
      this.pnlBusy.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.panelHeaderText.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusStrip
      // 
      this.statusStrip.AccessibleDescription = "StatusBar";
      this.statusStrip.AccessibleName = "StatusBar";
      this.statusStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
      this.statusStrip.AllowMerge = false;
      this.statusStrip.BackColor = System.Drawing.Color.Silver;
      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userStatusStripLabel,
            this.userValueStatusStripLabel,
            this.actionsStatusStripDropDownButton,
            this.navigationLocationStatusStripLabel,
            this.timeStatusStripLabel,
            this.btnLanguage});
      this.statusStrip.Location = new System.Drawing.Point(5, 1000);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
      this.statusStrip.Size = new System.Drawing.Size(1270, 22);
      this.statusStrip.SizingGrip = false;
      this.statusStrip.TabIndex = 2;
      this.statusStrip.Text = "statusStrip";
      this.statusStrip.Resize += new System.EventHandler(this.StatusStripResize);
      // 
      // userStatusStripLabel
      // 
      this.userStatusStripLabel.AutoSize = false;
      this.userStatusStripLabel.BackColor = System.Drawing.SystemColors.Control;
      this.userStatusStripLabel.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
      this.userStatusStripLabel.Name = "userStatusStripLabel";
      this.userStatusStripLabel.Size = new System.Drawing.Size(60, 17);
      this.userStatusStripLabel.Text = "User :";
      this.userStatusStripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      this.userStatusStripLabel.Translate = true;
      // 
      // userValueStatusStripLabel
      // 
      this.userValueStatusStripLabel.AutoSize = false;
      this.userValueStatusStripLabel.BackColor = System.Drawing.SystemColors.Control;
      this.userValueStatusStripLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
      this.userValueStatusStripLabel.Margin = new System.Windows.Forms.Padding(0, 3, 5, 2);
      this.userValueStatusStripLabel.Name = "userValueStatusStripLabel";
      this.userValueStatusStripLabel.Size = new System.Drawing.Size(150, 17);
      this.userValueStatusStripLabel.Text = "-";
      this.userValueStatusStripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // actionsStatusStripDropDownButton
      // 
      this.actionsStatusStripDropDownButton.AutoSize = false;
      this.actionsStatusStripDropDownButton.BackColor = System.Drawing.Color.Silver;
      this.actionsStatusStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.actionsStatusStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.actionsStatusStripDropDownButton.Margin = new System.Windows.Forms.Padding(5, 2, 5, 0);
      this.actionsStatusStripDropDownButton.Name = "actionsStatusStripDropDownButton";
      this.actionsStatusStripDropDownButton.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
      this.actionsStatusStripDropDownButton.ShowDropDownArrow = false;
      this.actionsStatusStripDropDownButton.Size = new System.Drawing.Size(370, 20);
      this.actionsStatusStripDropDownButton.Text = "--:-- : ---";
      this.actionsStatusStripDropDownButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // navigationLocationStatusStripLabel
      // 
      this.navigationLocationStatusStripLabel.AutoSize = false;
      this.navigationLocationStatusStripLabel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
      this.navigationLocationStatusStripLabel.Margin = new System.Windows.Forms.Padding(5, 3, 5, 2);
      this.navigationLocationStatusStripLabel.Name = "navigationLocationStatusStripLabel";
      this.navigationLocationStatusStripLabel.Size = new System.Drawing.Size(250, 17);
      this.navigationLocationStatusStripLabel.Text = "Initializing...";
      this.navigationLocationStatusStripLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // timeStatusStripLabel
      // 
      this.timeStatusStripLabel.AutoSize = false;
      this.timeStatusStripLabel.BackColor = System.Drawing.SystemColors.Control;
      this.timeStatusStripLabel.Margin = new System.Windows.Forms.Padding(5, 3, 5, 2);
      this.timeStatusStripLabel.Name = "timeStatusStripLabel";
      this.timeStatusStripLabel.Size = new System.Drawing.Size(115, 17);
      this.timeStatusStripLabel.Text = "-- - -- - ---- --:--";
      // 
      // btnLanguage
      // 
      this.btnLanguage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.btnLanguage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.btnLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nederlandsToolStripMenuItem,
            this.englishToolStripMenuItem});
      this.btnLanguage.Image = ((System.Drawing.Image)(resources.GetObject("btnLanguage.Image")));
      this.btnLanguage.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.btnLanguage.Name = "btnLanguage";
      this.btnLanguage.Size = new System.Drawing.Size(32, 20);
      this.btnLanguage.Text = "toolStripSplitButton1";
      this.btnLanguage.ButtonClick += new System.EventHandler(this.BtnLanguageButtonClick);
      // 
      // nederlandsToolStripMenuItem
      // 
      this.nederlandsToolStripMenuItem.Name = "nederlandsToolStripMenuItem";
      this.nederlandsToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
      // 
      // englishToolStripMenuItem
      // 
      this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
      this.englishToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
      // 
      // refreshTimer
      // 
      this.refreshTimer.Interval = 1000;
      this.refreshTimer.Tick += new System.EventHandler(this.RefreshTimerTick);
      // 
      // dasToolStripMenuItem
      // 
      this.dasToolStripMenuItem.Name = "dasToolStripMenuItem";
      this.dasToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
      // 
      // ribbonControlHeader
      // 
      this.ribbonControlHeader.AntiAlias = false;
      this.ribbonControlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(205)))), ((int)(((byte)(214)))));
      // 
      // 
      // 
      this.ribbonControlHeader.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.ribbonControlHeader.CanCustomize = false;
      this.ribbonControlHeader.CaptionHeight = 20;
      this.ribbonControlHeader.CaptionVisible = true;
      this.ribbonControlHeader.CategorizeMode = DevComponents.DotNetBar.eCategorizeMode.Categories;
      this.ribbonControlHeader.Dock = System.Windows.Forms.DockStyle.Top;
      this.ribbonControlHeader.EnableQatPlacement = false;
      this.ribbonControlHeader.Expanded = false;
      this.ribbonControlHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ribbonControlHeader.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
      this.ribbonControlHeader.Location = new System.Drawing.Point(5, 1);
      this.ribbonControlHeader.MdiSystemItemVisible = false;
      this.ribbonControlHeader.Name = "ribbonControlHeader";
      this.ribbonControlHeader.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
      this.ribbonControlHeader.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.startButton,
            this.homeQuickButton,
            this.previousQuickButton,
            this.nextQuickButton,
            this.refreshButtonItem,
            this.helpQuickButtonItem});
      this.ribbonControlHeader.Size = new System.Drawing.Size(1270, 145);
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
      this.ribbonControlHeader.TabGroupHeight = 14;
      this.ribbonControlHeader.TabGroups.AddRange(new DevComponents.DotNetBar.RibbonTabItemGroup[] {
            this.ProductionTabItemGroup});
      this.ribbonControlHeader.TabGroupsVisible = true;
      this.ribbonControlHeader.TabIndex = 26;
      this.ribbonControlHeader.Text = "Actemium - Client";
      this.ribbonControlHeader.UseCustomizeDialog = false;
      this.ribbonControlHeader.ExpandedChanged += new System.EventHandler(this.RibbonControlHeaderExpandedChanged);
      // 
      // startButton
      // 
      this.startButton.AutoExpandOnClick = true;
      this.startButton.CanCustomize = false;
      this.startButton.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
      this.startButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources._ActemiumIcon_24;
      this.startButton.ImagePaddingHorizontal = 2;
      this.startButton.ImagePaddingVertical = 2;
      this.startButton.KeyTips = "F";
      this.startButton.Name = "startButton";
      this.startButton.ShowSubItems = false;
      this.startButton.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer1});
      this.startButton.Tag = "NO_TRANSLATE";
      this.startButton.Text = "Start<u>&M</u>enu";
      // 
      // itemContainer1
      // 
      // 
      // 
      // 
      this.itemContainer1.BackgroundStyle.Class = "RibbonFileMenuContainer";
      this.itemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.itemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.itemContainer1.Name = "itemContainer1";
      this.itemContainer1.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer2});
      this.itemContainer1.Tag = "NO_TRANSLATE";
      // 
      // 
      // 
      this.itemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      // 
      // itemContainer2
      // 
      // 
      // 
      // 
      this.itemContainer2.BackgroundStyle.Class = "RibbonFileMenuTwoColumnContainer";
      this.itemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.itemContainer2.ItemSpacing = 0;
      this.itemContainer2.Name = "itemContainer2";
      this.itemContainer2.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.itemContainer3});
      this.itemContainer2.Tag = "NO_TRANSLATE";
      // 
      // 
      // 
      this.itemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      // 
      // itemContainer3
      // 
      // 
      // 
      // 
      this.itemContainer3.BackgroundStyle.Class = "RibbonFileMenuColumnOneContainer";
      this.itemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.itemContainer3.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical;
      this.itemContainer3.MinimumSize = new System.Drawing.Size(120, 0);
      this.itemContainer3.Name = "itemContainer3";
      this.itemContainer3.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.quickLogoffButton,
            this.logonLogoffButton,
            this.logonAsButton,
            this.userProfileButton,
            this.checkForUpdateButton,
            this.programFolderButton,
            this.aboutButton,
            this.exitButton});
      this.itemContainer3.Tag = "NO_TRANSLATE";
      // 
      // 
      // 
      this.itemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      // 
      // quickLogoffButton
      // 
      this.quickLogoffButton.BeginGroup = true;
      this.quickLogoffButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
      this.quickLogoffButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_UserDelete_24;
      this.quickLogoffButton.Name = "quickLogoffButton";
      this.quickLogoffButton.SubItemsExpandWidth = 24;
      this.quickLogoffButton.Tag = "1";
      this.quickLogoffButton.Text = "Logoff";
      this.quickLogoffButton.Translate = true;
      this.quickLogoffButton.Click += new System.EventHandler(this.QuickLogoffButtonClick);
      // 
      // logonLogoffButton
      // 
      this.logonLogoffButton.BeginGroup = true;
      this.logonLogoffButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
      this.logonLogoffButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_Login_24;
      this.logonLogoffButton.Name = "logonLogoffButton";
      this.logonLogoffButton.SubItemsExpandWidth = 24;
      this.logonLogoffButton.Tag = "1";
      this.logonLogoffButton.Text = "Logon screen";
      this.logonLogoffButton.Translate = true;
      this.logonLogoffButton.Click += new System.EventHandler(this.LogonLogoffButtonClick);
      // 
      // logonAsButton
      // 
      this.logonAsButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
      this.logonAsButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_User_24;
      this.logonAsButton.ImageFixedSize = new System.Drawing.Size(24, 24);
      this.logonAsButton.Name = "logonAsButton";
      this.logonAsButton.Text = "Logon As";
      // 
      // userProfileButton
      // 
      this.userProfileButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
      this.userProfileButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_UserManagement_24;
      this.userProfileButton.ImageFixedSize = new System.Drawing.Size(24, 24);
      this.userProfileButton.Name = "userProfileButton";
      this.userProfileButton.SubItemsExpandWidth = 24;
      this.userProfileButton.Text = "User Profile";
      this.userProfileButton.Translate = true;
      this.userProfileButton.Click += new System.EventHandler(this.UserProfileButtonClick);
      // 
      // checkForUpdateButton
      // 
      this.checkForUpdateButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
      this.checkForUpdateButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources._btnUpdate;
      this.checkForUpdateButton.Name = "checkForUpdateButton";
      this.checkForUpdateButton.Text = "Check for updates";
      this.checkForUpdateButton.Translate = true;
      this.checkForUpdateButton.Click += new System.EventHandler(this.CheckForUpdateButtonClick);
      // 
      // programFolderButton
      // 
      this.programFolderButton.BeginGroup = true;
      this.programFolderButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
      this.programFolderButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_ProgramFolder_24;
      this.programFolderButton.Name = "programFolderButton";
      this.programFolderButton.SubItemsExpandWidth = 24;
      this.programFolderButton.Tag = "1";
      this.programFolderButton.Text = "Open program folder";
      this.programFolderButton.Translate = true;
      this.programFolderButton.Click += new System.EventHandler(this.ProgramFolderButtonClick);
      // 
      // aboutButton
      // 
      this.aboutButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
      this.aboutButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources._ActemiumIcon_24;
      this.aboutButton.Name = "aboutButton";
      this.aboutButton.SubItemsExpandWidth = 24;
      this.aboutButton.Text = "  About";
      this.aboutButton.Translate = true;
      this.aboutButton.Click += new System.EventHandler(this.AboutButtonClick);
      // 
      // exitButton
      // 
      this.exitButton.BeginGroup = true;
      this.exitButton.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText;
      this.exitButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_ApplicationExit_24;
      this.exitButton.ImageFixedSize = new System.Drawing.Size(24, 24);
      this.exitButton.Name = "exitButton";
      this.exitButton.SubItemsExpandWidth = 24;
      this.exitButton.Text = "Exit";
      this.exitButton.Translate = true;
      this.exitButton.Click += new System.EventHandler(this.ExitButtonClick);
      // 
      // homeQuickButton
      // 
      this.homeQuickButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_Home_16;
      this.homeQuickButton.Name = "homeQuickButton";
      this.homeQuickButton.Click += new System.EventHandler(this.HomeButtonClick);
      // 
      // previousQuickButton
      // 
      this.previousQuickButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_Back_16;
      this.previousQuickButton.Name = "previousQuickButton";
      this.previousQuickButton.Click += new System.EventHandler(this.PreviousButtonClick);
      // 
      // nextQuickButton
      // 
      this.nextQuickButton.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_Next_16;
      this.nextQuickButton.Name = "nextQuickButton";
      this.nextQuickButton.Click += new System.EventHandler(this.NextButtonClick);
      // 
      // refreshButtonItem
      // 
      this.refreshButtonItem.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_Refresh_16;
      this.refreshButtonItem.Name = "refreshButtonItem";
      this.refreshButtonItem.Click += new System.EventHandler(this.RefreshButtonItemClick);
      // 
      // helpQuickButtonItem
      // 
      this.helpQuickButtonItem.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_Help_16;
      this.helpQuickButtonItem.Name = "helpQuickButtonItem";
      this.helpQuickButtonItem.Click += new System.EventHandler(this.HelpQuickButtonItemClick);
      // 
      // ProductionTabItemGroup
      // 
      this.ProductionTabItemGroup.Color = DevComponents.DotNetBar.eRibbonTabGroupColor.Green;
      this.ProductionTabItemGroup.GroupTitle = "Production";
      this.ProductionTabItemGroup.Name = "ProductionTabItemGroup";
      // 
      // 
      // 
      this.ProductionTabItemGroup.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.ProductionTabItemGroup.Style.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
      this.ProductionTabItemGroup.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
      // 
      // screenManagerPanel
      // 
      this.screenManagerPanel.BackColor = System.Drawing.Color.LightGray;
      this.screenManagerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.screenManagerPanel.Location = new System.Drawing.Point(5, 170);
      this.screenManagerPanel.Name = "screenManagerPanel";
      this.screenManagerPanel.Size = new System.Drawing.Size(1270, 830);
      this.screenManagerPanel.TabIndex = 0;
      this.screenManagerPanel.ScreenChanged += new Actemium.L3IC.OrderManager.Client.General.Events.ScreenChangedHandler(this.MainPanelScreenChanged);
      this.screenManagerPanel.Resize += new System.EventHandler(this.MainPanelResize);
      // 
      // pnlBusy
      // 
      this.pnlBusy.BackColor = System.Drawing.Color.DarkGray;
      this.pnlBusy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pnlBusy.Controls.Add(this.lblLoading);
      this.pnlBusy.Controls.Add(this.pictureBox1);
      this.pnlBusy.Cursor = System.Windows.Forms.Cursors.WaitCursor;
      this.pnlBusy.Location = new System.Drawing.Point(480, 348);
      this.pnlBusy.Name = "pnlBusy";
      this.pnlBusy.Size = new System.Drawing.Size(300, 70);
      this.pnlBusy.TabIndex = 5;
      this.pnlBusy.Visible = false;
      // 
      // lblLoading
      // 
      // 
      // 
      // 
      this.lblLoading.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      this.lblLoading.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
      this.lblLoading.FormatMask = null;
      this.lblLoading.Location = new System.Drawing.Point(86, 24);
      this.lblLoading.Name = "lblLoading";
      this.lblLoading.Size = new System.Drawing.Size(200, 23);
      this.lblLoading.TabIndex = 0;
      this.lblLoading.Text = "Loading, please wait...";
      this.lblLoading.Translate = true;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources._Busy;
      this.pictureBox1.Location = new System.Drawing.Point(28, 19);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(32, 32);
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // mainPanel
      // 
      this.mainPanel.BackColor = System.Drawing.Color.LightGray;
      this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.mainPanel.Location = new System.Drawing.Point(0, 144);
      this.mainPanel.Name = "mainPanel";
      this.mainPanel.Size = new System.Drawing.Size(1280, 602);
      this.mainPanel.TabIndex = 0;
      this.mainPanel.ScreenChanged += new Actemium.L3IC.OrderManager.Client.General.Events.ScreenChangedHandler(this.MainPanelScreenChanged);
      this.mainPanel.Resize += new System.EventHandler(this.MainPanelResize);
      // 
      // panelHeaderText
      // 
      this.panelHeaderText.Controls.Add(this.buttonDetach);
      this.panelHeaderText.Controls.Add(this.headerLabel);
      this.panelHeaderText.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelHeaderText.Location = new System.Drawing.Point(5, 146);
      this.panelHeaderText.Name = "panelHeaderText";
      this.panelHeaderText.Size = new System.Drawing.Size(1270, 24);
      this.panelHeaderText.TabIndex = 28;
      // 
      // buttonDetach
      // 
      this.buttonDetach.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
      this.buttonDetach.BackColor = System.Drawing.Color.SlateGray;
      this.buttonDetach.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
      this.buttonDetach.Dock = System.Windows.Forms.DockStyle.Right;
      this.buttonDetach.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_Windows_16;
      this.buttonDetach.Location = new System.Drawing.Point(1246, 24);
      this.buttonDetach.Name = "buttonDetach";
      this.buttonDetach.Size = new System.Drawing.Size(24, 0);
      this.buttonDetach.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
      this.buttonDetach.TabIndex = 1;
      this.buttonDetach.Visible = false;
      this.buttonDetach.Click += new System.EventHandler(this.buttonDetach_Click);
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
      this.headerLabel.Size = new System.Drawing.Size(1270, 24);
      this.headerLabel.TabIndex = 28;
      this.headerLabel.Tag = "NO_TRANSLATE";
      this.headerLabel.TextAlignment = System.Drawing.StringAlignment.Center;
      this.headerLabel.Translate = false;
      // 
      // generalRibbonTabItem
      // 
      this.generalRibbonTabItem.Checked = true;
      this.generalRibbonTabItem.Name = "generalRibbonTabItem";
      this.generalRibbonTabItem.Text = "General";
      // 
      // nextButtonItem
      // 
      this.nextButtonItem.Name = "nextButtonItem";
      // 
      // previousButtonItem
      // 
      this.previousButtonItem.Name = "previousButtonItem";
      // 
      // startScreenButtonItem
      // 
      this.startScreenButtonItem.Name = "startScreenButtonItem";
      // 
      // loginLogoutButtonItem
      // 
      this.loginLogoutButtonItem.HotFontBold = true;
      this.loginLogoutButtonItem.Image = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources.IE_Login_32;
      this.loginLogoutButtonItem.ImageFixedSize = new System.Drawing.Size(32, 32);
      this.loginLogoutButtonItem.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
      this.loginLogoutButtonItem.Name = "loginLogoutButtonItem";
      this.loginLogoutButtonItem.RibbonWordWrap = false;
      this.loginLogoutButtonItem.Tag = "1";
      this.loginLogoutButtonItem.Text = "Login Logout";
      this.loginLogoutButtonItem.Click += new System.EventHandler(this.Navigate);
      // 
      // MainForm
      // 
      this.AccessibleDescription = "";
      this.AccessibleName = "";
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(205)))), ((int)(((byte)(214)))));
      this.ClientSize = new System.Drawing.Size(1280, 1024);
      this.Controls.Add(this.pnlBusy);
      this.Controls.Add(this.screenManagerPanel);
      this.Controls.Add(this.panelHeaderText);
      this.Controls.Add(this.statusStrip);
      this.Controls.Add(this.ribbonControlHeader);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MinimumSize = new System.Drawing.Size(1280, 868);
      this.Name = "MainForm";
      this.Text = "Actemium";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
      this.Load += new System.EventHandler(this.MainFormLoad);
      this.ResizeBegin += new System.EventHandler(this.MainFormResizeBegin);
      this.ResizeEnd += new System.EventHandler(this.MainFormResizeEnd);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.pnlBusy.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.panelHeaderText.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

    }


    #endregion

    private Actemium.Windows.Forms.DevComponents2.Controls.StatusStrip statusStrip;
    private Actemium.Windows.Forms.DevComponents2.Controls.ToolStripStatusLabel userStatusStripLabel;
    private System.Windows.Forms.ToolStripDropDownButton actionsStatusStripDropDownButton;
    private System.Windows.Forms.ToolStripStatusLabel userValueStatusStripLabel;
    private System.Windows.Forms.ToolStripStatusLabel timeStatusStripLabel;
    private ScreenManagerPanel screenManagerPanel;
    private System.Windows.Forms.Timer refreshTimer;
    private System.Windows.Forms.ToolStripMenuItem dasToolStripMenuItem;
    private Actemium.Windows.Forms.DevComponents2.Controls.RibbonControl ribbonControlHeader;
    private DevComponents.DotNetBar.Office2007StartButton startButton;
    private DevComponents.DotNetBar.ItemContainer itemContainer1;
    private DevComponents.DotNetBar.ItemContainer itemContainer2;
    private DevComponents.DotNetBar.ItemContainer itemContainer3;
    //private DevComponents.DotNetBar.ButtonItem logonLogoffButton;
    //private DevComponents.DotNetBar.ButtonItem aboutButton;
    //private DevComponents.DotNetBar.ButtonItem exitButton;
    //private DevComponents.DotNetBar.ButtonItem checkForUpdateButton;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem logonLogoffButton;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem quickLogoffButton;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem aboutButton;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem exitButton;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem programFolderButton;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem checkForUpdateButton;
    private System.Windows.Forms.ToolStripStatusLabel navigationLocationStatusStripLabel;
    private ScreenManagerPanel mainPanel;
    private System.Windows.Forms.Panel panelHeaderText;
    private Actemium.Windows.Forms.DevComponents2.Controls.LabelX headerLabel;
    private DevComponents.DotNetBar.RibbonTabItemGroup ProductionTabItemGroup;
    private RibbonTabItem generalRibbonTabItem;
    private ButtonItem nextButtonItem;
    private ButtonItem previousButtonItem;
    private ButtonItem startScreenButtonItem;
    private ButtonItem loginLogoutButtonItem;
    private Panel pnlBusy;
    private PictureBox pictureBox1;
    private ToolStripSplitButton btnLanguage;
    private ToolStripMenuItem nederlandsToolStripMenuItem;
    private ToolStripMenuItem englishToolStripMenuItem;
    private Actemium.Windows.Forms.DevComponents2.Controls.LabelX lblLoading;
    private ButtonItem homeQuickButton;
    private ButtonItem previousQuickButton;
    private ButtonItem nextQuickButton;
    private ButtonItem refreshButtonItem;
    private ButtonItem helpQuickButtonItem;
    private Actemium.Windows.Forms.DevComponents2.Controls.ButtonItem userProfileButton;
    private ButtonItem logonAsButton;
    private ButtonX buttonDetach;
  }
}

