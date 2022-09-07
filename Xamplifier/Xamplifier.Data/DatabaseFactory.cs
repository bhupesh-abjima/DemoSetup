using System.Data;
using System.Data.SqlClient;

using Microsoft.Extensions.Logging;
using Xamplifier.DataInterfaces;

namespace Xamplifier.Data
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private readonly ILogger<IDatabaseFactory> _logger;
        private readonly string _connectionString;
        public DatabaseFactory(ILogger<IDatabaseFactory> logger, string connectionString)
        {
            _logger = logger;
            _connectionString = connectionString;
        }

        private IDbConnection _dbContext;
        public IDbConnection Get()
        {
            if (_dbContext == null)
            {
                try
                {
                    _dbContext = new SqlConnection(_connectionString);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Exception in DatabaseFactory/Get {0}ConnectionString: {1},  Exception:{2}", Environment.NewLine, _connectionString, ex);
                }
            }
            return _dbContext;
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
