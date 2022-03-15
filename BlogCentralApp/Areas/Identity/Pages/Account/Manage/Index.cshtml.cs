using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogCentralApp.Repositories;
using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;

namespace BlogCentralApp.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AuthorRepository _authorRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            AuthorRepository authorRepository,
           IWebHostEnvironment hostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authorRepository = authorRepository;
            _hostEnvironment = hostEnvironment;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        [BindProperty]
        public IFormFile file { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
            [Display(Name = "Street name")]
            public string? StreetName { get; set; }
            [Display(Name = "House number")]
            public int? HouseNumber { get; set; }
            [Display(Name = "City")]
            public string? CityName { get; set; }
            [Display(Name = "zip code")]
            public int? ZipCode { get; set; }
            [Display(Name = "Upload Image")]
            public string ImageUrl { get; set; }

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
                StreetName = author.StreetName,
                ZipCode = author.ZipCode,
                CityName = author.CityName,
                HouseNumber = author.HouseNumber,
                ImageUrl = author.ImageUrl,

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

            ///
            string wwwRootPath = _hostEnvironment.WebRootPath;
            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(wwwRootPath, @"images\Users");
                var extension = Path.GetExtension(file.FileName);

                if (Input.ImageUrl != null)
                {
                    var oldImagePath = Path.Combine(wwwRootPath, Input.ImageUrl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    file.CopyTo(fileStreams);
                }
                Input.ImageUrl = @"\images\Users\" + fileName + extension;
            } /////
            user.StreetName = Input.StreetName;
            user.CityName = Input.CityName;
            user.HouseNumber = Input.HouseNumber;
            user.ZipCode = Input.ZipCode;
            user.ImageUrl = Input.ImageUrl;
            await _authorRepository.Update(user);
            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}

