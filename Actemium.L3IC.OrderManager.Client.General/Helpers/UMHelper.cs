using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base.PropertyGrids;
using Actemium.UserManagement2.Business;
using Actemium.UserManagement2.Model;
using Actemium.Windows.Forms.SuperGrid;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.Helpers
{
  public class UMHelper
  {
    private const string CLASSNAME = nameof(UMHelper);

    public static UMHelper Instance = new UMHelper();

    public DataTable GetDataTable(List<User> users)
    {
      try
      {
        var dataTable = SuperGrid.DefineGridColumns(
          Translations.UserManagement2Form.Users,
          new SuperGrid.ColumnDefinition("User", "User", typeof(User), inUI: false),
          new SuperGrid.ColumnDefinition("User Id", "User Id", typeof(int), visible: false),
          new SuperGrid.ColumnDefinition("Username", "Username", typeof(string)),
          new SuperGrid.ColumnDefinition("First Name", "First Name", typeof(string)),
          new SuperGrid.ColumnDefinition("Last Name", "Last Name", typeof(string)),
          new SuperGrid.ColumnDefinition("Account Type", "Account Type", typeof(string)),
          new SuperGrid.ColumnDefinition("Domain", "Domain", typeof(string)),
          new SuperGrid.ColumnDefinition("Active", "Active", typeof(bool))
          );

        dataTable.BeginLoadData();

        foreach (var item in users)
        {
          var id = item.Id;
          var username = item.Username;
          var firstName = item.Name;
          var lastName = item.SurName;
          var accountType = item.AccountType;
          var domain = item.Domain;
          var active = item.IsActive;
          var row = dataTable.NewRow();

          dataTable.Rows.Add(
            item,
            id,
            username,
            firstName,
            lastName,
            accountType,
            domain,
            active
            );

          row.AcceptChanges();
        }

        dataTable.EndLoadData();
        return dataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public DataTable GetDataTable(List<Group> groups)
    {
      try
      {
        var dataTable = SuperGrid.DefineGridColumns(
          Translations.UserManagement2Form.Groups,
          new SuperGrid.ColumnDefinition("Group", "Group", typeof(Group), inUI: false),
          new SuperGrid.ColumnDefinition("Group Id", "Group Id", typeof(int), visible: false),
          new SuperGrid.ColumnDefinition("Name", "Name", typeof(string)),
          new SuperGrid.ColumnDefinition("Description", "Description", typeof(string)),
          new SuperGrid.ColumnDefinition("Domain Group Identifier", "Domain Group Identifier", typeof(string))
        );

        dataTable.BeginLoadData();

        foreach (var item in groups)
        {
          var id = item.Id;
          var name = item.Name;
          var description = item.Description;
          var domainGroupIdentifier = item.DomainGroupIdentifier;
          var row = dataTable.NewRow();

          dataTable.Rows.Add(
            item,
            id,
            name,
            description,
            domainGroupIdentifier
          );

          row.AcceptChanges();
        }

        dataTable.EndLoadData();
        return dataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public DataTable GetDataTable(List<Computer> computers)
    {
      try
      {
        var dataTable = SuperGrid.DefineGridColumns(
          Translations.UserManagement2Form.Computers,
          new SuperGrid.ColumnDefinition("Computer", "Computer", typeof(Computer), inUI: false),
          new SuperGrid.ColumnDefinition("Computer Id", "Computer Id", typeof(int), visible: false),
          new SuperGrid.ColumnDefinition("Host name", "Host name", typeof(string)),
          new SuperGrid.ColumnDefinition("Description", "Description", typeof(string)),
          new SuperGrid.ColumnDefinition("ACI Managed", "ACI Managed", typeof(bool))
        );

        dataTable.BeginLoadData();

        foreach (var item in computers)
        {
          var id = item.Id;
          var name = item.HostName;
          var description = item.Description;
          var aciManaged = item.ACIManaged;
          var row = dataTable.NewRow();

          dataTable.Rows.Add(
            item,
            id,
            name,
            description,
            aciManaged
          );

          row.AcceptChanges();
        }

        dataTable.EndLoadData();
        return dataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public List<ACIHelper> GetList(User user, List<AccessControlItem> accessControlItems, List<UserGroupList> userGroups, List<UserAccessControlList> userACIList, List<GroupAccessControlList> groupACIList)
    {
      var result = (from i in accessControlItems
        select new ACIHelper(i.Id, i.Category, i.Action, false)).ToList();

      foreach (var userACI in userACIList)
      {
        if (userACI.UserId != user.Id)
          continue;

        var res = result.Find(x => x != null && x.Id == userACI.AccessControlListId);
        if (res != null)
          res.Own = true;
      }

      foreach (var groupACI in groupACIList)
      {
        if (!userGroups.Exists(i => i.UserId == user.Id && i.GroupId == groupACI.GroupId))
          continue;

        var res = result.Find(x => x != null && x.Id == groupACI.AccessControlListId);
        if (res != null)
          res.Group = true;
      }

      return result;
    }

    public List<ACIHelper> GetList(Group group, List<AccessControlItem> accessControlItems, List<GroupAccessControlList> groupACIList)
    {
      var result = (from i in accessControlItems
        select new ACIHelper(i.Id, i.Category, i.Action, false)).ToList();

      foreach (var groupACI in groupACIList)
      {
        if (groupACI.GroupId != group.Id)
          continue;

        var res = result.Find(x => x != null && x.Id == groupACI.AccessControlListId);
        if (res != null)
          res.Own = true;
      }

      return result;
    }

    public List<ACIHelper> GetList(Computer computer, List<AccessControlItem> accessControlItems, List<ComputerAccessControlList> computerACIList)
    {
      var result = (from i in accessControlItems
        select new ACIHelper(i.Id, i.Category, i.Action, false)).ToList();

      foreach (var computerACI in computerACIList)
      {
        if (computerACI.ComputerId != computer.Id)
          continue;

        var res = result.Find(x => x != null && x.Id == computerACI.AccessControlListId);
        if (res != null)
          res.Own = true;
      }

      return result;
    }

    public DataTable GetDataTable<T>(List<ACIHelper> aciHelpers)
    {
      try
      {
        bool user = typeof(T) == typeof(User);

        var definitions = new List<SuperGrid.ColumnDefinition>
                          {
                            new SuperGrid.ColumnDefinition("ACI", "ACI", typeof(ACIHelper), inUI: false),
                            new SuperGrid.ColumnDefinition("Id", "Id", typeof(int), visible: false, editorType: typeof(GridLabelXEditControl)),
                            new SuperGrid.ColumnDefinition("Category", "Category", typeof(string), editorType: typeof(GridLabelXEditControl)),
                            new SuperGrid.ColumnDefinition("Action", "Action", typeof(string), editorType: typeof(GridLabelXEditControl)),
                            new SuperGrid.ColumnDefinition("Granted", "Granted", typeof(bool), editorType: typeof(GridCheckBoxXEditControl))
                          };
        
        if (user)
        {
          definitions.Add(new SuperGrid.ColumnDefinition("GroupGranted", "Granted in group", typeof(bool), editorType: typeof(GridCheckBoxXEditControl), allowEdit: false));
        }


        var dataTable = SuperGrid.DefineGridColumns(
          Translations.UserManagement2Form.AccessControlItems,
          definitions.ToArray()
        );

        dataTable.BeginLoadData();

        foreach (var item in aciHelpers)
        {
          var id = item.Id;
          var category = item.Category;
          var action = item.Action;
          var own = item.Own;
          
          var row = dataTable.NewRow();

          List<object> cells = new List<object>()
                               {
                                 item,
                                 id,
                                 category,
                                 action,
                                 own
                               };

          if (user)
          {
            var group = item.Group;
            cells.Add(group);
          }

          dataTable.Rows.Add(
            cells.ToArray()
          );

          row.AcceptChanges();
        }

        dataTable.EndLoadData();
        return dataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public DataTable GetDataTable(List<AccessControlItem> accessControlItems)
    {
      try
      {

        var definitions = new List<SuperGrid.ColumnDefinition>
                          {
                            new SuperGrid.ColumnDefinition("ACI", "ACI", typeof(AccessControlItem), inUI: false),
                            new SuperGrid.ColumnDefinition("Id", "Id", typeof(int), visible: false, editorType: typeof(GridLabelXEditControl)),
                            new SuperGrid.ColumnDefinition("Category", "Category", typeof(string), editorType: typeof(GridLabelXEditControl)),
                            new SuperGrid.ColumnDefinition("Action", "Action", typeof(string), editorType: typeof(GridLabelXEditControl))
                          };


        var dataTable = SuperGrid.DefineGridColumns(
          Translations.UserManagement2Form.AccessControlItems,
          definitions.ToArray()
        );

        dataTable.BeginLoadData();

        foreach (var item in accessControlItems)
        {
          var id = item.Id;
          var category = item.Category;
          var action = item.Action;

          var row = dataTable.NewRow();

          List<object> cells = new List<object>()
                               {
                                 item,
                                 id,
                                 category,
                                 action
                               };

          

          dataTable.Rows.Add(
            cells.ToArray()
          );

          row.AcceptChanges();
        }

        dataTable.EndLoadData();
        return dataTable;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

    public List<PropertyGridElement> CreatePropertyGridElements(User item)
    {
      var result = new List<PropertyGridElement>();
      try
      {
        if (item == null)
          return result;

        var category = $"01 - {string.Format(Translations.UserManagement2Form.User, item.Name)}";

        result.Add(new PropertyGridElement("User Id", item.Id.ToString(), category, ""));
        result.Add(new PropertyGridElement("Username", item.Username, category, ""));
        result.Add(new PropertyGridElement("First name", item.Name, category, ""));
        result.Add(new PropertyGridElement("Last name", item.SurName, category, ""));
        result.Add(new PropertyGridElement("Account Type", item.AccountType.ToString(), category, ""));
        result.Add(new PropertyGridElement("Domain", item.Domain, category, ""));
        result.Add(new PropertyGridElement("Active", item.IsActive.ToString(), category, ""));

        category = $"02 - {Translations.UserManagement2Form.Properties}";

        var properties = new ViewUserPropertyValues().GetByUser(item.Id).OrderBy(i => i.Name).ToList();

        foreach (var property in properties)
        {
          result.Add(new PropertyGridElement(property.Name, string.IsNullOrEmpty(property.Value) ? property.DefaultValue : property.Value, category, ""));
        }

        category = properties.Any() ? $"03 - {Translations.UserManagement2Form.Groups}" : $"02 - {Translations.UserManagement2Form.Groups}";

        var groups = new Groups().GetByUserId(item.Id);
        
        foreach (var group in groups)
        {
          result.Add(new PropertyGridElement(group.Name, group.Description, category, ""));
        }

        return result;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        result.Add(PropertyGridElement.NoData);
        return result;
      }
    }

    public List<PropertyGridElement> CreatePropertyGridElements(Group item)
    {
      var result = new List<PropertyGridElement>();
      try
      {
        if (item == null)
          return result;

        var category = $"01 - {string.Format(Translations.UserManagement2Form.Group, item.Name)}";

        result.Add(new PropertyGridElement("Group Id", item.Id.ToString(), category, ""));
        result.Add(new PropertyGridElement("Name", item.Name, category, ""));
        result.Add(new PropertyGridElement("Description", item.Description, category, ""));
        result.Add(new PropertyGridElement("Domain Group Identifier", item.DomainGroupIdentifier, category, ""));

        category = $"02 - {Translations.UserManagement2Form.Properties}";

        var properties = new ViewGroupPropertyValues().GetByGroup(item.Id).OrderBy(i => i.Name).ToList();

        foreach (var property in properties)
        {
          result.Add(new PropertyGridElement(property.Name, string.IsNullOrEmpty(property.Value) ? property.DefaultValue : property.Value, category, ""));
        }

        category = properties.Any() ? $"03 - {Translations.UserManagement2Form.Users}" : $"02 - {Translations.UserManagement2Form.Users}";

        var allUsers = new Users().GetAll();
        foreach(UserGroupList userGroup in new UserGroupLists().GetByGroupId(item.Id))
        {
          var user = allUsers.Find(x=>x.Id == userGroup.UserId);
          if (user != null)
          {
            result.Add(new PropertyGridElement(user.Id.ToString(), user.Username, category, ""));
          }
        }

        return result;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        result.Add(PropertyGridElement.NoData);
        return result;
      }
    }

    public List<PropertyGridElement> CreatePropertyGridElements(Computer item)
    {
      var result = new List<PropertyGridElement>();
      try
      {
        if (item == null)
          return result;

        var category = $"01 - {string.Format(Translations.UserManagement2Form.Computer, item.HostName)}";

        result.Add(new PropertyGridElement("Computer Id", item.Id.ToString(), category, ""));
        result.Add(new PropertyGridElement("Host name", item.HostName, category, ""));
        result.Add(new PropertyGridElement("Description", item.Description, category, ""));
        result.Add(new PropertyGridElement("ACI Managed", item.ACIManaged.ToString(), category, ""));

        category = $"02 - {Translations.UserManagement2Form.Properties}";

        var properties = new ViewComputerPropertyValues().GetByComputer(item.Id).OrderBy(i => i.Name).ToList();

        foreach (var property in properties)
        {
          result.Add(new PropertyGridElement(property.Name, string.IsNullOrEmpty(property.Value) ? property.DefaultValue : property.Value, category, ""));
        }

        return result;
      }
      catch (Exception ex)
      {
        Trace.WriteError(ex.Message, Trace.GetMethodName(), CLASSNAME, ex);
        result.Add(PropertyGridElement.NoData);
        return result;
      }
    }

    public class ACIHelper : AccessControlItem
    {
      public ACIHelper(int id, string category, string action, bool own, bool group = false)
        : base(id, category, action)
      {
        Own = own;
        Group = group;
      }

      public bool Own { get; set; }
      public bool Group { get; set; }
    }
  }
}
