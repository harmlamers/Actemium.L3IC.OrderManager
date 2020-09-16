using System;
using System.Collections.Generic;
using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Business
{
  public partial class Resources : ResourcesGennie
  {
    public List<Model.Resource> GetByCode(string code)
    {
      try
      {
        DataAccess.Resources resources = new DataAccess.Resources();
        List<Model.Resource> result = resources.GetByCode(code);

        return result;
      }
      catch (Exception ex)
      {
        Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, code);
        throw;
      }
    }
  }
}
