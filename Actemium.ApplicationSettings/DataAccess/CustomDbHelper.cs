using System.Data.Common;
using Actemium.Data.Common;

namespace Actemium.ApplicationSettings.DataAccess
{

  internal class CustomDbHelper : DbHelper
  {
    public CustomDbHelper(string connectionString)
      : base(connectionString)
    {
    }

    public CustomDbHelper(string connectionString, DbProviderFactory factory)
      : base(connectionString, factory)
    {
    }
  }
}
