using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Actemium.ApplicationSettings.Model;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.UserControls.GridEditControls
{
  public partial class GridListComboBoxExEditControl : GridComboBoxExEditControl
  {
    public GridListComboBoxExEditControl(List<DataSourceListItem> inputList)
    {
      InitializeComponent();
      
      ValueMember = "Key";
      DisplayMember = "Value";

      DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      DataSource = inputList.ToList();

    }

    
  }
}
