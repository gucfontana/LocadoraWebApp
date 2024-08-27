using FluentResults;
using Locadora.Dominio.ModuloTaxas;

namespace Locadora.Aplicacao.ModuloTaxas
{
    public class ServicoTaxas
    {
        private readonly IRepositorioTaxas repositorioTaxas;

        public ServicoTaxas(IRepositorioTaxas repositorioTaxas)
        {
            this.repositorioTaxas = repositorioTaxas;
        }

        public Result<Taxas> Inserir(Taxas taxa)
        {
            var errosValidacao = taxa.Validar();
            
            if (errosValidacao.Count > 0)
                return Result.Fail(errosValidacao);
            
            repositorioTaxas.Inserir(taxa);
            
            return Result.Ok(taxa);
        }

        public Result<Taxas> Editar(Taxas taxaEditada)
        {
            var taxa = repositorioTaxas.SelecionarPorId(taxaEditada.Id);

            if (taxaEditada is null)
                return Result.Fail("Taxa nao encontrada");
            
            var errosValidacao = taxa.Validar();
            
            if (errosValidacao.Count > 0)
                return Result.Fail(errosValidacao);
            
            taxa.Nome = taxaEditada.Nome;
            taxa.Valor = taxaEditada.Valor;
            taxa.TipoCobranca = taxaEditada.TipoCobranca;
            
            repositorioTaxas.Editar(taxa);
            
            return Result.Ok(taxa);
        }

        public Result<Taxas> Excluir(int taxaId)
        {
            var taxas = repositorioTaxas.SelecionarPorId(taxaId);
            
            if (taxas is null)
                return Result.Fail("Taxa nao encontrada");
            
            repositorioTaxas.Excluir(taxas);
            
            return Result.Ok(taxas);
        }

        public Result<Taxas> SelecionarPorId(int taxaId)
        {
            var taxas = repositorioTaxas.SelecionarPorId(taxaId);
            
            // se falhar
            if (taxas is null)
                return Result.Fail("Taxa nao encontrada");
            
            // se ok
            else return Result.Ok(taxas);
        }

        public Result<List<Taxas>> SelecionarTodos()
        {
            var taxas = repositorioTaxas.SelecionarTodos();
            
            return Result.Ok(taxas);
        }
    }
}
