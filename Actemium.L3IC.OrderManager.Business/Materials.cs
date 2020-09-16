using System;
using System.Collections.Generic;
using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Business {
    public partial class Materials : MaterialsGennie {
		public List<Model.Material> GetByCode(Int32 code) {
			try {
				DataAccess.Materials materials = new DataAccess.Materials();
				List<Model.Material> result = materials.GetByCode(code);

				return result;
			}
			catch (Exception ex) {
				Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, code);
				throw;
			}
		}
	}
}
