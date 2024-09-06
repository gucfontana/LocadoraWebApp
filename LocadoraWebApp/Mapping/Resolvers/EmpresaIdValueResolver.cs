using System.Security.Authentication;
using AutoMapper;
using Locadora.Aplicacao.ModuloAutenticacao;

namespace LocadoraWebApp.Mapping.Resolvers;

    public class EmpresaIdValueResolver : IValueResolver<object, object, int>
    {
        private readonly ServicoAutenticacao servicoAutenticacao;
        private readonly IHttpContextAccessor httpContextAccessor;

        public EmpresaIdValueResolver(ServicoAutenticacao servicoAutenticacao, IHttpContextAccessor httpContextAccessor)
        {
            this.servicoAutenticacao = servicoAutenticacao;
            this.httpContextAccessor = httpContextAccessor;
        }

        public int Resolve(object source, object destination, int destMember, ResolutionContext context)
        {
            var usuarioClaim = httpContextAccessor.HttpContext?.User;

            var empresaId = servicoAutenticacao.ObterIdEmpresaAsync(usuarioClaim!).Result;

            if (empresaId is null)
                throw new AuthenticationException("N�o foi poss�vel obter o ID da empresa requisitada!");

            return empresaId.Value;
        }
    }