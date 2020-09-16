using Actemium.UserManagement2;

// ReSharper disable InconsistentNaming

namespace Actemium.L3IC.OrderManager.General.Enums
{
#pragma warning disable RCS1060 // Declare each type in separate file.
  public sealed class ACICategories
#pragma warning restore RCS1060 // Declare each type in separate file.
  {
    // BASE
    public const string GENERAL = "Algemeen";
    
	  // General Configuration and User management (90xx)
	  public const string TRANSLATIONS = "Configuratie - Vertalingen";
	  public const string USERMANAGEMENT = "Gebruikersbeheer - Gebruikers";
	  public const string GROUPMANAGEMENT = "Gebruikersbeheer - Groepen";
	  public const string COMPUTERMANAGEMENT = "Gebruikersbeheer - Computers";
	  public const string APPLICATIONSETTINGSMANAGEMENT = "Configuratie - Settings";
	  public const string HISTORYKEYMANAGEMENT = "Configuratie - History Keys";
	  public const string USERPROFILE = "Configuratie - Gebruikersprofiel";
	  public const string DATAINTEGRATIONMESSAGES = "Diagnostiek - Data Integration Berichten";
	}

#pragma warning disable RCS1060 // Declare each type in separate file.
  public class ACIOptions : ACIOptionsBase
#pragma warning restore RCS1060 // Declare each type in separate file.
  {
    public const string LOGON = "Aanmelden";
    public const string VIEW = "Scherm openen";
		public const string SHOWLOGFILES = "Logbestanden bekijken";
	  public const string OPENPROGRAMFOLDER = "Programma map openen";
	  public const string LOGONAS = "Als een andere gebruiker inloggen";

    public const string SETUPDOMAINGROUPIDENTIFIER = "Domain Group Identifier instellen";
	  public const string SETUPCOMPUTERTOBEACIMANAGED = "ACI Beheerd instellen";
    public const string SHOWPASSWORD = "Wachtwoord zichtbaar maken";
	  public const string CHANGEPASSWORD = "Wachtwoord wijzigen";
    public const string USERCANUSEEMPTYPASSWORD = "Gebruiker mag een leeg wachtwoord gebruiken";
	  public const string CHANGEPROPERTIES = "Eigenschappen wijzigen";

    public const string ACTIVATE = "Activeren";
    public const string DEACTIVATE = "De-Activeren";

	  public const string ADD = "Toevoegen";
    public const string MODIFY = "Wijzigen";
	  public const string DELETE = "Verwijderen";

    public const string PRINT = "Printen";

    public const string SORT = "Sorteren";

    public const string RELEASE = "Vrijgeven";
	  public const string UNRELEASE = "Vrijgave intrekken";
	  public const string BLOCK = "Blokkeren";
	  public const string UNBLOCK = "Blokkering intrekken";
    public const string REJECT = "Afkeuren";
    public const string UNREJECT = "Afkeuring intrekken";
    public const string START = "Starten";
    public const string STARTMANUAL = "Handmatig Starten";
		public const string HOLD = "Onderbreken";
		public const string STOP = "Stoppen";
		public const string PAUSE = "Pause";

	}
}
