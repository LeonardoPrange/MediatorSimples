using System;
using System.Collections.Generic;

namespace MediatorSimples.Domain
{
    public class Tecnico
    {
        public Guid ID { get; private set; }
        public string Nome { get; private set; }
        public IEnumerable<Jogador> Time { get; private set; }

        public Tecnico(string nome)
        {
            ID = Guid.NewGuid();
            Nome = nome;
            Time = EscalaTime();
        }

        public void SubstituiJogador(Jogador JogadorEmCampo, Jogador JogadorNoBanco)
        {
            JogadorEmCampo.SaiDeCampo();
            JogadorNoBanco.EntraEmCampo();
        }

        private IEnumerable<Jogador> EscalaTime()
        {
            string[] nomes = new string[14] {"Leonardo", "Pedro", "Marco", 
            "Juliano", "Rô", "Portuga", "Luis", "Leandro", "Antonio", "Romulo", 
            "Peralta", "Pedro Legacy", "Marcel", "Gabriel"};
            for (int i = 0; i < nomes.Length; i++)
            {
                if(i <= 11)     
                    yield return new Jogador(nomes[i], i, true);
                else
                    yield return new Jogador(nomes[i], i, false);       
            }
        }
    }
}