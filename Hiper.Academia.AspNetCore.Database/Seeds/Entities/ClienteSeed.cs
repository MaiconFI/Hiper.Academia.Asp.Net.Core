using Hiper.Academia.AspNetCore.Database.Context;
using Hiper.Academia.AspNetCore.Domain;
using System;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Database.Seeds.Entities
{
    public class ClienteSeed : IEntitySeed
    {
        private readonly IHiperAcademiaContext _hiperAcademiaContext;

        public ClienteSeed(IHiperAcademiaContext hiperAcademiaContext)
        {
            _hiperAcademiaContext = hiperAcademiaContext;
        }

        public async Task ExecuteAsync()
        {
            var cliente = new Cliente("Brusque", DateTime.Now, "Joao", "(47) 69514747");
            await _hiperAcademiaContext.Clientes.AddAsync(cliente);
        }
    }
}