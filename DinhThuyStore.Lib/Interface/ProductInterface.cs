using DinhThuyStore.Lib.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhThuyStore.Lib.Interface
{
    public interface ProductInterface
    {
        List<ProductDto> GetAll();
        int Create(ProductDto model);
        bool CheckProductCode(string productCode);
        ProductDto GetByPKID (int id);
        int Delete(int id);
        int Update(ProductDto model);
        List<ProductDto> GetByCategoryID(int id);
    }
}
