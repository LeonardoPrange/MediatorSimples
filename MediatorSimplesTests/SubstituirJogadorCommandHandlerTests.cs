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

            var command = new SubstituirJogadorCommand(
                tecnico, 
                tecnico.Time.FirstOrDefault(j => j.Nome == "Leonardo"), 
                tecnico.Time.FirstOrDefault(j => j.Nome == "Marcel"), 
                new QuartoArbitro("Ivan")
            );

            var commandHandler = new SubstituirJogadorCommandHandler();

            var time = await commandHandler.Handle(command, new CancellationToken());
            time.FirstOrDefault(j => j.Nome == "Marcel").EstaEmCampo.Should().BeTrue();
            time.FirstOrDefault(j => j.Nome == "Leonardo").EstaEmCampo.Should().BeFalse();
        }
    }
}