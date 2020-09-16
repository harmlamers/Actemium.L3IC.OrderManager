using System;
using System.Data.Common;
using System.Collections.Generic;
using Actemium.Diagnostics;
using Actemium.Data.Common;

namespace Actemium.L3IC.OrderManager.DataAccess {
    public partial class Materials : MaterialsGennie {
		private readonly string _storedProcedure_GetByCode = "[dbo].[Materials_GetByCode]";

		public List<Model.Material> GetByCode(Int32 code) {
			DbDataReader reader = null;
			try {
				var helper = Database.GetDbHelper();
				reader = helper.ExecuteSPReader(_storedProcedure_GetByCode,
							helper.CreateInputParam("@Code", code));

				List<Model.Material> result = new List<Model.Material>();
				while (reader.Read()) {
					result.Add(CreateMaterial(reader));
				}
				return result;

			}
			catch (Exception ex) {
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, code);
				throw DbHelper.TranslateException(ex);
			}
			finally {
				reader?.Close();
      }
		}
	}
}
