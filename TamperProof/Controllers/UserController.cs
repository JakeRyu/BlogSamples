using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TamperProof.Models;

namespace TamperProof.Controllers
{
    public class UserController : Controller
    {
        UserRepository repo = new UserRepository();

        public ActionResult Detail(string id)
        {
            User model = null;

            if (id == null) 
                return HttpNotFound();

            // Decode id and convert it to the original type
            int decodedId;
            if(Int32.TryParse(id, out decodedId))
            {
                model = repo.Users.Where(u => u.Id == decodedId).SingleOrDefault();
            }
        
            if(model == null)
                return HttpNotFound();

            return View(model);
        }
    }
}