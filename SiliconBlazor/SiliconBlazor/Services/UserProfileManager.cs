using Microsoft.EntityFrameworkCore;
using SiliconBlazor.Data;

namespace SiliconBlazor.Services;

public class UserProfileManager(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;

    //public async Task<UserProfile> GetUserProfileAsync(string id)
    //{
    //    //var userProfile = await _context.UserProfiles.FirstOrDefaultAsync(x => x.Id == id);
    //    //return userProfile!;
    //}

    
}
