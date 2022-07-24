using BookStoreMVC.Models;
using BookStoreMVC.Repositories.Interfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookStoreMVC.Repositories.Classes
{
    public class AuthorRepository : IRepository<Author>
    {
        private readonly SqlConnection _connection;

        public AuthorRepository()
        {
            _connection =DbContext.GetConnection();
        }

        public async Task<int> Add(Author entity)
        {
            string sql = "INSERT INTO Authors (Name) VALUES (@Name)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Name", entity.Name);
            using IDbConnection db = _connection;
            return await db.ExecuteScalarAsync<int>(sql, dynamicParameters);
        }

        public async Task<int> Delete(int id)
        {
            string sql = "DELETE FROM Authors WHERE Id = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Id", id);
            using IDbConnection db = _connection;
            await db.ExecuteAsync(sql, dynamicParameters);
            return id;
        }

        public async Task<Author> Get(int id)
        {
            string sql = "SELECT * FROM Authors WHERE Id = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Id", id);
            using IDbConnection db = _connection;
            return await db.QueryFirstOrDefaultAsync<Author>(sql, dynamicParameters);
        }

        public async Task<IEnumerable<Author>> GetByBookId(int id)
        {
            string sql = "SELECT * FROM Authors WHERE Id IN (SELECT AuthorId FROM BookAuthors WHERE BookId = @Id)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Id", id);
            using IDbConnection db = _connection;
            return await db.QueryAsync<Author>(sql, dynamicParameters);
        }

        public async Task<int> Edit(Author entity)
        {
            string sql = "UPDATE Authors SET Name = @Name WHERE Id = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Name", entity.Name);
            dynamicParameters.Add("@Id", entity.Id);
            using IDbConnection db = _connection;
            await db.ExecuteAsync(sql, dynamicParameters);
            return entity.Id;
        }

        public async Task<IEnumerable<Author>> Get()
        {
            string sql = "SELECT * FROM Authors";
            using IDbConnection db = _connection;
            return await db.QueryAsync<Author>(sql);
        }

        public async Task<int> Count()
        {
            string sql = "SELECT COUNT(*) FROM Authors";
            using IDbConnection db = _connection;
            return await db.ExecuteScalarAsync<int>(sql);
        } 
    }
}
