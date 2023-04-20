using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace CowboyApi.Classes
{
    public class CowboyAuthenticationSchemeHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public CowboyAuthenticationSchemeHandler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {

        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var endpoint = Context.GetEndpoint();
            var anonymousAllowed = endpoint?.Metadata?.GetMetadata<IAllowAnonymous>();
            if (anonymousAllowed != null)
            {
                var testclaim = new ClaimsPrincipal();

                return Task.FromResult(AuthenticateResult.NoResult());
            }

            var hasClaim = Context.User.HasClaim(s => s.Type == ClaimTypes.Authentication);
            if (!hasClaim)
            {
                return Task.FromResult(AuthenticateResult.Fail("Authentication Failed"));
            }

            var claim = Context.User.FindFirst(ClaimTypes.Authentication);

            var test = claim.Value;



            return Task.FromResult(AuthenticateResult.NoResult());
        }
    }
}
