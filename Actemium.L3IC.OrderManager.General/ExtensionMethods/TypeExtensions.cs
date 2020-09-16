using System;

namespace Actemium.L3IC.OrderManager.General.ExtensionMethods
{
  public static class TypeExtensions
  {
    public static Type GetType(this string typeName)
    {
      var type = Type.GetType(typeName);
      if (type != null)
        return type;

      foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
      {
        type = a.GetType(typeName);
        if (type != null)
          return type;
      }
      return null;
    }
  }
}
