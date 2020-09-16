using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actemium.Diagnostics;

namespace Actemium.ApplicationSettings.Business
{
  public class DataSourceListItems
  {

    private const string CLASSNAME = nameof(DataSourceListItems);

    public virtual List<Model.DataSourceListItem> GetListById(Int32 listId)
    {
      try
      {
        DataAccess.DataSourceListItems dataSourceListItems = new DataAccess.DataSourceListItems();
        List<Model.DataSourceListItem> result = dataSourceListItems.GetListById(listId);

        return result;
      }
      catch(Exception ex)
      {
        Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
        throw;
      }
    }

  }
}
