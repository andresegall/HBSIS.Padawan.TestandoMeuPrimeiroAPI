using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBSIS.Padawan.TestandoMeuPrimeiroAPI.Models;

namespace HBSIS.Padawan.SimulacaoCOVIDAPI.Utilitarios
{
	public class Verifica
	{
		public static string NomeEstado(IEnumerable<Estado> contexto, string nome)
		{
			try
			{
				contexto.First(q => q.Nome == nome);
			}
			catch
			{
				return "Nome de estado inválido!";
			}

			return nome;
		}

		public static int Semanas(string getSemanas)
		{
			int semanas;
			try
			{
				semanas = Convert.ToInt32(getSemanas);
			}
			catch
			{
				semanas = 0;
			}

			return semanas;
		}
	}
}
