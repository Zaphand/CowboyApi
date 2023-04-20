using CowboyApi.Context;
using CowboyApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CowboyApi.Controllers
{
	[ApiController]
	public class AuthenticationController : ControllerBase
	{

		private readonly CowContext _context;
		public AuthenticationController(CowContext context) 
		{
			_context = context;
		}

		[AllowAnonymous]
		[HttpGet]
		[Route("auth/cowboy")]
		public IActionResult AuthenticateCowboy(UserInfo userInfo)
		{



			var cowboy = _context.Cowboys.Single(s=>s.Name == userInfo.Username);

			var passToCheck = userInfo.Password;

			var passKey = _context.PassKeys.Single(s=>s.CowboyId == cowboy.Id);
			var hasher = new PasswordHasher<Cowboy>();
			var result = hasher.VerifyHashedPassword(cowboy, passKey.HashedPassword, passToCheck);

			if (result == PasswordVerificationResult.Success)
			{
				return Ok("secret key");
			}

			return Unauthorized();

		}

	}
}
