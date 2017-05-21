
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

        [HttpGet("{id}")]
        public JsonResult Get(int id, int groupId)
        {
            User result = null;
            using (var db = new BloggingContext())
            {
                result = db.Users.SingleOrDefault(_ => _.Id == id);
            }

            return Json(result);
        }

        [HttpPost]
        public void Post([FromBody]User user)
        {
            using (var db = new BloggingContext())
            {
                int newId = 0;
                if (db.Users.Any())
                {
                    newId = db.Users.Max(_ => _.Id);
                }
                user.Id = ++newId; // Хз чет
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]User user)
        {
            if (id == user.Id)
            {
                using (var db = new BloggingContext())
                {
                    if (db.Users.Any(_=>_.Id == id))
                    {
                        db.Update(user);
                        db.SaveChanges();
                    }
                }
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var db = new BloggingContext())
            {
                var user = db.Users.SingleOrDefault(_=>_.Id== id);
                if (user != null)
                {
                    db.Users.Remove(user);
                    db.SaveChanges();
                }
            }
        }
    }


}