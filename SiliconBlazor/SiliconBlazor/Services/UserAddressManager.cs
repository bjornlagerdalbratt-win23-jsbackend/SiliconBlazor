using Microsoft.EntityFrameworkCore;
using SiliconBlazor.Data;
using System;

namespace SiliconBlazor.Services;

public class UserAddressManager(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;
    public async Task<UserAddress> GetUserAddressAsync(string id)
    {
        var userAddress = await _context.UserAddresses.FirstOrDefaultAsync(x => x.Id == id);
        return userAddress!;
    }
}
