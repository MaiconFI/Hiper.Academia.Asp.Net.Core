using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hiper.Academia.AspNetCore.Domain.Base
{
    public abstract class EntityBase : ErrorBase
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