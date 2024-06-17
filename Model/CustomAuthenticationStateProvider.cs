using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using PharmacyDataBase.Data;

public class CustomAuthenticationStateProvider : AuthenticationStateProvider
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public CustomAuthenticationStateProvider(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var user = _signInManager.Context.User;

        if (user.Identity?.IsAuthenticated ?? false)
        {
            var applicationUser = await _userManager.GetUserAsync(user);
            var claimsPrincipal = await CreateClaimsPrincipal(applicationUser);
            return new AuthenticationState(claimsPrincipal);
        }
        
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
    }

    private async Task<ClaimsPrincipal> CreateClaimsPrincipal(ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email)
        };

        var roles = await _userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var identity = new ClaimsIdentity(claims, "CustomAuthentication");
        return new ClaimsPrincipal(identity);
    }
}