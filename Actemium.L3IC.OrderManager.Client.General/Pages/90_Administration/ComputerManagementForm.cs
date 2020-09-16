using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.Client.General.PopupPages;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.Translations;
using Actemium.UserManagement2;
using Actemium.UserManagement2.Business;
using Actemium.UserManagement2.Model;
using Actemium.Windows.Forms.DevComponents2;
using Actemium.Windows.Forms.DevComponents2.Controls;

namespace Actemium.L3IC.OrderManager.Client.General.Pages._90_Administration
{
	public partial class ComputerManagementForm : BasePageForm
	{
		private const string CLASSNAME = nameof(ComputerManagementForm);

		public class AccessControlItemCategory
		{
			public AccessControlItemCategory(String category, Int32 userGroupId, Int32 totalACI, Int32 grantedACI)
			{
				Category = category;
				UserGroupId = userGroupId;
				TotalACI = totalACI;
				GrantedACI = grantedACI;
			}

			public string Category { get; set; }
			public int UserGroupId { get; set; }
			public int TotalACI { get; set; }
			public int GrantedACI { get; set; }
			public string DisplayGranted => $"{GrantedACI.ToString()}/{TotalACI.ToString()}";
		}

		public class AccessControlItemHelper : AccessControlItem
		{
			public AccessControlItemHelper(int id, string category, string action, bool granted)
				: base(id, category, action)
			{
				Granted = granted;
			}

			public bool Granted { get; set; }
		}

		private Boolean _add;
		private Boolean _modify;
		private Boolean _refreshingGroups;
		private Boolean _refreshingCategories;

		public List<AccessControlItem> ACIItems
		{
			get
			{
				if (CurrentUser.User == null)
          return null;

        return _aciItems ?? (_aciItems = new AccessControlItems().GetAll());
			}
		} private List<AccessControlItem> _aciItems;

		public List<ComputerAccessControlList> ComputerACIList
		{
			get
			{
				if (CurrentUser.User == null)
          return null;

        return _computerACIList ?? (_computerACIList = new ComputerAccessControlLists().GetAll());
			}
		} private List<ComputerAccessControlList> _computerACIList;


		public ComputerManagementForm()
		{
			InitializeComponent();

			Title = "User Management - Computers";
			NavigationItem = NavigationItems.ComputerManagement;
			ACICategory = ACICategories.COMPUTERMANAGEMENT;
		}

		private void SetChangeSettings()
		{
			try
			{
				if (!_add)
					UpdateEntryFields();

				EnableDisableButtons(!(_add || _modify));
				EnableDisableEntryFields();

				btnOK.Enabled = (_add || _modify);
				btnCancel.Enabled = (_add || _modify);
				dgvComputers.Enabled = !(_add || _modify);
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}


		#region Computer Handling (Upper Grid)
		#region EntryField handling
		private void EnableDisableEntryFields()
		{
			try
			{
				errorProvider.Clear();

				tbHostName.Enabled = (_add || _modify);
				tbDescription.Enabled = (_add || _modify);
				ckbACIManaged.Enabled = (_add || _modify);

				btnCancel.Enabled = (_add || _modify);
				btnOK.Enabled = (_add || _modify);
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}

		private void ClearEntryFields()
		{
			try
			{
				errorProvider.Clear();

				tbHostName.Clear();
				tbDescription.Clear();
				ckbACIManaged.Checked = false;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}

		private void UpdateEntryFields()
		{
			try
			{
				var selectedGroup = GetSelectedComputer();

				errorProvider.Clear();

        if (selectedGroup != null)
        {
          tbHostName.Text = selectedGroup.HostName;
          tbDescription.Text = selectedGroup.Description;
          ckbACIManaged.Checked = selectedGroup.ACIManaged;
        }
        else
        {
          ClearEntryFields();
        }
      }
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}
		#endregion

		#region Grid Handling
		private Computer GetSelectedComputer()
		{
			try
			{
				if ((dgvComputers.SelectedRows.Count > 0) && (dgvComputers.CurrentRow != null))
					return (Computer)dgvComputers.SelectedRows[0].DataBoundItem;

				return null;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}

		private void RefreshComputersGrid(Computer selectedItem)
		{
			bool foundSelection = false;

			try
			{
				#region General setup
				Application.DoEvents();
				dgvComputers.SuspendLayout();
				_refreshingGroups = true;
				#endregion

				#region Datasource/Action handling
				var dataSourceList = new Computers().GetAll();
				#endregion

				#region Datagrid filling and generation
				dgvComputers.DataSource = null; //Allways clear datasource before rebinding. The gridview cannot handle rebinding to a datasource with less items
			  if (dataSourceList.Count <= 0)
          return;

        dgvComputers.DataSource = new SortableBindingList<Computer>(dataSourceList);

			  if (dgvComputers.SortedColumn == null)
			    dgvComputers.Sort(dgvComputers.Columns[0], ListSortDirection.Ascending);


			  for (int i = 0; i < dgvComputers.Rows.Count; i++)
			  {
			    var dataBoundItem = (Computer)dgvComputers.Rows[i].DataBoundItem;

			    if ((selectedItem != null) && (dataBoundItem.Id == selectedItem.Id))
			    {
			      dgvComputers.Rows[i].Selected = true;
			      foundSelection = true;
			    }
			  }

			  #endregion
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
			finally
			{
				if (selectedItem == null || !foundSelection)
					dgvComputers.ClearSelection();

				SetChangeSettings();

				dgvComputers.ResumeLayout();
				_refreshingGroups = false;

				RefreshACICategoriesGrid(GetSelectedACICategory());
			}
		}

		private void DgvComputersSelectionChanged(object sender, EventArgs e)
		{
		  if (_refreshingGroups)
        return;

      try
		  {
		    SetChangeSettings();

		    RefreshACICategoriesGrid(GetSelectedACICategory());
		  }
		  catch (Exception ex)
		  {
		    Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);

		  }
		}
		#endregion

		#region Button Handling
		private void BtnAddClick(object sender, EventArgs e)
		{
			var triggerButton = (ButtonX)sender;
			Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

			EnableDisableButtons(true);
			if (!triggerButton.Enabled)
			{
				Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
				DisplayWarning(TranslationKey.CommonMessage_JustModified);
				return;
			}

			try
			{
				_add = true;

				ClearEntryFields();
				SetChangeSettings();
			}
			catch (Exception ex)
			{
				
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
		}

		private void BtnModifyClick(object sender, EventArgs e)
		{
			var triggerButton = (ButtonX)sender;
			Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

			EnableDisableButtons(true);
			if (!triggerButton.Enabled)
			{
				Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
				DisplayWarning(TranslationKey.CommonMessage_JustModified);
				return;
			}

			try
			{
				if ((dgvComputers.SelectedRows.Count == 1) && (dgvComputers.CurrentRow != null))
				{
					_modify = true;
					SetChangeSettings();
				}
			}
			catch (Exception ex)
			{
				var methodName = Trace.GetMethodName();
				Trace.WriteError("()", methodName, CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
		}

		private void BtnDeleteClick(object sender, EventArgs e)
		{
			var triggerButton = (ButtonX)sender;
			Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

			EnableDisableButtons(true);
			if (!triggerButton.Enabled)
			{
				Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
				DisplayWarning(TranslationKey.CommonMessage_JustModified);
				return;
			}

			ShowBusyBox = true;
			var selectedItem = GetSelectedComputer();

			try
			{
				if (selectedItem != null)
				{
					if (Confirm(TranslationKey.Confirm_Computer_Delete, "Delete Computer", "Are you sure to delete this computer included the authorization items?", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						ShowBusyBox = true;
						AddHistoryAction(TranslationKey.History_ComputerManagementForm_Deleted, "Computer '{0}' deleted.", selectedItem.HostName);
						Trace.WriteInformation("Computer: HostName={0}, Description={1}", Trace.GetMethodName(), CLASSNAME, selectedItem.HostName, selectedItem.Description);
						new Computers().Delete(selectedItem);
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
				_computerACIList = null;
				SetChangeSettings();
				RefreshComputersGrid(selectedItem);
				ShowBusyBox = false;
			}
		}

		private void BtnCancelClick(object sender, EventArgs e)
		{
			_add = false;
			_modify = false;

			SetChangeSettings();
		}

		private void BtnOKClick(object sender, EventArgs e)
		{
			var triggerButton = (ButtonX)sender;
			Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

			EnableDisableButtons(true);
			if (!triggerButton.Enabled)
			{
				Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
				DisplayWarning(TranslationKey.CommonMessage_JustModified);
				return;
			}

			try
			{
				ShowBusyBox = true;

				var modifiedComputer = CheckConstraints();

			  if (modifiedComputer == null)
          return;

        if (_modify && (Confirm(TranslationKey.Confirm_Computer_Modify, "Modify Computer", "Are you sure to modify this user computer?", MessageBoxButtons.YesNo) == DialogResult.Yes))
			  {
			    new Computers().Modify(modifiedComputer);
			    AddHistoryAction(TranslationKey.History_ComputerManagementForm_Modified, "Computer '{0}' modified.", modifiedComputer.HostName);
			    Trace.WriteInformation("Computer modified: HostName={0}", Trace.GetMethodName(), CLASSNAME, modifiedComputer.HostName);
			  }
			  else if (_add)
			  {
			    new Computers().Add(modifiedComputer);
			    modifiedComputer = new Computers().GetByHostName(modifiedComputer.HostName);
			    AddHistoryAction(TranslationKey.History_ComputerManagementForm_Added, "Computer '{0}' added.", modifiedComputer.HostName);
			    Trace.WriteInformation("Computer added: hostName={0}", Trace.GetMethodName(), CLASSNAME, modifiedComputer.HostName);
			  }

			  _add = false;
			  _modify = false;

			  _computerACIList = null;
			  RefreshComputersGrid(modifiedComputer);
			  SetChangeSettings();
			}
			catch (Exception ex)
			{
				
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
			finally
			{
				ShowBusyBox = false;
			}
		}


		private void EnableDisableButtons(bool enable)
		{
			try
			{
				btnAdd.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);

				var selectedComputer = GetSelectedComputer();

				enable = (enable && selectedComputer != null);

				btnModify.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY) && enable;
				btnDelete.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY) && enable;

				btnProperties.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY) && enable;

				btnDeSelectAll.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
				btnSelectAll.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY);
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}

		private Computer CheckConstraints()
		{
			try
			{
				var result = _modify ? GetSelectedComputer() : new Computer();

				Boolean hasError = false;
				errorProvider.Clear();

        if (tbHostName.Text.Length <= 0 || tbHostName.Text.Length > 50)
        {
          hasError = true;
          errorProvider.SetError(tbHostName, "Field required...");
        }
        else
        {
          result.HostName = tbHostName.Text;
        }

        if (tbDescription.Text.Length <= 0 || tbDescription.Text.Length > 255)
        {
          hasError = true;
          errorProvider.SetError(tbDescription, "Field required...");
        }
        else
        {
          result.Description = tbDescription.Text;
        }

        result.ACIManaged = ckbACIManaged.Checked;

				if (result.HostName != null && new Computers().GetAll().Find(g => g.Id != result.Id && String.Equals(g.HostName, result.HostName, StringComparison.InvariantCultureIgnoreCase)) != null)
				{
					hasError = true;
					errorProvider.SetError(tbHostName, "Host name must be unique...");
				}

				return hasError ? null : result;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}
		#endregion
		#endregion

		#region ACICategory Handling (Lower Left Grid)
		#region Grid Handling
		private AccessControlItemCategory GetSelectedACICategory()
		{
			try
			{
				if ((dgvACICategories.SelectedRows.Count > 0) && (dgvACICategories.CurrentRow != null))
					return (AccessControlItemCategory)dgvACICategories.SelectedRows[0].DataBoundItem;

				return null;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}

		private void RefreshACICategoriesGrid(AccessControlItemCategory selectedItem)
		{
			bool foundSelection = false;

			try
			{
				#region General setup
				Application.DoEvents();
				dgvACICategories.SuspendLayout();
				_refreshingCategories = true;
				#endregion

				#region Datasource/Action handling
				List<AccessControlItemCategory> dataSourceList = null;

				var selectedComputer = GetSelectedComputer();
				if (selectedComputer != null)
				{
					dataSourceList = (from c in
															(from i in ACIItems
															 join l in ComputerACIList.FindAll(ac => ac.ComputerId == selectedComputer.Id) on i.Id equals l.AccessControlListId into il
															 select new { i.Category, GrantedACI = il.Count() })
														group c by c.Category
															into g
															select new AccessControlItemCategory(g.Key, g.Sum(c => c.GrantedACI) == 0 ? -1 : g.Sum(c => c.GrantedACI) == g.Count(c => c.Category != null) ? 1 : 0, g.Count(c => c.Category != null), g.Sum(c => c.GrantedACI))).ToList();
				}
				else
				{
					dataSourceList = (from c in ACIItems
														group c by c.Category
															into g
															select new AccessControlItemCategory(g.Key, -1, g.Count(c => c.Category != null), 0)).ToList();
				}
        #endregion

        #region Datagrid filling and generation
        if (dataSourceList.Count > 0)
        {
          dgvACICategories.DataSource = new SortableBindingList<AccessControlItemCategory>(dataSourceList);

          if (dgvACICategories.SortedColumn == null)
            dgvACICategories.Sort(dgvACICategories.Columns[0], ListSortDirection.Ascending);


          for (int i = 0; i < dgvACICategories.Rows.Count; i++)
          {
            var dataBoundItem = (AccessControlItemCategory)dgvACICategories.Rows[i].DataBoundItem;
            if ((selectedItem == null) || (dataBoundItem.Category != selectedItem.Category))
              continue;

            dgvACICategories.Rows[i].Selected = true;
            foundSelection = true;
          }
        }
        else
        {
          dgvACICategories.DataSource = null;
        }
        #endregion
      }
			catch (Exception ex)
			{
				
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
			finally
			{
				if (selectedItem == null || !foundSelection)
					dgvACICategories.ClearSelection();

				dgvACICategories.ResumeLayout();
				_refreshingCategories = false;

				RefreshACIGrid(GetSelectedACI());
			}
		}

		private void DgvACICategoriesRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
		{
			try
			{
				var dataBoundItem = (AccessControlItemCategory)((DataGridView)sender).Rows[e.RowIndex].DataBoundItem;
        
				((DataGridView)sender).Rows[e.RowIndex].Cells["dgvcGranted"].Style.ForeColor = dataBoundItem.GrantedACI > 0 ? Color.Black : Color.Gray;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
			}
		}

		private void DgvACICategoriesSelectionChanged(object sender, EventArgs e)
		{
		  if (_refreshingCategories)
        return;

      try
		  {
		    RefreshACIGrid(null);
		  }
		  catch (Exception ex)
		  {
		    
		    Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
		    DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
		  }
		}
		#endregion
		#endregion

		#region ACI Handling (Lower Right Grid)
		#region Grid Handling
		private AccessControlItem GetSelectedACI()
		{
			try
			{
				if ((dgvACI.SelectedRows.Count > 0) && (dgvACI.CurrentRow != null))
					return (AccessControlItem)dgvACI.SelectedRows[0].DataBoundItem;

				return null;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}

		private void RefreshACIGrid(AccessControlItem selectedItem)
		{
			bool foundSelection = false;

			try
			{
				#region General setup
				Application.DoEvents();
				dgvACI.SuspendLayout();
				#endregion

				#region Datasource/Action handling
				List<AccessControlItemHelper> dataSourceList = null;

				var selectedGroup = GetSelectedComputer();
				var selectedCategory = GetSelectedACICategory();

				if (selectedGroup != null && selectedCategory != null)
				{
					dataSourceList = (from i in ACIItems
														join l in ComputerACIList.FindAll(ac => ac.ComputerId == selectedGroup.Id) on i.Id equals l.AccessControlListId into il
														where i.Category == selectedCategory.Category
														select new AccessControlItemHelper(i.Id, i.Category, i.Action, il.Any())).ToList();
				}
        #endregion

        #region Datagrid filling and generation
        if (dataSourceList?.Count > 0)
        {
          dgvACI.DataSource = new SortableBindingList<AccessControlItemHelper>(dataSourceList);

          if (dgvACI.SortedColumn == null)
            dgvACI.Sort(dgvACI.Columns[1], ListSortDirection.Ascending);

          for (int i = 0; i < dgvACI.Rows.Count; i++)
          {
            var dataBoundItem = (AccessControlItem)dgvACI.Rows[i].DataBoundItem;

            if ((selectedItem == null) || (dataBoundItem.Id != selectedItem.Id))
              continue;

            dgvACI.Rows[i].Selected = true;
            foundSelection = true;
          }
        }
        else
        {
          dgvACI.DataSource = null;
        }
        #endregion
      }
			catch (Exception ex)
			{
				
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
			finally
			{
				if (selectedItem == null || !foundSelection)
					dgvACI.ClearSelection();

				dgvACI.ResumeLayout();
			}
		}

		private void DgvACICellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				if (_refreshingGroups || _refreshingCategories || e.ColumnIndex != 0
					 || !CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY))
        {
          return;
        }

        var selectedACI = GetSelectedACI();
				var selectedComputer = GetSelectedComputer();

			  if (selectedACI == null || selectedComputer == null)
          return;

        var selectedComputerACIListItem = ComputerACIList.Find(aci => aci.ComputerId == selectedComputer.Id && aci.AccessControlListId == selectedACI.Id);

			  if (selectedComputerACIListItem != null)
			  {
			    new ComputerAccessControlLists().Delete(selectedComputerACIListItem);
			    ComputerACIList.RemoveAll(aci => aci.ComputerId == selectedComputer.Id && aci.AccessControlListId == selectedACI.Id);
			  }
			  else
			  {
			    selectedComputerACIListItem = new ComputerAccessControlList(selectedACI.Id, selectedComputer.Id);
			    new ComputerAccessControlLists().Add(selectedComputerACIListItem);
			    ComputerACIList.Add(selectedComputerACIListItem);
			  }

			  RefreshACICategoriesGrid(GetSelectedACICategory());
			}
			catch (Exception ex)
			{
				
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
		}
		#endregion

		#region Button Handling
		private void BtnSelectAllClick(object sender, EventArgs e)
		{
			var triggerButton = (ButtonX)sender;
			Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

			EnableDisableButtons(true);
			if (!triggerButton.Enabled)
			{
				Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
				DisplayWarning(TranslationKey.CommonMessage_JustModified);
				return;
			}

			try
			{
				if (_refreshingGroups || _refreshingCategories
						|| !CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY))
        {
          return;
        }

        var selectedComputer = GetSelectedComputer();
				var selectedACICategory = GetSelectedACICategory();

				if (selectedComputer != null && selectedACICategory != null)
				{
					var aciList = (from i in ACIItems
												 join l in ComputerACIList.FindAll(ac => ac.ComputerId == selectedComputer.Id) on i.Id equals l.AccessControlListId into il
												 where i.Category == selectedACICategory.Category && !il.Any()
												 select i);

					foreach (var item in aciList)
						new ComputerAccessControlLists().Add(new ComputerAccessControlList(item.Id, selectedComputer.Id));

					_computerACIList = null;
					RefreshACICategoriesGrid(GetSelectedACICategory());
				}
			}
			catch (Exception ex)
			{
				
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
		}

		private void BtnDeSelectAllClick(object sender, EventArgs e)
		{
			var triggerButton = (ButtonX)sender;
			Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);

			EnableDisableButtons(true);
			if (!triggerButton.Enabled)
			{
				Trace.WriteInformation("Action was not allowed. (Button='{0}')", Trace.GetMethodName(), CLASSNAME, triggerButton.Name);
				DisplayWarning(TranslationKey.CommonMessage_JustModified);
				return;
			}

			try
			{
				if (_refreshingGroups || _refreshingCategories
						|| !CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY))
        {
          return;
        }

        var selectedComputer = GetSelectedComputer();
				var selectedACICategory = GetSelectedACICategory();

				if (selectedComputer != null && selectedACICategory != null)
				{
					var aciList = (from l in ComputerACIList.FindAll(ac => ac.ComputerId == selectedComputer.Id)
												 join i in ACIItems.FindAll(aci => aci.Category == selectedACICategory.Category) on l.AccessControlListId equals i.Id into li
												 where li.Any()
                         select l);

					foreach (ComputerAccessControlList item in aciList)
						new ComputerAccessControlLists().Delete(item);

					_computerACIList = null;
					RefreshACICategoriesGrid(GetSelectedACICategory());
				}
			}
			catch (Exception ex)
			{
				
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
		}
		#endregion
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

				_computerACIList = null;
				_aciItems = null;

				RefreshComputersGrid(GetSelectedComputer());
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

		public override bool DeActivateAllowed()
		{
			return !_add && !_modify;
		}

		public override void DeActivateFromMain()
		{
			try
			{
				base.DeActivateFromMain();

				if (_add || _modify)
					BtnCancelClick(this, EventArgs.Empty);

				CurrentUser.ClearPermissions();
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}

		private void GroupManagementFormResize(object sender, EventArgs e)
		{
			try
			{
				pnlTop.Height = (Int32)((Height - 20) * 0.5);
				pnlBottomLeft.Width = (Int32)((Width - 20) * 0.5);
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
			}
		}
		#endregion

		private void BtnPropertiesClick(object sender, EventArgs e)
		{
			var selectedItem = GetSelectedComputer();
		  if (selectedItem == null)
        return;

      using (var popupForm = new PropertiesPopupForm(selectedItem))
		  {
		    var result = popupForm.ShowDialog(this);
		  }
		}
	}
}
