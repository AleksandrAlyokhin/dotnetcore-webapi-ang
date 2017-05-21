
using System.Linq;
using DotnetcoreWebapiAng.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetcoreWebapiAng.Controllers
{
    [Route("api/[controller]")]
    public class GroupsController : Controller
    {

        [HttpGet]
        public JsonResult Get()
        {
            Group[] result = null;
            using (var db = new BloggingContext())
            {
                result = db.Groups.ToArray();
            }

            return Json(result);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Group result = null;
            using (var db = new BloggingContext())
            {
                result = db.Groups.SingleOrDefault(_ => _.Id == id);
            }

            return Json(result);
        }

        [HttpPost]
        public void Post([FromBody]Group group)
        {
            using (var db = new BloggingContext())
            {
                int newId = 0;
                if (db.Groups.Any())
                {
                    newId = db.Groups.Max(_ => _.Id);
                }
                group.Id = ++newId; // Хз чет
                db.Groups.Add(group);
                db.SaveChanges();
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Group group)
        {
            if (id == group.Id)
            {
                using (var db = new BloggingContext())
                {
                    if (db.Groups.Any(_=>_.Id == id))
                    {
                        db.Update(group);
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
                var group = db.Groups.SingleOrDefault(_=>_.Id== id);
                if (group != null)
                {
                    db.Groups.Remove(group);
                    db.SaveChanges();
                }
            }
        }
    }


}