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
	public partial class UserManagementForm : BasePageForm
	{
		private const string CLASSNAME = nameof(UserManagementForm);

		public class AccessControlItemCategory
		{
			public AccessControlItemCategory(String category, Int32 userId, Int32 totalACI, Int32 grantedACI, Int32 grantedGroupACI)
			{
				Category = category;
				UserId = userId;
				TotalACI = totalACI;
				GrantedACI = grantedACI;
				GrantedGroupACI = grantedGroupACI;
			}

			public string Category { get; set; }
			public int UserId { get; set; }
			public int TotalACI { get; set; }
			public int GrantedACI { get; set; }
			public int GrantedGroupACI { get; set; }
			public string DisplayGranted { get { return string.Format("{0}/{1}/{2}", GrantedACI, GrantedGroupACI, TotalACI); } }
		}

		public class AccessControlItemHelper : AccessControlItem
		{
			public AccessControlItemHelper(int id, string category, string action, bool granted, bool groupGranted)
				: base(id, category, action)
			{
				Granted = granted;
				GroupGranted = groupGranted;
			}

			public bool Granted { get; set; }
			public bool GroupGranted { get; set; }
		}

		public class GroupHelper : Group
		{
			public GroupHelper(int id, string name, string description, string domainGroupIdentifier, bool member)
				: base(id, name, description, domainGroupIdentifier)
			{
				Member = member;
			}

			public bool Member { get; set; }
		}

		private Boolean _add;
		private Boolean _modify;
		private Boolean _refreshingUsers;
		private Boolean _refreshingCategories;
		private Boolean _refreshingGroups;


		public List<AccessControlItem> ACIItems
		{
			get
			{
				if (CurrentUser.User == null)
          return null;

        return _aciItems ?? (_aciItems = new AccessControlItems().GetAll());
			}
		} private List<AccessControlItem> _aciItems;

		public List<UserAccessControlList> UserACIList
		{
			get
			{
				if (CurrentUser.User == null)
          return null;

        return _userACIList ?? (_userACIList = new UserAccessControlLists().GetAll());
			}
		} private List<UserAccessControlList> _userACIList;

		public List<GroupAccessControlList> GroupACIList
		{
			get
			{
				if (CurrentUser.User == null)
          return null;

        return _groupACIList ?? (_groupACIList = new GroupAccessControlLists().GetAll());
			}
		} private List<GroupAccessControlList> _groupACIList;

		public List<Group> Groups
		{
			get
			{
				if (CurrentUser.User == null)
          return null;

        return _groups ?? (_groups = new Groups().GetAll());
			}
		} private List<Group> _groups;

		public List<UserGroupList> UserGroupList
		{
			get
			{
				if (CurrentUser.User == null)
          return null;

        return _userGroupList ?? (_userGroupList = new UserGroupLists().GetAll());
			}
		} private List<UserGroupList> _userGroupList;

		public UserManagementForm()
		{
			InitializeComponent();

			Title = "User Management - Users";
			NavigationItem = NavigationItems.UserManagement;
			ACICategory = ACICategories.USERMANAGEMENT;
		}

		private void SetChangeSettings()
		{
			try
			{
				UpdateEntryFields();
				EnableDisableButtons(!(_add || _modify));
				EnableDisableEntryFields();

				btnOK.Enabled = (_add || _modify);
				btnCancel.Enabled = (_add || _modify);
				dgvUsers.Enabled = !(_add || _modify);
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}


		#region User Handling (Upper Left Grid)
		#region EntryField handling
		private void EnableDisableEntryFields()
		{
			try
			{
				errorProvider.Clear();

				if(!_add && !_modify)
					ckbViewPassword.CheckState = CheckState.Unchecked;

				tbUserName.Enabled = (_add || _modify);
				tbPassword.Enabled = (_add || _modify);
				tbPasswordConfirm.Enabled = (_add || _modify);
				ckbIsActive.Enabled = false;// (_add || _modify);
				tbName.Enabled = (_add || _modify);
				tbSurname.Enabled = (_add || _modify);
				ckbViewPassword.Enabled = (_add || _modify);

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
				tbUserName.Clear();
				tbPassword.Clear();
				tbPasswordConfirm.Clear();
				tbName.Clear();
				tbSurname.Clear();
				ckbViewPassword.Checked = false;
				ckbIsActive.Checked = false;
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
				var selectedUser = GetSelectedUser();

				errorProvider.Clear();

        if (selectedUser != null)
        {
          tbUserName.Text = selectedUser.Username;
          tbPassword.Text = selectedUser.Password;
          tbPasswordConfirm.Text = selectedUser.Password;
          tbName.Text = selectedUser.Name;
          tbSurname.Text = selectedUser.SurName;
          ckbIsActive.Checked = selectedUser.IsActive;
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

		private void CkbViewPasswordCheckedChanged(object sender, EventArgs e)
		{
			tbPassword.PasswordChar = ckbViewPassword.Checked ? '\0' : '*';
			tbPassword.UseSystemPasswordChar = !ckbViewPassword.Checked;
			//tbPasswordConfirm.PasswordChar = ckbViewPassword.Checked ? '\0' : '*';
			//tbPasswordConfirm.UseSystemPasswordChar = !ckbViewPassword.Checked;
			tbPasswordConfirm.Enabled = !ckbViewPassword.Checked;
			tbPasswordConfirm.Text = ckbViewPassword.Checked ? "" : tbPassword.Text;
		}

		#endregion

		#region Grid Handling
		private void CkbShowInactiveCheckedUsersChanged(object sender, EventArgs e)
		{
			RefreshUsersGrid(GetSelectedUser());
		}

		private User GetSelectedUser()
		{
			try
			{
				if ((dgvUsers.SelectedRows.Count > 0) && (dgvUsers.CurrentRow != null))
					return (User)dgvUsers.SelectedRows[0].DataBoundItem;

				return null;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw;
			}
		}

		private void RefreshUsersGrid(User selectedItem)
		{
			bool foundSelection = false;

			try
			{
				#region General setup
				Application.DoEvents();
				dgvUsers.SuspendLayout();
				_refreshingUsers = true;
				#endregion

				#region Datasource/Action handling
				var dataSourceList = new Users().GetAll();
				if (!ckbShowInactiveUsers.Checked)
				{
					dataSourceList.RemoveAll(u => !u.IsActive);
				}
				#endregion

				#region Datagrid filling and generation
				dgvUsers.DataSource = null; //Allways clear datasource before rebinding. The gridview cannot handle rebinding to a datasource with less items
				if (dataSourceList.Count > 0)
				{
					dgvUsers.DataSource = new SortableBindingList<User>(dataSourceList);

					if (dgvUsers.SortedColumn == null)
						dgvUsers.Sort(dgvUsers.Columns[0], ListSortDirection.Ascending);

					for (int i = 0; i < dgvUsers.Rows.Count; i++)
					{
						var dataBoundItem = (User)dgvUsers.Rows[i].DataBoundItem;

						if ((selectedItem != null) && (dataBoundItem.Id == selectedItem.Id))
						{
							dgvUsers.Rows[i].Selected = true;
							foundSelection = true;
						}
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
					dgvUsers.ClearSelection();

				SetChangeSettings();

				dgvUsers.ResumeLayout();
				_refreshingUsers = false;

				RefreshACICategoriesGrid(GetSelectedACICategory());
				RefreshGroupsGrid(GetSelectedGroup());
			}
		}

		private void DgvUsersGridSelectionChanged(object sender, EventArgs e)
		{
			//if (!dgvUsers.DataSourceChanging && !_refreshingUsers)
			if (!_refreshingUsers)
			{
				try
				{
					SetChangeSettings();

					RefreshACICategoriesGrid(GetSelectedACICategory());
					RefreshGroupsGrid(GetSelectedGroup());
				}
				catch (Exception ex)
				{
					Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);

				}
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

				SetChangeSettings();
				ClearEntryFields();

				ckbIsActive.Checked = true;
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
				if ((dgvUsers.SelectedRows.Count == 1) && (dgvUsers.CurrentRow != null))
				{
					_modify = true;
					SetChangeSettings();
				}
			}
			catch (Exception ex)
			{
				
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
		}

		private void BtnPropertiesClick(object sender, EventArgs e)
		{
			var selectedItem = GetSelectedUser();
			if (selectedItem != null)
			{
        using (var popupForm = new PropertiesPopupForm(selectedItem))
        {
          var result = popupForm.ShowDialog(this);
        }
      }
		}

		private void BtnDeActivateClick(object sender, EventArgs e)
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
				User selectedUser = GetSelectedUser();

				if (selectedUser != null)
				{
					if (selectedUser.IsActive && Confirm(TranslationKey.Confirm_User_Deactivate, "Deactivate user", "Are you sure to de-activate this user?", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						ShowBusyBox = true;
						AddHistoryAction(TranslationKey.History_UserManagementForm_Deactivated, "User '{0}' deactivated.", selectedUser.Username);
						Trace.WriteInformation("User deactivated: GroupName={0}", Trace.GetMethodName(), CLASSNAME, selectedUser.Username);

						selectedUser.IsActive = false;
						new Users().Modify(selectedUser);
					}
				}
			}
			catch (Exception ex)
			{
				
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
			finally
			{
				SetChangeSettings();
				RefreshUsersGrid(GetSelectedUser());
				ShowBusyBox = false;
			}
		}

		private void BtnActivateClick(object sender, EventArgs e)
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
				User selectedUser = GetSelectedUser();

				if (selectedUser != null)
				{

					if (!selectedUser.IsActive && Confirm(TranslationKey.Confirm_User_Activate, "Activate user", "Are you sure to activate this user?", MessageBoxButtons.YesNo) == DialogResult.Yes)
					{
						ShowBusyBox = true;
						AddHistoryAction(TranslationKey.History_UserManagementForm_Activated, "User '{0}' activated.", selectedUser.Username);
						Trace.WriteInformation("User activated: GroupName={0}", Trace.GetMethodName(), CLASSNAME, selectedUser.Username);

						selectedUser.IsActive = true;
						new Users().Modify(selectedUser);
					}
				}
			}
			catch (Exception ex)
			{
				
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
			finally
			{
				SetChangeSettings();
				RefreshUsersGrid(GetSelectedUser());
				ShowBusyBox = false;
			}
		}

		private void BtnCancelClick(object sender, EventArgs e)
		{
			_add = false;
			_modify = false;
			ckbIsActive.Checked = !(!_add && !_modify);
			SetChangeSettings();
			RefreshUsersGrid(GetSelectedUser());
		}

		private void BtnOkClick(object sender, EventArgs e)
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

				var user = CheckConstraints();

				if (user != null)
				{
					if (_modify && (Confirm(TranslationKey.Confirm_User_Modify, "Modify User", "Are you sure to modify this user?", MessageBoxButtons.YesNo) == DialogResult.Yes))
					{
						new Users().Modify(user);
						AddHistoryAction(TranslationKey.History_UserManagementForm_Modified, "User '{0}' modified.", user.Username);
						Trace.WriteInformation("User modified: UserName= {0}", Trace.GetMethodName(), CLASSNAME, user.Username);
					}
					else if (_add)
					{
						user.AccountType = AccountTypes.DBUser;
						new Users().Add(user);
						AddHistoryAction(TranslationKey.History_UserManagementForm_Added, "User '{0}' added.", user.Username);
						Trace.WriteInformation("User added: GroupName= {0}", Trace.GetMethodName(), CLASSNAME, user.Username);
					}

					_add = false;
					_modify = false;
					ckbIsActive.Checked = !(!_add && !_modify);
					RefreshUsersGrid(user);
					SetChangeSettings();
				}
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

				var user = GetSelectedUser();

				enable = (enable && user != null);

				//btnAdd.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.Modify) && enable;
				btnModify.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY) && enable
																&& (user.AccountType == AccountTypes.DBSuperUser || user.AccountType == AccountTypes.DBUser);
				btnDeActivate.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.DEACTIVATE) && enable && user.IsActive
																&& (user.AccountType == AccountTypes.DBSuperUser || user.AccountType == AccountTypes.DBUser);
				btnActivate.Enabled = CurrentUser.HasPermission(ACICategory, ACIOptions.ACTIVATE) && enable && !user.IsActive
																&& (user.AccountType == AccountTypes.DBSuperUser || user.AccountType == AccountTypes.DBUser);

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

		private User CheckConstraints()
		{
			try
			{
				var result = _modify ? GetSelectedUser() : new User();

				Boolean hasError = false;
				errorProvider.Clear();

        if (tbUserName.Text.Length <= 0 || tbUserName.Text.Length > 50)
        {
          hasError = true;
          errorProvider.SetError(tbUserName, "Field required...");
        }
        else
        {
          result.Username = tbUserName.Text;
        }

        if (tbPassword.Text.Length <= 0 || tbPassword.Text.Length > 255)
				{
					hasError = true;
					errorProvider.SetError(tbPassword, "Field required...");
				}
				else
				{
					if (ckbViewPassword.CheckState != CheckState.Checked)
					{
						if (tbPasswordConfirm.Text.Length <= 0 || tbPasswordConfirm.Text.Length > 255)
						{
							hasError = true;
							errorProvider.SetError(tbPasswordConfirm, "Field required...");
						}
						else if (string.CompareOrdinal(tbPassword.Text, tbPasswordConfirm.Text) != 0)
						{
							hasError = true;
							errorProvider.SetError(tbPassword, "Inserted password mismatch...");
							errorProvider.SetError(tbPasswordConfirm, "Inserted password mismatch...");
						}
					}
					if (!hasError)
						result.Password = tbPassword.Text;
				}

				result.IsActive = ckbIsActive.Checked;
				result.Name = tbName.Text;
				result.SurName = tbSurname.Text;

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

		#region Group Handling (Upper Right Grid)
		private Group GetSelectedGroup()
		{
			try
			{
				if ((dgvGroups.SelectedRows.Count > 0) && (dgvGroups.CurrentRow != null))
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
				var selectedUser = GetSelectedUser();
				var dataSource = (from i in Groups
													select new GroupHelper(i.Id, i.Name, i.Description, null, false)).ToList();

				if (selectedUser != null)
				{
					foreach (var group in dataSource)
					{
						if (UserGroupList.Exists(i => i.UserId == selectedUser.Id && i.GroupId == group.Id))
							group.Member = true;
					}
				}
				#endregion

				#region Datagrid filling and generation
				if (dataSource.Count > 0)
				{
					dgvGroups.DataSource = new SortableBindingList<GroupHelper>(dataSource);

					if (dgvGroups.SortedColumn == null)
						dgvGroups.Sort(dgvGroups.Columns[1], ListSortDirection.Ascending);

					for (int i = 0; i < dgvGroups.Rows.Count; i++)
					{
						var dataBoundItem = (Group)dgvGroups.Rows[i].DataBoundItem;

						if ((selectedItem != null) && (dataBoundItem.Id == selectedItem.Id))
						{
							dgvGroups.Rows[i].Selected = true;
							foundSelection = true;
						}
					}
				}
				else
				{
					dgvGroups.DataSource = null;
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
				_refreshingGroups = false;

				if (selectedItem == null || !foundSelection)
					dgvGroups.ClearSelection();

				dgvGroups.ResumeLayout();
			}
		}

		private void GroupsGridCellClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				//if (dgvGroups.DataSourceChanging || _refreshingGroups || _refreshingUsers || e.ColumnIndex != 0
				//	 || !CurrentUser.HasPermission(ACICategory, ACIOptions.Modify))
				if (_refreshingGroups || _refreshingUsers || e.ColumnIndex != 0
					 || !CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY))
        {
          return;
        }

        var selectedGroup = GetSelectedGroup();
				var selectedUser = GetSelectedUser();

				if (selectedUser != null && (selectedUser.AccountType == AccountTypes.ADUser || selectedUser.AccountType == AccountTypes.ADSuperUser))
				{
					DisplayWarning(TranslationKey.Message_UserGroup_ModifyNotAllowed, "Action not allowed", "It is not allowed to modify group assignments for domain users.");
					return;
				}

				if (selectedGroup != null && selectedUser != null)
				{
					var selectedUserGroupListItem = UserGroupList.Find(aci => aci.UserId == selectedUser.Id && aci.GroupId == selectedGroup.Id);

					if (selectedUserGroupListItem != null)
					{
						new UserGroupLists().Delete(selectedUserGroupListItem);
						UserGroupList.RemoveAll(aci => aci.UserId == selectedUser.Id && aci.GroupId == selectedGroup.Id);
					}
					else
					{
						selectedUserGroupListItem = new UserGroupList(selectedUser.Id, selectedGroup.Id);
						new UserGroupLists().Add(selectedUserGroupListItem);
						UserGroupList.Add(selectedUserGroupListItem);
					}

					RefreshGroupsGrid(selectedGroup);
				}
			}
			catch (Exception ex)
			{
				
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				DisplayError(Trace.GetMethodName(), TranslationKey.CommonMessage_InternalError, ex);
			}
		}
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

				var selectedUser = GetSelectedUser();
				if (selectedUser != null)
				{
					dataSourceList = (from c in
															(from i in ACIItems
															 join l in UserACIList.FindAll(ac => ac.UserId == selectedUser.Id) on i.Id equals l.AccessControlListId into il
															 join x in GroupACIList.FindAll(ac => UserGroupList.Find(x => x.GroupId == ac.GroupId && x.UserId == selectedUser.Id) != null) on i.Id equals x.AccessControlListId into ix
															 select new { i.Category, GrantedACI = il.Count(), GrantedGroupACI = ix.Count() })
														group c by c.Category
															into g
															select new AccessControlItemCategory(g.Key, 
																																	g.Sum(c => c.GrantedACI) == 0 ? -1 : g.Sum(c => c.GrantedACI) == g.Count(c => c.Category != null) ? 1 : 0, 
																																	g.Count(c => c.Category != null), 
																																	g.Sum(c => c.GrantedACI),
																																	g.Sum(c => c.GrantedGroupACI)
																																	)).ToList();
				}
				else
				{
					dataSourceList = (from c in ACIItems
														group c by c.Category
															into g
															select new AccessControlItemCategory(g.Key, -1, g.Count(c => c.Category != null), 0, 0)).ToList();
				}
        #endregion

        #region Datagrid filling and generation
        if (dataSourceList?.Count > 0)
        {
          dgvACICategories.DataSource = new SortableBindingList<AccessControlItemCategory>(dataSourceList);

          if (dgvACICategories.SortedColumn == null)
            dgvACICategories.Sort(dgvACICategories.Columns[0], ListSortDirection.Ascending);

          for (int i = 0; i < dgvACICategories.Rows.Count; i++)
          {
            var dataBoundItem = (AccessControlItemCategory)dgvACICategories.Rows[i].DataBoundItem;
            if ((selectedItem != null) && (dataBoundItem.Category == selectedItem.Category))
            {
              dgvACICategories.Rows[i].Selected = true;
              foundSelection = true;
              break;
            }
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

				((DataGridView)sender).Rows[e.RowIndex].Cells["cACICategoriesGranted"].Style.ForeColor = dataBoundItem.GrantedACI > 0 ? Color.Black : Color.Gray;
			}
			catch (Exception ex)
			{
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
			}
		}

		private void DgvACICategoriesSelectionChanged(object sender, EventArgs e)
		{
			//if (!ACICategoriesGrid1.DataSourceChanging && !_refreshingCategories)
			if (!_refreshingCategories)
			{
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

				var selectedUser = GetSelectedUser();
				var selectedCategory = GetSelectedACICategory();

				if (selectedUser != null && selectedCategory != null)
				{
					dataSourceList = (from i in ACIItems
														join l in UserACIList.FindAll(ac => ac.UserId == selectedUser.Id) on i.Id equals l.AccessControlListId into il
														join x in GroupACIList.FindAll(ac => UserGroupList.Find(x => x.GroupId == ac.GroupId && x.UserId == selectedUser.Id) != null) on i.Id equals x.AccessControlListId into ix
														where i.Category == selectedCategory.Category
														select new AccessControlItemHelper(i.Id, i.Category, i.Action, il.Any(), ix.Any())).ToList();
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

            if ((selectedItem != null) && (dataBoundItem.Id == selectedItem.Id))
            {
              dgvACI.Rows[i].Selected = true;
              foundSelection = true;
            }
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
				//if (ACIGrid1.DataSourceChanging || _refreshingUsers || _refreshingCategories || e.ColumnIndex != 0
				//	 || !CurrentUser.HasPermission(ACICategory, ACIOptions.Modify))
				if (_refreshingUsers || _refreshingCategories || e.ColumnIndex != 0
					 || !CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY))
        {
          return;
        }

        var selectedACI = GetSelectedACI();
				var selectedUser = GetSelectedUser();

				if (selectedACI != null && selectedUser != null)
				{
					var selectedUserACIListItem = UserACIList.Find(aci => aci.UserId == selectedUser.Id && aci.AccessControlListId == selectedACI.Id);

					if (selectedUserACIListItem != null)
					{
						new UserAccessControlLists().Delete(selectedUserACIListItem);
						UserACIList.RemoveAll(aci => aci.UserId == selectedUser.Id && aci.AccessControlListId == selectedACI.Id);
					}
					else
					{
						selectedUserACIListItem = new UserAccessControlList(selectedACI.Id, selectedUser.Id);
						new UserAccessControlLists().Add(selectedUserACIListItem);
						UserACIList.Add(selectedUserACIListItem);
					}

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
				//if (ACIGrid1.DataSourceChanging || _refreshingGroups || _refreshingCategories
				//		|| !CurrentUser.HasPermission(ACICategory, ACIOptions.Modify))
				if (_refreshingGroups || _refreshingCategories
					|| !CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY))
        {
          return;
        }

        var selectedUser = GetSelectedUser();
				var selectedACICategory = GetSelectedACICategory();

				if (selectedUser != null && selectedACICategory != null)
				{
					var aciList = (from i in ACIItems
												 join l in UserACIList.FindAll(ac => ac.UserId == selectedUser.Id) on i.Id equals l.AccessControlListId into il
												 where i.Category == selectedACICategory.Category && !il.Any()
												 select i);

					foreach (var item in aciList)
						new UserAccessControlLists().Add(new UserAccessControlList(item.Id, selectedUser.Id));

					_userACIList = null;
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
				//if (ACIGrid1.DataSourceChanging || _refreshingGroups || _refreshingCategories
				//		|| !CurrentUser.HasPermission(ACICategory, ACIOptions.Modify))
				if (_refreshingGroups || _refreshingCategories
					|| !CurrentUser.HasPermission(ACICategory, ACIOptions.MODIFY))
        {
          return;
        }

        var selectedUser = GetSelectedUser();
				var selectedACICategory = GetSelectedACICategory();

				if (selectedUser != null && selectedACICategory != null)
				{
					var aciList = (from l in UserACIList.FindAll(ac => ac.UserId == selectedUser.Id)
												 join i in ACIItems.FindAll(aci => aci.Category == selectedACICategory.Category) on l.AccessControlListId equals i.Id into li
												 where li.Any()
                         select l);

					foreach (UserAccessControlList item in aciList)
						new UserAccessControlLists().Delete(item);

					_userACIList = null;
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
					throw new SecurityException(CurrentUser.User.Username, Translation.Instance.Translate(this, transKey, transKey.GetCommonMessage()));
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

				_userACIList = null;
				_groupACIList = null;
				_aciItems = null;

				_userGroupList = null;
				_groups = null;

				RefreshUsersGrid(GetSelectedUser());
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

		private void UserManagementFormResize(object sender, EventArgs e)
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
