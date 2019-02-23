using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatorSimples.Domain;
using MediatorSimples.Utils;
using MediatR;

namespace MediatorSimples.Application
{
    public class SubstituirJogadorCommandHandler : IRequestHandler<SubstituirJogadorCommand, IEnumerable<Jogador>>
    {
        public Task<IEnumerable<Jogador>> Handle(SubstituirJogadorCommand request, CancellationToken cancellationToken)
        {
            request.Tecnico.PedeSubstituicao(request.JogadorNoBanco.Nome, request.JogadorEmCampo.Nome);
            request.QuartoArbitro.LevantaPlaca(request.JogadorNoBanco.Numero, request.JogadorEmCampo.Numero);
            return Task.FromResult(
                SubstituiJogador(
                    request.Tecnico.Time, 
                    request.JogadorNoBanco.Nome, 
                    request.JogadorEmCampo.Nome
                )
            );
        }

        private IEnumerable<Jogador> SubstituiJogador(IEnumerable<Jogador> time, string nomeJogadorQueEntra, string nomeJogadorQueSai)
        {
            var timeAposSaida = JogadorSaiDeCampo(time, nomeJogadorQueSai);
            return JogadorEntraEmCampo(timeAposSaida, nomeJogadorQueEntra);
        }

        private IEnumerable<Jogador> JogadorEntraEmCampo(IEnumerable<Jogador> time, string nome)
        {
            foreach (var jogador in time)
            {
                if(jogador.Nome == nome)
                {
                    jogador.EntraEmCampo();
                    yield return jogador;
                }
                yield return jogador;
            }
        }

        private IEnumerable<Jogador> JogadorSaiDeCampo(IEnumerable<Jogador> time, string nome)
        {
            foreach (var jogador in time)
            {
                if(jogador.Nome == nome)
                {
                    jogador.SaiDeCampo();
                    yield return jogador;
                }
                yield return jogador;
            }
        }
    }
}