using System.Collections.Generic;
using System.Linq;
using COVID19_Simulator_Server.BD;
using HBSIS.Padawan.SimulacaoCOVIDAPI.Utilitarios;
using HBSIS.Padawan.TestandoMeuPrimeiroAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HBSIS.Padawan.TestandoMeuPrimeiroAPI.Controllers
{
	[ApiController]
	[Route("simuladorTransmissaoCOVID19")]
	public class Controller : ControllerBase
	{
		static IEnumerable<Estado> contexto = ImplementaEstados.Brasil();
		static int contaSemanas = 0;
		static int infectados = 0;
		static int curados = 0;
		static int mortos = 0;

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
			contaSemanas += Verifica.Semanas(getSemanas);

			Simulando.AtualizaContexto(ref contexto, Verifica.Semanas(getSemanas));

			foreach (var estado in contexto)
			{
				infectados += estado.Infectados;
				curados += estado.Curados;
				mortos += estado.Mortos;
			}

			return Verifica.Semanas(getSemanas) == 0 ?
				Ok("Nenhuma alteração realizada...") : Ok(contexto);
		}

		[HttpPut]
		[Route("upDateCondicaoDeContorno")]
		public ActionResult UpDateCondicaoDeContorno(string nome, [FromBody] Estado estado)
		{
			bool nomeValido = Verifica.NomeEstado(contexto, nome) != "Nome de estado inválido!";
			if (nomeValido)
			{
				contexto.First(q => q.Nome == nome).Infectados = estado.Infectados;
				contexto.First(q => q.Nome == nome).Curados = estado.Curados;
				contexto.First(q => q.Nome == nome).Mortos = estado.Mortos;
			}
			return nomeValido ? Ok(contexto) : Ok("Nome de estado inválido!");
		}

		[HttpDelete]
		[Route("deleteEstado")]
		public ActionResult DeleteEstado(string nome)
		{
			bool nomeValido = Verifica.NomeEstado(contexto, nome) != "Nome de estado inválido!";
			return nomeValido ?
				Ok(contexto = contexto.Where(q => q.Nome != nome)) : Ok("Nome de estado inválido!");
		}

		[HttpGet]
		[Route("getFinalizaSimulacao")]
		public ActionResult GetFinalizaSimulacao(string nome, string descricao)
		{
			var simulacaoFinal = new SimulacaoFinal()
			{
				ID = 999,
				Nome = nome,
				Descricao = descricao,
				Contexto = contexto,
				Semanas = contaSemanas,
				Infectados = infectados,
				Curados = curados,
				Mortos = mortos
			};
			Registrar.Simulacao(simulacaoFinal);

			foreach (var estado in contexto)
				Registrar.Estados(estado, simulacaoFinal.ID);

			return Ok(simulacaoFinal);
		}

		[HttpGet]
		[Route("getSimulacoesAnteriores")]
		public ActionResult GetSimulacoesAnteriores()
		{
			return Ok(Buscar.Simulacao());
		}
	}
}
