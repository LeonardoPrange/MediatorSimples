using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MediatorSimples.Utils
{
    public class Resposta<TResultado>
    {
        private readonly IList<string> _mensagens = new List<string>();
        public IEnumerable<string> Erros { get; }
        public TResultado Resultado { get; }
        public Resposta() => Erros = new ReadOnlyCollection<string>(_mensagens);
        public bool PossuiErros => Erros.Any();
        public Resposta(TResultado resultado) : this () => Resultado = resultado;
        public virtual Resposta<TResultado> AdicionaErros(string message)
        {
            _mensagens.Add(message);
            return this;
        }
    }

    public class Resposta: Resposta<object>
    {
        
    }

}