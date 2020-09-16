using System;
using System.Collections.Generic;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.Translations.Objects;

namespace Actemium.L3IC.OrderManager.Client.General
{
  public static class GlobalHandler
  {
    public static MainForm MainForm { get; set; }

    public static void AddHistoryAction(TranslationKey translationKey, String description, params object[] messageArgs)
    {
      MainForm.AddHistoryAction(translationKey, description, messageArgs);
    }

    public static bool ShowBusyBox
    {
      set => MainForm.ShowBusyBoxPanel(value);
    }

    public static bool AutoLogout { get; set; }

    public static NavigationItems HomeNavigationItem
    {
      get => _homeNavigationItem;
      set
      {
        if (value != NavigationItems.Error
              && value != NavigationItems.Logon
              && value != NavigationItems.Previous
              && value != NavigationItems.Next)
        {
          _homeNavigationItem = value;
        }
        else
        {
          _homeNavigationItem = NavigationItems.Home;
        }
      }
    }

    private static NavigationItems _homeNavigationItem = NavigationItems.Home;

    public static List<Language> ActiveLanguages()
    {

      var result = new List<Language>();

      var allLanguages = new Actemium.Translations.Business.Languages().GetAll();
      foreach (var language in allLanguages)
      {
        var activeString =
          ApplicationSettings.Business.ApplicationSettings.Instance[nameof(ApplicationSettingsCategories.Languages),$"Language_{language.CultureName.TrimEnd()}_Active"];
        Boolean.TryParse(
          activeString,
          out var active);
        if (active)
        {
          result.Add(language);
        }
      }

      return result;
    }
  }
}
