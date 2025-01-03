using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Fivesemtest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Fivesemtest.Pages.Users
{
    [Authorize(Roles = "admin, user")]
    public class LKModel : PageModel
    {
        private readonly Fivesemtest.Models.FivesemestercswrkContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UsersService _usersService;
        public LKModel(Fivesemtest.Models.FivesemestercswrkContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,UsersService usersService)
        {
            _usersService = usersService;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public Models.User CurUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                CurUser = user;
            }

            // проверка авторизации
            var userId = _userManager.GetUserId(User);
            if (user.IdentityUserId != userId && !User.IsInRole("admin"))
            {
                return Forbid();
            }

            return Page();
        }
    }
}