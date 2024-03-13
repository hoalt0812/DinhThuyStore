using DinhThuyStore.Lib.Dtos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinhThuyStore.Lib.Interface
{
    public interface AccountInterface
    {
        DataTable GetByUserNameAndPassword(string userName, string password);
        List<AccountDto> GetAll();
        int Create(AccountDto model);
        int Delete(int id);
        bool CheckUserName(string userName);
    }
}
