using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;
        
        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }
        internal IEnumerable<VaultKeep> Get()
        {
            string sql = "SELECT * FROM vaultkeeps";
            return _db.Query<VaultKeep>(sql);
        }
        internal VaultKeep Create(VaultKeep newVaultKeep)
        {
           string sql = @"INSERT INTO vaultkeeps (keepId, vaultId, userId)
                        VALUES (@KeepId, @VaultId, @UserId);
                        SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newVaultKeep);
            newVaultKeep.Id = id;
            return newVaultKeep;       
        }

        internal VaultKeep GetVaultKeepById(int id, string userId)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE id = @Id AND userId = @UserId";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id, userId });         
             }

        internal VaultKeep GetVaultKeepDeleteById(int id, string userId)
        {
            string sql = "SELECT * FROM vaultkeeps WHERE id = @Id AND userId = @UserId";
            return _db.QueryFirstOrDefault<VaultKeep>(sql, new { id , userId });        }
    
        internal void Delete(int id, string userId)
        {
            string sql = "DELETE FROM vaultkeeps WHERE id = @id AND userId = @UserId";
            _db.Execute(sql, new { id, userId });         }
    }
}