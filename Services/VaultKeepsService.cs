using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;
        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<VaultKeep> Get()
        {
            return _repo.Get();
        }

        public VaultKeep Create(VaultKeep newVaultKeep)
        {
            _repo.Create(newVaultKeep);
            return newVaultKeep;
        }

        internal VaultKeep GetVaultKeepById(int id, string userId)
        {
            var exists = _repo.GetVaultKeepById(id, userId);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;   
        }

        internal string Delete(int id, string userId)
        {
            var exists = _repo.GetVaultKeepDeleteById(id, userId);
            if (exists == null) { throw new Exception("Invalid Id"); }
            _repo.Delete(id, userId);
            return "Successfully Deleted";        }

    }
}