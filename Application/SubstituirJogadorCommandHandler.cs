using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatorSimples.Application
{
    public class SubstituirJogadorCommandHandler : IRequestHandler<SubstituirJogadorCommand, string>
    {
        public Task<string> Handle(SubstituirJogadorCommand request, CancellationToken cancellationToken)
        {
            request.Tecnico.SubstituiJogador(request.JogadorEmCampo, request.JogadorNoBanco);
            return Task.FromResult(
                request.QuartoArbitro.LevantaPlaca(
                    request.JogadorNoBanco.Numero, 
                    request.JogadorEmCampo.Numero
                )
            );
        }
    }
}