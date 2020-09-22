using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HBSIS.Padawan.TestandoMeuPrimeiroAPI.Models;

namespace COVID19_Simulator_Server.BD
{
	public class Registrar
	{
		public static void Simulacao(SimulacaoFinal simulacao)
		{
			Conexao conexao = new Conexao();
			SqlCommand command = new SqlCommand();

			command.CommandText = "insert into SIMULACAO (id, semanas, infectados, curados, mortos, _data, nome, descricao) values (@id, @semanas, @infectados, @curados, @mortos, @data, @nome, @descricao)";
			command.Parameters.AddWithValue("@id", simulacao.ID);
			command.Parameters.AddWithValue("@semanas", simulacao.Semanas);
			command.Parameters.AddWithValue("@infectados", simulacao.Infectados);
			command.Parameters.AddWithValue("@curados", simulacao.Curados);
			command.Parameters.AddWithValue("@mortos", simulacao.Mortos);
			command.Parameters.AddWithValue("@data", simulacao.Data);
			command.Parameters.AddWithValue("@nome", simulacao.Nome);
			command.Parameters.AddWithValue("@descricao", simulacao.Descricao);

			try
			{
				command.Connection = conexao.Conectar();
				command.ExecuteNonQuery();
				conexao.Desconectar();
			}
			catch (SqlException)
			{
			}
		}

		public static void Estados(Estado estado, int idSimulacao)
		{
			Conexao conexao = new Conexao();
			SqlCommand command = new SqlCommand();

			command.CommandText = "insert into ESTADO (id, simulacao, infectados, curados, mortos, nome) values (@id, @simulacao, @infectados, @curados, @mortos, @nome)";
			command.Parameters.AddWithValue("@id", estado.ID);
			command.Parameters.AddWithValue("@simulacao", idSimulacao);
			command.Parameters.AddWithValue("@infectados", estado.Infectados);
			command.Parameters.AddWithValue("@curados", estado.Curados);
			command.Parameters.AddWithValue("@mortos", estado.Mortos);
			command.Parameters.AddWithValue("@nome", estado.Nome);

			try
			{
				command.Connection = conexao.Conectar();
				command.ExecuteNonQuery();
				conexao.Desconectar();
			}
			catch (SqlException)
			{
			}
		}
	}
}
