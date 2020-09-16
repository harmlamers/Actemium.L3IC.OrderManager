using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using Actemium.ApplicationSettings.Model;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Base.PropertyGrids;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.Client.General.Helpers;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.Translations;
using Actemium.UserManagement2;
using Actemium.Windows.Forms.DevComponents2.Controls;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.Pages._90_Administration
{
  public partial class ApplicationSettingsManagementForm : BasePageForm
  {

    private const string CLASSNAME = nameof(ApplicationSettingsManagementForm);
    private const string OBJECT = nameof(ApplicationSetting);
    public bool IsRefreshing { get; private set; }
    private readonly List<PropertyGridElement> _lastGivenPropertyGridElementList = new List<PropertyGridElement>();
    private readonly Dispatcher _guiThread = Dispatcher.CurrentDispatcher;

    private List<ApplicationSetting> _loadDataResult;

    public ApplicationSettingsManagementForm(NavigationItems navi)
      : base()
    {
      try
      {
        InitializeComponent();
        NavigationItem = navi;

        InitializeTranslations();

        Title = "Application Settings Management";
        ACICategory = ACICategories.APPLICATIONSETTINGSMANAGEMENT;

        CreateAndInitializeButtons();
        ConfigureSuperGrid();

      }
      catch (Exception ex)
      {
        string name = Trace.GetMethodName();
        Trace.WriteError("()", name, CLASSNAME, ex);
        DisplayError(name, ex.Message);
      }
    }

    public DataTable GetApplicationSettingDataTable()
    {
      try
      {
        
        var applicationSettingsList =
          ApplicationSettings.Business.ApplicationSettings.Instance.GetAll()
            .ToList();
        var applicationSettingsDataTable = ApplicationSettingsHelper.Instance.GetDataTable(applicationSettingsList);

        return applicationSettingsDataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        return null;
      }
    }

    public override void ActivateFromMain(EventArgs e)
    {
      try
      {
        base.ActivateFromMain(e);

        if (!CurrentUser.HasPermission(ACICategory, ACIOptions.VIEW))
        {
          const TranslationKey transKey = TranslationKey.CommonMessage_NoAuthorization;
          throw new SecurityException(CurrentUser.User.Username, Translation.Instance.Translate(transKey, TranslationSubKey.Message, transKey.GetCommonMessage()));
        }
        Show();
        AddButtonRibbonBars();
        Refresh();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    private void RefreshGrid()
    {

      try
      {
        if (IsRefreshing) {
                    return;
                }

                ApplicationSettingsSupergrid.PrimaryGrid.Footer.Text = Translations.General.LoadingData;
        Task.Factory.StartNew(LoadDataTask).ContinueWith(OnContinuationFunction);
        ApplicationSettingsSupergrid.IdentifyingColumn = "ApplicationSetting";
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private List<ApplicationSetting> LoadDataTask()
    {
      try
      {
        IsRefreshing = true;

        ApplicationSettingsSupergrid.SuspendLayout();
        return ApplicationSettings.Business.ApplicationSettings.Instance.GetAll()
          .ToList();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        return null;
      }
    }

    private void OnContinuationFunction(Task<List<ApplicationSetting>> t)
    {
      try
      {
        _guiThread.Invoke(() =>
        {
          _loadDataResult = t.Result;
          
          ApplicationSettingsSupergrid.RememberSelection();
          ApplicationSettingsSupergrid.RestoreSelectionAfterRefresh();
          ApplicationSettingsSupergrid.SuspendLayout();
          ApplicationSettingsSupergrid.PrimaryGrid.Footer.Text = " ";
          ApplicationSettingsHelper.Instance.PopulateSettingsGrid(
            _loadDataResult, ApplicationSettingsSupergrid, valueColumn, applicationSettingColumn, applicationSettingCategoryColumn, nameColumn, descriptionColumn, datatypeColumn, true);
          ApplicationSettingsSupergrid.ResumeLayout(false);
          ApplicationSettingsSupergrid.PerformLayout();
          
        });
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
      }
      finally
      {
        IsRefreshing = false;
      }
    }

    public override void Refresh()
    {
      try
      {
        ShowBusyBox = true;
        RefreshGrid();

        EnableDisableControls();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
      finally
      {
        ShowBusyBox = false;
      }
    }

    private void EnableDisableControls()
    {
      if (ApplicationSettingsSupergrid == null)
        return;

      ApplicationSettingsSupergrid.PrimaryGrid.AllowEdit = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
      ApplicationSettingsSupergrid.PrimaryGrid.ShowEditingImage = true;
      ApplicationSettingsSupergrid.CellValueChanged -= ApplicationSettingsSupergridCellValueChanged;
      ApplicationSettingsSupergrid.SelectionChanged -= ApplicationSettingsSupergridSelectionChanged;
      ApplicationSettingsSupergrid.CellValueChanged += ApplicationSettingsSupergridCellValueChanged;
      ApplicationSettingsSupergrid.SelectionChanged += ApplicationSettingsSupergridSelectionChanged;
    }

    
    private DateTime _lastChange = DateTime.MinValue;

    private void ApplicationSettingsSupergridCellValueChanged(object sender, GridCellValueChangedEventArgs e)
    {
      if (_lastChange > DateTime.Now.AddSeconds(-1))
        return;

      _lastChange = DateTime.Now;
      var row = (ApplicationSetting)e.GridCell.GridRow.GetCell(OBJECT).Value;
      if (!CurrentUser.HasPermission(
        ACICategories.APPLICATIONSETTINGSMANAGEMENT,
        $"{ACIOptions.MODIFY}_Category_{((ApplicationSettingsCategories)row.ApplicationSettingsCategoryId).ToString()}"))
      {
        DisplayError(TranslationKey.Error_ApplicationSettings_InsufficientRights, "Insufficient Rights", "You don't have the right to edit a value of a setting of category {0}", Translations.ApplicationSettings.TranslatedApplicationSettingsCategoryDictionary[row.ApplicationSettingsCategoryId]);
        RefreshGrid();
        return;
      }
      row.Value = e.NewValue.ToString();
      ApplicationSettings.Business.ApplicationSettings.Instance.Modify(row);
      AddHistoryAction(TranslationKey.History_ApplicationSettingsAdministrationForm_Modified, "User {0} changed application setting {1} from {2} to {3}", CurrentUser.User.Username, Translations.ApplicationSettings.TranslatedApplicationSettingsNameDictionary[row.ApplicationSettingId], e.OldValue, row.Value);
    }

    private RibbonBar ApplicationSettingsRibbonBar { get; }
    private ButtonItem AddButtonItem { get; }
    private ButtonItem ModifyButtonItem { get; }
    private ButtonItem ManageButtonItem { get; }

    private void CreateAndInitializeButtons()
    {
      try
      {
        ApplicationSettingsSupergrid.PrimaryGrid.MultiSelect = false;
        // Add ButtonItem
        //AddButtonItem = MenuGenerator.CreateButtonItem(Properties.Resources.data_add, new Size(28, 28), "addInstallBaseButtonItem", Translations.InstallBaseAdministrationForm.Add);
        //ModifyButtonItem = MenuGenerator.CreateButtonItem(Properties.Resources.data_edit, new Size(28, 28), "modifyInstallBaseButtonItem", Translations.InstallBaseAdministrationForm.Modify);
        //ManageButtonItem = MenuGenerator.CreateButtonItem(Properties.Resources.data_preferences, new Size(28, 28), "manageInstallBaseButtonItem", Translations.InstallBaseAdministrationForm.Manage);


        //AddButtonItem.Click += AddButtonItemOnClick;
        //ModifyButtonItem.Click += ModifyButtonItemOnClick;
        //ManageButtonItem.Click += ManageButtonItem_Click;

        //AddButtonItem.Enabled = false;
        //ModifyButtonItem.Enabled = false;
        //ManageButtonItem.Enabled = false;

        // Add RibbonBar
        //var baseItems = new BaseItem[]
        //{
        //  //AddButtonItem,
        //  //ModifyButtonItem,
        //  //ManageButtonItem
        //};
        //ServerSideSettingsRibbonBar = MenuGenerator.CreateRibbonBar(baseItems, "ServerSideSettingsRibbonBar", Translations.ServerSideSettingsAdministrationForm.RibbonBar);
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void AddButtonRibbonBars()
    {
      try
      {
        //RibbonBars.Add(new Tuple<string, RibbonBar>("tiManagement", ServerSideSettingsRibbonBar));
      }
      catch (Exception ex)
      {
        var name = Trace.GetMethodName();
        Trace.WriteError("", name, CLASSNAME, ex);
      }
    }

    public override void DeActivateFromMain()
    {
      try
      {
        base.DeActivateFromMain();

        CurrentUser.ClearPermissions();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    #region Translations
    
    private void InitializeTranslations()
    {
      Translations.Initialize();
    }

    #endregion

    #region Configure SuperGrid & SuperGrid functions
    private void ConfigureSuperGrid()
    {
      ApplicationSettingsSupergrid.ApplyProjectDefaults();
      ApplicationSettingsSupergrid.IdentifyingColumn = OBJECT;
      ApplicationSettingsSupergrid.PrimaryGrid.MultiSelect = false;
      ApplicationSettingsSupergrid.DisplayNumberOfItems = true;
      ApplicationSettingsSupergrid.PrimaryGrid.DefaultRowHeight = 30;
      ApplicationSettingsSupergrid.PrimaryGrid.MouseEditMode = MouseEditMode.SingleClick;
      ApplicationSettingsSupergrid.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells;
    }
    #endregion

    private void ApplicationSettingsSupergridSelectionChanged(object sender, GridEventArgs e)
    {
      try
      {
        EnableDisableControls();
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }
  }
}
