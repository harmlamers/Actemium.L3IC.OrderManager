using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Actemium.Diagnostics;
using Actemium.L3IC.OrderManager.Client.General.Base;
using Actemium.L3IC.OrderManager.Client.General.Enums;
using Actemium.L3IC.OrderManager.Client.General.Events;
using Actemium.L3IC.OrderManager.Client.General.ExtensionMethods;
using Actemium.L3IC.OrderManager.Client.General.Pages;
using Actemium.L3IC.OrderManager.Client.General.Pages._10_MasterData;
using Actemium.L3IC.OrderManager.Client.General.Pages._90_Administration;
using Actemium.L3IC.OrderManager.Client.General.PopupPages;
using Actemium.L3IC.OrderManager.General.Translations;
using Actemium.Translations;

namespace Actemium.L3IC.OrderManager.Client.General {
    public class ScreenManagerPanel : Panel {
        private const string CLASSNAME = nameof(ScreenManagerPanel);

        private NavigationItems _activeScreen = NavigationItems.Null;

        private Stack<NavigationItems> _previousScreens = new Stack<NavigationItems>();
        private Stack<NavigationItems> _nextScreens = new Stack<NavigationItems>();

        protected override void Dispose(bool disposing) {
            if (CurrentScreen != null) {
                CurrentScreen.Hide();
                CurrentScreen.DeActivateFromMain();

                foreach (BasePageForm baseFormControl in Controls.OfType<BasePageForm>())
                    baseFormControl.Destroy();
            }

            base.Dispose(disposing);
        }

        protected override void OnResize(EventArgs eventargs) {
            try {
                base.OnResize(eventargs);
                if (CurrentScreen != null) {
                    CurrentScreen.Size = Size;
                }
            }
            catch (Exception ex) {
                Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
            }

        }

        private BasePageForm GetBasePageForm(NavigationItems screen, Boolean autoCreateNew) {
            try {
                if (screen == NavigationItems.Null)
                    return null;

                foreach (BasePageForm baseFormControl in Controls.OfType<BasePageForm>()) {
                    if (baseFormControl.NavigationItem != screen)
                        continue;

                    Trace.WriteVerbose("Form found in existing pool '{0}'.", Trace.GetMethodName(), CLASSNAME, screen);
                    return baseFormControl;
                }

                if (!autoCreateNew) {
                    Trace.WriteInformation("Form not found in existing pool '{0}' and not auto created.", Trace.GetMethodName(), CLASSNAME, screen);
                    return null;
                }

                //If none can be found, create a new instancce and add it to the main-panel
                var newControlBaseForm = CreateNewScreenForm(screen);
                if (newControlBaseForm == null)
                    throw new ApplicationException("No screen created: " + screen.ToString());

                newControlBaseForm.Dock = DockStyle.Fill;
                newControlBaseForm.TopLevel = false;
                Controls.Add(newControlBaseForm);

                Trace.WriteInformation("Form not found in existing pool '{0}' and is newly created and added to the pool.", Trace.GetMethodName(), CLASSNAME, screen);
                return newControlBaseForm;

            }
            catch (Exception ex) {
                Trace.WriteError("({0}, {1})", Trace.GetMethodName(), CLASSNAME, ex, screen, autoCreateNew);
                return null;
            }
        }

        public bool SetMainWindow(NavigationItems screen) {
            return SetMainWindow(screen, EventArgs.Empty);
        }

        public bool SetMainWindow(NavigationItems screen, EventArgs e) {
            try {
                Trace.WriteVerbose("({0})", Trace.GetMethodName(), CLASSNAME, screen);

                DoubleBuffered = true;
                SuspendLayout();

                if (CurrentScreen != null) {
                    // Is it allowed to exit the currently loaded screen? If not, exit this function immediately.
                    if (CurrentScreen.DoDeActivateAllowed() == false) {
                        if (Confirm(TranslationKey.Confirm_ActivateAllowed, "Screen navigation", "When continuing navigation, all non-saved changes will be lost.\r\n\r\nDo you want to continue?", MessageBoxButtons.YesNo) == DialogResult.No)
                            return true;
                    }

                    CurrentScreen.Hide();
                    CurrentScreen.DoDeActivateFromMain();
                }

                var newscreen = GetBasePageForm(screen, true);
                if (newscreen != null) {
                    newscreen.DoActivateFromMain(e);
                    newscreen.Size = new Size(Width, Height);
                    newscreen.Show();
                    newscreen.Dock = DockStyle.Fill;
                    newscreen.DoSetFocus();
                    newscreen.Refresh();
                    newscreen.BringToFront();
                    newscreen.DoActivatedFromMain(e);

                    Trace.WriteInformation("({0})", Trace.GetMethodName(), CLASSNAME, newscreen.Name);
                }

                _activeScreen = screen;

                bool doPush = false;
                if (_previousScreens.Count == 0)
                    doPush = true;
                else if (_previousScreens.Peek() != screen)
                    doPush = true;
                if (doPush && !screen.GetExcludeFromStack())
                    _previousScreens.Push(screen);

                return true;
            }
            catch (Exception ex) {
                Trace.WriteError("({0})", Trace.GetMethodName(), CLASSNAME, ex, screen);
                MessageBox.Show(ex.Message);
                if (screen != NavigationItems.Home && screen != NavigationItems.Logon)
                    SetMainWindow(NavigationItems.Home);

                return false;
            }
            finally {
                RaiseScreenChanged(screen);
                ResumeLayout();
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PreviousScreensCount => _previousScreens.Count;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int NextScreensCount => _nextScreens.Count;

        public void GoToHome() {
            try {
                _previousScreens = new Stack<NavigationItems>();
                _nextScreens = new Stack<NavigationItems>();

                SetMainWindow(GlobalHandler.HomeNavigationItem);
            }
            catch (Exception ex) {
                Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        public void GoToTest() {
            try {
                //_previousScreens = new Stack<NavigationItems>();
                //_nextScreens = new Stack<NavigationItems>();

                SetMainWindow(NavigationItems.Test);
            }
            catch (Exception ex) {
                Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        public void GoToNewProjectScreen() {
            try {
                //_previousScreens = new Stack<NavigationItems>();
                //_nextScreens = new Stack<NavigationItems>();

                SetMainWindow(NavigationItems.NewProjectForm);
            }
            catch (Exception ex) {
                Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        public void GoToPreviousScreen() {
            try {
                if (_previousScreens.Count <= 1)
                    return;
                // Ignore screens which are excluded from the navigation stack
                if (!_activeScreen.GetExcludeFromStack()) {
                    //Pop the stack so that the current page is removed from the stack
                    NavigationItems currentScreen = _previousScreens.Pop();

                    //And push it on the NextScreen-stack
                    _nextScreens.Push(currentScreen);
                }

                //Peek the stack so that the previous screen remains in the stack					
                NavigationItems previousScreen = _previousScreens.Peek();

                SetMainWindow(previousScreen);
            }
            catch (Exception ex) {
                Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        public void GoToNextScreen() {
            try {
                if (_nextScreens.Count <= 0)
                    return;
                //Pop the stack so that the current page is removed from the stack
                NavigationItems nextScreen = _nextScreens.Pop();

                SetMainWindow(nextScreen);
            }
            catch (Exception ex) {
                Trace.WriteError("()", Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        public NavigationItems PreviousScreen => _previousScreens.Peek();

        public void RefreshScreen() {
            try {
                CurrentScreen?.Refresh();
            }
            catch (Exception ex) {
                Trace.WriteError("", Trace.GetMethodName(), CLASSNAME, ex);
                throw;
            }
        }

        private BasePageForm CreateNewScreenForm(NavigationItems screen) {
            switch (screen) {
                // BASE
                case NavigationItems.Logon:
                    return new LogonForm();
                case NavigationItems.NoSelection:
                case NavigationItems.Home:
                    return new HomeForm();
                case NavigationItems.Error:
                    return new ErrorForm(true);
                case NavigationItems.UserProfile:
                    return new UserProfileForm();

                case NavigationItems.ApplicationSettings:
                    return new ApplicationSettingsManagementForm(screen);
                case NavigationItems.UserManagement:
                    return new UserManagement2Form(screen);
                //return new UserManagementForm();
                case NavigationItems.HistoryKeyManagement:
                    return new HistoryKeyManagementForm(screen);
                case NavigationItems.GroupManagement:
                    return new UserManagement2Form(screen);
                //return new GroupManagementForm();
                case NavigationItems.ComputerManagement:
                    return new UserManagement2Form(screen);
                //return new ComputerManagementForm();
                case NavigationItems.Translations:
                    return new TranslationsForm();

                // MASTERDATA
                case NavigationItems.MasterData:
                    return new MasterData();

                // ORDERS
                case NavigationItems.ActualOrders:
                    return new OrdersPage(screen);
                case NavigationItems.FinishedOrders:
                    return new OrdersPage(screen);

                // Remaining
                default:
                    return new ErrorForm(false);
            }
        }

        public event ScreenChangedHandler ScreenChanged;

        private void RaiseScreenChanged(NavigationItems screen) {
            ScreenChanged?.Invoke(this, new ScreenChangedEventArgs(screen));
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BasePageForm CurrentScreen => GetBasePageForm(_activeScreen, false);

        public virtual DialogResult Confirm(TranslationKey translationKey, string caption, string message, MessageBoxButtons buttons, params object[] messageArgs) {
            // translate
            caption = Translation.Instance.Translate(translationKey, TranslationSubKey.Caption, caption);
            message = Translation.Instance.Translate(translationKey, TranslationSubKey.Message, message, messageArgs);

            const MessageBoxIcon icon = MessageBoxIcon.Question;

            Trace.WriteInformation("CONFIRM DIALOG SHOW: Display='{0}', Message='{1}', Buttons={2}", Trace.GetMethodName(), CLASSNAME, Text, message, buttons);
            int timestamp = Environment.TickCount;

            DialogResult result = new MessageBoxForm(caption, message, buttons, icon, null).ShowDialog(this);
            Trace.WriteInformation("CONFIRM DIALOG ACK: Display='{0}', Ack Time={1} [ms], Message='{2}', Buttons={3}, Response={4}", Trace.GetMethodName(), CLASSNAME, Text, Environment.TickCount - timestamp, message, buttons, result);

            return result;
        }
    }
}

