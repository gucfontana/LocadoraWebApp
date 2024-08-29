namespace Locadora.Dominio.ModuloCombustiveis
{
    public class Combustiveis
    {
        public decimal ValorAlcool { get; set; }
        public decimal ValorDiesel { get; set; }
        public decimal ValorGas { get; set; }
        public decimal ValorGasolina { get; set; }

        public Combustiveis() {} // frameworks

        public Combustiveis(decimal valorAlcool, decimal valorDiesel, decimal valorGas, decimal valorGasolina) : this()
        {
            ValorAlcool = valorAlcool;
            ValorDiesel = valorDiesel;
            ValorGas = valorGas;
            ValorGasolina = valorGasolina;
        }

        public decimal ObterValorCombustiveis(TipoCombustivelEnum tipoCombustivel)
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
