using System;
using System.Reflection;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  public partial class AboutForm : Actemium.Windows.Forms.AboutForm
  {
    public AboutForm() : base()
    {
      InitializeComponent();
      if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
      {
        System.Version publishVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
        lblReleaseVersion.Text = String.Format("Publish version: {0}", publishVersion);
        lblReleaseVersion.Visible = true;
      }
      else
      {
        lblReleaseVersion.Visible = false;
      }
    }

    public AboutForm(Assembly currentAssembly, bool showLogFiles = false) : base(currentAssembly, showLogFiles)
    {
      InitializeComponent();
      if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
      {
        System.Version publishVersion = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
        lblReleaseVersion.Text = String.Format("Publish version: {0}", publishVersion);
        lblReleaseVersion.Visible = true;
      }
      else
      {
        lblReleaseVersion.Visible = false;
      }
    }
  }
}
