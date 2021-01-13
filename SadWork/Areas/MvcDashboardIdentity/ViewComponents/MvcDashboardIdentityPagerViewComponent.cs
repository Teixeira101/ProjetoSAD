using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SadWork.Areas.MvcDashboardIdentity.Models;
using SadWork.Areas.MvcDashboardIdentity.Models.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SadWork.Areas.MvcDashboardIdentity.ViewComponents
{
    public class MvcDashboardIdentityPagerViewComponent : ViewComponent
    {
        #region Construction

        public MvcDashboardIdentityPagerViewComponent()
        { }

        #endregion

        public IViewComponentResult Invoke(DataPage page)
        {
            var model = new MvcDashboardIdentityPagerModel();
            model.DataPage = page;

            return View(model);
        }
    }
}
