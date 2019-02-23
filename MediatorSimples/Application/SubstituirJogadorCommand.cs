using System;
using MediatorSimples.Domain;
using MediatR;

namespace MediatorSimples.Application
{
    public class SubstituirJogadorCommand: IRequest<string>
    {
        public Tecnico Tecnico { get; private set; }
        public Jogador JogadorEmCampo { get; private set; }
        public Jogador JogadorNoBanco { get; private set; }
        public QuartoArbitro QuartoArbitro { get; private set; }
    
        public SubstituirJogadorCommand(
            Tecnico tecnico,    
            Jogador jogadorEmCampo,
            Jogador jogadorNoBanco,
            QuartoArbitro quartoArbitro
        )
        {
            Tecnico = tecnico;
            JogadorEmCampo = jogadorEmCampo;
            JogadorNoBanco = jogadorNoBanco;
            QuartoArbitro = quartoArbitro;
        }
    }
}