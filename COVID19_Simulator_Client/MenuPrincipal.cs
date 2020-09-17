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

		private async void GetAllEstados()
		{
			using (var response = await new HttpClient().GetAsync("https://localhost:44360/simuladorTransmissaoCOVID19/getSituacaoAtual"))
			{
				if (response.IsSuccessStatusCode)
					txtDisplay.Text = await response.Content.ReadAsStringAsync();

				else
					MessageBox.Show("Não foi possível obter a situação atual : " + response.StatusCode);
			}
		}

		private async void PostNewEstado()
		{
			var estado = new Estado() { Nome = "DF" };

			var content = new StringContent(JsonConvert.SerializeObject(estado), Encoding.UTF8, "application/json");
			await new HttpClient().PostAsync("https://localhost:44360/simuladorTransmissaoCOVID19/postNovoEstado", content);

			GetAllEstados();
		}

		private async void GetSimulaEvolucaoCOVID()
		{
			int eita = 0;

			using (var response = await new HttpClient().GetAsync("https://localhost:44360/simuladorTransmissaoCOVID19/SimulaEvolucaoCOVID?getSemanas=" + eita))
			{
				if (response.IsSuccessStatusCode)
					txtDisplay.Text = await response.Content.ReadAsStringAsync();

				else
					MessageBox.Show("Não foi possível obter a simulação : " + response.StatusCode);
			}
		}

		private async void PutCondicaoDeContorno()
		{
			var eita = "DF";
			var estado = new Estado() { Infectados = 0, Curados = 0, Mortos = 0 };
			var content = new StringContent(JsonConvert.SerializeObject(estado), Encoding.UTF8, "application/json");

			HttpResponseMessage responseMessage = await new HttpClient().PutAsJsonAsync("https://localhost:44360/simuladorTransmissaoCOVID19/upDateCondicaoDeContorno?nomeEstado=" + eita, content);
			if (responseMessage.IsSuccessStatusCode)
			{
				MessageBox.Show("Condições de contorno no estado atualizadas");
			}
			else
			{
				MessageBox.Show("Falha ao atualizar condições de contorno : " + responseMessage.StatusCode);
			}
			GetAllEstados();
		}

		private void btnGetSituacaoAtual_Click(object sender, EventArgs e)
		{
			GetAllEstados();
		}

		private void btnPostNovoEstado_Click(object sender, EventArgs e)
		{
			PostNewEstado();
		}

		private void btnGetSimulaEvolucaoCOVID_Click(object sender, EventArgs e)
		{
			GetSimulaEvolucaoCOVID();
		}

		private void btnPutCondicaoDeContorno_Click(object sender, EventArgs e)
		{
			PutCondicaoDeContorno();
		}
	}
}
