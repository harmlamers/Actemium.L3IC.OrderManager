using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General {
    internal static class Program {
        public const string CLASSNAME = nameof(Program);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main() {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomainUnhandledException;

            //Ensure single instance application
            string mutexName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            using (new Mutex(true, mutexName, out var createdNew)) {
                if (createdNew) {
                    //This is the first/single instance
                    #region Main
                    SetupTracing();

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    GlobalHandler.MainForm = new MainForm();
                    Application.Run(GlobalHandler.MainForm);
                    #endregion
                }
                else {
                    //This is NOT the first/single instance.
                    //Find the other/single instance and set that one to the foreground (with finally quitting this instance)
                    var current = System.Diagnostics.Process.GetCurrentProcess();
                    foreach (var process in System.Diagnostics.Process.GetProcessesByName(current.ProcessName)) {
                        if (process.Id == current.Id) {
                            continue;
                        }

                        SetForegroundWindow(process.MainWindowHandle);
                        break;
                    }
                }
            }
        }

        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e) {
            Trace.WriteCritical("UNHANDLED EXCEPTION by {0}. ExceptionObject={1}, IsTerminating={2}", Trace.GetMethodName(), CLASSNAME, sender, e.ExceptionObject, e.IsTerminating);
            if (e.IsTerminating) {
                //Give tracelisteners a change to process the logmessages before terminating
                Thread.Sleep(1000);
            }
        }

        private static void SetupTracing() {
            try {
                Trace.AddTraceSource(new TraceSource("AppTraceSource"));

                var appConfigWatcher = new ConfigTraceSwitchWatcher();
                appConfigWatcher.Changed += ConfigTraceSwitchWatcherChanged;

                Trace.UpdateConfigurationAttributes();
            }
            catch (Exception ex) {
                throw new Exception("Error raised while trying to update the traceSources by their config file settings", ex);
            }
        }

        private static void ConfigTraceSwitchWatcherChanged(object sender, EventArgs e) {
            Trace.UpdateConfigurationAttributes();
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
#pragma warning disable IDE0040 // Add accessibility modifiers
        static extern bool SetForegroundWindow(IntPtr hWnd);
#pragma warning restore IDE0040 // Add accessibility modifiers
    }
}
