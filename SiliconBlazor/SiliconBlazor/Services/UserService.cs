using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SiliconBlazor.Data;

namespace SiliconBlazor.Services;

public class UserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly AuthenticationStateProvider _authenticationStateProvider;
    private readonly ApplicationDbContext _context;

    public UserService(UserManager<ApplicationUser> userManager, AuthenticationStateProvider authenticationStateProvider, ApplicationDbContext applicationDbContext)
    {
        _userManager = userManager;
        _authenticationStateProvider = authenticationStateProvider;
        _context = applicationDbContext;
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

    public async Task<IdentityResult> UpdateUserAsync(ApplicationUser updatedUser)
    {
        var existingUser = await GetUserAsync();
        if (existingUser == null) 
        {
            //returns no user 
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });
        }
        
        existingUser.FirstName = updatedUser.FirstName;
        existingUser.LastName = updatedUser.LastName;
        existingUser.Email = updatedUser.Email;
        existingUser.PhoneNumber = updatedUser.PhoneNumber;
        existingUser.Bio = updatedUser.Bio;
        existingUser.ProfileImage = updatedUser.ProfileImage;

        var result = await _userManager.UpdateAsync(existingUser);
        if (result.Succeeded) 
        {
            await _context.SaveChangesAsync();
        }
        return result;  
    }

    //public async Task<ApplicationUser> SignOutAsync()
    //{
    //    var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
    //    var user = authState.User;

    //    if (user.Identity.IsAuthenticated)
    //    {
    //        await _signInManager.SignOutAsync();
    //    }

    //    return null!;

    //}

}
