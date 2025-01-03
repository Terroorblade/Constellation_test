using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Fivesemtest.Models;
using System.Threading.Tasks;

namespace Fivesemtest.Models
{
    public class UsersService
    {
        private readonly FivesemestercswrkContext _context;
        // private readonly UserManager<IdentityUser> _userManager;

        public UsersService(FivesemestercswrkContext context)
        {
            _context = context;
            // _userManager = userManager;
        }

    //     public async Task CreateUserAsync(string email, string username, string password)
    //     {
    //         var user = new User
    //         {
    //             UserName = username,
    //             Email = email
    //         };

    //         var result = await _userManager.CreateAsync(user, password);

    //         if (result.Succeeded)
    //         {
    //             // Добавить пользователя в роль (например, "user")
    //             await _userManager.AddToRoleAsync(user, "user");
    //         }
    //         else
    //         {
    //             foreach (var error in result.Errors)
    //             {
    //                 Console.WriteLine(error.Description);
    //             }
    //         }
    //     }
    public async Task<int?> GetUserIdByUserIdAsync(string userId)
        {
            return await _context.Users.Where(c => c.IdentityUserId == userId).Select(c => c.UserId).FirstOrDefaultAsync();
        }

        public async Task<bool> IsUserIdExistsAsync(string userId)
        {
            return await _context.Users.AnyAsync(p => p.IdentityUserId == userId);
        }
    }
}
