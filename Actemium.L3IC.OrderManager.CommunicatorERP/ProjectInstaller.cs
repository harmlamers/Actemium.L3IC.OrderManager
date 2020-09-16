using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace Actemium.L3IC.OrderManager.CommunicatorERP
{
  [RunInstaller(true)]
  public partial class ProjectInstaller : System.Configuration.Install.Installer
  {
    public ProjectInstaller()
    {
      InitializeComponent();
    }
  }
}
