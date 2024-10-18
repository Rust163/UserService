using Dapper;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace UserService.Attributes {
    public class Repository<T> : IRepository<T> where T : class {
        private readonly IDbConnection _connection;
        private readonly string _tableName;

        public Repository(IDbConnection connection) {
            _connection = connection;
            _tableName = GetTableName();
        }

        private string GetTableName() {
            var tableAttributes = (TableAttribute)typeof(T).GetCustomAttributes(typeof(TableAttribute));
            return tableAttributes.TableName;
        }

        private IEnumerable<string> GetColumns() { 
            return typeof(T).GetProperties()
                .Where(p => p.GetCustomAttribute(typeof(ColumnAttribute)) != null)
                .Select(p => ((ColumnAttribute)p.GetCustomAttribute(typeof(ColumnAttribute))).ColumnName);
        }

        public async Task<T> GetByIdAsync(int id) {
            var columns = string.Join(", ", GetColumns());
            var queryGetById = $"SELECT {columns} FROM {_tableName} WHERE Id = @Id";
            return await _connection.QuerySingleOrDefaultAsync<T>(queryGetById, new{id = id});
        }

        public async Task<IEnumerable<T>> GetAllAsync() {
            var columns = string.Join(", ", GetColumns());
            var queryGetAll = $"SELECT {columns} FROM {_tableName}";
            return await _connection.QueryAsync<T>(queryGetAll);
        }

        public async Task AddAsync(T entity) {
            var columns = GetColumns();
            var columnsName = string.Join(", ", columns);
            var parametrName = string.Join(", ", columns.Select(c => $"@{c}"));
            var queryAdd = $"INSERT INTO {_tableName} ({columnsName}) VALUES ({parametrName})";
            await _connection.ExecuteAsync(queryAdd, entity);
        }

        public async Task UpdateAsync(T entity) {
            var columns = GetColumns();
            var setProp = string.Join(", ", columns.Select(c => $"{c} = @{c}"));
            var queryUpdate = $"UPDATE {_tableName} SET {setProp} WHERE Id = @Id";
            await _connection.ExecuteAsync(queryUpdate, entity);
        }

        public async Task DeleteAsync(int id) {
            var queryDelete = $"DELETE FROM {_tableName} WHERE Id = @Id";
            await _connection.ExecuteAsync(queryDelete, new {Id = id}); 
        }
    }
}
