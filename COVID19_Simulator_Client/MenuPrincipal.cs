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
					{
						var ProdutoJsonString = await response.Content.ReadAsStringAsync();
						pnlDisplay.DataSource = JsonConvert.DeserializeObject<Produto[]>(ProdutoJsonString).ToList();
					}
					else
					{
						MessageBox.Show("Não foi possível obter o produto : " + response.StatusCode);
					}
				}
			}
		}
	}
}
