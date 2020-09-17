using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COVID19_Simulator_Client.Models;
using Newtonsoft.Json;

namespace COVID19_Simulator_Client
{
	public partial class MenuPrincipal : Form
	{
		public MenuPrincipal()
		{
			InitializeComponent();
		}

		private void fontDialog1_Apply(object sender, EventArgs e)
		{

		}

		private void MenuPrincipal_Load(object sender, EventArgs e)
		{

		}

		private void txtUrl_TextChanged(object sender, EventArgs e)
		{

		}

		string URI = "";
		int codigoProduto = 1;
		private async void GetAllProdutos()
		{
			URI = txtUrl.Text;
			using (var client = new HttpClient())
			{
				using (var response = await client.GetAsync(URI))
				{
					if (response.IsSuccessStatusCode)
						txtDisplay.Text = await response.Content.ReadAsStringAsync();

					else
						MessageBox.Show("Não foi possível obter o estado : " + response.StatusCode);
				}
			}
		}

		private void btnAtual_Click(object sender, EventArgs e)
		{
			GetAllProdutos();
		}

		private void txtDisplay_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
