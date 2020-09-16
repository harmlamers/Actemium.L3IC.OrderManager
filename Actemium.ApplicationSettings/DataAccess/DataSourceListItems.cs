using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actemium.Data.Common;
using Actemium.Diagnostics;

namespace Actemium.ApplicationSettings.DataAccess
{
  public class DataSourceListItems
  {

    private const string CLASSNAME = nameof(DataSourceListItems);

    public virtual List<Model.DataSourceListItem> GetListById(Int32 listId)
    {
      DbDataReader reader = null;

      try
      {
        var helper = Database.GetDbHelper();
        List<Model.DataSourceListItem> result = new List<Model.DataSourceListItem>();

        if(listId >= 0)
        {
          var ListIdParameter = helper.CreateInputParam("@ListId", listId);
          var SuccessParameter = helper.CreateOutputParam("@Success", DbType.Boolean);
          var ErrorMessageParameter = helper.CreateOutputParam("@ErrorMessage", DbType.String);
          ErrorMessageParameter.Size = 4000;

          reader = helper.ExecuteSPReader(_storedProcedure_GetListById, ListIdParameter, SuccessParameter, ErrorMessageParameter);

          while (reader.Read())
          {
            result.Add(CreateDataSourceList(listId, reader));
          }
        }

        return result;

      }
      catch (Exception ex)
      {
        Trace.WriteError("{0}", Trace.GetMethodName(), CLASSNAME, ex, listId);
        throw DbHelper.TranslateException(ex);
      }

    }

    protected string _storedProcedure_GetListById = "[AS].[DataSources_GetListById]";

    protected virtual Model.DataSourceListItem CreateDataSourceList(Int32 listId, DbDataReader reader)
    {
      try
      {
        Model.DataSourceListItem result = new Model.DataSourceListItem(
          listId,
          (String)reader["Key"],
          (String)reader["Value"]);

        return result;
      }
      catch(Exception ex)
      {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
        throw DbHelper.TranslateException(ex);
      }
    }

  }
}
