using BlogCentralApp.Models.Components;
using BlogCentralApp.Repositories;
using BlogCentralLib.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCentralApp.Components
{
    [ViewComponent(Name = "SideBar")]
    public class SidebarComponent : ViewComponent   
    {
        private readonly CommentRepository _commentRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly VisitorRepository _visitorRepository;
        private readonly VisitRepository _visitRepository;

        

        public SidebarComponent( UserManager<IdentityUser> userManager, VisitorRepository visitorRepository, VisitRepository visitRepository)
        {

            
            _userManager = userManager;
            _visitorRepository = visitorRepository;
            _visitRepository = visitRepository;

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            SidebarViewModel model=new SidebarViewModel();
            model.Author = (Author)await _userManager.GetUserAsync((System.Security.Claims.ClaimsPrincipal)User);
            model.Views = await _visitRepository.GetAll().CountAsync();



            return View(model);
        }
    }
}
