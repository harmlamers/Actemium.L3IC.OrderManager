using System;
using System.ServiceProcess;
using Actemium.Diagnostics;

namespace CommunicatorERP
{
  static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main()
    {
      AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

#if DEBUG_SERVICE
      Service s = new Service();
      s.DebugService();
      Console.WriteLine("Press S to stop");
      while (Console.ReadKey().KeyChar.ToString().ToUpper() != "S")
      {
        Console.Clear();
        Console.WriteLine("Press S to stop");
      }
#else
      // More than one user Service may run within the same process. To add
      // another service to this process, change the following line to
      // create a second service object. For example,
      //
      //   ServicesToRun = new ServiceBase[] {new Service1(), new MySecondUserService()};
      //

      var ServicesToRun = new ServiceBase[] {
        new Service() 
      };

      ServiceBase.Run(ServicesToRun);
#endif
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      Actemium.Diagnostics.Trace.WriteCritical("UNHANDLED EXCEPTION by {0}. ExceptionObject={1}, IsTerminating={2}", "", Trace.GetMethodName(), sender, e.ExceptionObject, e.IsTerminating);
      System.Threading.Thread.Sleep(1000);
    }
  }
}
