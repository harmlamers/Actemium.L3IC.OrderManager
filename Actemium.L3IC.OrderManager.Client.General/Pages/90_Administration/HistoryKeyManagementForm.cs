using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Base.PropertyGrids;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.Client.General.Helpers;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.History.Business;
using Actemium.History.Model;
using Actemium.Translations;
using Actemium.UserManagement2;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.Pages._90_Administration
{
  public partial class HistoryKeyManagementForm : BasePageForm
  {

    private readonly string _classname;
    private const string OBJECT = nameof(HistoryKey);
    public bool IsRefreshing { get; private set; }
    private readonly List<PropertyGridElement> _lastGivenPropertyGridElementList = new List<PropertyGridElement>();
    private readonly Dispatcher _guiThread = Dispatcher.CurrentDispatcher;

    private DataTable _loadDataResult;

    public HistoryKeyManagementForm(NavigationItems navi)
      : base()
    {
      try
      {
        _classname = GetType().Name;
        InitializeComponent();
        NavigationItem = navi;

        InitializeTranslations();

        Title = "History Key Management";
        ACICategory = ACICategories.HISTORYKEYMANAGEMENT;

        CreateAndInitializeButtons();
        ConfigureSuperGrid();

      }
      catch (Exception ex)
      {
        string name = Trace.GetMethodName();
        Trace.WriteError("()", name, _classname, ex);
        DisplayError(name, ex.Message);
      }
    }

    public DataTable GetHistoryKeyDataTable()
    {
      try
      {
        
        var historyKeysList =
          HistoryKeys.Instance.GetAll().OrderBy(x=>x.HistoryKey)
            .ToList();
        var historyKeyDataTable = HistoryHelper.Instance.GetDataTable(historyKeysList);

        return historyKeyDataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), _classname, ex);
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
        Trace.WriteError("()", Trace.GetMethodName(), _classname, ex);
        throw;
      }
    }

    private void RefreshGrid()
    {

      try
      {
        if (IsRefreshing)
          return;

        HistoryKeysSupergrid.PrimaryGrid.Footer.Text = Translations.General.LoadingData;
        Task.Factory.StartNew(LoadDataTask).ContinueWith(OnContinuationFunction);
        HistoryKeysSupergrid.IdentifyingColumn = "HistoryKey";
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), _classname, ex);
      }
    }

    private DataTable LoadDataTask()
    {
      try
      {
        IsRefreshing = true;

        HistoryKeysSupergrid.SuspendLayout();
        return GetHistoryKeyDataTable();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), _classname, ex);
        return null;
      }
    }

    private void OnContinuationFunction(Task<DataTable> t)
    {
      try
      {
        _guiThread.Invoke(() =>
        {
          _loadDataResult = t.Result;

          _loadDataResult = t.Result;
          HistoryKeysSupergrid.SuspendLayout();
          HistoryKeysSupergrid.PrimaryGrid.Footer.Text = " ";
          HistoryKeysSupergrid.RefreshData(_loadDataResult);
          HistoryKeysSupergrid.ResumeLayout(false);
          HistoryKeysSupergrid.PerformLayout();

        });
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), _classname, ex);
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
        Trace.WriteError("()", Trace.GetMethodName(), _classname, ex);
        throw;
      }
      finally
      {
        ShowBusyBox = false;
      }
    }

    private void EnableDisableControls()
    {
      if (HistoryKeysSupergrid == null)
        return;

      HistoryKeysSupergrid.PrimaryGrid.AllowEdit = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
      HistoryKeysSupergrid.PrimaryGrid.ShowEditingImage = true;
      HistoryKeysSupergrid.CellValueChanged -= HistoryKeysSupergridCellValueChanged;
      HistoryKeysSupergrid.SelectionChanged -= HistoryKeysSupergridSelectionChanged;
      HistoryKeysSupergrid.CellValueChanged += HistoryKeysSupergridCellValueChanged;
      HistoryKeysSupergrid.SelectionChanged += HistoryKeysSupergridSelectionChanged;
    }

    
    private DateTime _lastChange = DateTime.MinValue;

    private void HistoryKeysSupergridCellValueChanged(object sender, GridCellValueChangedEventArgs e)
    {
      if (_lastChange > DateTime.Now.AddSeconds(-1))
        return;

      _lastChange = DateTime.Now;
      var row = (HistoryKey)e.GridCell.GridRow.GetCell(OBJECT).Value;
      if (!CurrentUser.HasPermission(
        ACICategories.HISTORYKEYMANAGEMENT,
        ACIOptions.MODIFY))
      {
        DisplayError(TranslationKey.Error_HistoryKeyManagement_InsufficientRights, "Insufficient Rights", "You don't have the right to edit a history key");
        RefreshGrid();
        return;
      }

      if (e.GridCell.GridColumn.Name.Equals("TraceLevel"))
      {
        row.TraceLevelValue = (System.Diagnostics.SourceLevels)e.NewValue;
        HistoryKeys.Instance.Modify(row);
        AddHistoryAction(TranslationKey.History_HistoryKeyAdministrationForm_ModifiedTraceLevel, "User {0} changed option Trace Level on {1} from {2} to {3}", CurrentUser.User.Username, row.HistoryKey, (System.Diagnostics.SourceLevels)e.OldValue, row.TraceLevel);
      }
      else if (e.GridCell.GridColumn.Name.Equals("ShowInClient"))
      {
        row.ShowInClient = (bool)e.NewValue;
        HistoryKeys.Instance.Modify(row);
        AddHistoryAction(TranslationKey.History_HistoryKeyAdministrationForm_ModifiedShowInClient, "User {0} changed option Show in Client on {1} from {2} to {3}", CurrentUser.User.Username, row.HistoryKey, e.OldValue, row.ShowInClient);
      }
      else if (e.GridCell.GridColumn.Name.Equals("SaveInDatabase"))
      {
        row.SaveInDatabase = (bool)e.NewValue;
        HistoryKeys.Instance.Modify(row);
        AddHistoryAction(TranslationKey.History_HistoryKeyAdministrationForm_ModifiedSaveInDatabase, "User {0} changed option Save in Database on {1} from {2} to {3}", CurrentUser.User.Username, row.HistoryKey, e.OldValue, row.SaveInDatabase);
      }
    }

    private void CreateAndInitializeButtons()
    {
      try
      {
        HistoryKeysSupergrid.PrimaryGrid.MultiSelect = false;
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), _classname, ex);
      }
    }

    private void AddButtonRibbonBars()
    {
      try
      {
        
      }
      catch (Exception ex)
      {
        var name = Trace.GetMethodName();
        Trace.WriteError("", name, _classname, ex);
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
        Trace.WriteError("()", Trace.GetMethodName(), _classname, ex);
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
      HistoryKeysSupergrid.ApplyProjectDefaults();
      HistoryKeysSupergrid.IdentifyingColumn = OBJECT;
      HistoryKeysSupergrid.PrimaryGrid.MultiSelect = false;
      HistoryKeysSupergrid.DisplayNumberOfItems = true;
      HistoryKeysSupergrid.PrimaryGrid.DefaultRowHeight = 30;
      HistoryKeysSupergrid.PrimaryGrid.MouseEditMode = MouseEditMode.SingleClick;
      HistoryKeysSupergrid.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells;
    }
    #endregion

    private void HistoryKeysSupergridSelectionChanged(object sender, GridEventArgs e)
    {
      try
      {
        EnableDisableControls();
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), _classname, ex);
      }
    }
  }
}
