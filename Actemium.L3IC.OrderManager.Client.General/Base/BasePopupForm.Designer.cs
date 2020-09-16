using Actemium.Diagnostics;
using DevComponents.DotNetBar;

namespace Actemium.L3IC.OrderManager.Client.General.Base
{
	partial class BasePopupForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		  this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BasePopupForm));
		  this.backgroundPanel = new PanelEx();
		  this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
		  this.backgroundPanel.SuspendLayout();
		  ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
      this.SuspendLayout();

		  // 
		  // backgroundPanel
		  // 
		  this.backgroundPanel.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
		  this.backgroundPanel.DisabledBackColor = System.Drawing.Color.Empty;
		  this.backgroundPanel.Dock = System.Windows.Forms.DockStyle.Fill;
		  this.backgroundPanel.Font = new System.Drawing.Font("Tahoma", 8F);
		  this.backgroundPanel.Location = new System.Drawing.Point(0, 0);
		  this.backgroundPanel.Margin = new System.Windows.Forms.Padding(4);
		  this.backgroundPanel.Name = "backgroundPanel";
		  this.backgroundPanel.Size = new System.Drawing.Size(668, 272);
		  this.backgroundPanel.Style.Alignment = System.Drawing.StringAlignment.Center;
		  this.backgroundPanel.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(234)))), ((int)(((byte)(238)))));
		  this.backgroundPanel.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(215)))), ((int)(((byte)(224)))));
		  this.backgroundPanel.Style.Border = DevComponents.DotNetBar.eBorderType.Raised;
		  this.backgroundPanel.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
		  this.backgroundPanel.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
		  this.backgroundPanel.Style.GradientAngle = 90;
		  this.backgroundPanel.TabIndex = 10;
		  // 
		  // errorProvider
		  // 
		  this.errorProvider.ContainerControl = this;
      // 
      // BasePopupForm
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
			this.BackColor = System.Drawing.Color.LightGray;
			this.ClientSize = new System.Drawing.Size(292, 273);
      this.Controls.Add(backgroundPanel);
			this.ControlBox = true;
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BasePopupForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "PopupBaseForm";
			this.Load += new System.EventHandler(this.BasePopupFormLoad);
		  this.backgroundPanel.ResumeLayout(false);
		  ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
      this.ResumeLayout(false);

		}

	  protected DevComponents.DotNetBar.PanelEx backgroundPanel;
	  protected System.Windows.Forms.ErrorProvider errorProvider;

    #endregion
  }
}