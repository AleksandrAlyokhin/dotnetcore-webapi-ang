
using System.Linq;
using DotnetcoreWebapiAng.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetcoreWebapiAng.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            User[] result = null;

            using (var db = new BloggingContext())
            {
                result = db.Users.ToArray();

            }

            return Json(result);
        }
    }
}