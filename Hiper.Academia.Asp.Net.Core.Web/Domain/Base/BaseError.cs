using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hiper.Academia.Asp.Net.Core.Web.Domain.Base
{
    public abstract class BaseError
    {
        protected BaseError()
        {
            Errors = new List<string>();
        }

        public ICollection<string> Errors { get; private set; }

        public void AddError(string error) => Errors.Add(error);

        public bool IsValid() => !Errors.Any();
    }
}
