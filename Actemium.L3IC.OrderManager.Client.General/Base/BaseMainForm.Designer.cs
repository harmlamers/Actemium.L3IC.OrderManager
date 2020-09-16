using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.Base
{
  partial class BaseMainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.components = new System.ComponentModel.Container();
      this.styleManager = new DevComponents.DotNetBar.StyleManager(this.components);
      this.SuspendLayout();
      // 
      // styleManager
      // 
      this.styleManager.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2007Silver;
      this.styleManager.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(87)))), ((int)(((byte)(154))))));
      // 
      // BaseMainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(205)))), ((int)(((byte)(214)))));
      this.ClientSize = new System.Drawing.Size(292, 273);
      this.EnableGlass = false;
      this.Name = "BaseMainForm";
      this.Text = "Actemium Client";
      this.ResumeLayout(false);

		}

		#endregion

    private DevComponents.DotNetBar.StyleManager styleManager;
	}
}