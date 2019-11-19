namespace Hiper.Academia.AspNetCore.Domain.Base.Builders
{
    public interface IBuilder<T> where T : EntityBase
    {
        T Build();
    }
}