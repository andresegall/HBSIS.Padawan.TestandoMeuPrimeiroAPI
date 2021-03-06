﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HBSIS.Padawan.TestandoMeuPrimeiroAPI.Models;

namespace COVID19_Simulator_Server.BD
{
	public class Atualizar
	{
		public static void Simulacao(Simulacao simulacao)
		{
			Conexao conexao = new Conexao();
			SqlCommand command = new SqlCommand();

			command.Parameters.AddWithValue("@semanas", simulacao.Semanas);
			command.Parameters.AddWithValue("@infectados", simulacao.Infectados);
			command.Parameters.AddWithValue("@curados", simulacao.Curados);
			command.Parameters.AddWithValue("@mortos", simulacao.Mortos);
			command.Parameters.AddWithValue("@data", DateTime.Now);
			command.Parameters.AddWithValue("@id", simulacao.ID);

			try
			{
				command.Connection = conexao.Conectar();
				command.CommandText = ("update SIMULACAO set semanas = @semanas where id = @id;");
				command.ExecuteNonQuery();
				command.CommandText = ("update SIMULACAO set infectados = @infectados where id = @id;");
				command.ExecuteNonQuery();
				command.CommandText = ("update SIMULACAO set curados = @curados where id = @id;");
				command.ExecuteNonQuery();
				command.CommandText = ("update SIMULACAO set mortos = @mortos where id = @id;");
				command.ExecuteNonQuery();
				command.CommandText = ("update SIMULACAO set data = @data where id = @id;");
				command.ExecuteNonQuery();
				conexao.Desconectar();
			}
			catch (SqlException)
			{
			}
		}
		public static void Estado(Estado estado, int idSimulacao)
		{
			Conexao conexao = new Conexao();
			SqlCommand command = new SqlCommand();

			command.Parameters.AddWithValue("@infectados", estado.Infectados);
			command.Parameters.AddWithValue("@curados", estado.Curados);
			command.Parameters.AddWithValue("@mortos", estado.Mortos);
			command.Parameters.AddWithValue("@simulacao", idSimulacao);
			command.Parameters.AddWithValue("@id", estado.ID);

			try
			{
				command.Connection = conexao.Conectar();
				command.CommandText = ($"update ESTADO set infectados = @infectados where (id = @id and simulacao = @simulacao);");
				command.ExecuteNonQuery();
				command.CommandText = ($"update ESTADO set curados = @curados where (id = @id and simulacao = @simulacao);");
				command.ExecuteNonQuery();
				command.CommandText = ($"update ESTADO set mortos = @mortos where (id = @id and simulacao = @simulacao);");
				command.ExecuteNonQuery();
				conexao.Desconectar();
			}
			catch (SqlException)
			{
			}
		}

	}
}
