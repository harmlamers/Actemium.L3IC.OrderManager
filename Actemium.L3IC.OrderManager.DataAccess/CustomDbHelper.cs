using System.Configuration;
using System.Data.Common;
using Actemium.Data.Common;

namespace Actemium.L3IC.OrderManager.DataAccess
{

  internal class CustomDbHelper : DbHelper
  {
    public CustomDbHelper(string connectionString)
      : base(connectionString)
    {
    }

    public CustomDbHelper(ConnectionStringSettings connectionStringSetting)
      : base(connectionStringSetting)
    {
    }

    public CustomDbHelper(string connectionString, DbProviderFactory factory)
      : base(connectionString, factory)
    {
    }
  }
}