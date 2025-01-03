using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Fivesemtest.Models;

namespace Fivesemtest.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly FivesemestercswrkContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CreateModel(FivesemestercswrkContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [BindProperty]
        public User CurUser { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string UserId { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId)
        {
            UserId = userId;

            if (string.IsNullOrEmpty(UserId))
            {
                return Forbid(); // запрет доступа, если нет параметра в запросе
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

             // Создаем новый IdentityUser
            var identityUser = new IdentityUser
            {
                UserName = CurUser.Username,
                Email = CurUser.Email
            };

 var result = await _userManager.CreateAsync(identityUser, CurUser.PasswordHash); // Вы должны передавать пароль, не хэш
            if (result.Succeeded)
            {
                // После успешного создания привязываем IdentityUser к вашей модели User
                CurUser.IdentityUserId = identityUser.Id;

                // Добавляем User в вашу базу данных
                _context.Users.Add(CurUser);
                await _context.SaveChangesAsync();

                // Авторизация пользователя (если нужно)
                if (!User.IsInRole("admin"))
                {
                    await _signInManager.SignInAsync(identityUser, isPersistent: false);
                }

                // Перенаправление в зависимости от роли пользователя
                if (User.IsInRole("admin"))
                {
                    return RedirectToPage("./Index");
                }
                else
                {
                    return RedirectToPage("/Index");
                }
            }

            // Если создание не удалось, выводим ошибки
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }

        // [BindProperty]
        // public IdentityUser User { get; set; }

    //     public void OnGet()
    //     {
    //     }

    //     public async Task<IActionResult> OnPostAsync()
    //     {
    //         if (!ModelState.IsValid)
    //         {
    //             return Page();
    //         }

    //         var user = new IdentityUser
    //         {
    //             UserName = User.UserName,
    //             Email = User.Email,
    //         };

    //         var result = await _userManager.CreateAsync(user, User.PasswordHash);
    //         if (result.Succeeded)
    //         {
    //             // Можно сразу выполнить вход для нового пользователя, если нужно
    //             await _signInManager.SignInAsync(user, isPersistent: false);
    //             return RedirectToPage("/Index"); // Перенаправление на главную страницу
    //         }

    //         foreach (var error in result.Errors)
    //         {
    //             ModelState.AddModelError(string.Empty, error.Description);
    //         }

    //         return Page();
    //     }
    }
}
