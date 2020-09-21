using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace COVID19_Simulator_Server.BD
{
	public class Conexao
	{
		SqlConnection conexao = new SqlConnection();

		public Conexao()
		{
			conexao.ConnectionString = @"Data Source=NT-04282\SQLEXPRESS;Initial Catalog=COVID19Simulator;Integrated Security=True";
		}
		public SqlConnection Conectar()
		{
			if (conexao.State == System.Data.ConnectionState.Closed)
				conexao.Open();

			return conexao;
		}
		public void Desconectar()
		{
			if (conexao.State == System.Data.ConnectionState.Open)
				conexao.Close();
		}
	}
}
