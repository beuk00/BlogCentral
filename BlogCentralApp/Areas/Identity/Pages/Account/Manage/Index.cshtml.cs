using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlogCentralApp.Repositories;
using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogCentralApp.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AuthorRepository _authorRepository;
        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            AuthorRepository authorRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorRepository = authorRepository;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [Display(Name ="Street name")]
            public string? StreetName { get; set; }
            [Display(Name = "House number")]
            public int? HouseNumber { get; set; }
            [Display(Name = "City")]
            public string? CityName { get; set; }
            [Display(Name = "zip code")]
            public int? ZipCode { get; set; }

        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            Author author = (Author)await _userManager.GetUserAsync(HttpContext.User);

            
            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                StreetName=author.StreetName,
                ZipCode=author.ZipCode,
                CityName=author.CityName,
                HouseNumber=author.HouseNumber,
                
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            
            Author user = (Author)await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Session is ended.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            
            
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }
            user.StreetName=Input.StreetName;
            user.CityName=Input.CityName;
            user.HouseNumber=Input.HouseNumber;
            user.ZipCode=Input.ZipCode;
            await _authorRepository.Update(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
