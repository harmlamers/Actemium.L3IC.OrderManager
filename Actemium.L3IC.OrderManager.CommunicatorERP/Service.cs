using Actemium.Services.WCF;

namespace CommunicatorERP
{
  public partial class Service : ServiceBaseWCF
  {
    private const string TRACE_NAME = "CommunicatorERP";
    public Service() : base(TRACE_NAME)
    {
      InitializeComponent();
    }

    protected override void SetupServiceThreads()
    {
      base.SetupServiceThreads();
      ERPImportWorker worker = new ERPImportWorker();
      ServiceThreads.Add(worker);
    }
  }
}
