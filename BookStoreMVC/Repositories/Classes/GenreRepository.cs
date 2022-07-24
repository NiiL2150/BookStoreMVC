using BookStoreMVC.Models;
using BookStoreMVC.Repositories.Interfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookStoreMVC.Repositories.Classes
{
    public class GenreRepository : IRepository<Genre>
    {
        private readonly SqlConnection _connection;

        public GenreRepository()
        {
            _connection = DbContext.GetConnection();
        }

        public async Task<int> Add(Genre entity)
        {
            string sql = "INSERT INTO Genres (Name) VALUES (@Name)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Name", entity.Name);
            using IDbConnection db = _connection;
            return await db.ExecuteScalarAsync<int>(sql, dynamicParameters);
        }

        public async Task<int> Delete(int id)
        {
            string sql = "DELETE FROM Genres WHERE Id = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Id", id);
            using IDbConnection db = _connection;
            await db.ExecuteAsync(sql, dynamicParameters);
            return id;
        }

        public async Task<Genre> Get(int id)
        {
            string sql = "SELECT * FROM Genres WHERE Id = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Id", id);
            using IDbConnection db = _connection;
            return await db.QueryFirstOrDefaultAsync<Genre>(sql, dynamicParameters);
        }

        public async Task<IEnumerable<Genre>> GetByBookId(int id)
        {
            string sql = "SELECT * FROM Genres WHERE Id IN (SELECT GenreId FROM BookGenres WHERE BookId = @Id)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Id", id);
            using IDbConnection db = _connection;
            return await db.QueryAsync<Genre>(sql, dynamicParameters);
        }

        public async Task<int> Edit(Genre entity)
        {
            string sql = "UPDATE Genres SET Name = @Name WHERE Id = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Name", entity.Name);
            dynamicParameters.Add("@Id", entity.Id);
            using IDbConnection db = _connection;
            await db.ExecuteAsync(sql, dynamicParameters);
            return entity.Id;
        }

        public async Task<IEnumerable<Genre>> Get()
        {
            string sql = "SELECT * FROM Genres";
            using IDbConnection db = _connection;
            return await db.QueryAsync<Genre>(sql);
        }

        public async Task<int> Count()
        {
            string sql = "SELECT COUNT(*) FROM Genres";
            using IDbConnection db = _connection;
            return await db.ExecuteScalarAsync<int>(sql);
        }
    }
}
