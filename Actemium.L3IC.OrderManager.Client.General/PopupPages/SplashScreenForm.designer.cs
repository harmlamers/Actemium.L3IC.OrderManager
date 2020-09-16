using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
	partial class SplashScreenForm
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
      this.panel2 = new System.Windows.Forms.Panel();
      this.labelRelease = new System.Windows.Forms.Label();
      this.labelProjectName = new System.Windows.Forms.Label();
      this.labelActemium = new System.Windows.Forms.Label();
      this.labelStatus = new System.Windows.Forms.Label();
      this.panel2.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.Transparent;
      this.panel2.BackgroundImage = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources._ActemiumSplashscreen;
      this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel2.Controls.Add(this.labelRelease);
      this.panel2.Controls.Add(this.labelProjectName);
      this.panel2.Controls.Add(this.labelActemium);
      this.panel2.Controls.Add(this.labelStatus);
      this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panel2.Location = new System.Drawing.Point(0, 0);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(550, 319);
      this.panel2.TabIndex = 0;
      // 
      // labelRelease
      // 
      this.labelRelease.BackColor = System.Drawing.Color.Transparent;
      this.labelRelease.Font = new System.Drawing.Font("Gill Sans MT", 12F, System.Drawing.FontStyle.Bold);
      this.labelRelease.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(140)))));
      this.labelRelease.Location = new System.Drawing.Point(17, 206);
      this.labelRelease.Name = "labelRelease";
      this.labelRelease.Size = new System.Drawing.Size(300, 23);
      this.labelRelease.TabIndex = 11;
      this.labelRelease.Text = "[Release xxx]";
      // 
      // labelProjectName
      // 
      this.labelProjectName.AutoSize = true;
      this.labelProjectName.BackColor = System.Drawing.Color.Transparent;
      this.labelProjectName.Font = new System.Drawing.Font("Gill Sans MT", 16F, System.Drawing.FontStyle.Bold);
      this.labelProjectName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(140)))));
      this.labelProjectName.Location = new System.Drawing.Point(15, 152);
      this.labelProjectName.Name = "labelProjectName";
      this.labelProjectName.Size = new System.Drawing.Size(179, 31);
      this.labelProjectName.TabIndex = 9;
      this.labelProjectName.Text = "#ProjectName#";
      // 
      // labelActemium
      // 
      this.labelActemium.AutoSize = true;
      this.labelActemium.BackColor = System.Drawing.Color.Transparent;
      this.labelActemium.Font = new System.Drawing.Font("Gill Sans MT", 16F, System.Drawing.FontStyle.Bold);
      this.labelActemium.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(140)))));
      this.labelActemium.Location = new System.Drawing.Point(15, 117);
      this.labelActemium.Name = "labelActemium";
      this.labelActemium.Size = new System.Drawing.Size(354, 31);
      this.labelActemium.TabIndex = 8;
      this.labelActemium.Text = "Actemium";
      // 
      // labelStatus
      // 
      this.labelStatus.BackColor = System.Drawing.Color.Transparent;
      this.labelStatus.Font = new System.Drawing.Font("Gill Sans MT", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.labelStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(63)))), ((int)(((byte)(140)))));
      this.labelStatus.Location = new System.Drawing.Point(11, 262);
      this.labelStatus.Name = "labelStatus";
      this.labelStatus.Size = new System.Drawing.Size(368, 47);
      this.labelStatus.TabIndex = 0;
      this.labelStatus.Text = "[Status]";
      this.labelStatus.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
      // 
      // SplashScreenForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(550, 319);
      this.ControlBox = false;
      this.Controls.Add(this.panel2);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "SplashScreenForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "SplashScreen";
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label labelStatus;
		private System.Windows.Forms.Label labelProjectName;
    private System.Windows.Forms.Label labelActemium;
		private System.Windows.Forms.Label labelRelease;
	}
}