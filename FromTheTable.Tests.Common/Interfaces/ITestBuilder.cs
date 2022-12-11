namespace FromTheTable.Tests.Common.Interfaces;

public interface ITestBuilder
{
    void Save();
    Task SaveAsync();
}