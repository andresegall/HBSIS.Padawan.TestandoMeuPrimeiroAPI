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

			command.CommandText = "insert into SIMULACAO (id, infectados, curados, mortos) values (@id, @infectados, @curados, @mortos)";
			command.Parameters.AddWithValue("@id", simulacao.ID);
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
	}
}
