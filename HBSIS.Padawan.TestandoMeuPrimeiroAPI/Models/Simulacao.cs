﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBSIS.Padawan.SimulacaoCOVIDAPI.Utilitarios;

namespace HBSIS.Padawan.TestandoMeuPrimeiroAPI.Models
{
	public class Simulacao
	{
		public int ID { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public DateTime Data { get; set; }
		public IEnumerable<Estado> Contexto { get; set; }
		public int Semanas { get; set; }
		public int Infectados { get; set; }
		public int Curados { get; set; }
		public int Mortos { get; set; }

		public Simulacao()
		{
			ID = 0;
			Nome = "";
			Descricao = "";
			Data = DateTime.Now;
			Contexto = ImplementaEstados.Brasil();
			Semanas = 0;
			Infectados = 0;
			Curados = 0;
			Mortos = 0;
		}
	}
}
