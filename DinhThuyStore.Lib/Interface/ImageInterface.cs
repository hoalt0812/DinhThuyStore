using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DinhThuyStore.Lib.Interface
{
    public interface ImageInterface
    {
        string SaveImage(HttpPostedFileBase postedFile);
        bool DeleteImage(string imageFileName);
    }
}
