using System;
using System.Windows.Forms;
using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{

  public static class SplashScreen
	{
		private const string CLASSNAME = nameof(SplashScreen);

		private static SplashScreenForm _splashScreen;

		public static void Show(Form owner, string message, int delayInmSec)
		{
			try
			{
				if (_splashScreen == null)
					_splashScreen = new SplashScreenForm();

				_splashScreen.Owner = owner;
				_splashScreen.Show(message);
				if (delayInmSec > 99)
          System.Threading.Thread.Sleep(delayInmSec);
			}
			catch (Exception ex)
			{
        Trace.WriteError("('{0}')", Trace.GetMethodName(), CLASSNAME, ex, message);
			}
			finally
			{
				Application.DoEvents();
			}
		}

		public static void Close()
		{
		  _splashScreen?.Close();
		  _splashScreen = null;
		}
	}
}
