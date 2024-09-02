using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloGrupoVeiculos;

namespace Locadora.Dominio.ModuloVeiculos
{
    public class Veiculos : EntidadeBase 
    {
        // Propriedades
public string Modelo { get; set; }
        public string Marca { get; set; }
        public TipoCombustivel TipoCombustivel { get; set; }
        public int CapacidadeTanque { get; set; }
        public int GrupoVeiculosId { get; set; }
        public GrupoVeiculos ? GrupoVeiculos { get; set; }
        public byte[] Fotos { get; set; }

        // Construtores
        protected Veiculos() {}

        public Veiculos(string modelo, string marca, TipoCombustivel tipoCombustivel, int capacidadeTanque, int grupoVeiculosId)
        {
            Modelo = modelo;
            Marca = marca;
            TipoCombustivel = tipoCombustivel;
            CapacidadeTanque = capacidadeTanque;
            GrupoVeiculosId = grupoVeiculosId;
        }

        // Validações
        public override List<string> Validar()
        {
            List<string> erros = [];

            if (string.IsNullOrEmpty(Modelo))
                erros.Add("Modelo é obrigatório");

            if (string.IsNullOrEmpty(Marca))
                erros.Add("Marca é obrigatória");

            if (CapacidadeTanque == 0)
                erros.Add("Capacidade do tanque é obrigatória");

            if (GrupoVeiculosId == 0)
                erros.Add("Grupo de veículos é obrigatório");

            return erros;
        }

        public static bool Alugado { get; set; }
        
        public static void Alugar()
        {
            Alugado = true;
        }

        public static void Desocupar()
        {
            Alugado = false;
        }
    }
}
