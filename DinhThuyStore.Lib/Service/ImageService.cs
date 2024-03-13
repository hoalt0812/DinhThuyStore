using DinhThuyStore.Lib.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DinhThuyStore.Lib.Service
{
    public class ImageService : ImageInterface
    {
        public bool DeleteImage(string imageFileName)
        {
            try
            {
                var wwwPath = AppDomain.CurrentDomain.BaseDirectory;
                var path = Path.Combine(wwwPath, "Uploads", imageFileName);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public string SaveImage(HttpPostedFileBase postedFile)
        {
            var wwwPath = AppDomain.CurrentDomain.BaseDirectory;
            var path = Path.Combine(wwwPath, "Uploads");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var ext = Path.GetExtension(postedFile.FileName);
            string uniqueString = Guid.NewGuid().ToString();
            var newFileName = uniqueString + ext;
            var fileWithPath = Path.Combine(path, newFileName);
            postedFile.SaveAs(fileWithPath);
            return newFileName;
        }
    }
}
