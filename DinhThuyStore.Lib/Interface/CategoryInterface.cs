using DinhThuyStore.Lib.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhThuyStore.Lib.Interface
{
    public interface CategoryInterface
    {
        List<CategoryDto> GetAll();
        int Create(CategoryDto model);
        int Update(CategoryDto model);
        int Delete(int id);
        bool CheckCategoryName(string categoryName);
        CategoryDto GetByPKID(int id);
    }
}
