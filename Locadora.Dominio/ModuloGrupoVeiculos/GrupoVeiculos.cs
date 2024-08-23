using System.Runtime.CompilerServices;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloVeiculos;

namespace Locadora.Dominio.ModuloGrupoVeiculos;

public class GrupoVeiculos : EntidadeBase
{
    protected GrupoVeiculos() {} // construtor vazio para o Entity Framework

    public GrupoVeiculos(string nome) // construtor para criar um novo GrupoVeiculos
    {
Nome = nome;
}

        public string Nome { get; set; } = null!; // propriedade para o nome do GrupoVeiculos

        public List<Veiculos> Veiculos { get; set; } = []; // propriedade para a lista de Veiculos

    public override List<string> Validar() // método para validar o GrupoVeiculos
    {
        var erros = new List<string>();

        if (Nome.Length < 3)
            erros.Add("Nome é obrigatório");

        return erros;
    }

}

