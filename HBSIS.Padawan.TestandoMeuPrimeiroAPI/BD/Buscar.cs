using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using HBSIS.Padawan.TestandoMeuPrimeiroAPI.Models;

namespace COVID19_Simulator_Server.BD
{
	public class Buscar
	{
		public static List<Simulacao> Simulacao()
		{
			Conexao conexao = new Conexao();
			SqlCommand command = new SqlCommand();

			command.CommandText = "select * from SIMULACAO";
			command.Connection = conexao.Conectar();

			SqlDataReader data = command.ExecuteReader();
			List<Simulacao> listaSimulacoes = new List<Simulacao>();

			if (data.HasRows)
			{
				while (data.Read())
				{
					listaSimulacoes.Add(new Simulacao() 
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

		public static List<Estado> Estados(int idSimulacao)
		{
			Conexao conexao = new Conexao();
			SqlCommand command = new SqlCommand();

			command.CommandText = $"select * from ESTADO where simulacao = {idSimulacao}";
			command.Connection = conexao.Conectar();

			SqlDataReader data = command.ExecuteReader();
			List<Estado> listaEstados = new List<Estado>();

			if (data.HasRows)
			{
				while (data.Read())
				{
					listaEstados.Add(new Estado()
					{
						ID = data.GetInt32(0),
						Infectados = data.GetInt32(2),
						Curados = data.GetInt32(3),
						Mortos = data.GetInt32(4),
						Nome = data.GetString(5),
					});
				}
			}
			else
			{
				Console.WriteLine("No rows found.");
			}

			conexao.Desconectar();
			return listaEstados;
		}
	}
}
