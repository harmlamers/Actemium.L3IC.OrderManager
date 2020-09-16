using System;
using System.Reflection;
using System.Windows.Forms;
using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
	public partial class SplashScreenForm : Form
	{
		private const string CLASSNAME = nameof(SplashScreenForm);

		public SplashScreenForm()
		{
			InitializeComponent();

			labelProjectName.Text = AssemblyTitle;
      
      var version = new Version(999, 999);
      foreach (AssemblyName assemblyName in Assembly.GetEntryAssembly().GetReferencedAssemblies())
      {
        if (!(assemblyName.Name.Contains(".Client.General") && assemblyName.Name.Contains("Actemium.")))
          continue;

        version = assemblyName.Version;
        break;
      }

#if DEBUG
		  labelRelease.Text = $"Debug {version}";
#else
      labelRelease.Text = $"Release {version}";
#endif


    }

    public void Show(string message)
		{
			try
			{
				labelStatus.Text = message;
				Trace.WriteInformation("('{0}')", Trace.GetMethodName(), CLASSNAME, message);
				Show();
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

		public new void Close()
		{
			base.Close();
		}

		public static string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
			  if (attributes.Length <= 0)
          return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);

        var titleAttribute = (AssemblyTitleAttribute)attributes[0];
			  return titleAttribute.Title != "" ? titleAttribute.Title : System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
			}
		}
	}
}
