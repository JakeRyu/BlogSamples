using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZipAndDownload.Models;

namespace ZipAndDownload.Controllers
{
    public class ZipAndDownloadController : Controller
    {
        public ViewResult Simple()
        {
            return View();
        }

        public ActionResult Download()
        {
            var fileStorage = new FileStorage();
            List<string> filePaths = fileStorage.GetFiles();

            return new ZipResult("SampleFiles.zip", filePaths);
        }
    }
}


