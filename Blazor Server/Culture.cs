using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAppLocale
{
    [Route("/[controller]")]
    [ApiController]
    public class Culture : ControllerBase
    {
        public ActionResult SetCulture()
        {
            IRequestCultureFeature culture = HttpContext.Features.Get<IRequestCultureFeature>();
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(new string[] { "en-US", "fr-FR" }
                    .Where(option => option != culture.RequestCulture.Culture.Name)
                    .FirstOrDefault())));

            return Redirect("/");
        }
    }
}
