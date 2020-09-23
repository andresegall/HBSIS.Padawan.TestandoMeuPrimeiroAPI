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
		static Simulacao simulacaoFinal = new Simulacao() { ID = Buscar.Simulacao().Last(q => q.ID >= 0).ID + 1 };

		[HttpGet]
		[Route("getSituacaoAtual")]
		public ActionResult GetSituacaoAtual()
		{
			return Ok(simulacaoFinal.Contexto);
		}

		[HttpPost]
		[Route("postNovoEstado")]
		public ActionResult PostNovoEstado([FromBody] Estado estado)
		{
			estado.ID = simulacaoFinal.Contexto.Last(q => q.ID > 0).ID + 1;
			simulacaoFinal.Contexto = simulacaoFinal.Contexto.Append(estado);
			return Ok(simulacaoFinal.Contexto);
		}

		[HttpGet]
		[Route("SimulaEvolucaoCOVID")]
		public ActionResult GetSimulacao(string getSemanas)
		{
			simulacaoFinal.Semanas += Verifica.Semanas(getSemanas);

			IEnumerable<Estado> contexto = simulacaoFinal.Contexto;
			Simulando.AtualizaContexto(ref contexto, Verifica.Semanas(getSemanas));
			simulacaoFinal.Contexto = contexto;

			foreach (var estado in simulacaoFinal.Contexto)
			{
				simulacaoFinal.Infectados += estado.Infectados;
				simulacaoFinal.Curados += estado.Curados;
				simulacaoFinal.Mortos += estado.Mortos;
			}

			return Verifica.Semanas(getSemanas) == 0 ?
				Ok("Nenhuma alteração realizada...") : Ok(simulacaoFinal.Contexto);
		}

		[HttpPut]
		[Route("upDateCondicaoDeContorno")]
		public ActionResult UpDateCondicaoDeContorno(string nome, [FromBody] Estado estado)
		{
			bool nomeValido = Verifica.NomeEstado(simulacaoFinal.Contexto, nome) != "Nome de estado inválido!";
			if (nomeValido)
			{
				simulacaoFinal.Contexto.First(q => q.Nome == nome).Infectados = estado.Infectados;
				simulacaoFinal.Contexto.First(q => q.Nome == nome).Curados = estado.Curados;
				simulacaoFinal.Contexto.First(q => q.Nome == nome).Mortos = estado.Mortos;
			}
			return nomeValido ? Ok(simulacaoFinal.Contexto) : Ok("Nome de estado inválido!");
		}

		[HttpDelete]
		[Route("deleteEstado")]
		public ActionResult DeleteEstado(string nome)
		{
			bool nomeValido = Verifica.NomeEstado(simulacaoFinal.Contexto, nome) != "Nome de estado inválido!";
			return nomeValido ?
				Ok(simulacaoFinal.Contexto = simulacaoFinal.Contexto.Where(q => q.Nome != nome)) : Ok("Nome de estado inválido!");
		}

		[HttpGet]
		[Route("getFinalizaNovaSimulacao")]
		public ActionResult GetFinalizaNovaSimulacao(string nome, string descricao)
		{
			simulacaoFinal.Nome = nome;
			simulacaoFinal.Descricao = descricao;

			Registrar.Simulacao(simulacaoFinal);

			foreach (var estado in simulacaoFinal.Contexto)
				Registrar.Estados(estado, simulacaoFinal.ID);

			return Ok(simulacaoFinal);
		}

		[HttpGet]
		[Route("getSimulacoesAnteriores")]
		public ActionResult GetSimulacoesAnteriores()
		{
			return Ok(Buscar.Simulacao());
		}

		[HttpGet]
		[Route("getSelecionaSimulacaoAnterior")]
		public ActionResult getSelecionaSimulacaoAnterior(int id)
		{
			simulacaoFinal = Buscar.Simulacao().First(q => q.ID == id);
			simulacaoFinal.Contexto = Buscar.Estados(id);
			return Ok(simulacaoFinal);
		}

		[HttpGet]
		[Route("getAtualizaSimulacao")]
		public ActionResult GetAtualizaSimulacao()
		{
			Atualizar.Simulacao(simulacaoFinal);

			//TEM QUE ARRUMAR ESSA PARTE*************
			foreach (var estado in simulacaoFinal.Contexto)
				Registrar.Estados(estado, simulacaoFinal.ID);

			return Ok(simulacaoFinal);
		}

		[HttpDelete]
		[Route("deleteSimulacao")]
		public ActionResult DeleteSimulacao(int idSimulacao)
		{
			IEnumerable<Estado> contexto = ImplementaEstados.Brasil();
			Simulacao simulacaoFinal = new Simulacao() { ID = Buscar.Simulacao().Last(q => q.ID >= 0).ID + 1 };
			Excluir.Simulacao(idSimulacao);
			return Ok("Simulação excluida com sucesso!");
		}
	}
}
