using TesteApi.Api.Models;
using System.Collections.Generic;
using System;

namespace TesteApi.Api.Repositories
{
    public interface IFundoCapitalRepository
    {
        void Adicionar(FundoCapital fundo);

        void Alterar(FundoCapital fundo);

        IEnumerable<FundoCapital> ListarFundos();

        FundoCapital ObterPorId(Guid id);

        void RemoverFundo(FundoCapital fundo);


    }
}