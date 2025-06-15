using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebServer.Models;
using WebServer.Data;

namespace WebServer.Repositories
{
    public class DeviceInfoRepository : IRepository<DeviceInfoModel>
    {
        private readonly AppDbContext _db;

        public DeviceInfoRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<DeviceInfoModel>> GetAll()
        {
            return await _db.DeviceInfos.ToListAsync();
        }

        public async Task<DeviceInfoModel?> GetById(object id)
        {
            // 복합키라면 id를 튜플 등으로 받아서 처리해야 함
            return await Task.FromResult<DeviceInfoModel?>(null);
        }

        public async Task Add(DeviceInfoModel entity)
        {
            await _db.DeviceInfos.AddAsync(entity);
        }

        public async Task Remove(DeviceInfoModel entity)
        {
            _db.DeviceInfos.Remove(entity);
            await Task.CompletedTask;
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
