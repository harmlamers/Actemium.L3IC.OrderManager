using Actemium.L3IC.OrderManager.General.Translations;

namespace Actemium.L3IC.OrderManager.General.Enums
{
  [TranslatableEnum]
  public enum UserManagementProperties
  {
    //General (1xxx)

    //User (1xx)
    UserPreferredLanguage = 100,
    UserMenuBarDefaultExpanded = 101,

    //Computer (2xx)
    ComputerDefaultNavigationItem = 200,
    ComputerDefaultUser = 201,
    ComputerAutoLogoutTime = 202,
    ComputerTimeFormat = 203,
    ComputerPathToServerRoot = 204,
    ComputerLogFileLocation = 205,
    ComputerDefaultLanguage = 206,
    ComputerMenuBarDefaultExpanded = 207,
    ComputerMaxDetachedForms = 208,

    //Group (3xx)
  }
}
