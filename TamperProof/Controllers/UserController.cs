using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public ActionResult GoToPartnerSite(string id)
        {
            AesCryptography cipher = new AesCryptography();
            string secretKey = "9hXe9j9K2jXto5vIA66QAiFKBgOS9LKJFdDWI+IKp3mTn7ybSNxwV3ZQZ2UwX/l73nx5K77cu+6HRSUT7bE/VQ==";
            string dateTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            // HMAC(ID + DATETIME)
            byte[] hmac = HashedMac.ComputeHash(secretKey, string.Concat(id, dateTime));

            //Uri url = new Uri("http://localhost:50257/Authentication.aspx");
            UriBuilder target = new UriBuilder("http", "localhost", 50257, "Authenticate.aspx");
            
            target.Query = string.Format("i={0}&t={1}&h={2}",
                HttpServerUtility.UrlTokenEncode(cipher.EncryptStringToBytes(id)),
                HttpServerUtility.UrlTokenEncode(cipher.EncryptStringToBytes(dateTime)),
                HttpServerUtility.UrlTokenEncode(hmac));

            return Redirect(target.Uri.AbsoluteUri);
        }
    }
}