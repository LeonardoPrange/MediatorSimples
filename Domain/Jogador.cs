using System;

namespace MediatorSimples.Domain
{
    public class Jogador
    {
        public Guid ID { get; private set; }
        public string Nome { get; private set; }
        public int Numero { get; private set; }
        public bool EstaEmCampo { get; private set; }

        public Jogador(string nome, int numero, bool estaEmCampo)
        {
            ID = Guid.NewGuid();
            Nome = nome;
            Numero = numero;
            EstaEmCampo = estaEmCampo;
        }
        public void SaiDeCampo()
        {
            EstaEmCampo = false;
        }

        public void EntraEmCampo()
        {
            EstaEmCampo = true;
        }
    }
}