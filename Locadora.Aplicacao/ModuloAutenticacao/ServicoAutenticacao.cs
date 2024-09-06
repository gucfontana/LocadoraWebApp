using System.Security.Authentication;
using System.Security.Claims;
using FluentResults;
using Locadora.Dominio.ModuloAutenticacao;
using Locadora.Dominio.ModuloFuncionario;
using Microsoft.AspNetCore.Identity;

namespace Locadora.Aplicacao.ModuloAutenticacao
{
    public class ServicoAutenticacao
    {
        private readonly UserManager<Usuario> userManager;
        private readonly SignInManager<Usuario> signInManager;
        private readonly RoleManager<Perfil> roleManager;
        private readonly IRepositorioFuncionario repositorioFuncionario;

        public ServicoAutenticacao(UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, RoleManager<Perfil> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            IRepositorioFuncionario repositorioFuncionario;
        }

        public async Task<Result<Usuario>> Registrar(Usuario usuario, string senha, TipoUsuarioEnum tipoUsuario)
        {
            var resultadoCriacaoUsuario = await userManager.CreateAsync(usuario, senha);

            var tipoUsuarioStr = tipoUsuario.ToString();

            var resultadoBuscaTipoUsuario = await roleManager.FindByNameAsync(tipoUsuarioStr);

            if (resultadoBuscaTipoUsuario is null)
            {
                var perfil = new Perfil()
                {
                    Name = tipoUsuarioStr,
                    NormalizedName = tipoUsuarioStr.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                };

                await roleManager.CreateAsync(perfil);
            }

            await userManager.AddToRoleAsync(usuario, tipoUsuarioStr);

            if (resultadoCriacaoUsuario.Succeeded && tipoUsuario == TipoUsuarioEnum.Empresa)
            {
                await signInManager.SignInAsync(usuario, isPersistent: false);
            }
            else if (!resultadoCriacaoUsuario.Succeeded)
            {
                var erros = resultadoCriacaoUsuario.Errors.Select(s => s.Description);

                return Result.Fail(erros);
            }
            return Result.Ok(usuario);
        }

        public async Task<Result> Login(string usuario, string senha)
        {
            var resultadoLogin = await signInManager.PasswordSignInAsync(usuario, senha, false, false);

            if (!resultadoLogin.Succeeded)
                return Result.Fail("Login ou senha incorretos");

            return Result.Ok();
        }

        public async Task<Result> LogOut()
        {
            await signInManager.SignOutAsync();

            return Result.Ok();
        }

        public async Task<int ?> ObterIdEmpresaAsync(ClaimsPrincipal claim)
        {
            var usuario = await userManager.GetUserAsync(claim);

            var perfilSelecionado = TipoUsuarioEnum.Funcionario.ToString();

            if (claim.IsInRole(perfilSelecionado))
            {
                var funcionario = repositorioFuncionario
                    .SelecionarPorId(f => f.UsuarioId == usuario!.Id);

                if (funcionario is null)
                    throw new AuthenticationException("N�o foi poss�vel selecionar o funcion�rio registrado!");

                return funcionario.EmpresaId;
            }

            return usuario?.Id;
        }
    }
}
