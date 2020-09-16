using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.Pages
{
  partial class ErrorForm
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
			this.errorLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// errorLabel
			// 
			this.errorLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.errorLabel.BackColor = System.Drawing.Color.LightGray;
			this.errorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.errorLabel.Location = new System.Drawing.Point(178, 144);
			this.errorLabel.Name = "errorLabel";
			this.errorLabel.Size = new System.Drawing.Size(673, 325);
			this.errorLabel.TabIndex = 0;
			this.errorLabel.Text = "---";
			this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ErrorForm
			// 
			this.BackColor = System.Drawing.Color.LightGray;
			this.ClientSize = new System.Drawing.Size(1016, 639);
			this.ControlBox = false;
			this.Controls.Add(this.errorLabel);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.KeyPreview = true;
			this.Name = "ErrorForm";
			this.Resize += new System.EventHandler(this.ErrorFormResize);
			this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Label errorLabel;



  }
}