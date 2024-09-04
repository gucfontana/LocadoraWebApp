﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Dominio.Compartilhado;
using Locadora.Dominio.ModuloAlugueis;
using Locadora.Dominio.ModuloCombustiveis;
using Locadora.Dominio.ModuloGrupoVeiculos;

namespace Locadora.Dominio.ModuloVeiculos
{
    public class Veiculos : EntidadeBase
    {
        // Propriedades
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public TipoCombustivelEnum TipoCombustivel { get; set; }
        public int CapacidadeTanque { get; set; }
        public int GrupoVeiculosId { get; set; }
        public GrupoVeiculos ? GrupoVeiculos { get; set; }
        public byte[] Fotos { get; set; }

        public bool Alugado { get; set; }

        // Construtores
        protected Veiculos() {}

        public Veiculos(string modelo, string marca, TipoCombustivel tipoCombustivel, int capacidadeTanque, int grupoVeiculosId)
        {
            Modelo = modelo;
            Marca = marca;
            TipoCombustivel = (TipoCombustivelEnum)tipoCombustivel;
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

        public void Alugar()
        {
            Alugado = true;
        }

        public void Entregar()
        {
            Alugado = false;
        }

        public object CalcularLitrosParaAbastecimento(MarcadorCombustivelEnum marcadorCombustivel)
        {
            switch (marcadorCombustivel)
            {
                case MarcadorCombustivelEnum.Vazio: return CapacidadeTanque;

                case MarcadorCombustivelEnum.Cheio: return ( CapacidadeTanque - ( CapacidadeTanque * 4 / 4 ) );

                case MarcadorCombustivelEnum.Metade: return ( CapacidadeTanque - ( CapacidadeTanque * 1 / 2 ) );

                default:
                    return 0;
            }
        }
    }
}
