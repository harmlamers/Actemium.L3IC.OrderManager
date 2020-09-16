using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Actemium.L3IC.OrderManager.General.ExtensionMethods
{
  public static class XmlDocumentExtensionMethods
	{
    public static string AsString(this XmlDocument xmlDoc)
    {
      var sw = new StringWriter();
      var tx = new XmlTextWriter(sw);
      xmlDoc.WriteTo(tx);
      var strXmlText = sw.ToString().Replace(@"\", @"\\");
      return XDocument.Parse(strXmlText).ToString();
    }
  }
}
