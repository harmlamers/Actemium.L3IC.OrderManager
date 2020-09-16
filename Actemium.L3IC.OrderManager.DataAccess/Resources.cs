using System;
using System.Collections.Generic;
using System.Data.Common;
using Actemium.Data.Common;
using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.DataAccess
{
  public partial class Resources : ResourcesGennie
  {
    private readonly string _storedProcedure_GetByCode = "[dbo].[Resources_GetByCode]";

    public List<Model.Resource> GetByCode(string code)
    {
      DbDataReader reader = null;
      try
      {
        var helper = Database.GetDbHelper();
        reader = helper.ExecuteSPReader(_storedProcedure_GetByCode,
              helper.CreateInputParam("@ResourceCode", code));

        List<Model.Resource> result = new List<Model.Resource>();
        while (reader.Read())
        {
          result.Add(CreateResource(reader));
        }
        return result;

      }
      catch (Exception ex)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, code);
        throw DbHelper.TranslateException(ex);
      }
      finally
      {
        reader?.Close();
      }
    }

  }
}
