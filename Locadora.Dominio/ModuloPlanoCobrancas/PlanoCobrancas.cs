using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloGrupoVeiculos;

namespace Locadora.Dominio.ModuloPlanoCobrancas
{
    public class PlanoCobrancas : EntidadeBase
    {
        public int GrupoVeiculosId { get; set; }
        public GrupoVeiculos ? GrupoVeiculos { get; set; }
        public decimal ValorDiario { get; set; }
        public decimal ValorKmDiario { get; set; }
        public decimal ValorKmControlado { get; set; }
        public decimal ValorDiarioControlado { get; set; }
        public decimal ValorKmExcedido { get; set; }
        public decimal ValorDiarioKmLivre { get; set; }

        protected PlanoCobrancas() {}

        public PlanoCobrancas
        (
            int grupoVeiculosId,
            decimal valorDiario,
            decimal valorKmDiario,
            decimal valorKmControlado,
            decimal valorDiarioControlado,
            decimal valorKmExcedido,
            decimal valorDiarioKmLivre
        )
        {
            GrupoVeiculosId = grupoVeiculosId;
            ValorDiario = valorDiario;
            ValorKmDiario = valorKmDiario;
            ValorKmControlado = valorKmControlado;
            ValorDiarioControlado = valorDiarioControlado;
            ValorKmExcedido = valorKmExcedido;
            ValorDiarioKmLivre = valorDiarioKmLivre;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (GrupoVeiculosId == 0)
                erros.Add("Grupo de veículos é obrigatório");

            return erros;
        }
    }
}
