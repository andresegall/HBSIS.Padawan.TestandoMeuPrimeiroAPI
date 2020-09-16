using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBSIS.Padawan.TestandoMeuPrimeiroAPI.Models;

namespace HBSIS.Padawan.SimulacaoCOVIDAPI
{
	public class ImplementaEstados
	{
		public static List<Estado> Brasil()
		{
			return new List<Estado>()
			{
				(new Estado(){ Nome="AC", ID=0}),
				(new Estado(){ Nome="AL", ID=1}),
				(new Estado(){ Nome="AP", ID=2}),
				(new Estado(){ Nome="AM", ID=3}),
				(new Estado(){ Nome="BA", ID=4}),
				(new Estado(){ Nome="CE", ID=5}),
				(new Estado(){ Nome="ES", ID=6}),
				(new Estado(){ Nome="GO", ID=7}),
				(new Estado(){ Nome="MA", ID=8}),
				(new Estado(){ Nome="MT", ID=9}),
				(new Estado(){ Nome="MS", ID=10}),
				(new Estado(){ Nome="MG", ID=11}),
				(new Estado(){ Nome="PA", ID=12}),
				(new Estado(){ Nome="PB", ID=13}),
				(new Estado(){ Nome="PR", ID=14}),
				(new Estado(){ Nome="PE", ID=15}),
				(new Estado(){ Nome="PI", ID=16}),
				(new Estado(){ Nome="RJ", ID=17}),
				(new Estado(){ Nome="RN", ID=18}),
				(new Estado(){ Nome="RS", ID=19}),
				(new Estado(){ Nome="RO", ID=20}),
				(new Estado(){ Nome="RR", ID=21}),
				(new Estado(){ Nome="SC", ID=22}),
				(new Estado(){ Nome="SP", ID=23}),
				(new Estado(){ Nome="SE", ID=24}),
				(new Estado(){ Nome="TO", ID=25}),
			};
		}
	}
}
