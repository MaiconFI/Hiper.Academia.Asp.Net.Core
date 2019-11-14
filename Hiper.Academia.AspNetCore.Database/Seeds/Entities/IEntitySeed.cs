using System.Threading.Tasks;

namespace Hiper.Academia.AspNetCore.Database.Seeds.Entities
{
    public interface IEntitySeed
    {
        Task ExecuteAsync();
    }
}