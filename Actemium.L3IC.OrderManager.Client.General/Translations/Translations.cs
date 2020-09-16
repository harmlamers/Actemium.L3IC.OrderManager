using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.General.Enums;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.Translations;

namespace Actemium.L3IC.OrderManager.Client.General
{
  [SuppressMessage("ReSharper", "InconsistentNaming")]
  // ReSharper disable once MemberHidesStaticFromOuterClass
  internal static partial class Translations
  {
    #region ApplicationSettingsManagementForm

    internal static class ApplicationSettingsManagementForm
    {
      public static string RibbonBar;
      public static string ApplicationSetting;


      // ReSharper disable once MemberHidesStaticFromOuterClass
      public static void Initialize()
      {
        RibbonBar = Translation.Instance.Translate(nameof(ApplicationSettingsManagementForm), nameof(RibbonBar), "Application setting configuration");
        ApplicationSetting = Translation.Instance.Translate(nameof(ApplicationSettingsManagementForm), nameof(ApplicationSetting), "Application setting");
      }
    }

    #endregion

    #region PropertyGridElements
    internal static class PropertyGridElements
    {
      public static string NoData;
      public static string Unknown;

      public static void Initialize()
      {
        NoData = Translation.Instance.Translate("PropertyGridElements", "NoData", "No data available", new object[0]);
        Unknown = Translation.Instance.Translate("PropertyGridElements", "Unknown", "Unknown", new object[0]);
      }
    }
    #endregion

    #region MainForm

    internal static class MainForm
    {
      private const string KEYNAME = nameof(MainForm);
      public static string ExitClientCaption;
      public static string ExitClientMessage;
      public static string ApplicationStarted;
      public static string NavigationFailed;
      public static string WaitingForInitialisation;
      public static string CheckingForUpdates;
      public static string MultipleUsersForKeyCard;
      public static string UserNotFound;
      public static string UserCannotLogin;
      public static string UserStatusStripLabel;

      public static void Initialize()
      {
        ExitClientCaption = Translation.Instance.Translate(KEYNAME, nameof(ExitClientCaption), "Exit Client");
        ExitClientMessage = Translation.Instance.Translate(KEYNAME, nameof(ExitClientMessage), "Are you sure you want to exit the client?");
        ApplicationStarted = Translation.Instance.Translate(KEYNAME, nameof(ApplicationStarted), "Application started.");
        NavigationFailed = Translation.Instance.Translate(KEYNAME, nameof(NavigationFailed), "Navigation failed to '{0}'.");
        WaitingForInitialisation = Translation.Instance.Translate(KEYNAME, nameof(WaitingForInitialisation), "Waiting for initialisation.....");
        CheckingForUpdates = Translation.Instance.Translate(KEYNAME, nameof(CheckingForUpdates), "Checking for updates...");
        MultipleUsersForKeyCard = Translation.Instance.Translate(KEYNAME, nameof(MultipleUsersForKeyCard), "Multiple users found for keycard: {0}");
        UserNotFound = Translation.Instance.Translate(KEYNAME, nameof(UserNotFound), "User with key: {0} not found");
        UserCannotLogin = Translation.Instance.Translate(KEYNAME, nameof(UserCannotLogin), "User {0} has no permissions to Log in");
        UserStatusStripLabel = Translation.Instance.Translate(KEYNAME, nameof(UserStatusStripLabel), "User :");
      }
    }

    internal static class HomeForm
    {
      private const string KEYNAME = nameof(HomeForm);
      public static string WelcomeLabel;

      public static void Initialize()
      {
        WelcomeLabel = Translation.Instance.Translate(KEYNAME, nameof(WelcomeLabel), "Welcome to the {0}, make a selection in the menu...");
      }
    }

    #endregion

    #region ErrorForm

    internal static class ErrorForm
    {
      private const string KEYNAME = nameof(ErrorForm);
      public static string UnknownError;
      public static string PageNotFound;

      public static void Initialize()
      {
        UnknownError = Translation.Instance.Translate(KEYNAME, nameof(UnknownError), "An unknown error occured during navigation");
        PageNotFound = Translation.Instance.Translate(KEYNAME, nameof(PageNotFound), "The page was not found...");
      }
    }

    #endregion

    #region LogonForm

    internal static class LogonForm
    {
      private const string KEYNAME = nameof(LogonForm);
      public static string NoAuthorisation;

      public static void Initialize()
      {
        NoAuthorisation = Translation.Instance.Translate(KEYNAME, nameof(NoAuthorisation), "User has insufficient rights to log on to the client.");
      }
    }

    #endregion

    #region UserManagementForm

    internal static class UserManagementForm
    {
      private const string KEYNAME = nameof(UserManagementForm);


      public static void Initialize()
      {
      }
    }

    #endregion

    #region ComputerManagementForm

    internal static class ComputerManagementForm
    {
      private const string KEYNAME = nameof(ComputerManagementForm);

      public static void Initialize()
      { 
      }
    }

    #endregion

    #region GroupManagementForm

    internal static class GroupManagementForm
    {
      private const string KEYNAME = nameof(GroupManagementForm);

      public static void Initialize()
      {
      }
    }

    #endregion

    #region UserManagement2Form

    internal static class UserManagement2Form
    {
      private const string KEYNAME = nameof(UserManagement2Form);

      public static string Users;
      public static string Groups;
      public static string Computers;
      public static string User;
      public static string Group;
      public static string Computer;
      public static string Properties;
      public static string AccessControlItems;
      public static string ACIId;
      public static string ACICategory;
      public static string ACIAction;
      public static string ACIGranted;
      public static string ACIGroupGranted;
      public static string GrantAll;
      public static string GrantSelected;
      public static string RevokeAll;
      public static string RevokeSelected;
      public static string ACI;

      public static void Initialize()
      {
        Users = Translation.Instance.Translate(KEYNAME, nameof(Users), "Users");
        Groups = Translation.Instance.Translate(KEYNAME, nameof(Groups), "Groups");
        Computers = Translation.Instance.Translate(KEYNAME, nameof(Computers), "Computers");
        User = Translation.Instance.Translate(KEYNAME, nameof(User), "User: {0}");
        Group = Translation.Instance.Translate(KEYNAME, nameof(Group), "Group: {0}");
        Computer = Translation.Instance.Translate(KEYNAME, nameof(Computer), "Computer: {0}");
        Properties = Translation.Instance.Translate(KEYNAME, nameof(Properties), "Properties");
        AccessControlItems = Translation.Instance.Translate(KEYNAME, nameof(AccessControlItems), "Access Control Items");
        ACIId = Translation.Instance.Translate(KEYNAME, nameof(ACIId), "Id");
        ACICategory = Translation.Instance.Translate(KEYNAME, nameof(ACICategory), "Category");
        ACIAction = Translation.Instance.Translate(KEYNAME, nameof(ACIAction), "Action");
        ACIGranted = Translation.Instance.Translate(KEYNAME, nameof(ACIGranted), "Granted");
        ACIGroupGranted = Translation.Instance.Translate(KEYNAME, nameof(ACIGroupGranted), "Granted via group");
        GrantAll = Translation.Instance.Translate(KEYNAME, nameof(GrantAll), "Grant all");
        GrantSelected = Translation.Instance.Translate(KEYNAME, nameof(GrantSelected), "Grant selected");
        RevokeAll = Translation.Instance.Translate(KEYNAME, nameof(RevokeAll), "Revoke all");
        RevokeSelected = Translation.Instance.Translate(KEYNAME, nameof(RevokeSelected), "Revoke selected");
        ACI = Translation.Instance.Translate(KEYNAME, nameof(ACI), "Acces Control Items");
      }
    }

    #endregion

    #region UserManagement2AddModifyPopupForm

    internal static class UserManagement2AddModifyPopupForm
    {
      private const string KEYNAME = nameof(UserManagement2AddModifyPopupForm);

      public static string AddUser;
      public static string AddGroup;
      public static string AddComputer;

      public static string ModifyUser;
      public static string ModifyGroup;
      public static string ModifyComputer;

      

      public static void Initialize()
      {
        AddUser = Translation.Instance.Translate(KEYNAME, nameof(AddUser), "Add user");
        AddGroup = Translation.Instance.Translate(KEYNAME, nameof(AddGroup), "Add group");
        AddComputer = Translation.Instance.Translate(KEYNAME, nameof(AddComputer), "Add computer");

        ModifyUser = Translation.Instance.Translate(KEYNAME, nameof(ModifyUser), "Modify user: {0}");
        ModifyGroup = Translation.Instance.Translate(KEYNAME, nameof(ModifyGroup), "Modify group: {0}");
        ModifyComputer = Translation.Instance.Translate(KEYNAME, nameof(ModifyComputer), "Modify computer: {0}");
      }
    }

    #endregion

    #region UserProfileForm

    internal static class UserProfileForm
    {
      private const string KEYNAME = nameof(UserProfileForm);

      public static string ChangePassword;

      public static void Initialize()
      {
        ChangePassword = Translation.Instance.Translate(KEYNAME, nameof(ChangePassword), "Change password");
      }
    }

    #endregion

    #region PropertiesPopupForm

    internal static class PropertiesPopupForm
    {
      private const string KEYNAME = nameof(PropertiesPopupForm);
      public static string Property;
      public static string TitleGroup;
      public static string TitleComputer;
      public static string TitleUser;

      public static void Initialize()
      {
        Property = Translation.Instance.Translate(KEYNAME, nameof(Property), "Property");
        TitleGroup = Translation.Instance.Translate(KEYNAME, nameof(TitleGroup), "Properties for group: {0}");
        TitleComputer = Translation.Instance.Translate(KEYNAME, nameof(TitleComputer), "Properties for computer: {0}");
        TitleUser = Translation.Instance.Translate(KEYNAME, nameof(TitleUser), "Properties for user: {0}");
      }
    }

    #endregion

    #region HistoryKeyManagementForm

    internal static class HistoryKeyManagementForm
    {
      private const string KEYNAME = nameof(HistoryKeyManagementForm);
      public static string HistoryKey;

      public static void Initialize()
      {
        HistoryKey = Translation.Instance.Translate(KEYNAME, nameof(HistoryKey), "History Key");
      }
    }

    #endregion

    #region MembershipPopupForm

    internal static class MembershipPopupForm
    {
      private const string KEYNAME = nameof(MembershipPopupForm);
      public static string TitleGroup;
      public static string TitleUser;

      public static void Initialize()
      {
        TitleGroup = Translation.Instance.Translate(KEYNAME, nameof(TitleGroup), "Users in group: {0}");
        TitleUser = Translation.Instance.Translate(KEYNAME, nameof(TitleUser), "Groups for user: {0}");
      }
    }

    #endregion

    #region PeriodFilterUserControl

    internal static class PeriodFilterUserControl
    {
      private const string KEYNAME = nameof(PeriodFilterUserControl);
      public static string ManualSelection;
      public static string Last4Hours;
      public static string Last8Hours;
      public static string Last24Hours;
      public static string Last3Days;
      public static string Last7Days;
      public static string Last14Days;
      public static string Last100Days;
      public static string Next14Days;
      public static string Next7Days;
      public static string Next3Days;
      public static string Next24Hours;
      public static string Next8Hours;
      public static string Next4Hours;
      public static string PastAndNext7Days;
      public static string Past4YearsAndNext7Days;

      public static string Manual;
      public static string Current;

      public static string FilteredFromSelected;
      public static string FilterdFrom;
      public static string FilterdTill;
      public static string NoFilter;

      public static void Initialize()
      {
        ManualSelection = Translation.Instance.Translate(KEYNAME, nameof(ManualSelection), "Manual");
        Last4Hours = Translation.Instance.Translate(KEYNAME, nameof(Last4Hours), "Last 4 hours");
        Last8Hours = Translation.Instance.Translate(KEYNAME, nameof(Last8Hours), "Last 8 hours");
        Last24Hours = Translation.Instance.Translate(KEYNAME, nameof(Last24Hours), "Last 24 hours");
        Last3Days = Translation.Instance.Translate(KEYNAME, nameof(Last3Days), "Last 3 days");
        Last7Days = Translation.Instance.Translate(KEYNAME, nameof(Last7Days), "Last 7 days");
        Last14Days = Translation.Instance.Translate(KEYNAME, nameof(Last14Days), "Last 14 days");
        Last100Days = Translation.Instance.Translate(KEYNAME, nameof(Last100Days), "Last 100 days");
        Next14Days = Translation.Instance.Translate(KEYNAME, nameof(Next14Days), "Next 14 days");
        Next7Days = Translation.Instance.Translate(KEYNAME, nameof(Next7Days), "Next 7 days");
        Next3Days = Translation.Instance.Translate(KEYNAME, nameof(Next3Days), "Next 3 days");
        Next24Hours = Translation.Instance.Translate(KEYNAME, nameof(Next24Hours), "Next 24 hours");
        Next8Hours = Translation.Instance.Translate(KEYNAME, nameof(Next8Hours), "Next 8 hours");
        Next4Hours = Translation.Instance.Translate(KEYNAME, nameof(Next4Hours), "Next 4 hours");
        PastAndNext7Days = Translation.Instance.Translate(KEYNAME, nameof(PastAndNext7Days), "Last and next 7 days");
        Past4YearsAndNext7Days = Translation.Instance.Translate(KEYNAME, nameof(Past4YearsAndNext7Days), "Last 4 years and next 7 days");

        Manual = Translation.Instance.Translate(KEYNAME, nameof(Manual), "(Manual)");
        Current = Translation.Instance.Translate(KEYNAME, nameof(Current), "(Current)");

        FilteredFromSelected = Translation.Instance.Translate(KEYNAME, nameof(FilteredFromSelected), "Period filter - Filtered from {0:dd-MM-yyyy HH:mm} to {1:dd-MM-yyyy HH:mm} {2}");
        FilterdFrom = Translation.Instance.Translate(KEYNAME, nameof(FilterdFrom), "Period filter - Filtered from {0:dd-MM-yyyy HH:mm} {1}");
        FilterdTill = Translation.Instance.Translate(KEYNAME, nameof(FilterdTill), "Period filter - Filtered till {0:dd-MM-yyyy HH:mm} {1}");
        NoFilter = Translation.Instance.Translate(KEYNAME, nameof(NoFilter), "Period filter - No filter used");
      }
    }

    #endregion

    #region PropertyGrid

    internal static class PropertyGrid
    {
      private const string KEYNAME = nameof(PropertyGrid);
      public static string PropertyGridTitle;
      public static string NoData;
      public static string Unknown;

      public static void Initialize()
      {
        PropertyGridTitle = Translation.Instance.Translate(KEYNAME, nameof(PropertyGridTitle), "Properties");
        NoData = Translation.Instance.Translate(nameof(KEYNAME), nameof(NoData), "No data available");
        Unknown = Translation.Instance.Translate(nameof(KEYNAME), nameof(Unknown), "Unknown");
      }
    }

    #endregion

    #region General

    internal static class General
    {
      private const string KEYNAME = nameof(General);
      public static string True;
      public static string False;

      public static string LoadingData;

      public static string Yes;
      public static string No;
      public static string OK;
      public static string Cancel;
      public static string Abort;
      public static string Retry;
      public static string Ignore;

      public static string Error;
      public static string Warning;

      public static string Activate;
      public static string Deactivate;

      public static string Add;
      public static string Modify;
      public static string Delete;

      public static string Manage;

      public static string NoAuthorisation;

      public static string MandatoryData;
      public static string MustBeUnique;

      public static string PasswordMismatch;
      public static string WrongPassword;


      public static void Initialize()
      {
        True = Translation.Instance.Translate(KEYNAME, nameof(True), "True");
        False = Translation.Instance.Translate(KEYNAME, nameof(False), "False");

        LoadingData = Translation.Instance.Translate(KEYNAME, nameof(LoadingData), "Loading data...");

        Yes = Translation.Instance.Translate(KEYNAME, nameof(Yes), "Yes");
        No = Translation.Instance.Translate(KEYNAME, nameof(No), "No");
        OK = Translation.Instance.Translate(KEYNAME, nameof(OK), "OK");
        Cancel = Translation.Instance.Translate(KEYNAME, nameof(Cancel), "Cancel");
        Abort = Translation.Instance.Translate(KEYNAME, nameof(Abort), "Abort");
        Retry = Translation.Instance.Translate(KEYNAME, nameof(Retry), "Retry");
        Ignore = Translation.Instance.Translate(KEYNAME, nameof(Ignore), "Ignore");

        Error = Translation.Instance.Translate(KEYNAME, nameof(Error), "Error");
        Warning = Translation.Instance.Translate(KEYNAME, nameof(Warning), "Warning");

        Activate = Translation.Instance.Translate(KEYNAME, nameof(Activate), "Activate");
        Deactivate = Translation.Instance.Translate(KEYNAME, nameof(Deactivate), "Deactivate");

        Add = Translation.Instance.Translate(KEYNAME, nameof(Add), "Add");
        Modify = Translation.Instance.Translate(KEYNAME, nameof(Modify), "Modify");
        Delete = Translation.Instance.Translate(KEYNAME, nameof(Delete), "Delete");

        Manage = Translation.Instance.Translate(KEYNAME, nameof(Manage), "Manage");

        NoAuthorisation = Translation.Instance.Translate(KEYNAME, nameof(NoAuthorisation), "No authorization");

        MandatoryData = Translation.Instance.Translate(KEYNAME, nameof(MandatoryData), "Mandatory data");
        MustBeUnique = Translation.Instance.Translate(KEYNAME, nameof(MustBeUnique), "Value is not unique");

        PasswordMismatch = Translation.Instance.Translate(KEYNAME, nameof(PasswordMismatch), "Inserted password mismatch...");
        WrongPassword = Translation.Instance.Translate(KEYNAME, nameof(WrongPassword), "Wrong password");
      }
    }

    #endregion

    #region Enums

    internal static class Enums
    {
      public static Dictionary<Enum, string> TranslatedEnumDictionary;

      public static void Initialize()
      {
        TranslatedEnumDictionary = new Dictionary<Enum, string>();

        var query = Assembly.GetExecutingAssembly()
          .GetTypes()
          .Where(t => t.IsEnum && t.IsPublic && t.GetCustomAttribute(typeof(TranslatableEnum)) != null).ToList();

        query.AddRange(Assembly.GetAssembly(typeof(UserManagementProperties))
          .GetTypes()
          .Where(t => t.IsEnum && t.IsPublic && t.GetCustomAttribute(typeof(TranslatableEnum)) != null).ToList());

        foreach (Type t in query)
        {
          var values = Enum.GetValues(t);
          foreach (Enum value in values)
          {
            TranslatedEnumDictionary.Add(value, Translation.Instance.Translate($"Enum_{t.Name}", $"{value}", value.ToString()));
          }
        }
      }
    }

    #endregion

    #region ApplicationSettings

    internal static class ApplicationSettings
    {
      public static Dictionary<int, string> TranslatedApplicationSettingsDescriptionDictionary;
      public static Dictionary<int, string> TranslatedApplicationSettingsNameDictionary;
      public static Dictionary<int, string> TranslatedApplicationSettingsCategoryDictionary;

      public static void Initialize()
      {
        TranslatedApplicationSettingsDescriptionDictionary = new Dictionary<int, string>();
        TranslatedApplicationSettingsNameDictionary = new Dictionary<int, string>();
        TranslatedApplicationSettingsCategoryDictionary = new Dictionary<int, string>();

        var settings = Actemium.ApplicationSettings.Business.ApplicationSettings.Instance.GetAll();
        foreach (var applicationSetting in settings)
        {
          TranslatedApplicationSettingsNameDictionary.Add(applicationSetting.ApplicationSettingId, Translation.Instance.Translate($"AS_{applicationSetting.Name}", "Name", applicationSetting.Name));
          TranslatedApplicationSettingsDescriptionDictionary.Add(applicationSetting.ApplicationSettingId, Translation.Instance.Translate($"AS_{applicationSetting.Name}", "Description", applicationSetting.Description));
        }

        var settingCategories = Actemium.ApplicationSettings.Business.ApplicationSettingsCategories.Instance.GetAll();
        foreach (var applicationSettingCategory in settingCategories)
        {
          TranslatedApplicationSettingsCategoryDictionary.Add(applicationSettingCategory.ApplicationSettingsCategoryId, Translation.Instance.Translate($"AS_Category_{applicationSettingCategory.Name}", "Name", applicationSettingCategory.Name));
        }
      }
    }

    #endregion

    #region Translations

    internal static class TranslationsForm
    {
      private const string KEYNAME = nameof(TranslationsForm);
      public static string TranslationText;

      public static void Initialize()
      {
        TranslationText = Translation.Instance.Translate(KEYNAME, nameof(TranslationText), "Translation");
      }
    }

    #endregion

    #region re_initialize

    private static bool _initialized;

    public static void Initialize()
    {
      try
      {
        if (!_initialized)
        {
          Translation.CurrentLanguageChangedEvent += Translation_CurrentLanguageChangedEvent;

          foreach (var nestedType in typeof(Translations).GetTypeInfo().DeclaredNestedTypes)
          {
            var initializeMethod = (from m in nestedType.DeclaredMethods
                                    where m.Name == "Initialize"
                                          && m.IsStatic
                                    select m).FirstOrDefault();
            initializeMethod?.Invoke(null, null);

            var initializeExtraMethod = (from m in nestedType.DeclaredMethods
                                         where m.Name == "InitializeExtra"
                                               && m.IsStatic
                                         select m).FirstOrDefault();
            initializeExtraMethod?.Invoke(null, null);
          }

          _initialized = true;
          RaiseTranslationsInitializedEvent();
        }
      }
      catch (Exception ex)
      {
        Trace.WriteError("()", nameof(Initialize), nameof(Translations), ex);
        throw new ApplicationException("Failed to initialize translations. Please check the trace-file for more details.", ex);
      }
    }

    private static void ReInitialize()
    {
      if (_initialized)
      {
        Translation.CurrentLanguageChangedEvent -= Translation_CurrentLanguageChangedEvent;
        _initialized = false;
      }
      Initialize();
    }

    private static void Translation_CurrentLanguageChangedEvent(object sender, EventArgs e)
    {
      ReInitialize();
    }

    public delegate void TranslationsInitialized(object sender, EventArgs e);
    public static event Translations.TranslationsInitialized TranslationsInitializedEvent;

    private static void RaiseTranslationsInitializedEvent()
    {
      TranslationsInitializedEvent?.Invoke((object)null, EventArgs.Empty);
    }

        //public static DialogResult DisplayError(this ContainerControl parent, string caption, Exception ex)
        //{
        //  string message = TranslateException(ex);
        //  return parent.DisplayError(caption, new Exception(message));
        //}

        //public static string TranslateException(Exception ex)
        //{
        //  string message;
        //  TranslatableException translatableEx = ex as TranslatableException;
        //  if (translatableEx != null)
        //  {
        //    message = Translation.Instance.Translate(translatableEx.Key, translatableEx.SubKey, translatableEx.Message);
        //    if (translatableEx.Args != null && translatableEx.Args.Any(x => x != null))
        //      message = string.Format(message, translatableEx.Args);
        //  }
        //  else
        //  {
        //    message = ex.Message;
        //  }

        //  return message;
        //}

        #endregion

        #region MasterData

        internal static class MasterData {
            private const string KEYNAME = nameof(MasterData);

            public static string Materials;
            public static string Id;
            public static string Code;
            public static string Description;
            public static string Properties;

            public static void Initialize() {
                Materials = Translation.Instance.Translate(KEYNAME, nameof(Materials), "Materials"); 
                Id = Translation.Instance.Translate(KEYNAME, nameof(Id), "Id");
                Code = Translation.Instance.Translate(KEYNAME, nameof(Code), "Code");
                Description = Translation.Instance.Translate(KEYNAME, nameof(Description), "Description");
                Properties = Translation.Instance.Translate(KEYNAME, nameof(Properties), "Properties");
            }
        }

        #endregion

        #region MasterDataAddModifyPopupForm

        internal static class MasterDataAddModifyPopupForm {
            private const string KEYNAME = nameof(MasterDataAddModifyPopupForm);

            public static string AddMaterial;

            public static string ModifyMaterial;

            public static string MustBeNumeric;

            public static string SelectFromList;

            public static string TooLarge;


            public static void Initialize() {
                AddMaterial = Translation.Instance.Translate(KEYNAME, nameof(AddMaterial), "Add material");

                ModifyMaterial = Translation.Instance.Translate(KEYNAME, nameof(ModifyMaterial), "Modify material: {0}");

                MustBeNumeric = Translation.Instance.Translate(KEYNAME, nameof(MustBeNumeric), "Value is not numeric");

                SelectFromList = Translation.Instance.Translate(KEYNAME, nameof(SelectFromList), "Value must be selected from list");

                TooLarge = Translation.Instance.Translate(KEYNAME, nameof(TooLarge), "Max value = " + Int32.MaxValue.ToString());
            }
        }

        #endregion

        #region MasterDataPropertiesPopupForm

        internal static class MasterDataPropertiesPopupForm {
            private const string KEYNAME = nameof(MasterDataPropertiesPopupForm);

            public static string AddMaterial;

            public static string ModifyMaterial;

            public static string MustBeNumeric;

            public static string SelectFromList;

            public static string TooLarge;


            public static void Initialize() {
                AddMaterial = Translation.Instance.Translate(KEYNAME, nameof(AddMaterial), "Add material");

                ModifyMaterial = Translation.Instance.Translate(KEYNAME, nameof(ModifyMaterial), "Modify material: {0}");

                MustBeNumeric = Translation.Instance.Translate(KEYNAME, nameof(MustBeNumeric), "Value is not numeric");

                SelectFromList = Translation.Instance.Translate(KEYNAME, nameof(SelectFromList), "Value must be selected from list");

                TooLarge = Translation.Instance.Translate(KEYNAME, nameof(TooLarge), "Max value = " + Int32.MaxValue.ToString());
            }
        }

        #endregion

        #region Orders

        internal static class OrdersPage {
            private const string KEYNAME = nameof(OrdersPage);

            public static string Orders;
            public static string Code;
            public static string PlannedStart;
            public static string Resource;
            public static string ArticleNumber;
            public static string Article;
            public static string Quantity;
            public static string StartTime;
            public static string EndTime;

            public static void Initialize() {
                Orders = Translation.Instance.Translate(KEYNAME, nameof(Orders), "Orders");
                Code = Translation.Instance.Translate(KEYNAME, nameof(Code), "Code");
                PlannedStart = Translation.Instance.Translate(KEYNAME, nameof(PlannedStart), "PlannedStart");
                Resource = Translation.Instance.Translate(KEYNAME, nameof(Resource), "Resource");
                ArticleNumber = Translation.Instance.Translate(KEYNAME, nameof(ArticleNumber), "ArticleNumber");
                Article = Translation.Instance.Translate(KEYNAME, nameof(Article), "Article");
                Quantity = Translation.Instance.Translate(KEYNAME, nameof(Quantity), "Quantity");
                StartTime = Translation.Instance.Translate(KEYNAME, nameof(StartTime), "StartTime");
                EndTime = Translation.Instance.Translate(KEYNAME, nameof(EndTime), "EndTime");
            }
        }

        #endregion
    }
}
