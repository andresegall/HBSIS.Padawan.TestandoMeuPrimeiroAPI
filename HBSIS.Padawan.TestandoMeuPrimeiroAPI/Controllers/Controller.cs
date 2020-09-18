using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HBSIS.Padawan.SimulacaoCOVIDAPI;
using HBSIS.Padawan.SimulacaoCOVIDAPI.Utilitarios;
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
		public static Simulacao meajudaDEEEUS;

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
		public ActionResult GetSimulacao(string getSemanas)
		{
			var semanas = Verifica.Semanas(contexto, getSemanas);

			Simulacao.AtualizaContexto(ref contexto, semanas);

			return semanas == 0 ? Ok("Simulação não realizada!") : Ok(contexto);
		}

		[HttpPut]
		[Route("upDateCondicaoDeContorno")]
		public ActionResult UpDateCondicaoDeContorno(string nomeEstado, [FromBody] Estado estado)
		{
			nomeEstado = Verifica.NomeEstado(contexto, nomeEstado);

			contexto.First(q => q.Nome == nomeEstado).Infectados = estado.Infectados;
			contexto.First(q => q.Nome == nomeEstado).Curados = estado.Curados;
			contexto.First(q => q.Nome == nomeEstado).Mortos = estado.Mortos;

			return nomeEstado == "Nome de estado inválido!" ? Ok(nomeEstado) : Ok(contexto);
		}

		[HttpDelete]
		[Route("deleteEstado")]
		public ActionResult DeleteEstado(string nomeEstado)
		{
			nomeEstado = Verifica.NomeEstado(contexto, nomeEstado);

			List<Estado> removeList = contexto.Where(q => q.ID > 0).ToList();

			if (nomeEstado != "Nome de estado inválido!")
				removeList.Remove(removeList.First(q => q.Nome == nomeEstado));

			contexto = removeList;

			return nomeEstado == "Nome de estado inválido!" ? Ok(nomeEstado) : Ok(contexto);
		}

		[HttpGet]
		[Route("getFinalizaSimulacao")]
		public ActionResult GetFinalizaSimulacao()
		{
			return Ok(contexto);
		}
	}
}
