using System;
using System.Collections.Generic;
using System.Linq;
using Actemium.Diagnostics;
using Microsoft.Win32;

namespace Actemium.L3IC.OrderManager.Client.General
{

	public class WindowsRegistryHandler
	{
		private const string CLASSNAME = nameof(WindowsRegistryHandler);

		private const string MASTER_REG_KEY = "SOFTWARE\\Actemium\\Client";
		private const string SAVED_USERS_SUB_KEY = "SavedUsers";

		public List<SavedUser> GetAllSavedUsers(out String lastUser)
		{
			var result = new List<SavedUser>();
			lastUser = "";
			RegistryKey masterKey = null;

			try
			{
				masterKey = Registry.CurrentUser.OpenSubKey(MASTER_REG_KEY);
				if (masterKey != null)
				{
					lastUser = masterKey.GetValue("LastUser", "").ToString();
					RegistryKey savedUsersKey = masterKey.OpenSubKey(SAVED_USERS_SUB_KEY);
					if (savedUsersKey != null)
					{
						result.AddRange(from name in savedUsersKey.GetSubKeyNames()
														select savedUsersKey.OpenSubKey(name) into userKey
														where userKey != null
														select new SavedUser(userKey.GetValue("UserName", "").ToString(), "", (int)userKey.GetValue("LastPage", -1)));
					}
				}
			}
			catch (Exception ex)
			{
        Trace.WriteError("Loading user info from registry failed", Trace.GetMethodName(), CLASSNAME, ex);
			}
			finally
			{
			  masterKey?.Close();
			}
			return result;
		}

		public void SaveUser(SavedUser user)
		{
			RegistryKey masterKey = null;

			try
			{
				masterKey = Registry.CurrentUser.CreateSubKey(MASTER_REG_KEY);
				if (masterKey == null)
					return;

				masterKey.SetValue("LastUser", user.Username);

				RegistryKey userKey = masterKey.CreateSubKey($"{SAVED_USERS_SUB_KEY}\\{user.Username}");
				if (userKey == null)
					return;

				userKey.SetValue("UserName", user.Username);
				userKey.SetValue("LastPage", user.LastPage);
			}
			catch (Exception ex)
			{
        Trace.WriteError("Saving user info to registry failed", Trace.GetMethodName(), CLASSNAME, ex);
			}
			finally
			{
			  masterKey?.Close();
			}
		}

		public void SaveLastPage(string userName, int page)
		{
			RegistryKey masterKey = null;

			try
			{
				masterKey = Registry.CurrentUser.CreateSubKey(MASTER_REG_KEY);

			  RegistryKey userKey = masterKey?.CreateSubKey($"{SAVED_USERS_SUB_KEY}\\{userName}");
				if (userKey == null)
					return;

				userKey.SetValue("LastPage", page);
			}
			catch (Exception ex)
			{
        Trace.WriteError("Saving user info to registry failed", Trace.GetMethodName(), CLASSNAME, ex);
			}
			finally
			{
			  masterKey?.Close();
			}
		}

		public void SaveLastUsedServer(string systemName)
		{
			RegistryKey masterKey = null;

			try
			{
				masterKey = Registry.CurrentUser.CreateSubKey(MASTER_REG_KEY);
				if (masterKey == null)
					return;

				masterKey.SetValue("LastUsedServer", systemName);
			}
			catch (Exception ex)
			{
        Trace.WriteError("Saving server info to registry failed", Trace.GetMethodName(), CLASSNAME, ex);
			}
			finally
			{
			  masterKey?.Close();
			}
		}

		public string GetLastUsedServer()
		{
			RegistryKey masterKey = null;

			try
			{
				masterKey = Registry.CurrentUser.OpenSubKey(MASTER_REG_KEY);

				if (masterKey != null)
					return masterKey.GetValue("LastUsedServer", "").ToString();
			}
			catch (Exception ex)
			{
        Trace.WriteError("Loading server info from registry failed", Trace.GetMethodName(), CLASSNAME, ex);
			}
			finally
			{
			  masterKey?.Close();
			}
			return String.Empty;
		}
	}
}
