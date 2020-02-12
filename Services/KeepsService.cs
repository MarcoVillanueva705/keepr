using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
    public class KeepsService
    {
        private readonly KeepsRepository _repo;
        public KeepsService(KeepsRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Keep> Get()
        {
            return _repo.Get();
        }

        internal Keep GetKeepById(int id)
        {
            var exists = _repo.GetKeepById(id);
            if (exists == null) { throw new Exception("Invalid Id"); }
            return exists;        
        }

        public Keep Create(Keep newKeep)
        {
            _repo.Create(newKeep);
            return newKeep;
        }

        internal Keep Edit(Keep update)
        {
            var exists = _repo.GetKeepById(update.Id);
            if (exists == null) { throw new Exception("Invalid Id");
             }
            _repo.Edit(update);
            return update;
        }

        internal object Delete(int id, string userId)
        {
            var exists = _repo.GetKeepDeleteById(id, userId);
            if (exists == null) { throw new Exception("Invalid Id"); }
            _repo.Delete(id, userId);
            return "Successfully Deleted";
        }

        public IEnumerable <Keep> GetByUserId(string userId)
        {
            return _repo.GetByUserId(userId);
        }
    }
}