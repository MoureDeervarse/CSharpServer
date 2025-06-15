using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebServer.Models;
using WebServer.Data;

namespace WebServer.Repositories
{
    public class SocialInfoRepository : IRepository<SocialInfoModel>
    {
        private readonly AppDbContext _db;

        public SocialInfoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<SocialInfoModel>> GetAll()
        {
            return await _db.SocialInfos.ToListAsync();
        }

        public async Task<SocialInfoModel?> GetById(object id)
        {
            // 복합키라면 id를 튜플 등으로 받아서 처리해야 함
            return await Task.FromResult<SocialInfoModel?>(null);
        }

        public async Task Add(SocialInfoModel entity)
        {
            await _db.SocialInfos.AddAsync(entity);
        }

        public async Task Remove(SocialInfoModel entity)
        {
            _db.SocialInfos.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
