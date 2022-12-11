using FromTheTable.Domain.Interfaces;

namespace FromTheTable.Tests.Common.Interfaces;

public interface IBuilder<T> where T : class
{
    T Build();
    Task<T> BuildAsync();
}