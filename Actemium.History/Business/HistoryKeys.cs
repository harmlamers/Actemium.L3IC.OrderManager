using Actemium.History.Configuration;
using Actemium.History.Model;

namespace Actemium.History.Business
{
  public partial class HistoryKeys
  {
    public HistoryKey GetOrAddHistoryKey(string historyKey)
    {
      var key = GetById(historyKey);
      if (key != null)
        return key;

      key = new HistoryKey(historyKey, SettingsHIST.ShowActionsInClientDefault, SettingsHIST.SaveActionsInDatabaseDefault, SettingsHIST.TraceLevelDefault.ToString());
      Add(key);
      return key;
    }
  }
}
