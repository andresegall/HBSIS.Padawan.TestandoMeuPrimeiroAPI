using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HBSIS.Padawan.TestandoMeuPrimeiroAPI.Models;

namespace COVID19_Simulator_Server.BD
{
	public class Buscar
	{
		public static List<SimulacaoFinal> Simulacao()
		{
			Conexao conexao = new Conexao();
			SqlCommand command = new SqlCommand();

			command.CommandText = "select * from SIMULACAO";
			command.Connection = conexao.Conectar();

			SqlDataReader data = command.ExecuteReader();
			List<SimulacaoFinal> listaSimulacoes = new List<SimulacaoFinal>();

			if (data.HasRows)
			{
				while (data.Read())
				{
					listaSimulacoes.Add(new SimulacaoFinal() 
					{
						ID = data.GetInt32(0),
						Semanas = data.GetInt32(1),
						Infectados = data.GetInt32(2),
						Curados = data.GetInt32(3),
						Mortos = data.GetInt32(4),
						Data = data.GetDateTime(5),
						Nome = data.GetString(6),
						Descricao = data.GetString(7)
					});
				}
			}
			else
			{
				Console.WriteLine("No rows found.");
			}

			conexao.Desconectar();
			return listaSimulacoes;
		}
	}
}
