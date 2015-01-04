using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZipAndDownload.Models
{
    public class FileStorage
    {
        public List<string> GetFiles()
        {
            List<string> filePaths = new List<string>();
            filePaths.Add(HttpContext.Current.Server.MapPath("~/Files/SampleFile1.txt"));
            filePaths.Add(HttpContext.Current.Server.MapPath("~/Files/SampleFile2.txt"));

            return filePaths;
        }
    }
}