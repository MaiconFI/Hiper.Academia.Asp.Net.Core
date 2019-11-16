using System.Collections.Generic;

namespace Hiper.Academia.AspNetCore.Dtos.Base
{
    public abstract class DtoBase
    {
        protected DtoBase()
        {
            Errors ??= new List<string>();
        }

        public ICollection<string> Errors { get; private set; }

        public void AddError(string error)
        {
            if (!Errors.Contains(error))
                Errors.Add(error);
        }

        public void AddError(IEnumerable<string> errors)
        {
            foreach (var error in errors) AddError(error);
        }
    }
}