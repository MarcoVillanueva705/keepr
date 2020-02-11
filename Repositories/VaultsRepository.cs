using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultsRepository
    {
        private readonly IDbConnection _db;
        
        public VaultsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<Vault> Get()
        {
            string sql = "SELECT * FROM vaults;";
            return _db.Query<Vault>(sql);
        }
        internal Vault Create(Vault newVault)
        {
           string sql = @"INSERT INTO vaults (name, description, userId)
                        VALUES (@Name, @Description, @UserId);
                        SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newVault);
            newVault.Id = id;
            return newVault;       
        }

        internal Vault GetVaultById(int id, string userId)
        {
            string sql = "SELECT * FROM vaults WHERE id = @Id AND userId = @UserId";
            return _db.QueryFirstOrDefault<Vault>(sql, new { id, userId });         
        }

        internal Vault GetVaultDeleteById(int id, string userId)
        {
            string sql = "SELECT * FROM vaults WHERE id = @Id AND userId = @UserId";
            return _db.QueryFirstOrDefault<Vault>(sql, new { id , userId });        }
    
        internal void Delete(int id, string userId)
        {
            string sql = "DELETE FROM vaults WHERE id = @id AND userId = @UserId";
            _db.Execute(sql, new { id, userId });         }
    }
}