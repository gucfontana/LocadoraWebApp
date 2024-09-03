namespace Locadora.Dominio.ModuloCombustiveis
{
    public class Combustiveis
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }

        public decimal ValorGasolina { get; set; }
        public decimal ValorGas { get; set; }
        public decimal ValorDiesel { get; set; }
        public decimal ValorAlcool { get; set; }

        protected Combustiveis() {}

        public Combustiveis
        (
            decimal valorGasolina,
            decimal valorGas,
            decimal valorDiesel,
            decimal valorAlcool
        ) : this()
        {
            ValorGasolina = valorGasolina;
            ValorGas = valorGas;
            ValorDiesel = valorDiesel;
            ValorAlcool = valorAlcool;
        }

        public decimal ObterValorCombustivel(TipoCombustivelEnum tipoCombustivel)
        {
            return tipoCombustivel switch
            {
                TipoCombustivelEnum.Alcool => ValorAlcool,
                TipoCombustivelEnum.Diesel => ValorDiesel,
                TipoCombustivelEnum.Gas => ValorGas,
                _ => ValorGasolina
            };
        }
    }
}