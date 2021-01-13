using Microsoft.AspNetCore.Mvc;
using SadWork.Areas.MvcDashboardIdentity.Models.ViewComponents;
using SadWork.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SadWork.Areas.MvcDashboardIdentity.ViewComponents
{
    public class MvcDashboardIdentityNavBarViewComponent : ViewComponent
    {
        #region Construction

        private readonly ApplicationDbContext context;

        public MvcDashboardIdentityNavBarViewComponent(ApplicationDbContext context)
        {
            this.context = context;
        }

        #endregion

        public IViewComponentResult Invoke()
        {
            var model = new MvcDashboardIdentityNavBarModel();
            model.UserCount = context.Users.Count();
            model.RoleCount = context.Roles.Count();
            return View(model);
        }
    }
}
