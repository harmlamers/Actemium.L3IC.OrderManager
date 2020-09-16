using System;
// ReSharper disable InconsistentNaming

namespace Actemium.L3IC.OrderManager.General.Translations
{
#pragma warning disable RCS1060 // Declare each type in separate file.
                               /// <summary>
                               /// This enum is used as key for custom messages to ensure unique keys in the database.
                               /// </summary>
  public enum TranslationKey
#pragma warning restore RCS1060 // Declare each type in separate file.
  {
    #region General
	  None,
	  BusinessLayer,

    Title,
	  Title_UserProperties,
	  Title_GroupProperties,
	  Title_ComputerProperties,
	  Title_Reserved,

	  PeriodFilter_NoFilter,
	  PeriodFilter_FilteredTill,
	  PeriodFilter_FilteredFrom,
	  PeriodFilter_FilteredFromSelected,
	  PeriodFilter_Manual,
	  PeriodFilter_Current,
	  PeriodFilter_InvalidTime,
	  PeriodFilter_ManualSelection,
	  PeriodFilter_Last100days,
	  PeriodFilter_Last14days,
	  PeriodFilter_Last7days,
	  PeriodFilter_Last3days,
	  PeriodFilter_Last24hours,
	  PeriodFilter_Last8hours,
	  PeriodFilter_Last4hours,
	  PeriodFilter_Next4hours,
	  PeriodFilter_Next8hours,
	  PeriodFilter_Next24hours,
	  PeriodFilter_Next3days,
	  PeriodFilter_Next7days,
	  PeriodFilter_Next14days,
	  PeriodFilter_PastAndNext7Days,
	  PeriodFilter_Past4YearsAndNext7Days,

    #endregion
    
		#region Messages
		Message_ScreenResolution,
		Message_Client_Old_Version,
	  Message_Client_In_MaintenaceMode,
    Message_NoDefaultUserConfigured,
		Message_HelpForAlarmNotFound,
		Message_User_IncorrectPassword,
		Message_User_InsufficientPermissions,
		Message_User_LicensesOccupied,
		Message_UserGroup_ModifyNotAllowed,
		Message_NoConnectionToServer,
		Message_PictureNotFound,
    Message_EmptyPasswordNoLongerAllowed,
		#endregion

		#region Error messages
		Error_Logon_LoginFailed,
		Error_Help_NoHelpDefined,
    Error_ApplicationSettings_InsufficientRights,
	  Error_HistoryKeyManagement_InsufficientRights,
    #endregion

    #region Confirm messages
    Confirm_Client_Exit,
		Confirm_Logoff,
		Confirm_User_Activate,
		Confirm_User_Deactivate,
		Confirm_User_Modify,
		Confirm_UserGroup_Modify,
		Confirm_UserGroup_Delete,
		Confirm_Computer_Delete,
		Confirm_Computer_Modify,
		Confirm_Configuration_Modify,
		Confirm_Translation_Modify,
	  Confirm_ActivateAllowed,
	  Confirm_Material_Add,
	  Confirm_Material_Modify,
	  Confirm_Material_Delete,
    Confirm_Material_DeleteFailed,
    Confirm_Orders_Start,
    Confirm_Orders_Stop,
    #endregion

    #region History actions
    History_ApplicationStarted,
	  History_NavigationFailed,
	  History_Language_Changed,
	  History_Language_Changed_By_User,

    History_ComputerManagementForm_Added,
		History_ComputerManagementForm_Modified,
		History_ComputerManagementForm_Deleted,
    History_ComputerManagementForm_ACIGranted,
    History_ComputerManagementForm_ACIRevoked,

    History_GroupManagementForm_Added,
		History_GroupManagementForm_Modified,
		History_GroupManagementForm_Deleted,
    History_GroupManagementForm_ACIGranted,
    History_GroupManagementForm_ACIRevoked,

    History_LogonForm_LoggedOn,
		History_LogonForm_LoggedOff,
    History_LogonForm_LoginFailed,
    History_Automatic_LogOn,
    History_Automatic_LogOff,
    History_Automatic_ReturnHome,
    History_LogonForm_LoggedOnAs,

    History_UserManagementForm_Added,
		History_UserManagementForm_Modified,
		History_UserManagementForm_Deactivated,
		History_UserManagementForm_Activated,
    History_UserManagementForm_ACIGranted,
	  History_UserManagementForm_ACIRevoked,

	  History_UserProfile_PasswordChanged,

    History_ApplicationSettingsAdministrationForm_Modified,

	  History_HistoryKeyAdministrationForm_ModifiedTraceLevel,
	  History_HistoryKeyAdministrationForm_ModifiedShowInClient,
	  History_HistoryKeyAdministrationForm_ModifiedSaveInDatabase,

    History_PropertiesPopupForm_User_Modified,
    History_PropertiesPopupForm_Group_Modified,
    History_PropertiesPopupForm_Computer_Modified,

	  History_MembershipPopupForm_Added,
	  History_MembershipPopupForm_Deleted,

    History_TranslationsForm_Modified,
    
		#endregion
    
		#region Common messages
		/// <summary>
		/// Common messages are used in multiple places in the code. The CommonMessage attribute ensures that the text is declared on just one place
		/// </summary>
		[CommonMessage("An internal error occured. See trace file for more information.", Caption = "Error")]
		CommonMessage_InternalError,

		[CommonMessage("This action is not allowed. The object might just have been modified.", Caption = "Action not allowed")]
		CommonMessage_JustModified,

		[CommonMessage("No authorization", Caption = "Action not allowed")]
		CommonMessage_NoAuthorization,

		[CommonMessage("Mandatory entry field...")]
		CommonMessage_MandatoryEntryField,

		[CommonMessage("Make a selection...")]
    CommonMessage_MandatorySelectionField,

		[CommonMessage("Query resultVar not of correct objecttype")]
		CommonMessage_InvalidCast,

    [CommonMessage("The entry of a comment is required...")]
    CommonMessage_CommentRequired,

		[CommonMessage("The 'pipe'-symbol ('|') may not be used...")]
		CommonMessage_InvalidPipeSymbolUsage,

		[CommonMessage("The entry has an invalid prefix...")]
		CommonMessage_InvalidPrefix,

		[CommonMessage("The entry has an invalid format")]
		CommonMessage_InvalidFormat,

		[CommonMessage("Invalid time...")]
		CommonMessage_InvalidTime,

		[CommonMessage("Time is in the past...")]
		CommonMessage_TimeInPast,

		[CommonMessage("Time is in the future...")]
		CommonMessage_TimeInFuture,

    [CommonMessage("Palletlabel is being printed.", Caption = "Printing")]
    CommonMessage_LabelPrinting,

    [CommonMessage("Order report is being printed.", Caption = "Printing")]
    CommonMessage_OrderPrinting,

    [CommonMessage("No report available for this order type or status.", Caption = "Invalid option")]
    CommonMessage_NoReport
    #endregion
  }


#pragma warning disable RCS1060 // Declare each type in separate file.
                               /// <summary>
                               /// Extiontion class to extract the enum caption and message
                               /// </summary>
  public static class Enum_ExtiontionMethods
#pragma warning restore RCS1060 // Declare each type in separate file.
  {
		/// <summary>
		/// Returns the caption text from the CommonMessage attribute
		/// </summary>
		public static string GetCommonCaption(this Enum value)
		{
			try
			{
				var fieldInfo = value.GetType().GetField(value.ToString());
				var attributes = (CommonMessageAttribute[])fieldInfo.GetCustomAttributes(typeof(CommonMessageAttribute), false);
				if (attributes.Length > 0)
					return attributes[0].Caption;

				return "";
			}
			catch
			{
				return "";
			}
		}

		/// <summary>
		/// Returns the Message text from the CommonMessage attribute
		/// </summary>
		public static string GetCommonMessage(this Enum value)
		{
			try
			{
				var fieldInfo = value.GetType().GetField(value.ToString());
				var attributes = (CommonMessageAttribute[])fieldInfo.GetCustomAttributes(typeof(CommonMessageAttribute), false);
				if (attributes.Length > 0)
					return attributes[0].Message;

				return "";
			}
			catch
			{
				return "";
			}
		}
	}
}

