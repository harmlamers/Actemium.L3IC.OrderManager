using System;
using System.ComponentModel;
using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.General.ExtensionMethods
{
  public static class StringExtensionMethods
	{
    private const string CLASSNAME = nameof(StringExtensionMethods);

		public static T? ToNullable<T>(this string s) where T : struct
		{
			var result = new T?();
			try
			{
				if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
				{
					TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
					result = (T)conv.ConvertFrom(s);
				}
			}
		  catch (Exception ex)
		  {
        Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
      }

		  return result;
		}
	}
}
