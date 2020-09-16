using System;
using System.Data.Common;
using System.Collections.Generic;
using Actemium.Diagnostics;
using Actemium.Data.Common;

namespace Actemium.L3IC.OrderManager.DataAccess {
    public partial class Orders : OrdersGennie {
		private readonly string _storedProcedure_GetAllActual = "[dbo].[Orders_GetAllActual]";
		private readonly string _storedProcedure_GetAllHistory = "[dbo].[Orders_GetAllHistory]";
    private readonly string _storedProcedure_GetByCode = "[dbo].[Orders_GetByCode]";

    public List<Model.Order> GetAllActual() {
			DbDataReader reader = null;
			try {
				var helper = Database.GetDbHelper();
				reader = helper.ExecuteSPReader(_storedProcedure_GetAllActual);

				List<Model.Order> result = new List<Model.Order>();
				while (reader.Read()) {
					result.Add(CreateOrder(reader));
				}

				return result;
			}
			catch (Exception ex) {
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw DbHelper.TranslateException(ex);
			}
			finally {
				reader?.Close();
			}
		}

		public List<Model.Order> GetAllHistory() {
			DbDataReader reader = null;
			try {
				var helper = Database.GetDbHelper();
				reader = helper.ExecuteSPReader(_storedProcedure_GetAllHistory);

				List<Model.Order> result = new List<Model.Order>();
				while (reader.Read()) {
					result.Add(CreateOrder(reader));
				}

				return result;
			}
			catch (Exception ex) {
				Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
				throw DbHelper.TranslateException(ex);
			}
			finally {
				reader?.Close();
			}
		}

    public List<Model.Order> GetByCode(string code)
    {
      DbDataReader reader = null;
      try
      {
        var helper = Database.GetDbHelper();
        reader = helper.ExecuteSPReader(_storedProcedure_GetByCode,
              helper.CreateInputParam("@Code", code));

        List<Model.Order> result = new List<Model.Order>();
        while (reader.Read())
        {
          result.Add(CreateOrder(reader));
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
