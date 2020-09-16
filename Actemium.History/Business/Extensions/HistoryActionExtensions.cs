using System.Collections.Generic;
using Actemium.History.Model;

namespace Actemium.History.Business.Extensions
{
  public static class HistoryActionExtensions
  {
    public static List<object> GetParameterList(this HistoryAction action)
    {
      return HistoryActions.Instance.XML2Parameters(action.Parameters);
    }

    public static object[] GetParameterArray(this HistoryAction action)
    {
      return HistoryActions.Instance.XML2Parameters(action.Parameters).ToArray();
    }
  }
}
