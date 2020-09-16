using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DevComponents.DotNetBar.SuperGrid;

namespace Actemium.L3IC.OrderManager.Client.General.UserControls.GridEditControls
{
  public partial class GridSourceLevelsComboBoxExEditControl : GridComboBoxExEditControl
  {
    public GridSourceLevelsComboBoxExEditControl()
    {
      InitializeComponent();
      
      ValueMember = "Value";
      DisplayMember = "Display";
      DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      DataSource = new List<SourceLevels>()
                   {
                     SourceLevels.Off,
                     SourceLevels.Verbose,
                     SourceLevels.Information,
                     SourceLevels.Warning,
                     SourceLevels.Error,
                     SourceLevels.Critical
                   }.Select(value => new { Display = value.ToString(), Value = (int)value })
                    .ToList();
    }
  }
}
