using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Actemium.L3IC.OrderManager.Client.General.Base
{
  public partial class BasePopupForm : BasePageForm
	{
    private const string CLASSNAME = nameof(BasePopupForm);

		public BasePopupForm()
		{
			InitializeComponent();
			StartPosition = FormStartPosition.CenterParent;
		} 

		private void BasePopupFormLoad(object sender, System.EventArgs e)
		{
			Initialize();

		  if (this.Owner is BaseMainForm owner)
			{
				owner.BeforeUserLogoutEvent += OwnerOnBeforeUserLogoutEvent;
				owner.ScreenChangedEvent += OwnerOnScreenChangedEvent;
			}
		}
		

		#region ITranslatableControl

		[Browsable(true)]
		[Category("Actemium")]
		[DefaultValue(true)]
		[Description("Do not translate this control if set to false")]
		public Boolean Translate { get; set; }

		private new Form ParentForm
		{
			get
			{
				if (_parentForm == null)
				{
					_parentForm = FindForm();
					if (_parentForm == null)
						throw new Exception($"Control with name {this.Name} has no parent form.");
				}
				return _parentForm;
			}
		}

		private Form _parentForm = null;
    
		#endregion

		/// <summary>
		/// Close popup before logging out
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void OwnerOnBeforeUserLogoutEvent(object sender, EventArgs eventArgs)
		{
			DialogResult = DialogResult.Cancel;
		}

		/// <summary>
		/// Clsoe popup when changing screen
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="eventArgs"></param>
		private void OwnerOnScreenChangedEvent(object sender, EventArgs eventArgs)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
