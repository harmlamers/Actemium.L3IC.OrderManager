using System;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.Translations;
using Actemium.Translations.Business;

namespace Actemium.L3IC.OrderManager.General.Translations
{
	public static class TranslationExtensions
	{
		private const string CLASSNAME = nameof(TranslationExtensions);

		#region public functions

		/// <summary>
		/// Translate a key
		/// </summary>
		public static string Translate(this Translation translation, TranslationKey key, string defaultValue, params object[] args)
		{
			try
			{
        return translation.Translate(nameof(TranslationKey.BusinessLayer), key.ToString(), defaultValue, args);
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0}, {1})", Trace.GetMethodName(), CLASSNAME, ex, key, defaultValue);
				throw new TranslationException(CLASSNAME + $".Translate() failed with error '{ex.Message}'", ex);
			}
		}

		/// <summary>
		/// Translate a key
		/// </summary>
		public static string Translate(this Translation translation, TranslationKey key, TranslationSubKey subKey, string defaultValue, params object[] args)
		{
			try
			{
				return translation.Translate(nameof(TranslationKey.BusinessLayer), $"{key.ToString()}_{subKey.ToString()}", defaultValue, args);
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0}, {1})", Trace.GetMethodName(), CLASSNAME, ex, key, defaultValue);
				throw new TranslationException(CLASSNAME + $".Translate() failed with error '{ex.Message}'", ex);
			}
		}

		/// <summary>
		/// Translate message for form
		/// (Used for variable texts like labels on a form)
		/// </summary>
		public static string Translate(this Translation translation, Form form, TranslationKey key, string defaultValue, params object[] args)
		{
			try
			{
				return translation.Translate(form.Name, key.ToString(), defaultValue, args);
			}
			catch (Exception ex)
			{
				Trace.WriteError("({0}, {1}, {2})", Trace.GetMethodName(), CLASSNAME, ex, form, key, defaultValue);
				throw new TranslationException(CLASSNAME + $".Translate() failed with error '{ex.Message}'", ex);
			}
		}
		

		#endregion




	}
	
}
