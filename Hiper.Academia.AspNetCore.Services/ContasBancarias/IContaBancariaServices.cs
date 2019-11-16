using System.Threading.Tasks;
using Hiper.Academia.AspNetCore.Domain.ContasBancarias;

namespace Hiper.Academia.AspNetCore.Services.ContasBancarias
{
    public interface IContaBancariaServices
    {
        Task<ContaBancaria> GetContaBancariaLogadaAsync();
    }
}