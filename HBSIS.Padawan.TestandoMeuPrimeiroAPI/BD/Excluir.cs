using System.Data.SqlClient;

namespace COVID19_Simulator_Server.BD
{
	public class Excluir
	{
		public static void Simulacao(int idSimulacao)
		{
			Conexao conexao = new Conexao();
			SqlCommand command = new SqlCommand();

			try
			{
				command.Connection = conexao.Conectar();
				command.CommandText = $"delete from ESTADO where simulacao = {idSimulacao}";
				command.ExecuteNonQuery();
				command.CommandText = $"delete from SIMULACAO where id = {idSimulacao}";
				command.ExecuteNonQuery();
				conexao.Desconectar();
			}
			catch (SqlException)
			{
			}
		}
	}
}
