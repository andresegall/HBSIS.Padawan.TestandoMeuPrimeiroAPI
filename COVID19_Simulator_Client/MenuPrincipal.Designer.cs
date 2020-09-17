namespace COVID19_Simulator_Client
{
	partial class MenuPrincipal
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.fontDialog1 = new System.Windows.Forms.FontDialog();
			this.txtUrl = new System.Windows.Forms.TextBox();
			this.txtDisplay = new System.Windows.Forms.TextBox();
			this.pnlDisplay = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// fontDialog1
			// 
			this.fontDialog1.Apply += new System.EventHandler(this.fontDialog1_Apply);
			// 
			// txtUrl
			// 
			this.txtUrl.Location = new System.Drawing.Point(167, 34);
			this.txtUrl.Name = "txtUrl";
			this.txtUrl.Size = new System.Drawing.Size(458, 23);
			this.txtUrl.TabIndex = 0;
			this.txtUrl.Text = "https://localhost:44360/simuladorTransmissaoCOVID19/getSituacaoAtual";
			this.txtUrl.TextChanged += new System.EventHandler(this.txtUrl_TextChanged);
			// 
			// txtDisplay
			// 
			this.txtDisplay.Location = new System.Drawing.Point(461, 113);
			this.txtDisplay.Multiline = true;
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.Size = new System.Drawing.Size(229, 192);
			this.txtDisplay.TabIndex = 0;
			// 
			// pnlDisplay
			// 
			this.pnlDisplay.Location = new System.Drawing.Point(65, 141);
			this.pnlDisplay.Name = "pnlDisplay";
			this.pnlDisplay.Size = new System.Drawing.Size(170, 164);
			this.pnlDisplay.TabIndex = 1;
			// 
			// MenuPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.pnlDisplay);
			this.Controls.Add(this.txtDisplay);
			this.Controls.Add(this.txtUrl);
			this.Name = "MenuPrincipal";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.MenuPrincipal_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.TextBox txtDisplay;
		private System.Windows.Forms.Panel pnlDisplay;
	}
}

