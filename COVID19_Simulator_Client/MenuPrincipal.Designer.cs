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
			this.txtDisplay = new System.Windows.Forms.TextBox();
			this.btnGetSituacaoAtual = new System.Windows.Forms.Button();
			this.btnPostNovoEstado = new System.Windows.Forms.Button();
			this.btnGetSimulaEvolucaoCOVID = new System.Windows.Forms.Button();
			this.btnPutCondicaoDeContorno = new System.Windows.Forms.Button();
			this.btnDeleteEstado = new System.Windows.Forms.Button();
			this.txtNome = new System.Windows.Forms.TextBox();
			this.txtEstado = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtDisplay
			// 
			this.txtDisplay.Location = new System.Drawing.Point(67, 38);
			this.txtDisplay.Multiline = true;
			this.txtDisplay.Name = "txtDisplay";
			this.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDisplay.Size = new System.Drawing.Size(468, 290);
			this.txtDisplay.TabIndex = 0;
			// 
			// btnGetSituacaoAtual
			// 
			this.btnGetSituacaoAtual.Location = new System.Drawing.Point(67, 359);
			this.btnGetSituacaoAtual.Name = "btnGetSituacaoAtual";
			this.btnGetSituacaoAtual.Size = new System.Drawing.Size(152, 56);
			this.btnGetSituacaoAtual.TabIndex = 1;
			this.btnGetSituacaoAtual.Text = "Situação Atual";
			this.btnGetSituacaoAtual.UseVisualStyleBackColor = true;
			this.btnGetSituacaoAtual.Click += new System.EventHandler(this.btnGetSituacaoAtual_Click);
			// 
			// btnPostNovoEstado
			// 
			this.btnPostNovoEstado.Location = new System.Drawing.Point(225, 359);
			this.btnPostNovoEstado.Name = "btnPostNovoEstado";
			this.btnPostNovoEstado.Size = new System.Drawing.Size(152, 56);
			this.btnPostNovoEstado.TabIndex = 1;
			this.btnPostNovoEstado.Text = "Incluir Estado";
			this.btnPostNovoEstado.UseVisualStyleBackColor = true;
			this.btnPostNovoEstado.Click += new System.EventHandler(this.btnPostNovoEstado_Click);
			// 
			// btnGetSimulaEvolucaoCOVID
			// 
			this.btnGetSimulaEvolucaoCOVID.Location = new System.Drawing.Point(383, 359);
			this.btnGetSimulaEvolucaoCOVID.Name = "btnGetSimulaEvolucaoCOVID";
			this.btnGetSimulaEvolucaoCOVID.Size = new System.Drawing.Size(152, 56);
			this.btnGetSimulaEvolucaoCOVID.TabIndex = 1;
			this.btnGetSimulaEvolucaoCOVID.Text = "Simular Evolução";
			this.btnGetSimulaEvolucaoCOVID.UseVisualStyleBackColor = true;
			this.btnGetSimulaEvolucaoCOVID.Click += new System.EventHandler(this.btnGetSimulaEvolucaoCOVID_Click);
			// 
			// btnPutCondicaoDeContorno
			// 
			this.btnPutCondicaoDeContorno.Location = new System.Drawing.Point(541, 359);
			this.btnPutCondicaoDeContorno.Name = "btnPutCondicaoDeContorno";
			this.btnPutCondicaoDeContorno.Size = new System.Drawing.Size(152, 56);
			this.btnPutCondicaoDeContorno.TabIndex = 1;
			this.btnPutCondicaoDeContorno.Text = "Condições de Contorno";
			this.btnPutCondicaoDeContorno.UseVisualStyleBackColor = true;
			this.btnPutCondicaoDeContorno.Click += new System.EventHandler(this.btnPutCondicaoDeContorno_Click);
			// 
			// btnDeleteEstado
			// 
			this.btnDeleteEstado.Location = new System.Drawing.Point(717, 359);
			this.btnDeleteEstado.Name = "btnDeleteEstado";
			this.btnDeleteEstado.Size = new System.Drawing.Size(152, 56);
			this.btnDeleteEstado.TabIndex = 1;
			this.btnDeleteEstado.Text = "Excluir Estado";
			this.btnDeleteEstado.UseVisualStyleBackColor = true;
			this.btnDeleteEstado.Click += new System.EventHandler(this.btnDeleteEstado_Click);
			// 
			// txtNome
			// 
			this.txtNome.Location = new System.Drawing.Point(670, 38);
			this.txtNome.Name = "txtNome";
			this.txtNome.Size = new System.Drawing.Size(144, 23);
			this.txtNome.TabIndex = 2;
			// 
			// txtEstado
			// 
			this.txtEstado.Location = new System.Drawing.Point(670, 79);
			this.txtEstado.Multiline = true;
			this.txtEstado.Name = "txtEstado";
			this.txtEstado.Size = new System.Drawing.Size(144, 127);
			this.txtEstado.TabIndex = 2;
			// 
			// MenuPrincipal
			// 
			this.ClientSize = new System.Drawing.Size(939, 483);
			this.Controls.Add(this.txtEstado);
			this.Controls.Add(this.txtNome);
			this.Controls.Add(this.btnDeleteEstado);
			this.Controls.Add(this.btnPutCondicaoDeContorno);
			this.Controls.Add(this.btnGetSimulaEvolucaoCOVID);
			this.Controls.Add(this.btnPostNovoEstado);
			this.Controls.Add(this.btnGetSituacaoAtual);
			this.Controls.Add(this.txtDisplay);
			this.Name = "MenuPrincipal";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FontDialog fontDialog1;
		private System.Windows.Forms.TextBox txtUrl;
		private System.Windows.Forms.TextBox txtDisplay;
		private System.Windows.Forms.Button btnGetSituacaoAtual;
		private System.Windows.Forms.Button btnIncluirEstado;
		private System.Windows.Forms.Button btnPostNovoEstado;
		private System.Windows.Forms.Button btnGetSimulaEvolucaoCOVID;
		private System.Windows.Forms.Button btnPutCondicaoDeContorno;
		private System.Windows.Forms.Button btnDeleteEstado;
		private System.Windows.Forms.TextBox txtNome;
		private System.Windows.Forms.TextBox txtEstado;
	}
}

