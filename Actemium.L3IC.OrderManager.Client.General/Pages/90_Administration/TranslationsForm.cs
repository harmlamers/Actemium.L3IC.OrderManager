using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.Client.General.Helpers;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.Translations;
using Actemium.Translations.Business;
using Actemium.Translations.Objects;
using Actemium.UserManagement2;
using Actemium.Windows.Forms.DevComponents2.Controls;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.Pages._90_Administration
{
	public partial class TranslationsForm : BasePageForm
	{
		private const string CLASSNAME = nameof(TranslationsForm);
	  private const string OBJECT = nameof(ApplicationTranslation);

	  public bool IsRefreshing { get; private set; }
	  private readonly Dispatcher _guiThread = Dispatcher.CurrentDispatcher;

	  private DataTable _loadDataResult;

		public TranslationsForm()
		{
			InitializeComponent();

		  InitializeTranslations();
      
      Title = "Management - Translations";
			NavigationItem = NavigationItems.Translations;
			ACICategory = ACICategories.TRANSLATIONS;

		  CreateAndInitializeButtons();
		  ConfigureSuperGrid();
    }




    #region Grid Handling

	  public DataTable GetApplicationTranslationsDataTable()
	  {
	    try
	    {

	      var applicationTranslationsList =
	        new ApplicationTranslations().GetAll();
	      var applicationTranslationsDataTable = ApplicationTranslationsHelper.Instance.GetDataTable(applicationTranslationsList);

	      return applicationTranslationsDataTable;
	    }
	    catch (Exception ex)
	    {
	      Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
	      return null;
	    }
	  }

	
		#endregion

		#region ControlBase and Form Implementation
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
        if (IsRefreshing)
          return;

        TranslationsSupergrid.PrimaryGrid.Footer.Text = Translations.General.LoadingData;
        Task.Factory.StartNew(LoadDataTask).ContinueWith(OnContinuationFunction);
        TranslationsSupergrid.IdentifyingColumn = "ApplicationTranslation";
        
        TranslationsSupergrid.Reinitialize();
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private DataTable LoadDataTask()
    {
      try
      {
        IsRefreshing = true;

        TranslationsSupergrid.SuspendLayout();
        return GetApplicationTranslationsDataTable();
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
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
          TranslationsSupergrid.SuspendLayout();
          TranslationsSupergrid.PrimaryGrid.Footer.Text = " ";
          TranslationsSupergrid.RefreshData(_loadDataResult);
          TranslationsSupergrid.ResumeLayout(false);
          TranslationsSupergrid.PerformLayout();
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
      if (TranslationsSupergrid == null)
        return;

      var somethingSelected = TranslationsSupergrid.SelectedObjects?.Any() ?? false;
      TranslationsSupergrid.PrimaryGrid.AllowEdit = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
      TranslationsSupergrid.PrimaryGrid.ShowEditingImage = true;
      TranslationsSupergrid.CellValueChanged -= TranslationsSupergridCellValueChanged;
      TranslationsSupergrid.CellValueChanged += TranslationsSupergridCellValueChanged;
    }

    private void TranslationsSupergridCellValueChanged(object sender, GridCellValueChangedEventArgs e)
    {
      var row = (ApplicationTranslation)e.GridCell.GridRow.GetCell(OBJECT).Value;
      var gridTitle = (string)e.GridCell.GridColumn.DataPropertyName;
      var langId = int.Parse(gridTitle.Split('_')[1]);
      
      var translation = new ApplicationTranslations().GetByKeyAndLanguageId(row.Key, langId).Find(x=>x.SubKey.Equals(row.SubKey))
                        ?? new ApplicationTranslation(-1, row.Key, row.SubKey, langId, e.NewValue as string);

      if (langId != (int)Enums.Languages.en_GB && string.IsNullOrEmpty(e.NewValue as string))
      {
        new ApplicationTranslations().Delete(translation);
      }
      else if (translation.Id == -1)
      {
        new ApplicationTranslations().Add(translation);
      }
      else
      {
        translation.Value = e.NewValue as string;
        new ApplicationTranslations().Modify(translation);
      }
      //AddHistoryAction(TranslationKey.History_TranslationsForm_Modified, "Translation '{0}' '{1}' for '{2}' modified from {3} to {4} by user {5}.", row.Key, row.SubKey, Translations.Enums.TranslatedEnumDictionary[(Enums.Languages)langId], e.OldValue, row.Value, CurrentUser.User.Username);
      AddHistoryAction(TranslationKey.History_TranslationsForm_Modified, "Translation '{0}' '{1}' for '{2}' modified from {3} to {4} by user {5}.", row.Key, row.SubKey, (Enums.Languages)langId, e.OldValue, row.Value, CurrentUser.User.Username);
    }

    private RibbonBar ApplicationSettingsRibbonBar { get; }
    private DevComponents.DotNetBar.ButtonItem AddButtonItem { get; }
    private DevComponents.DotNetBar.ButtonItem ModifyButtonItem { get; }
    private ButtonItem ManageButtonItem { get; }

    private void CreateAndInitializeButtons()
    {
      try
      {
        TranslationsSupergrid.PrimaryGrid.MultiSelect = false;
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

    #endregion

	  #region Translations

	  private void InitializeTranslations()
	  {
	    Translations.Initialize();
	  }

    #endregion

	  #region Configure SuperGrid & SuperGrid functions
	  private void ConfigureSuperGrid()
	  {
	    TranslationsSupergrid.ApplyProjectDefaults();
	    TranslationsSupergrid.IdentifyingColumn = OBJECT;
	    TranslationsSupergrid.PrimaryGrid.MultiSelect = false;
	    TranslationsSupergrid.DisplayNumberOfItems = true;
	    TranslationsSupergrid.PrimaryGrid.DefaultRowHeight = 30;
	    TranslationsSupergrid.PrimaryGrid.MouseEditMode = MouseEditMode.SingleClick;
	    TranslationsSupergrid.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells;
	  }
	  #endregion

  }
}
