using IncomeStatement.Domain.Common;
using IncomeStatement.Domain.Statement;
using IncomeStatement.Domain.Statement.Interfaces;
using IncomeStatement.Infrastructure.Persistance;
using IncomeStatement.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System.Data;

namespace IncomeStatement.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger _logger;

        private IDbTransaction _transaction;
        private IDbConnection _connection;
        private bool _disposed;

        public UnitOfWork(DapperContext context, ILogger<UnitOfWork> logger)
        {
            _logger = logger;
            _connection = context.CreateConnection();
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }
        public IStatementRepository Statements => 
            new StatementRepository(_transaction, _logger);
        
        public IRepository<LineItem> LineItems => 
            new LineItemRespository(_transaction, _logger);

        public IRepository<LineItemCategory> Categories =>
            new CategoryRepository(_transaction, _logger);

        public IRepository<LineItemSubcategory> Subcategories =>
            new SubcategoryRepository(_transaction, _logger);

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError("{}", ex.Message);
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();

            }
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _transaction.Dispose();
                    _connection.Close();
                    _connection.Dispose();  
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
