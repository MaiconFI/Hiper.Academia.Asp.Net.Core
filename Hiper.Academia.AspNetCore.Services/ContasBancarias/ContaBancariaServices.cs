using Hiper.Academia.AspNetCore.Domain.ContasBancarias;
using Hiper.Academia.AspNetCore.Repositories.ContasBancarias;
using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Services.ContasBancarias
{
    public class ContaBancariaServices : IContaBancariaServices
    {
        private readonly IContaBancariaRepository _contaBancariaRepository;

        public ContaBancariaServices(IContaBancariaRepository contaBancariaRepository)
        {
            _contaBancariaRepository = contaBancariaRepository;
        }

        public async Task<ContaBancaria> GetContaBancariaLogadaAsync()
            => await _contaBancariaRepository.GetContaBancariaLogadaAsync();
    }
}