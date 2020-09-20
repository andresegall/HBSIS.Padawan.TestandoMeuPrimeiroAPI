using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using COVID19_Simulator_Server.BD;
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
		static IEnumerable<Estado> contexto = ImplementaEstados.Brasil();
		int contaSemanas = 0;

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
			contaSemanas = semanas;

			Simulando.AtualizaContexto(ref contexto, semanas);

			return semanas == 0 ? Ok("Simulação não realizada!") : Ok(contexto);
		}

		[HttpPut]
		[Route("upDateCondicaoDeContorno")]
		public ActionResult UpDateCondicaoDeContorno(string nomeEstado, [FromBody] Estado estado)
		{
			bool nomeValido = Verifica.NomeEstado(contexto, nomeEstado) != "Nome de estado inválido!";

			if (nomeValido)
			{
				contexto.First(q => q.Nome == nomeEstado).Infectados = estado.Infectados;
				contexto.First(q => q.Nome == nomeEstado).Curados = estado.Curados;
				contexto.First(q => q.Nome == nomeEstado).Mortos = estado.Mortos;
			}

			return nomeValido ? Ok(contexto) : Ok("Nome de estado inválido!");
		}

		[HttpDelete]
		[Route("deleteEstado")]
		public ActionResult DeleteEstado(string nomeEstado)
		{
			bool nomeValido = Verifica.NomeEstado(contexto, nomeEstado) != "Nome de estado inválido!";

			return nomeValido ?
				Ok(contexto = contexto.Where(q => q.Nome != nomeEstado)) : Ok("Nome de estado inválido!");
		}

		[HttpGet]
		[Route("getFinalizaSimulacao")]
		public ActionResult GetFinalizaSimulacao(string nome, string descricao)
		{
			var simulacaoFinal = new SimulacaoFinal()
			{
				Nome = nome,
				Descricao = descricao,
				Contexto = contexto,
				Semanas = contaSemanas
			};

			Registrar.Simulacao(simulacaoFinal);
			return Ok(simulacaoFinal);
		}
	}
}
