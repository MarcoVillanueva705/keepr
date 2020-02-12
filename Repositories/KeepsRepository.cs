using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class KeepsRepository
    {
        private readonly IDbConnection _db;

        public KeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Keep> Get()
        {
            string sql = "SELECT * FROM keeps WHERE isPrivate = 0;";
            return _db.Query<Keep>(sql);
        }

        internal Keep Create(Keep newKeep)
        {
           string sql = @"INSERT INTO keeps (name, description, userId, img, isPrivate)
                        VALUES (@Name, @Description, @UserId, @Img, @IsPrivate);
                        SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newKeep);
            newKeep.Id = id;
            return newKeep;       
        }

         internal void Edit(Keep update)
        {
            string sql = @"
            UPDATE keeps
            SET 
            name = @Name,
            description = @Description,
            userId = @UserId,
            img = @Img,
            isPrivate = @IsPrivate
            WHERE id = @Id; 
            ";
            _db.Execute(sql, update);
        }

        

        internal Keep GetKeepById(int id)
        {
            string sql = "SELECT * FROM keeps WHERE id = @Id";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id });       
        }

        internal IEnumerable<Keep> GetByUserId(string userId)
        {
            string sql = "SELECT * FROM keeps WHERE isPrivate = 1 AND userId = @UserId;";
            return _db.Query<Keep>(sql);        }

        internal Keep GetKeepDeleteById(int id, string userId)
        {
            string sql = "SELECT * FROM keeps WHERE id = @Id AND userId = @UserId";
            return _db.QueryFirstOrDefault<Keep>(sql, new { id , userId });
        }

        internal void Delete(int id, string userId)
        {
            string sql = "DELETE FROM keeps WHERE id = @id AND userId = @UserId";
            _db.Execute(sql, new { id, userId });        
        }
    }
}