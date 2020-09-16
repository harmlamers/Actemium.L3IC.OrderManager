using System;
using System.Configuration;
using System.Data.Common;
using Actemium.Data.Exceptions;
using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.DataAccess
{
  internal sealed class Database
  {
    private static DbProviderFactory _cachedFactory;
    private static string _cachedConnectionString;
    private static CustomDbHelper _cachedDbHelper;
    private const String CLASSNAME = nameof(Database);

    /// <summary>
    /// Get the connection for the database
    /// </summary>
    /// <returns></returns>
    public static DbProviderFactory GetFactory()
    {
      if (_cachedFactory == null)
      {
        if (string.IsNullOrEmpty(ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString))
          throw new DalException("Can't find connectionString AppConnection in configuration file");

        _cachedFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings["AppConnection"].ProviderName);
      }
      return _cachedFactory;
    }

    /// <summary>
    /// Retrieve the connectionstring from the configuration file
    /// </summary>
    /// <returns></returns>
    public static string GetConnectionString()
    {
      string connectionString;

      if (_cachedConnectionString == null)
      {
        connectionString = ConfigurationManager.ConnectionStrings["AppConnection"].ConnectionString;
      }
      else
      {
        return _cachedConnectionString;
      }

      if (string.IsNullOrEmpty(connectionString))
        throw new DalException("Can't find connectionString AppConnection in configuration file");

      Trace.WriteInformation(connectionString, Trace.GetMethodName(), CLASSNAME);
      var csb = new DbConnectionStringBuilder { ConnectionString = connectionString };

      Trace.WriteInformation("Password in connectionstring is encrypted and will be decoded.", Trace.GetMethodName(),
        CLASSNAME);

      if (csb.TryGetValue("Password", out var pwdBase64))
      {
        csb["Password"] = Security.Encryption.Decrypt((string)pwdBase64, EncryptionKeyDefault.Key);
      }

      _cachedConnectionString = csb.ConnectionString;
      return csb.ConnectionString;
    }

    /// <summary>
    /// Retrieve the DbHelper class
    /// </summary>
    /// <returns></returns>
    public static CustomDbHelper GetDbHelper()
    {
      return _cachedDbHelper ?? (_cachedDbHelper = new CustomDbHelper(GetConnectionString(), GetFactory()));
    }
  }
}
