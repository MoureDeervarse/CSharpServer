using System.Collections.Generic;
using WebServer.Models;

namespace WebServer.Repositories
{
    public interface IDeviceInfoRepository
    {
        IEnumerable<DeviceInfoModel> GetAll();
        DeviceInfoModel GetById(int id);
        void Add(DeviceInfoModel model);
    }
}
