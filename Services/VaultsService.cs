using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class VaultsService
    {
        private readonly VaultsRepository _repo;
        public VaultsService(VaultsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Vault> Get()
        {
            return _repo.Get();
        }

        public Vault Create(Vault newVault)
        {
            _repo.Create(newVault);
            return newVault;
        }

        internal Vault GetVaultById(int id, string userId)
        {
            var exists = _repo.GetVaultById(id, userId);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;   
        }

        internal string Delete(int id, string userId)
        {
            var exists = _repo.GetVaultDeleteById(id, userId);
            if (exists == null) { throw new Exception("Invalid Id"); }
            _repo.Delete(id, userId);
            return "Successfully Deleted";        }

    }
}