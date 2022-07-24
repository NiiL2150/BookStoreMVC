using BookStoreMVC.Models;
using BookStoreMVC.Repositories.Interfaces;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace BookStoreMVC.Repositories.Classes
{
    //only getting book by individual id loads genres and authors
    public class BookRepository : IRepository<Book>
    {
        private readonly SqlConnection _connection;

        public BookRepository()
        {
            _connection = DbContext.GetConnection();
        }

        public async Task<int> Add(Book entity)
        {
            string sql = "INSERT INTO Books (Title, Description, Price, Pages) VALUES (@Title, @Description, @Price, @Pages)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Title", entity.Title);
            dynamicParameters.Add("@Description", entity.Description);
            dynamicParameters.Add("@Price", entity.Price);
            dynamicParameters.Add("@Pages", entity.Pages);
            using IDbConnection db = _connection;
            return await db.ExecuteScalarAsync<int>(sql, dynamicParameters);
        }

        public async Task<int> Delete(int id)
        {
            string sql = "DELETE FROM Books WHERE Id = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Id", id);
            using IDbConnection db = _connection;
            await db.ExecuteAsync(sql, dynamicParameters);
            return id;
        }

        public async Task<Book> Get(int id)
        {
            string sql = "SELECT * FROM Books WHERE Id = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Id", id);
            using IDbConnection db = _connection;
            Book book = await db.QueryFirstOrDefaultAsync<Book>(sql, dynamicParameters);
            string sql2 = "SELECT Id FROM BookGenres WHERE BookId = @Id";
            DynamicParameters dynamicParameters2 = new();
            dynamicParameters2.Add("@Id", id);
            book.GenresIds = (IList<int>)await db.QueryAsync<int>(sql2, dynamicParameters2);
            string sql3 = "SELECT Id FROM BookAuthors WHERE BookId = @Id";
            DynamicParameters dynamicParameters3 = new();
            dynamicParameters3.Add("@Id", id);
            book.AuthorsIds = (IList<int>)await db.QueryAsync<int>(sql3, dynamicParameters3);
            return book;
        }

        public async Task<int> Edit(Book entity)
        {
            string sql = "UPDATE Books SET Title = @Title, Description = @Description, Price = @Price, Pages = @Pages WHERE Id = @Id";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@Title", entity.Title);
            dynamicParameters.Add("@Description", entity.Description);
            dynamicParameters.Add("@Price", entity.Price);
            dynamicParameters.Add("@Pages", entity.Pages);
            dynamicParameters.Add("@Id", entity.Id);
            using IDbConnection db = _connection;
            await db.ExecuteAsync(sql, dynamicParameters);
            return entity.Id;
        }

        public async Task<int> AddAuthor(int bookId, int authorId)
        {
            string sql = "INSERT INTO BookAuthors (BookId, AuthorId) VALUES (@BookId, @AuthorId)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@BookId", bookId);
            dynamicParameters.Add("@AuthorId", authorId);
            using IDbConnection db = _connection;
            return await db.ExecuteScalarAsync<int>(sql, dynamicParameters);
        }

        public async Task<int> AddGenre(int bookId, int genreId)
        {
            string sql = "INSERT INTO BookGenres (BookId, GenreId) VALUES (@BookId, @GenreId)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@BookId", bookId);
            dynamicParameters.Add("@GenreId", genreId);
            using IDbConnection db = _connection;
            return await db.ExecuteScalarAsync<int>(sql, dynamicParameters);
        }

        public async Task<int> DeleteAuthor(int bookId, int authorId)
        {
            string sql = "DELETE FROM BookAuthors WHERE BookId = @BookId AND AuthorId = @AuthorId";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@BookId", bookId);
            dynamicParameters.Add("@AuthorId", authorId);
            using IDbConnection db = _connection;
            await db.ExecuteAsync(sql, dynamicParameters);
            return bookId;
        }

        public async Task<int> DeleteGenre(int bookId, int genreId)
        {
            string sql = "DELETE FROM BookGenres WHERE BookId = @BookId AND GenreId = @GenreId";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@BookId", bookId);
            dynamicParameters.Add("@GenreId", genreId);
            using IDbConnection db = _connection;
            await db.ExecuteAsync(sql, dynamicParameters);
            return bookId;
        }

        public async Task<IEnumerable<Book>> Get()
        {
            string sql = "SELECT * FROM Books";
            using IDbConnection db = _connection;
            return await db.QueryAsync<Book>(sql);
        }

        public async Task<int> Count()
        {
            string sql = "SELECT COUNT(*) FROM Books";
            using IDbConnection db = _connection;
            return await db.ExecuteScalarAsync<int>(sql);
        }

        public async Task<IEnumerable<Book>> GetByGenre(int genreId)
        {
            string sql = "SELECT * FROM Books WHERE Id IN (SELECT BookId FROM BookGenres WHERE GenreId = @GenreId)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@GenreId", genreId);
            using IDbConnection db = _connection;
            return await db.QueryAsync<Book>(sql, dynamicParameters);
        }

        public async Task<IEnumerable<Book>> GetByAuthor(int authorId)
        {
            string sql = "SELECT * FROM Books WHERE Id IN (SELECT BookId FROM BookAuthors WHERE AuthorId = @AuthorId)";
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@AuthorId", authorId);
            using IDbConnection db = _connection;
            return await db.QueryAsync<Book>(sql, dynamicParameters);
        }
    }
}
