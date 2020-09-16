using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBSIS.Padawan.SimulacaoCOVIDAPI;
using HBSIS.Padawan.TestandoMeuPrimeiroAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HBSIS.Padawan.TestandoMeuPrimeiroAPI.Controllers
{
	[ApiController]
	[Route("simuladorTransmissaoCOVID19")]
	public class Controller : ControllerBase
	{
		public static IEnumerable<Estado> contexto = ImplementaEstados.Brasil();

		[HttpGet]
		[Route("getSituacaoAtual")]
		public ActionResult GetSituacaoAtual()
		{
			return Ok(contexto);
		}

		[HttpPost]
		[Route("postNovoEstado")]
		public ActionResult PostNovoEstado([FromBody] Estado estado)
		{
			estado.ID = contexto.Last(q => q.ID > 0).ID + 1;
			contexto = contexto.Append(estado);
			return Ok(contexto);
		}

		[HttpGet]
		[Route("SimulaEvolucaoCOVID")]
		public ActionResult GetSimulacao(int semanas)
		{
			Simulacao.AtualizaContexto(ref contexto, semanas);
			return Ok(contexto);
		}

		[HttpPut]
		[Route("upDateCondicaoDeContorno")]
		public ActionResult UpDateCondicaoDeContorno(string nomeEstado, [FromBody] Estado estado)
		{
			contexto.First(q => q.Nome == nomeEstado).Infectados = estado.Infectados;
			contexto.First(q => q.Nome == nomeEstado).Curados = estado.Curados;
			contexto.First(q => q.Nome == nomeEstado).Mortos = estado.Mortos;

			return Ok(contexto);
		}

		[HttpDelete]
		[Route("deleteEstado")]
		public ActionResult DeleteEstado(string nomeEstado)
		{
			List<Estado> removeList = contexto.Where(q => q.ID > 0).ToList();
			removeList.Remove(removeList.First(q => q.Nome == nomeEstado));

			contexto = removeList;

			return Ok(contexto);
		}
	}
}
