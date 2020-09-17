using System;
using System.Collections.Generic;

namespace COVID19_Simulator_Client.Models
{
	public class Estado
	{
		public int ID { get; set; }
		public int Infectados { get; set; }
		public int Curados { get; set; }
		public int Mortos { get; set; }
		public string Nome { get; set; }

		public Estado()
		{
			Infectados = 0;
			Curados = 0;
			Mortos = 0;
		}
	}
}
