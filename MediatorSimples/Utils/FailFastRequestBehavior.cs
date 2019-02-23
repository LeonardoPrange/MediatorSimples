using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace MediatorSimples.Utils
{
    public class FailFastRequestBehavior<TRequisicao, TResposta> 
    : IPipelineBehavior<TRequisicao, TResposta> where TRequisicao 
    : IRequest<TResposta> where TResposta : Resposta
    {
        private readonly IEnumerable<IValidator> _validators;

        public FailFastRequestBehavior(IEnumerable<IValidator<TRequisicao>> validators)
        {
            _validators = validators;
        }

        public Task<TResposta> Handle(TRequisicao requisicao, CancellationToken cancellationToken, RequestHandlerDelegate<TResposta> next)
        {
            var falhas = _validators
                .Select(v => v.Validate(requisicao))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            return falhas.Any()
                ? Errors(falhas)
                : next();
        }

        private static Task<TResposta> Errors(IEnumerable<ValidationFailure> falhas)
        {
            var resposta = new Resposta();

            foreach (var falha in falhas)
            {
                resposta.AdicionaErros(falha.ErrorMessage);
            }

            return Task.FromResult(resposta as TResposta);
        }
    }
}
