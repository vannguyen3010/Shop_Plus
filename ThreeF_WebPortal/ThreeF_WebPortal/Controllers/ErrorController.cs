using ThreeF_WebPortal.Lib;
using ThreeF_WebPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeF_WebPortal.Controllers
{
    public class ErrorController : BaseController<ErrorController>
    {
        private static List<int> listStatusCode = new List<int> { 400, 404, 408, 500, 503 };
        public IActionResult Index(int statusCode)
        {
            if (listStatusCode.Contains(statusCode))
            {
                if (statusCode == 408)
                {
                    TempData["Timeout"] = "Phiên làm việc đã hết hạn, vui lòng đăng nhập lại.";
                    return Redirect("/account/signout");
                }
                return View($"~/Views/Error/{statusCode}.cshtml");
            }
            return View("~/Views/Error/404.cshtml");
        }
        //public async Task<IActionResult> ExpiredDomain()
        //{
        //    var domainCheck = await _s_SupplierConfigure.checkExistsDomain<List<M_SupplierConfigure>>(GlobalVariables.is_development ? "happygreen.vn" : HttpContext.Request.Host.ToString());
        //    if (domainCheck.result == 0 && domainCheck.data != null && domainCheck.data.FirstOrDefault().status == 1)
        //    {
        //        if (domainCheck.data.FirstOrDefault().expirationDate != null && domainCheck.data.FirstOrDefault().expirationDate.Value.Date < DateTime.UtcNow.AddHours(7).Date)
        //            return View();
        //        return Redirect("/");
        //    }
        //    return Redirect("/error/404");
        //}
    }
}
