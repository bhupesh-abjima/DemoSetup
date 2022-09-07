using System.Data;

namespace Xamplifier.DataInterfaces
{
    public interface IDatabaseFactory : IDisposable
    {
        IDbConnection Get();
    }
}