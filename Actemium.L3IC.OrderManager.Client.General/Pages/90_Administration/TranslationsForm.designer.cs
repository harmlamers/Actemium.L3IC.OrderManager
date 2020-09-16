using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.Pages._90_Administration
{
	partial class TranslationsForm
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
    /// the contents of this method met the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
      this.pnlFull = new System.Windows.Forms.Panel();
      this.TranslationsSupergrid = new Windows.Forms.SuperGrid.SuperGrid();
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
      this.pnlFull.SuspendLayout();
      this.SuspendLayout();
      // 
      // errorProvider
      // 
      this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
      this.errorProvider.ContainerControl = this;
      // 
      // pnlFull
      // 
      this.pnlFull.Controls.Add(this.TranslationsSupergrid);
      this.pnlFull.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pnlFull.Location = new System.Drawing.Point(0, 0);
      this.pnlFull.Name = "pnlFull";
      this.pnlFull.Size = new System.Drawing.Size(1016, 639);
      this.pnlFull.TabIndex = 26;
      // 
      // TranslationsSupergrid
      // 
      this.TranslationsSupergrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.TranslationsSupergrid.Location = new System.Drawing.Point(0, 0);
      this.TranslationsSupergrid.Name = "TranslationsSupergrid";
      this.TranslationsSupergrid.Size = new System.Drawing.Size(1016, 639);
      this.TranslationsSupergrid.TabIndex = 0;
      this.TranslationsSupergrid.Translate = true;
      // 
      // TranslationsForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.BackColor = System.Drawing.Color.LightGray;
      this.ClientSize = new System.Drawing.Size(1016, 639);
      this.Controls.Add(this.pnlFull);
      this.ForeColor = System.Drawing.SystemColors.ControlText;
      this.KeyPreview = true;
      this.Name = "TranslationsForm";
      ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
      this.pnlFull.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.Panel pnlFull;
		private Windows.Forms.SuperGrid.SuperGrid TranslationsSupergrid;
  }
}
