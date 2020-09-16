namespace Actemium.L3IC.OrderManager.Client.General.PopupPages
{
  partial class AboutForm
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
      this.lblReleaseVersion = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // lblReleaseVersion
      // 
      this.lblReleaseVersion.AutoSize = true;
      this.lblReleaseVersion.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblReleaseVersion.Location = new System.Drawing.Point(368, 60);
      this.lblReleaseVersion.Name = "lblReleaseVersion";
      this.lblReleaseVersion.Size = new System.Drawing.Size(19, 23);
      this.lblReleaseVersion.TabIndex = 14;
      this.lblReleaseVersion.Text = "-";
      // 
      // AboutForm
      // 
      this.ClientSize = new System.Drawing.Size(794, 359);
      this.Controls.Add(this.lblReleaseVersion);
      this.Name = "AboutForm";
      this.Controls.SetChildIndex(this.lblReleaseVersion, 0);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label lblReleaseVersion;
  }
}
