using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Business;
using Actemium.L3IC.OrderManager.Business.Enums;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.Client.General.Helpers;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.L3IC.OrderManager.Model;
using Actemium.Windows.Forms.DevComponents2.Controls;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.Pages
{
  public partial class OrdersPage : BasePageForm
  {
    private const string CLASSNAME = nameof(OrdersPage);
    private readonly string[] _predefinedPeriodFilter = { "Last day", "Last 3 days", "Last 7 days", "Last 100 days" }; // Values other then Last Day must contain numbers
    private const string START_FILTER = "Last 7 days";

    private readonly ErrorProvider _errorProvider;
    private readonly List<Resource> _resources = new Resources().GetAll();
    private List<CheckBoxX> _resourcesCheckboxes;
    private readonly List<Control> _filterControls = new List<Control>();
    public bool IsRefreshingOrdersSupergrid { get; private set; }
    public bool FilterActive { get; private set; }

    private readonly Dispatcher _guiThread = Dispatcher.CurrentDispatcher;
    private readonly string _orderGridObject = "Order";

    public OrdersPage(NavigationItems navigationItem)
    {
      InitializeComponent();

      _errorProvider = new ErrorProvider(components);

      NavigationItem = navigationItem;
      FilterActive = false;

      switch (NavigationItem)
      {
        case NavigationItems.ActualOrders:
          Name = "Actual Orders";
          Title = "Actual Orders";
          break;
        case NavigationItems.FinishedOrders:
          Name = "Finished Orders";
          Title = "Finished Orders";
          break;
      }

      CreateAndInitializeButtons();
      ConfigureOrdersSupergrid();

      ChangeFilterText();
      EnableDisableControls();
    }

    #region Buttons
    private void CreateAndInitializeButtons()
    {
      _resourcesCheckboxes = CreateResourceSelectionBoxes();

      ConfigureHistoryFilters();
      InitializeOrdersPredefinedFilterDropdownX();
      SetFromDateAndToDate(OrdersPredefinedFilterDropdownX.Text);
    }

    private void EnableDisableControls()
    {
      bool finishedOrders = false;

      if (NavigationItem == NavigationItems.FinishedOrders)
      {
        finishedOrders = true;
      }

      foreach (Control filterControl in _filterControls)
      {
        filterControl.Visible = finishedOrders;
      }


      EnableDisableStartStopButtons();
      OrdersStartStopOrderGroupBox.Visible = !finishedOrders;
      OrdersFilterResetButtonX.Enabled = FilterActive;
    }

    private void EnableDisableStartStopButtons()
    {
      var selectedOrders = OrdersSupergrid.SelectedObjects;

      if (NavigationItem == NavigationItems.ActualOrders)
      {
        if (selectedOrders.Count > 0)
        {
          foreach (Order order in selectedOrders)
          {
            if (order.StartDate is null)
            {
              OrdersStartOrderButtonX.Enabled = true;
              OrdersStopOrderButtonX.Enabled = false;
            }
            else
            {
              OrdersStartOrderButtonX.Enabled = false;
              OrdersStopOrderButtonX.Enabled = true;
            }
          }
        }
        else
        {
          OrdersStartOrderButtonX.Enabled = false;
          OrdersStopOrderButtonX.Enabled = false;
        }
      }
    }

    private List<CheckBoxX> CreateResourceSelectionBoxes()
    {
      List<CheckBoxX> addedCheckboxes = new List<CheckBoxX>();

      int startX = 12;
      const int startY = 12;
      const int height = 25;
      const int distance = 10;
      const int width = 100;
      const int checkboxSize = 20;

      foreach (Resource resource in _resources)
      {
        CheckBoxX checkBox = CreateResourceSelectionBox(startX, startY, width, height, checkboxSize, resource);
        addedCheckboxes.Add(checkBox);
        startX += width + distance;
      }

      return addedCheckboxes;
    }

    private CheckBoxX CreateResourceSelectionBox(int x, int y, int width, int height, int checkboxSize, Resource item)
    {
      CheckBoxX resourceCheckbox = new CheckBoxX();

      resourceCheckbox.Name = item.Code + "CheckBox";
      resourceCheckbox.Text = item.Description;
      resourceCheckbox.Checked = true;
      resourceCheckbox.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
      resourceCheckbox.Location = new System.Drawing.Point(x, y);
      resourceCheckbox.Size = new System.Drawing.Size(width, height);
      resourceCheckbox.CheckSignSize = new System.Drawing.Size(checkboxSize, checkboxSize);
      resourceCheckbox.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
      resourceCheckbox.TabIndex = 3;
      resourceCheckbox.Font = new System.Drawing.Font("Tahoma", 12F);
      resourceCheckbox.Translate = false;
      resourceCheckbox.CheckValueChanged += ResourceCheckBox_CheckChanged;

      OrdersSettingsGroupBox.Controls.Add(resourceCheckbox);

      return resourceCheckbox;
    }
    #endregion

    #region EventHandlers
    private void ResourceCheckBox_CheckChanged(object sender, EventArgs e)
    {
      if (sender is CheckBoxX)
      {
        Refresh();
      }
    }

    private void OrdersPredefinedFilterDropdownX_SelectedValueChanged(object sender, System.EventArgs e)
    {
      SetFromDateAndToDate(OrdersPredefinedFilterDropdownX.Text);
    }

    private void OrdersFilterResetButtonX_Click(object sender, EventArgs e)
    {
      ResetFilters();
      Refresh();
    }

    private void OrdersFilterApplyButtonX_Click(object sender, EventArgs e)
    {
      if (CheckTimeFields())
      {
        DateTime fromDate = OrdersFromDateFilterInput.Value;
        DateTime fromTime = DateTime.Parse(OrdersFromTimeFilterTextBox.Text);
        DateTime fromDateTime = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, fromTime.Hour, fromTime.Minute, fromTime.Second);

        DateTime toDate = OrdersToDateFilterInput.Value;
        DateTime toTime = DateTime.Parse(OrdersToTimeFilterTextBox.Text);
        DateTime toDateTime = new DateTime(toDate.Year, toDate.Month, toDate.Day, toTime.Hour, toTime.Minute, toTime.Second);

        if (DateTime.Compare(toDateTime, fromDateTime) >= 1)
        {
          FilterActive = true;
          OrdersFromDateFilterInput.Value = fromDateTime;
          OrdersToDateFilterInput.Value = toDateTime;

          ChangeFilterText();
          EnableDisableControls();
          Refresh();
        }
        else
        {
          _errorProvider.SetError(OrdersToTimeFilterTextBox, "Date is not after fromdate");
        }
      }
    }

    private void OrdersSupergrid_SelectionChanged(object sender, GridEventArgs e)
    {
      EnableDisableStartStopButtons();
    }

    private void OrdersStopOrderButtonX_Click(object sender, EventArgs e)
    {
      if (Confirm(TranslationKey.Confirm_Orders_Stop, "Stop order", "Are you sure to stop this order?", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        foreach (Order selectedOrder in OrdersSupergrid.SelectedObjects)
        {
          OrderStatus status = new Orders().StopOrder(selectedOrder);


          switch (status)
          {
            case OrderStatus.Stop_Before_Start:
              DisplayError("Stop failed", "First start order");
              break;
            case OrderStatus.Succes:
              Refresh();
              break;
          }
        }
      }
    }

    private void OrdersStartOrderButtonX_Click(object sender, EventArgs e)
    {
      if (Confirm(TranslationKey.Confirm_Orders_Start, "Start order", "Are you sure to start this order?", MessageBoxButtons.YesNo) == DialogResult.Yes)
      {
        foreach (Order selectedOrder in OrdersSupergrid.SelectedObjects)
        {
          OrderStatus status = new Orders().StartOrder(selectedOrder);

          switch (status)
          {
            case OrderStatus.Resource_in_use:
              DisplayError("Start failed", "Starting order failed:\r\nResource is in use");
              break;
            case OrderStatus.Succes:
              Refresh();
              break;
          }
        }
      }
    }
    #endregion

    public override void Refresh()
    {
      try
      {
        ShowBusyBox = true;

        ResetFilters();
        RefreshOrdersSupergrid();
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

    #region SuperGrid
    private void RefreshOrdersSupergrid()
    {
      try
      {
        if (IsRefreshingOrdersSupergrid)
        {
          return;
        }

        OrdersSupergrid.PrimaryGrid.Footer.Text = Translations.General.LoadingData;
        Task.Factory.StartNew(LoadOrdersDataTask).ContinueWith(OnLoadOrdersContinuationFunction);
        OrdersSupergrid.IdentifyingColumn = _orderGridObject;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void ConfigureOrdersSupergrid()
    {
      OrdersSupergrid.ApplyProjectDefaults();
      OrdersSupergrid.IdentifyingColumn = _orderGridObject;
      OrdersSupergrid.PrimaryGrid.MultiSelect = false;
      OrdersSupergrid.DisplayNumberOfItems = true;
      OrdersSupergrid.PrimaryGrid.DefaultRowHeight = 30;
      OrdersSupergrid.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells;
    }

    private DataTable LoadOrdersDataTask()
    {
      try
      {
        IsRefreshingOrdersSupergrid = true;

        OrdersSupergrid.SuspendLayout();

        switch (NavigationItem)
        {
          case NavigationItems.ActualOrders:
            return GetActualOrdersDataTable();
          case NavigationItems.FinishedOrders:
            return GetFinishedOrdersDataTable();
          default:
            return null;
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        return null;
      }
    }

    private void OnLoadOrdersContinuationFunction(Task<DataTable> t)
    {
      try
      {
        _guiThread.Invoke(() =>
        {
          OrdersSupergrid.RememberSelection();
          OrdersSupergrid.RestoreSelectionAfterRefresh();
          OrdersSupergrid.SuspendLayout();
          OrdersSupergrid.PrimaryGrid.Footer.Text = " ";
          OrdersSupergrid.RefreshData(t.Result);
          OrdersSupergrid.ResumeLayout(false);
          OrdersSupergrid.PerformLayout();
        });
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
      finally
      {
        IsRefreshingOrdersSupergrid = false;
      }
    }
    #endregion

    #region Datatables
    private DataTable GetActualOrdersDataTable()
    {
      List<Order> actualOrders = new Orders().GetAllActual();
      actualOrders = EvaluateResourceFilters(actualOrders);

      DataTable actualOrdersDatatable = ORHelper.Instance.GetActualOrdersDataTable(actualOrders);

      return actualOrdersDatatable;
    }

    private DataTable GetFinishedOrdersDataTable()
    {
      List<Order> finishedOrders = new Orders().GetAllHistory();
      finishedOrders = EvaluateResourceFilters(finishedOrders);
      finishedOrders = EvaluateDateTimeFilters(finishedOrders);

      DataTable finishedOrdersDatatable = ORHelper.Instance.GetFinishedOrdersDataTable(finishedOrders);

      return finishedOrdersDatatable;
    }

    private List<Order> EvaluateResourceFilters(List<Order> allOrders)
    {
      List<Order> filteredOrders = new List<Order>();

      foreach (Order order in allOrders)
      {
        foreach (var resourceCheckBox in _resourcesCheckboxes)
        {
          foreach (var resource in _resources)
          {
            if (order.ResourceId == resource.Id && resource.Description == resourceCheckBox.Text && resourceCheckBox.Checked)
            {
              filteredOrders.Add(order);
            }
          }
        }
      }

      return filteredOrders;
    }

    private List<Order> EvaluateDateTimeFilters(List<Order> allOrders)
    {
      List<Order> filteredOrders = new List<Order>();
      DateTime fromDateTime = OrdersFromDateFilterInput.Value;
      DateTime toDateTime = OrdersToDateFilterInput.Value;

      foreach (Order order in allOrders)
      {
        if (order.StartDate.HasValue)
        {
          DateTime startDate = order.StartDate.Value;

          if (DateTime.Compare(startDate, fromDateTime) >= 0 && DateTime.Compare(startDate, toDateTime) <= 0)
          {
            filteredOrders.Add(order);
          }
        }
      }

      return filteredOrders;
    }
    #endregion

    private void OrdersPageResize(object sender, EventArgs e)
    {
      PositionStartStopOrderButtons();
    }

    private void PositionStartStopOrderButtons()
    {
      const int DISTANCE = 12;
      const int Y = 16;
      int screenWidth = OrdersStartStopOrderGroupBox.Width;
      int startButtonWidth = OrdersStartOrderButtonX.Width;
      int stopButtonWidth = OrdersStopOrderButtonX.Width;

      int x = screenWidth - startButtonWidth - DISTANCE;
      OrdersStopOrderButtonX.Location = new System.Drawing.Point(x, Y);

      x = x - stopButtonWidth - DISTANCE;
      OrdersStartOrderButtonX.Location = new System.Drawing.Point(x, Y);
    }

    private void InitializeOrdersPredefinedFilterDropdownX()
    {
      foreach (string predefined in _predefinedPeriodFilter)
      {
        OrdersPredefinedFilterDropdownX.Items.Add(predefined);

        if (predefined == START_FILTER)
        {
          OrdersPredefinedFilterDropdownX.SelectedItem = predefined;
        }
      }

      OrdersPredefinedFilterDropdownX.SelectedValueChanged += OrdersPredefinedFilterDropdownX_SelectedValueChanged;
    }

    private void ConfigureHistoryFilters()
    {
      _filterControls.Add(OrdersToTimeFilterLabel);
      _filterControls.Add(OrdersFromTimeFilterLabel);
      _filterControls.Add(OrdersToTimeFilterTextBox);
      _filterControls.Add(OrdersFromTimeFilterTextBox);
      _filterControls.Add(OrdersToDateFilterInput);
      _filterControls.Add(OrdersFromDateFilterInput);
      _filterControls.Add(OrdersPredefinedFilterLabelX);
      _filterControls.Add(OrdersPredefinedFilterDropdownX);
      _filterControls.Add(OrdersFilterApplyButtonX);
      _filterControls.Add(OrdersFilterResetButtonX);
      _filterControls.Add(OrdersFromDateTimeFilterLabelX);
      _filterControls.Add(OrdersToDateTimeFilterLabelX);
      _filterControls.Add(OrdersActualFilterLabelX);

      OrdersFilterApplyButtonX.Click += OrdersFilterApplyButtonX_Click;
      OrdersFilterResetButtonX.Click += OrdersFilterResetButtonX_Click;
    }

    private void SetFromDateAndToDate(string filter = null)
    {
      string filtered = "";
      int daysMinusToday = 1;

      if (filter != null)
      {
        foreach (string predefinedFilter in _predefinedPeriodFilter)
        {
          if (filter == predefinedFilter)
          {
            filtered = string.Join("", filter.Where(char.IsDigit));
          }
        }
      }

      if (filtered != "")
      {
        daysMinusToday = int.Parse(filtered);
      }

      OrdersToDateFilterInput.Value = DateTime.Now;
      OrdersToTimeFilterTextBox.Text = OrdersToDateFilterInput.Value.ToString("HH:mm");

      OrdersFromDateFilterInput.Value = OrdersToDateFilterInput.Value.AddDays(-daysMinusToday);
      OrdersFromTimeFilterTextBox.Text = OrdersFromDateFilterInput.Value.ToString("HH:mm");
    }

    private void ChangeFilterText()
    {
      OrdersActualFilterLabelX.Text = $"Active period filter: Start {OrdersFromDateFilterInput.Value} to {OrdersFromDateFilterInput.Value}";
    }

    private bool CheckTimeFields()
    {
      _errorProvider.Clear();

      if (!DateTime.TryParse(OrdersFromTimeFilterTextBox.Text, out DateTime startTime))
      {
        _errorProvider.SetError(OrdersFromTimeFilterTextBox, "Invalid timeformat");
        return false;
      }

      if (!DateTime.TryParse(OrdersToTimeFilterTextBox.Text, out DateTime endTime))
      {
        _errorProvider.SetError(OrdersToTimeFilterTextBox, "Invalid timeformat");
        return false;
      }

      return true;
    }

    private void ResetFilters()
    {
      FilterActive = false;
      OrdersPredefinedFilterDropdownX.SelectedItem = null;

      foreach (string item in OrdersPredefinedFilterDropdownX.Items)
      {
        if (item == START_FILTER)
        {
          OrdersPredefinedFilterDropdownX.SelectedItem = item;
        }
      }

      ChangeFilterText();
      EnableDisableControls();
    }
  }
}
