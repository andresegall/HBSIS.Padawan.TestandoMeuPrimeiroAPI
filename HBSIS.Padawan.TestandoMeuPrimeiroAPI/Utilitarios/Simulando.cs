using System;
using System.Collections.Generic;
using System.Linq;
using HBSIS.Padawan.TestandoMeuPrimeiroAPI.Models;

namespace HBSIS.Padawan.SimulacaoCOVIDAPI.Utilitarios
{
	public static class Simulando
	{
		public static void AtualizaContexto(ref IEnumerable<Estado> contexto, int tempo)
		{
			int semanas = 0;
			var rand = new Random();

			while (semanas < tempo)
			{
				var estadosAfetados = contexto.Where(q => q.Infectados > 0).ToList();

				foreach (var item in estadosAfetados)
				{
					int infectados = contexto.First(q => q.Nome == item.Nome).Infectados;

					if (infectados > 100)
					{
						//Morrem 1,75% dos infectados
						contexto.First(q => q.Nome == item.Nome).Mortos += (int)(infectados * 0.0175);
						contexto.First(q => q.Nome == item.Nome).Infectados -= (int)(infectados * 0.0175);
					}

					//30% dos infectados se recuperam
					contexto.First(q => q.Nome == item.Nome).Curados += (int)(infectados * 0.3);
					contexto.First(q => q.Nome == item.Nome).Infectados -= (int)(infectados * 0.3);

					//Triplica o número de infectados no estado
					contexto.First(q => q.Nome == item.Nome).Infectados *= 3;

					//Existe 48% de chance de um infectado ir para outro estado
					if (rand.Next(0,2) == 0)
					{
						var sorteio = rand.Next(0, contexto.Count());
						contexto.First(q => q.Nome == item.Nome).Infectados -= 1;
						contexto.First(q => q.ID == sorteio).Infectados += 1;
					}
				}
				semanas++;
			}
		}
	}
}
