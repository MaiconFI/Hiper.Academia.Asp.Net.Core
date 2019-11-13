using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hiper.Academia.Asp.Net.Core.Web.Domain.Base
{
    public abstract class BaseEntity : BaseError
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private set; }

        public Guid IdExterno { get; private set; }

        public void GerarIdExterno() => IdExterno = Guid.NewGuid();

        public void SetId(long id)
        {
            if (id == default)
            {
                AddError("Id inválido.");
                return;
            }

            Id = id;
        }
    }
}
