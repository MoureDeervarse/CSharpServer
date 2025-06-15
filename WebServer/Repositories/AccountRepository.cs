using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebServer.Models;
using WebServer.Data;

namespace WebServer.Repositories
{
    public class AccountRepository : IRepository<AccountModel>
    {
        private readonly AppDbContext _db;

        public AccountRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<AccountModel>> GetAll()
        {
            return await _db.Accounts.ToListAsync();
        }

        public async Task<AccountModel?> GetById(object id)
        {
            return await _db.Accounts.FindAsync(id);
        }

        public async Task<AccountModel?> GetByEmail(string email)
        {
            return await _db.Accounts.FirstOrDefaultAsync(a => a.Email == email);
        }

        public async Task Add(AccountModel entity)
        {
            await _db.Accounts.AddAsync(entity);
        }

        public async Task Remove(AccountModel entity)
        {
            _db.Accounts.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
