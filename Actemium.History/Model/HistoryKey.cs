using System;
using System.Diagnostics;

namespace Actemium.History.Model
{
  public partial class HistoryKey
  {
    public SourceLevels TraceLevelValue
    {
      get => (SourceLevels)Enum.Parse(typeof(SourceLevels), TraceLevel);
      set => TraceLevel = value.ToString();
    }
  }
}
