using System;
using System.Drawing;
using System.Linq;
using Actemium.Diagnostics;
using DevComponents.DotNetBar.Rendering;

namespace Actemium.L3IC.OrderManager.Client.General.DevComponentStyles
{
	public static class ButtonX
	{
		private const string CLASSNAME = nameof(ButtonX);
		private const string DEFAULT_COLOR_TABLE_NAME = "OrangeWithBackground";
		private const string RED_COLOR_NAME = "CustomRed";

		private static bool _isInitalized = false;

		public static string Default = "";

		public static string CustomRed
		{
			get
			{
				if (!_isInitalized)
					CreateCustomRedColor();

				return RED_COLOR_NAME;
			}

		}

		private static void CreateCustomRedColor()
		{
			try
			{
				Trace.WriteVerbose("", Trace.GetMethodName(), CLASSNAME);

				var renderer = GlobalManager.Renderer as Office2007Renderer;
				var table = new Office2007ButtonItemColorTable { Name = RED_COLOR_NAME };
				var defaultTable = new Office2007ButtonItemColorTable();

				switch (GlobalManager.Renderer)
				{
				  case Office2007Renderer _ when renderer?.ColorTable.ButtonItemColors.Contains(table.Name) == true:
				    Trace.WriteVerbose("CustomStyle already added", "CreateCustomRedColor", CLASSNAME);
				    return;
				  case Office2007Renderer _ when renderer?.ColorTable.ButtonItemColors.Contains(DEFAULT_COLOR_TABLE_NAME) == true:
				    Office2007ButtonItemColorTable[] tables = new Office2007ButtonItemColorTable[renderer.ColorTable.ButtonItemColors.Count];
				    renderer.ColorTable.ButtonItemColors.CopyTo(tables, 0);
				    defaultTable = tables.First(t => t.Name == DEFAULT_COLOR_TABLE_NAME);
				    break;
				  case Office2007Renderer _:
				    Trace.WriteError("DefaultColorTableName {0} does not exist, some button states can show inconsistent behaviour", Trace.GetMethodName(), CLASSNAME, DEFAULT_COLOR_TABLE_NAME);
				    break;
				}

				table.Checked = defaultTable.Checked;
				table.Disabled = defaultTable.Disabled;
				table.Expanded = defaultTable.Expanded;
				table.MouseOverSplitInactive = defaultTable.MouseOverSplitInactive;

				// Define standard colors when mouse is not over the button
			  table.Default =
			    new Office2007ButtonItemStateColorTable
			    {
			      OuterBorder =
			      {
			        Start = ColorTranslator.FromHtml("#FF6060"),
			        End = ColorTranslator.FromHtml("#FF3F3F")
			      },
			      TopBackground =
			      {
			        Start = ColorTranslator.FromHtml("#FF2626"),
			        End = ColorTranslator.FromHtml("#E10F0F")
			      },
			      BottomBackground =
			      {
			        Start = ColorTranslator.FromHtml("#E10F0F"),
			        End = ColorTranslator.FromHtml("#830F0F")
			      },
			      BottomBackgroundHighlight =
			      {
			        Start = ColorTranslator.FromHtml("#FF6060"),
			        End = Color.Transparent
			      },
			      Text = Color.AntiqueWhite
			    };

			  //// Define colors when mouse is over the button
			  table.MouseOver =
			    new Office2007ButtonItemStateColorTable
			    {
			      OuterBorder =
			      {
			        Start = ColorTranslator.FromHtml("#FF9760"),
			        End = ColorTranslator.FromHtml("#FF813E")
			      },
			      TopBackground =
			      {
			        Start = ColorTranslator.FromHtml("#FF7024"),
			        End = ColorTranslator.FromHtml("#E8580B")
			      },
			      BottomBackground =
			      {
			        Start = ColorTranslator.FromHtml("#E8580B"),
			        End = ColorTranslator.FromHtml("#893A10")
			      },
			      BottomBackgroundHighlight =
			      {
			        Start = ColorTranslator.FromHtml("#FF9760"),
			        End = Color.Transparent
			      },
			      Text = Color.AntiqueWhite
			    };

			  //// Define colors when mouse is pressed
			  table.Pressed =
			    new Office2007ButtonItemStateColorTable
			    {
			      OuterBorder =
			      {
			        Start = ColorTranslator.FromHtml("#FFBE60"),
			        End = ColorTranslator.FromHtml("#FFB13E")
			      },
			      TopBackground =
			      {
			        Start = ColorTranslator.FromHtml("#FFA624"),
			        End = ColorTranslator.FromHtml("#E88E0B")
			      },
			      BottomBackground =
			      {
			        Start = ColorTranslator.FromHtml("#E88E0B"),
			        End = ColorTranslator.FromHtml("#895710")
			      },
			      BottomBackgroundHighlight =
			      {
			        Start = ColorTranslator.FromHtml("#FFBE60"),
			        End = Color.Transparent
			      },
			      Text = Color.AntiqueWhite
			    };

			  if (GlobalManager.Renderer is Office2007Renderer)
				{
					renderer.ColorTable.ButtonItemColors.Add(table);
				}

				_isInitalized = true;
			}
			catch (Exception ex)
			{
				Trace.WriteError("", "CreateCustomRedColor", CLASSNAME, ex);
				throw;
			}
		}


	}
}
