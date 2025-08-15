
using APIApplication.Models.Request;
using APIApplication.Models.Respone;
using APIApplication.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace APIApplication.Services
{
    public class NoteService(IConfiguration config) : INoteService {

        string _connectionString = config.GetConnectionString("DefaultConnection");

        public async Task<IEnumerable<NoteRespone>> GetAll(Guid userId) {

            using var connection = new SqlConnection(_connectionString);
            var sql = @"SELECT
	                        Note.*,
	                        [User].Id,
	                        [User].Username,
	                        [User].Role 
                        FROM Note
                        LEFT JOIN [User] ON [User].Id = Note.UserId
                        WHERE Note.UserId = @UserId
                        ORDER BY
	                        note.CreatedAt DESC";
           return await connection.QueryAsync<NoteRespone, UserRespone, NoteRespone>(
                   sql,
                   (note, user) =>
                   {
                       note.User = user;
                       return note;
                   },
                   new { UserId = userId },
                   splitOn: "UserId"
               );

        }

        public async Task<NoteRespone?> GetById(Guid id, Guid userId) {

            using var connection = new SqlConnection(_connectionString);

            var sql = @"
                SELECT
                    Note.*,
                    [User].Id,
                    [User].Username,
                    [User].Role 
                FROM Note
                LEFT JOIN [User] ON [User].Id = Note.UserId
                WHERE Note.Id = @Id AND Note.UserId = @UserId";

                    var note = await connection.QueryAsync<NoteRespone, UserRespone, NoteRespone>(
                        sql,
                        (note, user) =>
                        {
                            note.User = user;
                            return note;
                        },
                        new { Id = id, UserId = userId },
                        splitOn: "UserId"
                    );

            return note.FirstOrDefault();
        }

        public async Task<int?> Create(NoteRequest request, Guid userId) {

            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO note(Id, Title, Content, CreatedAt, UpdatedAt, UserId) " +
                "VALUES (NEWID(), @Title, @Content,GETDATE(),GETDATE(), @UserId);" +
                "SELECT CAST(SCOPE_IDENTITY() as int);";

            var newId = await connection.ExecuteScalarAsync<int>(sql, new
            {
                Title = request.Title,
                request.Content,
                UserId = userId

            });

            return newId;
        }

        public async Task<bool?> Update(Guid userId, Guid id, NoteRequest request) { 
       
            var sql = "UPDATE note " +
                "SET Title = @Title, " +
                "Content = @Content, " +
                "UpdatedAt = GETDATE() " +
                "WHERE Id = @Id " +
                "AND UserId = @UserId";

            using var connection = new SqlConnection(_connectionString);

            var affectedRows = await connection.ExecuteAsync(sql, new
            {
                Title = request.Title,
                Content = request.Content,
                Id = id,
                UserId = userId

            });

            return affectedRows > 0;

        }

        public async Task<bool?> Delete(Guid id, Guid userId) { 

            using var connection = new SqlConnection(_connectionString);
            var sql = "DELETE FROM Note WHERE Id = @Id AND UserId = @UserId";
            var affectedRows = await connection.ExecuteAsync(sql, new { 
                Id = id,
                UserId = userId
            });

            return affectedRows > 0;

        }

    }
}
