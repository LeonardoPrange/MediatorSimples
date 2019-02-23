using System.Linq;
using System.Threading;
using FluentAssertions;
using MediatorSimples.Application;
using MediatorSimples.Domain;
using Xunit;

namespace MediatorSimples.Tests
{
    public class SubstituirJogadorCommandHandlerTests
    {
        [Fact (DisplayName=@"
            DADO
                Que Antonio escalou o time da Qualyteam
            Quando
                Durante o jogo ele descide fazer uma substituição
            Então
                Quarto arbitro Ivan levanta a bandeira
                E Leonardo sai de campo 
                e Marcel entra em campo
        ")]
        public async void Handle_DeveSubstituirLeonardoPorMarcel()
        {
            var tecnico = new Tecnico("Antonio");
            var jogadorParaSair = tecnico.Time.FirstOrDefault(j => j.Nome == "Leonardo");
            var jogadorParaEntrar = tecnico.Time.FirstOrDefault(j => j.Nome == "Marcel");
            var quartoArbitro = new QuartoArbitro("Ivan");
            
            var command = new SubstituirJogadorCommand(
                tecnico, 
                jogadorParaSair, 
                jogadorParaEntrar, 
                quartoArbitro
            );
            
            var commandHandler = new SubstituirJogadorCommandHandler();
            var resposta = await commandHandler.Handle(command, new CancellationToken());
            
            resposta.Should().Be($"Entra: {jogadorParaEntrar.Numero} - Sai: {jogadorParaSair.Numero}");
        }
    }
}