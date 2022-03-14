using BlogCentralApp.Models.Components;
using BlogCentralApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Components
{
    [ViewComponent(Name = "MainNavigation")]
    public class MainNavComponent : ViewComponent   
    {
        private List<MainNavLinkVm> publicLinks { get; set; }
        private List<MainNavLinkVm> adminLinks { get; set; }

        private readonly BlogRepository _blogRepository;

        public MainNavComponent(BlogRepository blogRepository)
        {
            _blogRepository = blogRepository;

            publicLinks = new List<MainNavLinkVm>();


            adminLinks = new List<MainNavLinkVm>(publicLinks);

            
        }
        public async Task<IViewComponentResult> InvokeAsync(bool isAdmin)
        {
            var navlinks = publicLinks;
            if (isAdmin == true)
            {
                navlinks = adminLinks;
            }

            foreach (var navlink in navlinks)
            {
                if (RouteData.Values["area"]?.ToString().ToLower() == navlink.Area.ToLower() &&
                    RouteData.Values["controller"]?.ToString().ToLower() == navlink.Controller.ToLower() &&
                    RouteData.Values["action"]?.ToString().ToLower() == navlink.Action.ToLower() &&
                    RouteData.Values["topic"]?.ToString().ToLower() == navlink.Text.ToLower())
                {
                    navlink.IsActive = true;
                }
            }

            return View(navlinks);
        }
    }
}
