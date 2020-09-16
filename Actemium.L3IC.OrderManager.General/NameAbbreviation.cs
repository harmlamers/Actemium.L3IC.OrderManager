using Actemium.L3IC.OrderManager.General.Enums;
using System.Linq;

namespace Actemium.L3IC.OrderManager.General
{
  public static class NameAbbreviation
  {
    public static string GetAbbreviation(string firstName, string lastName, NameAbbreviationStyle style)
    {
      if (string.IsNullOrEmpty(lastName))
      {
        //Remove all vowels and '.' except the capitals and take first 3 characters
        const string vowels = "aeiouy.";
        firstName = new string(firstName.Where(c => !vowels.Contains(c)).ToArray());
        return firstName.Substring(0, 3).ToUpperInvariant();
      }
      switch (style)
      {
        case NameAbbreviationStyle.Actemium:
          return $"{firstName.Substring(0,1)}{lastName.Substring(0, 1)}{lastName.Substring(lastName.Length-1, 1)}".ToUpperInvariant();
        case NameAbbreviationStyle.Microsoft:
          return $"{firstName.Substring(0, 1)}{lastName.Substring(0, 1)}".ToUpperInvariant();
        default:
          return null;
      }
    }

    
  }
}
