using System;

namespace Actemium.ApplicationSettings.Model
{
  public class DataSourceListItem
  {
    private const string CLASSNAME = nameof(DataSourceListItem);

    public DataSourceListItem()
    {

    }

    public DataSourceListItem(int listId, string key, string value)
    {
      ListId = listId;
      Key = key;
      Value = value;
    }

    public Int32 ListId { get; set; }

    public String Key { get; set; }

    public String Value { get; set; }

    public override string ToString()
    {
      return string.Format("DataSourceListItem:ListId={0}, Key={1}, Value={2}", 
        ListId, Key, Value);
    }

    public override bool Equals(object obj)
    {
      if(obj is DataSourceListItem)
      {
        return (GetHashCode() == obj.GetHashCode());
      }
      return false;
    }

    public override int GetHashCode()
    {
      return (ListId.ToString() + Key).GetHashCode();
    }

  }
}
