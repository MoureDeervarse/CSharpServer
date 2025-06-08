using System.Collections.Generic;
using WebServer.Models;

namespace WebServer.Repositories
{
    public interface IAccountRepository
    {
        IEnumerable<AccountModel> GetAll();
        AccountModel GetById(int id);
        void Add(AccountModel model);
    }
}
