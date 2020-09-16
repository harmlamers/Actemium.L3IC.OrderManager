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
	public partial class GroupManagementForm : BasePageForm
	{
		private const string CLASSNAME = nameof(GroupManagementForm);

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

		public List<GroupAccessControlList> GroupACIList
		{
			get
			{
				if (CurrentUser.User == null)
          return null;

        return _groupACIList ?? (_groupACIList = new GroupAccessControlLists().GetAll());
			}
		} private List<GroupAccessControlList> _groupACIList;


		public GroupManagementForm()
		{
			InitializeComponent();

			Title = "User Management - Groups";
			NavigationItem = NavigationItems.GroupManagement;
			ACICategory = ACICategories.GROUPMANAGEMENT;
		}

		private void SetChangeSettings()
		{
			try
			{
				if (!_add)
					UpdateEntryFields();

				EnableDisableButtons(!(_add || _modify));
				EnableDisableEntryFields();

				btnOK.Enabled = _add || _modify;
				btnCancel.Enabled = _add || _modify;
				dgvGroups.Enabled = !(_add || _modify);
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}


		#region Group Handling (Upper Grid)
		#region EntryField handling
		private void EnableDisableEntryFields()
		{
			try
			{
				errorProvider.Clear();

				tbName.Enabled = _add || _modify;
				tbDescription.Enabled = _add || _modify;
				tbDomainGroupIdentifier.Enabled = _add || _modify;

				btnCancel.Enabled = _add || _modify;
				btnOK.Enabled = _add || _modify;
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

				tbName.Clear();
				tbDescription.Clear();
				tbDomainGroupIdentifier.Clear();
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
				var selectedGroup = GetSelectedGroup();

				errorProvider.Clear();

        if (selectedGroup != null)
        {
          tbName.Text = selectedGroup.Name;
          tbDescription.Text = selectedGroup.Description;
          tbDomainGroupIdentifier.Text = selectedGroup.DomainGroupIdentifier;
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
		private Group GetSelectedGroup()
		{
			try
			{
				if (dgvGroups.SelectedRows.Count > 0 && dgvGroups.CurrentRow != null)
					return (Group)dgvGroups.SelectedRows[0].DataBoundItem;

				return null;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}

		private void RefreshGroupsGrid(Group selectedItem)
		{
			bool foundSelection = false;

			try
			{
				#region General setup
				Application.DoEvents();
				dgvGroups.SuspendLayout();
				_refreshingGroups = true;
				#endregion

				#region Datasource/Action handling
				var dataSourceList = new Groups().GetAll();
				#endregion

				#region Datagrid filling and generation
				dgvGroups.DataSource = null; //Allways clear datasource before rebinding. The gridview cannot handle rebinding to a datasource with less items
			  if (dataSourceList.Count <= 0)
          return;

        dgvGroups.DataSource = new SortableBindingList<Group>(dataSourceList);

			  if (dgvGroups.SortedColumn == null)
			    dgvGroups.Sort(dgvGroups.Columns[0], ListSortDirection.Ascending);


			  for (int i = 0; i < dgvGroups.Rows.Count; i++)
			  {
			    var dataBoundItem = (Group)dgvGroups.Rows[i].DataBoundItem;

			    if (selectedItem == null || dataBoundItem.Id != selectedItem.Id)
            continue;

          dgvGroups.Rows[i].Selected = true;
			    foundSelection = true;
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
					dgvGroups.ClearSelection();

				SetChangeSettings();

				dgvGroups.ResumeLayout();
				_refreshingGroups = false;

				RefreshACICategoriesGrid(GetSelectedACICategory());
			}
		}

		private void GroupsGridSelectionChanged(object sender, EventArgs e)
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
			  if (dgvGroups.SelectedRows.Count != 1 || dgvGroups.CurrentRow == null)
          return;

        _modify = true;
			  SetChangeSettings();
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
			var selectedItem = GetSelectedGroup();

			try
			{
			  if (selectedItem == null)
          return;

        if (Confirm(
			        TranslationKey.Confirm_UserGroup_Delete, "Delete User group",
			        "Are you sure to delete this user group included the authorization items?", MessageBoxButtons.YesNo)
			      != DialogResult.Yes)
        {
          return;
        }

        ShowBusyBox = true;
			  AddHistoryAction(TranslationKey.History_GroupManagementForm_Deleted, "User group '{0}' deleted.", selectedItem.Name);
			  Trace.WriteInformation("Group deleted: GroupName={0}, DomainGroupId={1}", Trace.GetMethodName(), CLASSNAME, selectedItem.Name, selectedItem.Description);
			  new Groups().Delete(selectedItem);
			}
			catch (Exception ex)
			{
				
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
				ShowBusyBox = false;
			}
			finally
			{
				_groupACIList = null;
				SetChangeSettings();
				RefreshGroupsGrid(GetSelectedGroup());
				ShowBusyBox = false;
			}
		}

		private void BtnPropertiesClick(object sender, EventArgs e)
		{
			var selectedItem = GetSelectedGroup();
		  if (selectedItem == null)
        return;

      using (var popupForm = new PropertiesPopupForm(selectedItem))
		  {
		    var result = popupForm.ShowDialog(this);
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

				var modifiedGroup = CheckConstraints();

			  if (modifiedGroup == null)
          return;

        if (_modify && Confirm(TranslationKey.Confirm_UserGroup_Modify, "Modify User group", "Are you sure you want to modify this user group?", MessageBoxButtons.YesNo) == DialogResult.Yes)
			  {
			    new Groups().Modify(modifiedGroup);
			    AddHistoryAction(TranslationKey.History_GroupManagementForm_Modified, "User group '{0}' modified.", modifiedGroup.Name);
			    Trace.WriteInformation("Group modified: GroupName={0}", Trace.GetMethodName(), CLASSNAME, modifiedGroup.Name);
			  }
			  else if (_add)
			  {
			    new Groups().Add(modifiedGroup);
			    modifiedGroup = new Groups().GetAll().First(i => i.Name == modifiedGroup.Name);
			    AddHistoryAction(TranslationKey.History_GroupManagementForm_Added, "User group '{0}' added.", modifiedGroup.Name);
			    Trace.WriteInformation("Group added: GroupName={0}", Trace.GetMethodName(), CLASSNAME, modifiedGroup.Name);
			  }

			  _add = false;
			  _modify = false;

			  _groupACIList = null;
			  RefreshGroupsGrid(modifiedGroup);
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
				btnAdd.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY) && enable;

				var selectedGroup = GetSelectedGroup();

				enable = enable && selectedGroup != null;

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

		private Group CheckConstraints()
		{
			try
			{
				var result = _modify ? GetSelectedGroup() : new Group();

				Boolean hasError = false;
				errorProvider.Clear();

        if (tbName.Text.Length <= 0 || tbName.Text.Length > 50)
        {
          hasError = true;
          errorProvider.SetError(tbName, "Field required...");
        }
        else
        {
          result.Name = tbName.Text;
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

        result.DomainGroupIdentifier = tbDomainGroupIdentifier.Text;

				if (result.Name != null && new Groups().GetAll().Find(g => g.Id != result.Id && String.Equals(g.Name, result.Name, StringComparison.InvariantCultureIgnoreCase)) != null)
				{
					hasError = true;
					errorProvider.SetError(tbName, "Group name must be unique...");
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
				if (dgvACICategories.SelectedRows.Count > 0 && dgvACICategories.CurrentRow != null)
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

				var selectedGroup = GetSelectedGroup();
				if (selectedGroup != null)
				{
					dataSourceList = (from c in
															(from i in ACIItems
															 join l in GroupACIList.FindAll(ac => ac.GroupId == selectedGroup.Id) on i.Id equals l.AccessControlListId into il
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
            if (selectedItem == null || dataBoundItem.Category != selectedItem.Category)
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
				if (dgvACI.SelectedRows.Count > 0 && dgvACI.CurrentRow != null)
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

				var selectedGroup = GetSelectedGroup();
				var selectedCategory = GetSelectedACICategory();

				if (selectedGroup != null && selectedCategory != null)
				{
					dataSourceList = (from i in ACIItems
														join l in GroupACIList.FindAll(ac => ac.GroupId == selectedGroup.Id) on i.Id equals l.AccessControlListId into il
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

            if (selectedItem == null || dataBoundItem.Id != selectedItem.Id)
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
				var selectedGroup = GetSelectedGroup();

			  if (selectedACI == null || selectedGroup == null)
          return;

        var selectedGroupACIListItem = GroupACIList.Find(aci => aci.GroupId == selectedGroup.Id && aci.AccessControlListId == selectedACI.Id);

			  if (selectedGroupACIListItem != null)
			  {
			    new GroupAccessControlLists().Delete(selectedGroupACIListItem);
			    GroupACIList.RemoveAll(aci => aci.GroupId == selectedGroup.Id && aci.AccessControlListId == selectedACI.Id);
			  }
			  else
			  {
			    selectedGroupACIListItem = new GroupAccessControlList(selectedACI.Id, selectedGroup.Id);
			    new GroupAccessControlLists().Add(selectedGroupACIListItem);
			    GroupACIList.Add(selectedGroupACIListItem);
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

        var selectedGroup = GetSelectedGroup();
				var selectedACICategory = GetSelectedACICategory();

			  if (selectedGroup == null || selectedACICategory == null)
          return;

        var aciList = from i in ACIItems
			    join l in GroupACIList.FindAll(ac => ac.GroupId == selectedGroup.Id) on i.Id equals l.AccessControlListId into il
			    where i.Category == selectedACICategory.Category && !il.Any()
			    select i;

			  foreach (var item in aciList)
			    new GroupAccessControlLists().Add(new GroupAccessControlList(item.Id, selectedGroup.Id));

			  _groupACIList = null;
			  RefreshACICategoriesGrid(GetSelectedACICategory());
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

        var selectedGroup = GetSelectedGroup();
				var selectedACICategory = GetSelectedACICategory();

			  if (selectedGroup == null || selectedACICategory == null)
          return;

        var aciList = from l in GroupACIList.FindAll(ac => ac.GroupId == selectedGroup.Id)
			    join i in ACIItems.FindAll(aci => aci.Category == selectedACICategory.Category) on l.AccessControlListId equals i.Id into li
			    where li.Any()
                      select l;

			  foreach (GroupAccessControlList item in aciList)
			    new GroupAccessControlLists().Delete(item);

			  _groupACIList = null;
			  RefreshACICategoriesGrid(GetSelectedACICategory());
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

			  if (CurrentUser.HasPermission(ACICategory, ACIOptions.VIEW))
          return;

        const TranslationKey transKey = TranslationKey.CommonMessage_NoAuthorization;
			  throw new SecurityException(CurrentUser.User.Username, Translation.Instance.Translate(transKey, TranslationSubKey.Message, transKey.GetCommonMessage()));
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
				_groupACIList = null;
				_aciItems = null;

				RefreshGroupsGrid(GetSelectedGroup());
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



	}
}
