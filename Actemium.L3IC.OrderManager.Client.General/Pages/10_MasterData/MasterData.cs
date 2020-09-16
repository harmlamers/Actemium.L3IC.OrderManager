using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Business;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Base.PropertyGrids;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.Client.General.Helpers;
using Actemium.L3IC.OrderManager.Client.General.PopupPages;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.L3IC.OrderManager.Model;
using Actemium.Windows.Forms.DevComponents2.Controls;
using Actemium.Windows.Forms.MenuGenerator;
using DevComponents.DotNetBar.SuperGrid;


namespace Actemium.L3IC.OrderManager.Client.General.Pages._10_MasterData
{
  public partial class MasterData : BasePageForm
  {
    private const string CLASSNAME = nameof(MasterData);

    public bool IsRefreshingTopGrid { get; private set; }
    public bool IsRefreshingPropertyGrid { get; private set; }
    private List<PropertyGridElement> _lastGivenTopPropertyGridElementList = new List<PropertyGridElement>();
    private readonly Dispatcher _guiThread = Dispatcher.CurrentDispatcher;
    private readonly string _topGridObject = "";

    private RibbonBar MaterialsRibbonBar { get; set; }

    private ButtonItem AddButtonItem { get; set; }
    private ButtonItem ModifyButtonItem { get; set; }
    private ButtonItem DeleteButtonItem { get; set; }
    private ButtonItem PropertiesButtonItem { get; set; }

    public MasterData()
    {
      InitializeComponent();

      NavigationItem = NavigationItems.MasterData;

      Title = "Material Management";
      Name = "Material Management";
      ACICategory = ACICategories.GENERAL;
      _topGridObject = "Material";

      CreateAndInitializeButtons();
      ConfigureSuperGrid();
    }
    #region Buttons and Ribbon
    private void CreateAndInitializeButtons()
    {
      try
      {
        var addImage = Properties.Resources.IE_UserAdd_24;
        var modifyImage = Properties.Resources.IE_UserModify_24;
        var deleteImage = Properties.Resources.IE_UserDelete_24;
        var propertiesImage = Properties.Resources.IE_UserProperties_24;
        var memberShipImage = Properties.Resources.IE_GroupManagement_24;
        var activateImage = Properties.Resources.IE_UserActivate_24;
        var deactivateImage = Properties.Resources.IE_UserDeactivate_24;

        // Add ButtonItem
        AddButtonItem = MenuGenerator.CreateButtonItem(addImage, nameof(AddButtonItem), "Add", false, null, true);
        ModifyButtonItem = MenuGenerator.CreateButtonItem(modifyImage, nameof(ModifyButtonItem), "Modify", false, null, true);
        DeleteButtonItem = MenuGenerator.CreateButtonItem(deleteImage, nameof(DeleteButtonItem), "Delete", false, null, true);
        PropertiesButtonItem = MenuGenerator.CreateButtonItem(propertiesImage, nameof(PropertiesButtonItem), "Properties", false, null, true);

        AddButtonItem.Click += ButtonItemClick;
        ModifyButtonItem.Click += ButtonItemClick;
        DeleteButtonItem.Click += ButtonItemClick;
        PropertiesButtonItem.Click += ButtonItemClick;

        AddButtonItem.Visible = true;
        ModifyButtonItem.Visible = true;
        DeleteButtonItem.Visible = true;
        PropertiesButtonItem.Visible = true;

        EnableDisableButtons();

        // Add RibbonBar
        var baseItems = new DevComponents.DotNetBar.BaseItem[]{
                    AddButtonItem,
                    ModifyButtonItem,
                    DeleteButtonItem,
                    PropertiesButtonItem
                };

        MaterialsRibbonBar = MenuGenerator.CreateRibbonBar(baseItems, nameof(MaterialsRibbonBar), Translations.General.Manage);
      }
      catch (Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void EnableDisableButtons()
    {
      int selectedObjects = topSupergrid.SelectedObjects.Count;
      AddButtonItem.Enabled = true;

      if (selectedObjects > 0)
      {
        DeleteButtonItem.Enabled = true;
        PropertiesButtonItem.Enabled = true;
        if (selectedObjects > 1)
        {
          ModifyButtonItem.Enabled = false;
        }
        else
        {
          ModifyButtonItem.Enabled = true;
        }
      }
      else
      {
        ModifyButtonItem.Enabled = false;
        DeleteButtonItem.Enabled = false;
        PropertiesButtonItem.Enabled = false;
      }
    }

    private void ButtonItemClick(object sender, EventArgs e)
    {
      ButtonItem buttonItem = (ButtonItem)sender;

      switch (buttonItem.Name)
      {
        case "AddButtonItem":
          AddClicked();
          break;
        case "ModifyButtonItem":
          ModifyClicked();
          break;
        case "DeleteButtonItem":
          DeleteClicked();
          break;
        case "PropertiesButtonItem":
          PropertiesClicked();
          break;
      }
    }

    public override void ActivateFromMain(EventArgs e)
    {
      base.ActivateFromMain(e);
      AddButtonsRibbonBars();
      Refresh();
    }

    public void AddButtonsRibbonBars()
    {
      try
      {
        RibbonBars.Add(new Tuple<string, RibbonBar>("tiMasterData", MaterialsRibbonBar));
      }
      catch (Exception ex)
      {
        var name = Trace.GetMethodName();
        Trace.WriteError("", name, CLASSNAME, ex);
      }
    }
    #endregion

    #region Grids
    private void ConfigureSuperGrid()
    {
      topSupergrid.ApplyProjectDefaults();
      topSupergrid.IdentifyingColumn = _topGridObject;
      topSupergrid.PrimaryGrid.MultiSelect = false;
      topSupergrid.DisplayNumberOfItems = true;
      topSupergrid.PrimaryGrid.DefaultRowHeight = 30;
      topSupergrid.PrimaryGrid.ColumnAutoSizeMode = ColumnAutoSizeMode.AllCells;
    }

    public void UpdateTopPropertyGrid(List<PropertyGridElement> propertyGridElementList)
    {
      try
      {
        _lastGivenTopPropertyGridElementList = propertyGridElementList;

        Task.Factory.StartNew(InitializeTopPropertyGridElements)
          .ContinueWith(ApplyTopPropertyGridElements);
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void InitializeTopPropertyGridElements()
    {
      try
      {
        foreach (PropertyGridElement element in _lastGivenTopPropertyGridElementList)
        {
          element.Initialize();
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void ApplyTopPropertyGridElements(Task t)
    {
      try
      {
        _guiThread.Invoke(() =>
        {
          topPropertyGrid.Item.Clear();
          foreach (PropertyGridElement element in _lastGivenTopPropertyGridElementList)
          {
            string sValue = "";
            if (element.Value != null)
            {
              sValue = element.Value;
            }
            topPropertyGrid.Item.Add(element.Name, element.Value, true, element.Category, sValue, true);
          }
          topPropertyGrid.Refresh();
        });
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private void RefreshTopGrid()
    {
      try
      {
        if (IsRefreshingTopGrid)
          return;

        topSupergrid.PrimaryGrid.Footer.Text = Translations.General.LoadingData;
        Task.Factory.StartNew(LoadTopDataTask).ContinueWith(OnTopContinuationFunction);
        topSupergrid.IdentifyingColumn = _topGridObject;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
    }

    private DataTable LoadTopDataTask()
    {
      try
      {
        IsRefreshingTopGrid = true;

        topSupergrid.SuspendLayout();

        switch (NavigationItem)
        {
          case NavigationItems.MasterData:
            return GetMaterialsDataTable();
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

    private void OnTopContinuationFunction(Task<DataTable> t)
    {
      try
      {
        _guiThread.Invoke(() =>
        {
          topSupergrid.RememberSelection();
          topSupergrid.RestoreSelectionAfterRefresh();
          topSupergrid.SuspendLayout();
          topSupergrid.PrimaryGrid.Footer.Text = " ";
          topSupergrid.RefreshData(t.Result);
          topSupergrid.ResumeLayout(false);
          topSupergrid.PerformLayout();
        });
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }
      finally
      {
        IsRefreshingTopGrid = false;
      }
    }
    #endregion

    private void TopSupergridSelectionChanged(object sender, DevComponents.DotNetBar.SuperGrid.GridEventArgs e)
    {
      List<PropertyGridElement> propertyList = new List<PropertyGridElement>();

      try
      {
        foreach (var row in topSupergrid.SelectedObjects)
        {
          propertyList.AddRange(new MDHelper().CreatePropertyGridElements((Material)row));
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
      }

      EnableDisableButtons();
      UpdateTopPropertyGrid(propertyList);
    }

    #region Datatables
    public DataTable GetMaterialsDataTable()
    {
      try
      {
        var materialsList = new Materials().GetAll();
        var materialsDataTable = MDHelper.Instance.GetDataTable(materialsList);

        return materialsDataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        return null;
      }
    }
    #endregion

    private void AddClicked()
    {
      AddModifyScreen(null as Material);
    }

    private void ModifyClicked()
    {
      foreach (Material selectedMaterial in topSupergrid.SelectedObjects)
      {
        AddModifyScreen(selectedMaterial);
        return;
      }

      AddModifyScreen(null as Material);
    }

    private void DeleteClicked()
    {
      foreach (Material selectedMaterial in topSupergrid.SelectedObjects)
      {
        bool inBomItems = CheckMaterialInBomItems(selectedMaterial);
        bool inOrders = CheckMaterialInOrders(selectedMaterial);

        if (!inBomItems && !inOrders)
        {
          if (Confirm(TranslationKey.Confirm_Material_Delete, "Delete Material",
              "Are you sure to delete this material?", MessageBoxButtons.YesNo) == DialogResult.Yes)
          {
            new MDHelper().DeleteMaterialParameterValues(selectedMaterial);
            new Materials().Delete(selectedMaterial);
          }

        }
        else
        {
          DisplayError(TranslationKey.Confirm_Material_DeleteFailed, "Delete failed", "Deleting from material failed. Item is in an excisting order");
        }
      }

      Refresh();
    }

    private void PropertiesClicked()
    {
      foreach (Material selectedMaterial in topSupergrid.SelectedObjects)
      {
        PropertiesScreen(selectedMaterial);
        return;
      }
    }

    private void AddModifyScreen(Material material)
    {
      try
      {
        Material selectedItem = material;
        using (var popupForm = new MDAddModifyPopupForm(material))
        {
          var result = popupForm.ShowDialog(this);
          if (result != DialogResult.OK)
            return;

          ShowBusyBox = true;

          Material materialResult = popupForm.MaterialResult;
          bool add = selectedItem == null;
          bool modify = !add;

          if (materialResult == null)
          {
            return;
          }

          if (modify && (Confirm(TranslationKey.Confirm_Material_Modify, "Modify Material",
              "Are you sure to modify this material?", MessageBoxButtons.YesNo) == DialogResult.Yes))
          {
            new Materials().Modify(materialResult);
          }
          else if (add)
          {
            new Materials().Add(materialResult);
          }
        }
      }
      catch (Exception ex)
      {

        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
        ShowBusyBox = false;
      }
      finally
      {
        Refresh();
        ShowBusyBox = false;
      }
    }

    private void PropertiesScreen(Material material)
    {
      try
      {
        Material selectedItem = material;
        using (var popupForm = new MDPropertiesPopupForm(material))
        {
          var result = popupForm.ShowDialog(this);
          if (result != DialogResult.OK)
            return;
        }
      }
      catch (Exception ex)
      {

        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
        ShowBusyBox = false;
      }
      finally
      {
        Refresh();
        ShowBusyBox = false;
      }
    }

    private bool CheckMaterialInBomItems(Material material)
    {
      List<BomItem> items = new BomItems().GetByMaterialId(material.Id);

      return items.Count != 0;
    }

    private bool CheckMaterialInOrders(Material material)
    {
      var orders = new Orders().GetByMaterialId(material.Id);

      return orders.Count != 0;
    }

    public override bool DeActivateAllowed()
    {
      return true;
    }

    public override void DeActivateFromMain()
    {
      try
      {
        base.DeActivateFromMain();

      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public override void Refresh()
    {
      try
      {
        ShowBusyBox = true;

        UpdateTopPropertyGrid(_lastGivenTopPropertyGridElementList);
        RefreshTopGrid();
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

    private void MasterDataResize(object sender, EventArgs e)
    {

    }
  }
}
