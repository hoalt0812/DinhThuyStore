using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhThuyStore.Lib.Dtos
{
    public class ProductDto
    {
        public int PKID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public string Price { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
