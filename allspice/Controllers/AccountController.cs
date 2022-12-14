using System;
using System.Threading.Tasks;
using allspice.Models;
using allspice.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace allspice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<Account>> Get()
        {
            try
            {
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetOrCreateProfile(userInfo));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("recipes")]
        [Authorize]
        public async Task<ActionResult<Account>> GetRecipesByUser()
        {
            try 
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetRecipesByUser(user.Id));
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }

        [HttpGet("favorites")]
        [Authorize]

        public async Task<ActionResult<Account>> GetFavoritesByUser()
        {
            try 
            {
                Account user = await HttpContext.GetUserInfoAsync<Account>();
                return Ok(_accountService.GetFavoritesByUser(user.Id));
            }
            catch (Exception e)
            {
              return BadRequest(e.Message);
            }
        }
        
    }


}