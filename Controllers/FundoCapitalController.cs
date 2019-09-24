using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TesteApi.Api.Models;
using TesteApi.Api.Repositories;

namespace TesteApi.Api.Controllers
{
    public class FundoCapitalController : Controller
    {
        private readonly IFundoCapitalRepository _repositorio;

        public FundoCapitalController(IFundoCapitalRepository repositorio)
        {
            _repositorio = repositorio;
        }
        
        [HttpGet("v1/fundocapital")]
        public IActionResult ListarFundos()
        {
            return Ok(
                _repositorio.ListarFundos()
            );
        }

        [HttpPost("v1/fundocapital")]
        public IActionResult AdicionarFundo([FromBody]FundoCapital fundo)
        {
            _repositorio.Adicionar(fundo);
            return Ok();
        }

        [HttpPut("v1/fundocapital/{id}")]
        public IActionResult AlterarFundo(Guid id, [FromBody]FundoCapital fundo)
        {
            var fundoAntigo = _repositorio.ObterPorId(id);
            if(fundoAntigo == null)
            {
                return NotFound();
            }

            fundoAntigo.Nome = fundo.Nome;
            fundoAntigo.ValorAtual = fundo.ValorAtual;
            fundoAntigo.ValorNecessario = fundo.ValorNecessario;
            fundoAntigo.ValorAtual = fundo.ValorAtual;

            _repositorio.Alterar(fundoAntigo);
            return Ok(fundoAntigo);
        }

        [HttpGet("v1/fundocapital/{id}")]
        public IActionResult ObterFundo(Guid id)
        {
            var fundoAntigo = _repositorio.ObterPorId(id);

            if(fundoAntigo == null)
            {
                return NotFound();
            }

            return Ok(fundoAntigo);
        }

        [HttpDelete("v1/fundocapital/{id}")]
        public IActionResult RemoverFundo(Guid id)
        {
            var fundoAntigo = _repositorio.ObterPorId(id);

            if(fundoAntigo == null)
            {
                return NotFound();
            }
            _repositorio.RemoverFundo(fundoAntigo);
            return Ok(fundoAntigo);
        }
    }
}