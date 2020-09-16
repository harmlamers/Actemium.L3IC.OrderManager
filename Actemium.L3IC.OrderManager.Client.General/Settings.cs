using System.Configuration;
using Actemium.L3IC.OrderManager.General.Configuration;

namespace Actemium.L3IC.OrderManager.Client.General
{
  public sealed class Settings : Actemium.L3IC.OrderManager.General.Configuration.SettingsBase
	{
    private const string CLASSNAME = nameof(Settings);

		#region AppConfig Handling
		static Settings()
		{
			Navigation = (ConfigHandlerNavigation)ConfigurationManager.GetSection("Navigation");
		}

		public static ConfigHandlerNavigation Navigation { get; }
		#endregion
	}
}
