using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.EntityFrameworkCore;
using SiliconBlazor.Data;
using SiliconBlazor.ViewModels;
using System;

namespace SiliconBlazor.Services;

public class UserAddressManager(ApplicationDbContext context)
{
    private readonly ApplicationDbContext _context = context;
    public async Task<UserAddress> GetUserAddressAsync(string id)
    {
        var userAddress = await _context.UserAddresses.FirstOrDefaultAsync(x => x.Id == id);
        return userAddress ?? new UserAddress(); 
    }

    public async Task<AddressViewModel> GetOrCreateAddressAsync(string addressline1, string? addressline2, string postalcode, string city)
    {
        try
        {
            var existingAddress = await _context.UserAddresses.FirstOrDefaultAsync(x => x.AddressLine_1 == addressline1 && x.AddressLine_2 == addressline2 && x.PostalCode == postalcode && x.City == city);
            
            if (existingAddress != null)
            {
                return new AddressViewModel
                {
                    Id = existingAddress.Id,
                    AddressLine_1 = existingAddress.AddressLine_1,
                    AddressLine_2 = existingAddress.AddressLine_2,
                    PostalCode = existingAddress.PostalCode,
                    City = existingAddress.City
                };
            }

            var newAddress = new UserAddress
            {
                AddressLine_1 = addressline1,
                AddressLine_2 = addressline2,
                PostalCode = postalcode,
                City = city
            };

            _context.UserAddresses.Add(newAddress);
            await _context.SaveChangesAsync();

            return new AddressViewModel
            {
                Id = newAddress.Id,
                AddressLine_1 = newAddress.AddressLine_1,
                AddressLine_2 = newAddress.AddressLine_2,
                PostalCode = newAddress.PostalCode,
                City = newAddress.City
            };
        }
        catch (Exception ex) 
        {
            throw new Exception("Error while getting or creating address", ex);
        }

    }

    public async Task<AddressViewModel> UpdateAddressAsync(string userId, string addressline1, string? addressline2, string postalcode, string city)
    {
        var user = await _context.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Id == userId);
        if (user == null)
        {
            throw new Exception("Could not find user");
        }

        if (user.Address != null)
        {
            user.Address.AddressLine_1 = addressline1;
            user.Address.AddressLine_2 = addressline2;
            user.Address.PostalCode = postalcode;
            user.Address.City = city;
        }
        else
        {
            //create new address if there is none on the user already
            var newAddress = new UserAddress
            {
                AddressLine_1 = addressline1,
                AddressLine_2 = addressline2,
                PostalCode = postalcode,
                City = city

            };
            _context.UserAddresses.Add(newAddress);
            user.Address = newAddress; 
            user.UserAddressId = newAddress.Id;
            await _context.SaveChangesAsync();

        }

        _context.Users.Update(user);
        await _context.SaveChangesAsync();

        return new AddressViewModel
        {
            Id = userId,
            AddressLine_1 = addressline1,
            AddressLine_2 = addressline2,
            PostalCode = postalcode,
            City = city

        };
    }
}

