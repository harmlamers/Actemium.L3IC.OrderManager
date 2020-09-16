// ReSharper disable InconsistentNaming

namespace Actemium.L3IC.OrderManager.General.Translations
{

  /// <summary>
  /// Attribute to store common messages. This to ensure that the common message is only declared in one place
  /// </summary>
  [System.AttributeUsage(System.AttributeTargets.Field)]
	public class CommonMessageAttribute : System.Attribute
	{
		public string Caption;
		public string Message;

		public CommonMessageAttribute(string message)
		{
			Message = message;
			Caption = "";
		}
	}
}

