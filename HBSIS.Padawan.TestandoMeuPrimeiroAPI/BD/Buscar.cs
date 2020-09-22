using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using HBSIS.Padawan.TestandoMeuPrimeiroAPI.Models;

namespace COVID19_Simulator_Server.BD
{
	public class Buscar
	{
		public static string Simulacao()
		{
			Conexao conexao = new Conexao();
			SqlCommand command = new SqlCommand();
			string teste = "";

			command.CommandText = "select id from SIMULACAO";

			command.Connection = conexao.Conectar();

			SqlDataReader data = command.ExecuteReader();
			DataTable schemaTable = data.GetSchemaTable();

			foreach (DataRow row in schemaTable.Rows)
			{
				foreach (DataColumn column in schemaTable.Columns)
				{
					teste = ($"{column.ColumnName} = {row[column]}");
				}
			}

			conexao.Desconectar();
			return teste;
		}
	}
}
