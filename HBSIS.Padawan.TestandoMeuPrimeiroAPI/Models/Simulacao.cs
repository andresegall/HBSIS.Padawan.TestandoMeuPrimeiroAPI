using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HBSIS.Padawan.TestandoMeuPrimeiroAPI.Models
{
	public class Simulacao
	{
		public int ID { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public DateTime Data { get; set; }
		public List<Estado> Contexto { get; set; }

		public Simulacao()
		{
			ID = 0;
			Nome = "";
			Descricao = "";
			Data = DateTime.UtcNow;
			Contexto = new List<Estado>();
		}
	}
}
