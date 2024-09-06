using Microsoft.AspNetCore.Identity;

namespace Locadora.Dominio.ModuloAutenticacao
{
    public sealed class Usuario : IdentityUser<int> 
    {
        public Usuario()
        {
            EmailConfirmed = true;
        }
    }
}