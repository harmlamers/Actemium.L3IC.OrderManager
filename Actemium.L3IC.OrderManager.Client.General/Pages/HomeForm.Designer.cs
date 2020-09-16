using Actemium.Diagnostics;

namespace Actemium.L3IC.OrderManager.Client.General.Pages
{
  partial class HomeForm
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
            this.welcomeLabel = new Actemium.Windows.Forms.DevComponents2.Controls.LabelX();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            // 
            // 
            // 
            this.welcomeLabel.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.welcomeLabel.DataType = Actemium.Windows.Forms.DevComponents2.Controls.DataTypeEnum.String;
            this.welcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.FormatMask = null;
            this.welcomeLabel.Location = new System.Drawing.Point(37, 457);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(600, 27);
            this.welcomeLabel.TabIndex = 6;
            this.welcomeLabel.Text = "Welcome to the Actemium Client, make a selection in the menu...";
            this.welcomeLabel.Translate = false;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BackgroundImage = global::Actemium.L3IC.OrderManager.Client.General.Properties.Resources._ActemiumLogo;
            this.logoPictureBox.Location = new System.Drawing.Point(256, 183);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(452, 106);
            this.logoPictureBox.TabIndex = 9;
            this.logoPictureBox.TabStop = false;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(1016, 639);
            this.Controls.Add(this.logoPictureBox);
            this.Controls.Add(this.welcomeLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.KeyPreview = true;
            this.Name = "HomeForm";
            this.Load += new System.EventHandler(this.HomeFormLoad);
            this.Resize += new System.EventHandler(this.HomeFormResize);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    #endregion

		private Actemium.Windows.Forms.DevComponents2.Controls.LabelX welcomeLabel;
		private System.Windows.Forms.PictureBox logoPictureBox;
  }
}