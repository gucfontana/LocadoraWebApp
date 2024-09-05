using Microsoft.AspNetCore.Identity;

namespace Locadora.Dominio.ModuloAutenticacao
{
    public sealed class Usuario : IdentityUser<int> 
    {
        public int ? EmpresaId { get; set; }
        public Usuario ? Empresa { get; set; }

        public Usuario()
        {
            EmailConfirmed = true;
        }
    }
}