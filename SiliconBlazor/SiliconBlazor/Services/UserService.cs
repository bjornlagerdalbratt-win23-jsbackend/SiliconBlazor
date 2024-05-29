using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiliconBlazor.Data;

namespace SiliconBlazor.Services;

public class UserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public UserService(UserManager<ApplicationUser> userManager, AuthenticationStateProvider authenticationStateProvider)
    {
        _userManager = userManager;
        _authenticationStateProvider = authenticationStateProvider;
    }


    public async Task<ApplicationUser> GetUserAsync()
    {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var user = authState.User;

        if (user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null!;
        }

        var currentUser = await _userManager.GetUserAsync(user);

        return currentUser ?? null!;
    }

    //private readonly UserManager<ApplicationUser> _userManager;
    //private readonly AuthenticationStateProvider _authenticationStateProvider;
    //private readonly ApplicationDbContext _context;

    //public UserService(UserManager<ApplicationUser> userManager, AuthenticationStateProvider authenticationStateProvider, ApplicationDbContext context)
    //{
    //    _userManager = userManager;
    //    _authenticationStateProvider = authenticationStateProvider;
    //    _context = context;
    //}

    //public async Task<ApplicationUser> GetUserAsync()
    //{
    //    var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
    //    var user = authState.User;

    //    if (user.Identity == null || !user.Identity.IsAuthenticated)
    //    {
    //        return null!;
    //    }

    //    var currentUser = await _userManager.GetUserAsync(user);

    //    if (currentUser != null && currentUser.UserProfileId != null)
    //    {
    //        currentUser.UserProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == currentUser.UserProfileId);
    //    }

    //    return currentUser ?? null!;
    //}


}
