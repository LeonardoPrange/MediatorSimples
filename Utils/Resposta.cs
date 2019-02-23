using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MediatorSimples.Utils
{
    public class Response<TResult>
    {
        private readonly IList<string> _messages = new List<string>();

        public IEnumerable<string> Errors { get; }
        public TResult Result { get; }
        public Response() => Errors = new ReadOnlyCollection<string>(_messages);
        public bool HasErrors => Errors.Any();
        public Response(TResult result) : this () => Result = result;
        public virtual Response<TResult> AddError(string message)
        {
            _messages.Add(message);
            return this;
        }
    }

    public class Response: Response<object>
    {
        
    }

}