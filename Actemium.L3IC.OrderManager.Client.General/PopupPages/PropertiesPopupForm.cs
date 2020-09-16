using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Helpers;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.UserManagement2;
using Actemium.UserManagement2.Business;
using Actemium.UserManagement2.Model;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
	public partial class PropertiesPopupForm : BasePopupForm
	{
		private const string CLASSNAME = nameof(PropertiesPopupForm);
	  private const string OBJECT = "PropertyValue";

    private readonly User _user;
		private readonly Group _group;
		private readonly Computer _computer;

	  private DataTable _loadDataResult;
	  private readonly Dispatcher _guiThread = Dispatcher.CurrentDispatcher;

    public bool IsRefreshing { get; private set; }


    private PropertiesPopupForm()
		{
			InitializeComponent();
		  InitializeTranslations();
		  ConfigureSuperGrid();
    }

		public PropertiesPopupForm(User user)
			: this()
		{
			_user = user;
			lblTitle.Text = string.Format(Translations.PropertiesPopupForm.TitleUser, _user.Username);
		  ACICategory = ACICategories.USERMANAGEMENT;
    }

		public PropertiesPopupForm(Group group)
			: this()
		{
			_group = group;
			lblTitle.Text = string.Format(Translations.PropertiesPopupForm.TitleGroup, _group.Name);
		  ACICategory = ACICategories.GROUPMANAGEMENT;
    }

		public PropertiesPopupForm(Computer computer)
			: this()
		{
			_computer = computer;
			lblTitle.Text = string.Format(Translations.PropertiesPopupForm.TitleComputer, _computer.HostName);
		  ACICategory = ACICategories.COMPUTERMANAGEMENT;
    }

	  public override void ActivateFromMain(EventArgs e)
	  {
	    try
	    {
	      base.ActivateFromMain(e);

	      if (!CurrentUser.HasPermission(ACICategory, ACIOptions.VIEW))
	      {
	        throw new SecurityException(CurrentUser.User.Username, Translations.General.NoAuthorisation);
	      }
	      Show();
	      Refresh();
	    }
	    catch (Exception ex)
	    {
	      Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
	      throw;
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
	    PropertiesSupergrid.ApplyProjectDefaults();
	    PropertiesSupergrid.IdentifyingColumn = OBJECT;
	    PropertiesSupergrid.PrimaryGrid.MultiSelect = false;
	    PropertiesSupergrid.DisplayNumberOfItems = true;
	    PropertiesSupergrid.PrimaryGrid.DefaultRowHeight = 30;
	    PropertiesSupergrid.PrimaryGrid.MouseEditMode = MouseEditMode.SingleClick;
	    PropertiesSupergrid.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells;
	  }
    #endregion

	  public DataTable GetPropertiesDataTable()
	  {
	    try
	    {
	      if (_user != null)
	      {
	        return UMPropertiesHelper.Instance.GetDataTable(new ViewUserPropertyValues().GetByUser(_user.Id).OrderBy(i => i.Name).ToList(), ACICategory);
	      }
	      if (_group != null)
	      {
	        return UMPropertiesHelper.Instance.GetDataTable(new ViewGroupPropertyValues().GetByGroup(_group.Id).OrderBy(i => i.Name).ToList(), ACICategory);
	      }
	      return _computer != null ? UMPropertiesHelper.Instance.GetDataTable(new ViewComputerPropertyValues().GetByComputer(_computer.Id).OrderBy(i => i.Name).ToList(), ACICategory) : null;
	    }
	    catch (Exception ex)
	    {
	      Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
	      return null;
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

	  private void RefreshGrid()
	  {

	    try
	    {
	      if (IsRefreshing)
          return;

        PropertiesSupergrid.PrimaryGrid.Footer.Text = Translations.General.LoadingData;
	      Task.Factory.StartNew(LoadDataTask).ContinueWith(OnContinuationFunction);
	      PropertiesSupergrid.IdentifyingColumn = OBJECT;
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

	      PropertiesSupergrid.SuspendLayout();

	      return GetPropertiesDataTable();
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
	                          PropertiesSupergrid.RememberSelection();
	                          PropertiesSupergrid.RestoreSelectionAfterRefresh();
	                          PropertiesSupergrid.SuspendLayout();
	                          PropertiesSupergrid.PrimaryGrid.Footer.Text = " ";
	                          PropertiesSupergrid.RefreshData(_loadDataResult);
	                          PropertiesSupergrid.ResumeLayout(false);
	                          PropertiesSupergrid.PerformLayout();
	                        });
	    }
	    catch (Exception ex)
	    {
	      Trace.WriteError("()", nameof(OnContinuationFunction), CLASSNAME, ex);
	    }
	    finally
	    {
	      IsRefreshing = false;
	    }
	  }

	  private void EnableDisableControls()
	  {
	    if (PropertiesSupergrid == null)
        return;

      var somethingSelected = PropertiesSupergrid.SelectedObjects?.Any() ?? false;
	    PropertiesSupergrid.PrimaryGrid.AllowEdit = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
	    PropertiesSupergrid.PrimaryGrid.ShowEditingImage = true;
	    PropertiesSupergrid.CellValueChanged -= PropertiesSupergridCellValueChanged;
      PropertiesSupergrid.CellValueChanged += PropertiesSupergridCellValueChanged;
	  }

	  private void PropertiesSupergridCellValueChanged(object sender, GridCellValueChangedEventArgs e)
	  {
	    try
	    {
	      if (_user != null)
	      {
	        var row = (ViewUserPropertyValue)e.GridCell.GridRow.GetCell(OBJECT).Value;
	        row.Value = (string)e.NewValue;
	        if (string.IsNullOrEmpty(row.Value) || row.Value.Equals(row.DefaultValue))
	        {
	          var property = new UserPropertyValues().GetById(row.PropertyId, _user.Id);
	          if (property != null)
	          {
	            new UserPropertyValues().Delete(property);
	          }
	        }
	        else
	        {
	          new UserPropertyValues().AddOrUpdate(new UserPropertyValue(row.PropertyId, _user.Id, row.Value));
	        }
	        AddHistoryAction(TranslationKey.History_PropertiesPopupForm_User_Modified, "User {0} changed user property {1} from {2} to {3} for user {4}", CurrentUser.User.Username, Translations.Enums.TranslatedEnumDictionary[(UserManagementProperties)row.PropertyId], e.OldValue, row.Value, _user.Username);
        }
	      else if (_group != null)
	      {
	        var row = (ViewGroupPropertyValue)e.GridCell.GridRow.GetCell(OBJECT).Value;
	        row.Value = (string)e.NewValue;
	        if (string.IsNullOrEmpty(row.Value) || row.Value.Equals(row.DefaultValue))
	        {
	          var property = new GroupPropertyValues().GetById(row.PropertyId, _group.Id);
	          if (property != null)
	          {
	            new GroupPropertyValues().Delete(property);
	          }
	        }
	        else
	        {
	          new GroupPropertyValues().AddOrUpdate(new GroupPropertyValue(row.PropertyId, _group.Id, row.Value));
	        }
	        AddHistoryAction(TranslationKey.History_PropertiesPopupForm_Group_Modified, "User {0} changed group property {1} from {2} to {3} for group {4}", CurrentUser.User.Username, Translations.Enums.TranslatedEnumDictionary[(UserManagementProperties)row.PropertyId], e.OldValue, row.Value, _group.Name);
        }
	      else if (_computer != null)
	      {
	        var row = (ViewComputerPropertyValue)e.GridCell.GridRow.GetCell(OBJECT).Value;
	        row.Value = (string)e.NewValue;
	        if (string.IsNullOrEmpty(row.Value) || row.Value.Equals(row.DefaultValue))
	        {
	          var property = new ComputerPropertyValues().GetById(row.PropertyId, _computer.Id);
	          if (property != null)
	          {
	            new ComputerPropertyValues().Delete(property);
	          }
	        }
	        else
	        {
	          new ComputerPropertyValues().AddOrUpdate(new ComputerPropertyValue(row.PropertyId, _computer.Id, row.Value));
	        }
	        AddHistoryAction(TranslationKey.History_PropertiesPopupForm_Computer_Modified, "User {0} changed computer property {1} from {2} to {3} for computer {4}", CurrentUser.User.Username, Translations.Enums.TranslatedEnumDictionary[(UserManagementProperties)row.PropertyId], e.OldValue, row.Value, _computer.HostName);
        }
	    }
	    catch (Exception ex)
	    {
	      Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
	      DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
	    }
	    finally
	    {
	      Refresh();
	    }
    }

    private void PropertiesPopupFormActivated(object sender, EventArgs e)
    {
      ActivateFromMain(e);
    }

    private void PropertiesPopupFormFormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
    {
      DeActivateFromMain();
    }
  }
}
