using FluentValidation;

namespace MediatorSimples.Application
{
    public class SubstituirJogadorCommandValidator: AbstractValidator<SubstituirJogadorCommand>
    {
        public SubstituirJogadorCommandValidator()
        {
            RuleFor(command => command.Tecnico).NotNull();
            RuleFor(command => command.JogadorEmCampo).NotNull();
            RuleFor(command => command.JogadorNoBanco).NotNull();
            RuleFor(command => command.QuartoArbitro).NotNull();
        }
    }
}