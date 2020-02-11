using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class VaultKeepsController: ControllerBase
    {
        private readonly VaultKeepsService _vks;
        public VaultKeepsController(VaultKeepsService vks)
        {
            _vks = vks;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VaultKeep>> Get()
        {
            try
            {
                return Ok(_vks.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [HttpPost]
        public ActionResult<VaultKeep> Post([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                //keepId?
                newVaultKeep.UserId = userId;
                return Ok(_vks.Create(newVaultKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/keeps")]
        public ActionResult<VaultKeep> GetVaultKeepById(int id)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.GetVaultKeepById(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}/keeps/{vaultId}")]
         public ActionResult<String> Delete(int id, int vaultId)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_vks.Delete(id, vaultId, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}