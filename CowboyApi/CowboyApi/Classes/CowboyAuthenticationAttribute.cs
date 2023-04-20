
using CowboyApi.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace CowboyApi.Classes
{
	public class CowboyAuthenticationAttribute : IAuthorizationFilter
	{
		private readonly CowContext _context;
		public CowboyAuthenticationAttribute(CowContext context) 
		{
			_context = context;
		}


		public void OnAuthorization(AuthorizationFilterContext context)
		{
			var hasAuthentication = context.HttpContext.User.HasClaim(s => s.Type == ClaimTypes.Authentication);
			

			if(!hasAuthentication)
			{
				context.Result = new ForbidResult();
				return;
			}

			var authClaim = context.HttpContext.User.FindFirst(ClaimTypes.Authentication);

		

			
		}
	}
}
