using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.Translations;
using DevComponents.DotNetBar;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  public partial class MessageBoxForm : BasePageForm
	{
		private const string CLASSNAME = nameof(MessageBoxForm);

		public string UserInput { get; set; }

    public sealed override string Text
    {
      get => base.Text;
      set => base.Text = value;
    }

    private MessageBoxForm()
		{
			InitializeComponent();

			//Remove minimize and maximize buttons
			ArrayList items = ribbonControl.RibbonStrip.GetItems("", typeof(SystemCaptionItem));
			foreach (SystemCaptionItem sci in items)
			{
			  if (sci.IsSystemIcon)
          continue;

        sci.MinimizeVisible = false;
			  sci.RestoreMaximizeVisible = false;
			  break;
			}
		}

		public MessageBoxForm(string caption, string message, MessageBoxButtons buttons, MessageBoxIcon icon, string labelTextForInputField)
			: this()
		{
			panel1.Visible = labelTextForInputField != null;
			lblbInputText.Text = labelTextForInputField;
			Text = caption;
			messageLabel.Font = message.Length > 350
				? new Font("Tahoma", 8F, FontStyle.Regular, GraphicsUnit.Point, 0)
				: new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			messageLabel.Text = message;

			SetButtons(buttons);

			switch (icon)
			{
				case MessageBoxIcon.Information:
					pictureBoxIcon.Image = Properties.Resources.IE_Comment_32;
					break;
				case MessageBoxIcon.None:
					break;
				case MessageBoxIcon.Question:
					pictureBoxIcon.Image = Properties.Resources.IE_Help_32;
					break;
				case MessageBoxIcon.Error:
					pictureBoxIcon.Image = Properties.Resources.IE_ApplicationExit_32;
					break;
				case MessageBoxIcon.Warning:
					pictureBoxIcon.Image = Properties.Resources._Exclamation;
					break;

			  default:
			    throw new ArgumentOutOfRangeException(nameof(icon), icon, null);
			}
		}

    private void MessageBoxFormActivated(object sender, EventArgs e)
    {
      if (tbUserInput.Visible)
      {
        tbUserInput.Focus();
      }
    }

	  private void SetButtons(MessageBoxButtons buttons)
		{
			switch (buttons)
		  {
			  case MessageBoxButtons.OK:
			    button3.DialogResult = DialogResult.OK;
			    button3.Text = Translation.IsInitialized ? Translations.General.OK : "Ok";
			    button3.Image = Properties.Resources.IE_OK_32;

			    button1.Visible = false;
				  button2.Visible = false;
			    button3.Visible = true;
				  break;

			  case MessageBoxButtons.OKCancel:
				  button2.DialogResult = DialogResult.OK;
					button2.Text = Translation.IsInitialized ? Translations.General.OK : "Ok";
			    button2.Image = Properties.Resources.IE_OK_32;

				  button3.DialogResult = DialogResult.Cancel;
					button3.Text = Translation.IsInitialized ? Translations.General.Cancel : "Cancel";
			    button3.Image = Properties.Resources.IE_ApplicationExit_32;

          button1.Visible = false;
			    button2.Visible = true;
			    button3.Visible = true;
          break;

			  case MessageBoxButtons.YesNo:
          button2.DialogResult = DialogResult.Yes;
			    button2.Text = Translation.IsInitialized ? Translations.General.Yes : "Yes";
			    button2.Image = Properties.Resources.IE_OK_32;

			    button3.DialogResult = DialogResult.No;
			    button3.Text = Translation.IsInitialized ? Translations.General.No : "No";
			    button3.Image = Properties.Resources.IE_ApplicationExit_32;

			    button1.Visible = false;
			    button2.Visible = true;
			    button3.Visible = true;
          break;
		    case MessageBoxButtons.AbortRetryIgnore:
		      button1.DialogResult = DialogResult.Abort;
		      button1.Text = Translation.IsInitialized ? Translations.General.Abort : "Abort";
		      button1.Image = Properties.Resources.IE_ApplicationExit_32;

		      button2.DialogResult = DialogResult.Retry;
		      button2.Text = Translation.IsInitialized ? Translations.General.Retry : "Retry";
		      button2.Image = Properties.Resources.IE_Refresh_32;

		      button3.DialogResult = DialogResult.Ignore;
		      button3.Text = Translation.IsInitialized ? Translations.General.Ignore : "Ignore";
		      button3.Image = Properties.Resources.IE_OK_32;

          button1.Visible = true;
		      button2.Visible = true;
		      button3.Visible = true;
		      break;
        case MessageBoxButtons.YesNoCancel:
          button1.DialogResult = DialogResult.Yes;
          button1.Text = Translation.IsInitialized ? Translations.General.Yes : "Yes";
          button1.Image = Properties.Resources.IE_OK_32;

          button2.DialogResult = DialogResult.No;
          button2.Text = Translation.IsInitialized ? Translations.General.No : "No";
          button2.Image = Properties.Resources.IE_ApplicationExit_32;

          button3.DialogResult = DialogResult.Cancel;
          button3.Text = Translation.IsInitialized ? Translations.General.Cancel : "Cancel";
          button3.Image = Properties.Resources.IE_ApplicationExit_32;

          button1.Visible = true;
          button2.Visible = true;
          button3.Visible = true;
          break;
        case MessageBoxButtons.RetryCancel:
          button2.DialogResult = DialogResult.Retry;
          button2.Text = Translation.IsInitialized ? Translations.General.Retry : "Retry";
          button2.Image = Properties.Resources.IE_Refresh_32;

          button3.DialogResult = DialogResult.Cancel;
          button3.Text = Translation.IsInitialized ? Translations.General.Cancel : "Cancel";
          button3.Image = Properties.Resources.IE_ApplicationExit_32;

          button1.Visible = false;
          button2.Visible = true;
          button3.Visible = true;
          break;
        default:
		      throw new ArgumentOutOfRangeException(nameof(buttons), buttons, null);
		  }
		}

		private void RegisterUserInput(object sender, EventArgs e)
		{
			UserInput = tbUserInput.Text;
		}
  }
}
