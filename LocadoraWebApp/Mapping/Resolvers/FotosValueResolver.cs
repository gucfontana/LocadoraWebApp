using AutoMapper;
using Locadora.Dominio.ModuloVeiculos;
using LocadoraWebApp.Models;

namespace LocadoraWebApp.Mapping.Resolvers
{
    public class FotosValueResolver : IValueResolver<FormularioVeiculosViewModel, Veiculos, byte[]>
    {
        public FotosValueResolver() { }

        public byte[] Resolve
        (
            FormularioVeiculosViewModel source,
            Veiculos destination,
            byte[] destMember,
            ResolutionContext context
        )
        {
            using (var memoryStream = new MemoryStream())
            {
                source.Fotos.CopyTo(memoryStream);

                return memoryStream.ToArray();
            }
        }
    }
}