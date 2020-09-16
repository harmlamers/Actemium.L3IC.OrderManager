using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Actemium.Diagnostics;
using Actemium.UserManagement2.Model;
using Actemium.Windows.Forms.DevComponents2.Controls;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.Helpers
{
  public class UMMembershipHelper
  {
    private const string CLASSNAME = nameof(UMMembershipHelper);

    public static UMMembershipHelper Instance = new UMMembershipHelper();

    public List<GroupHelper> GetList(User user, List<UserGroupList> userGroupList, List<Group> groups)
    {
      var result = (from i in groups
                    select new GroupHelper(i.Id, i.Name, i.Description, null, false)).ToList();

      foreach (var group in result)
      {
        if (userGroupList.Exists(i => i.UserId == user.Id && i.GroupId == group.Id))
          group.Member = true;
      }

      return result;
    }

    public List<UserHelper> GetList(Group group, List<UserGroupList> userGroupList, List<User> users)
    {
      var result = (from i in users
                    select new UserHelper(i.Id, i.Username, i.Password, i.Name, i.SurName, i.AccountType, i.IsActive, false)).ToList();

      foreach (var user in result)
      {
        if (userGroupList.Exists(i => i.UserId == user.Id && i.GroupId == group.Id))
          user.Member = true;
      }

      return result;
    }

    public DataTable GetDataTable(List<UserHelper> users)
    {
      try
      {
        var dataTable = SuperGrid.DefineGridColumns(
          Translations.UserManagement2Form.Users,
          new SuperGrid.ColumnDefinition("Object", "Object", typeof(UserHelper), inUI: false),
          new SuperGrid.ColumnDefinition(
              "Member", "Member", typeof(bool), editorType: typeof(GridCheckBoxXEditControl)),
          new SuperGrid.ColumnDefinition(
            "Username", "Username", typeof(string), editorType: typeof(GridLabelXEditControl)),
          new SuperGrid.ColumnDefinition(
            "Name", "Name", typeof(string), editorType: typeof(GridLabelXEditControl)),
          new SuperGrid.ColumnDefinition(
            "SurName", "Surname", typeof(string), editorType: typeof(GridLabelXEditControl)),
          new SuperGrid.ColumnDefinition(
            "AccountType", "Account Type", typeof(string), editorType: typeof(GridLabelXEditControl))

          );
        dataTable.BeginLoadData();

        foreach (var item in users)
        {
          var row = dataTable.NewRow();

          dataTable.Rows.Add(
            item,
            item.Member,
            item.Username,
            item.Name,
            item.SurName,
            item.AccountType
            );

          row.AcceptChanges();
        }

        dataTable.EndLoadData();
        return dataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public DataTable GetDataTable(List<GroupHelper> groups)
    {
      try
      {
        var dataTable = SuperGrid.DefineGridColumns(
          Translations.UserManagement2Form.Groups,
          new SuperGrid.ColumnDefinition("Object", "Object", typeof(GroupHelper), inUI: false),
          new SuperGrid.ColumnDefinition(
            "Member", "Member", typeof(bool), editorType: typeof(GridCheckBoxXEditControl)),
          new SuperGrid.ColumnDefinition(
            "GroupName", "Group Name", typeof(string), editorType: typeof(GridLabelXEditControl))
        );
        dataTable.BeginLoadData();

        foreach (var item in groups)
        {
          var row = dataTable.NewRow();

          dataTable.Rows.Add(
            item,
            item.Member,
            item.Name
          );

          row.AcceptChanges();
        }

        dataTable.EndLoadData();
        return dataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
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

    public class UserHelper : User
    {
      public UserHelper(int id, string username, string password, string name, string surName, AccountTypes accountType, bool isActive, bool member)
        : base(id, username, password, name, surName, accountType, isActive)
      {
        Member = member;
      }

      public bool Member { get; set; }
    }
  }
}
