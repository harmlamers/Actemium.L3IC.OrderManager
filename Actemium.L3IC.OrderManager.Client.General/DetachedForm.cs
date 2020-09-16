using System;
using System.Windows.Forms;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.Diagnostics;
using Actemium.UserManagement2;
using Actemium.L3IC.OrderManager.General;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.Translations;
using Actemium.L3IC.OrderManager.General.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Actemium.L3IC.OrderManager.Client.General
{
  public partial class DetachedForm : BaseMainForm
  {
    private const string CLASSNAME = nameof(DetachedForm);
    private BasePageForm _screen;
    public EventHandler DetachedFormClosed;
    public MainForm _mainForm;

    public DetachedForm(MainForm mainForm)
    {
      InitializeComponent();
      _mainForm = mainForm;
      Translation.CurrentLanguageChangedEvent += Translation_CurrentLanguageChangedEvent;
    }

    private void Translation_CurrentLanguageChangedEvent(object sender, EventArgs e)
    {
      headerLabel.Text = _screen.TranslatedTitle;
    }

    public override void Refresh()
    {
      _screen.Refresh();
      base.Refresh();
    }


    public void Attach(BasePageForm screen)
    {
      _screen = screen;
      screen.Dock = DockStyle.Fill;
      screen.TopLevel = false;
      mainPanel.Controls.Add(screen);
      headerLabel.Text = screen.TranslatedTitle;
    }

    private void DetachedForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      OnDetachedFormClosed();
    }

    private void OnDetachedFormClosed()
    {
      if (DetachedFormClosed != null)
        DetachedFormClosed(this, EventArgs.Empty);
    }

    public void OnLogon()
    {
      try
      {
        loggedOffLabel.Visible = false;

        if (CurrentUser.HasPermission(_screen.ACICategory, ACIOptions.VIEW))
        {
          noAuthorizationLabel.Visible = false;
          _screen.Visible = true;
          _screen.ActivateFromMain(new EventArgs());
        }
        else
          noAuthorizationLabel.Visible = true;
      }
      catch (Exception ex)
      {
        Trace.WriteError("", nameof(OnLogon), CLASSNAME, ex);
      }
    }

    public void OnLogoff()
    {
      try
      {
        loggedOffLabel.Visible = true;
        noAuthorizationLabel.Visible = false;
        _screen.Visible = false;
        _screen.DeActivateFromMain();
      }
      catch (Exception ex)
      {
        Trace.WriteError("", nameof(OnLogoff), CLASSNAME, ex);
      }
    }

    private void DetachedForm_Load(object sender, EventArgs e)
    {
      Initialize();
    }

    private void DetachedForm_KeyDown(object sender, KeyEventArgs e)
    {
      _mainForm.MainFormKeyDown(sender, e);
    }
  }
}

