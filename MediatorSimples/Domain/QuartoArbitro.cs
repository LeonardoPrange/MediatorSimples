using System;

namespace MediatorSimples.Domain
{
    public class QuartoArbitro
    {
        public Guid ID { get; private set; }
        public string Nome { get; private set; }

        public QuartoArbitro(string nome)
        {
            ID = Guid.NewGuid();
            Nome = nome;
        }

        public string LevantaPlaca(int numeroEntra, int numeroSai)
        => $"Entra: {numeroEntra} - Sai: {numeroSai}";     
    }
}