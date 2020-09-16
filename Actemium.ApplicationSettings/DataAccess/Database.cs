using System;
using System.Data.Common;
using Actemium.ApplicationSettings.Configuration;
using Actemium.Data.Exceptions;
using Actemium.Diagnostics;

namespace Actemium.ApplicationSettings.DataAccess
{
  internal sealed class Database
  {
    private static string _cachedConnectionString;
    private static CustomDbHelper _cachedDbHelper;
    private const String CLASSNAME = nameof(Database);

    /// <summary>
    /// Retrieve the connectionstring from the configuration file
    /// </summary>
    /// <returns></returns>
    public static string GetConnectionString()
    {
      if (_cachedConnectionString != null)
        return _cachedConnectionString;

      var connectionString = SettingsAS.ConnectionStringASDB;

      if (string.IsNullOrEmpty(connectionString))
        throw new DalException("Can't find connectionString in section 'AS' in configuration file");

      Trace.WriteInformation(connectionString, Trace.GetMethodName(), CLASSNAME);
      var csb = new DbConnectionStringBuilder { ConnectionString = connectionString };

      Trace.WriteInformation("Password in connectionstring is encrypted and will be decoded.", Trace.GetMethodName(), CLASSNAME);

      String passwordKey = null;
      if (csb.ContainsKey("Password"))
        passwordKey = "Password";
      else if (csb.ContainsKey("pwd"))
        passwordKey = "pwd";

      if (passwordKey == null)
      {
        Trace.WriteWarning("No password in connectionstring as ('password' or 'pwd').", Trace.GetMethodName(), CLASSNAME);
      }
      else if (csb.TryGetValue(passwordKey, out var pwdBase64))
      {
        try
        {
          csb[passwordKey] = Security.Encryption.Decrypt((string)pwdBase64, EncryptionKeyDefault.Key);
        }
        catch
        {
          Trace.WriteError("Password in connectionstring could not be decrypted.", Trace.GetMethodName(), CLASSNAME);
        }
      }

      _cachedConnectionString = csb.ConnectionString;
      return _cachedConnectionString;
    }

    /// <summary>
    /// Retrieve the DbHelper class
    /// </summary>
    /// <returns></returns>
    public static CustomDbHelper GetDbHelper()
    {
      return _cachedDbHelper ?? (_cachedDbHelper = new CustomDbHelper(GetConnectionString()));
    }
  }
}
