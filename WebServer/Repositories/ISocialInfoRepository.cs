using System.Collections.Generic;
using WebServer.Models;

namespace WebServer.Repositories
{
    public interface ISocialInfoRepository
    {
        IEnumerable<SocialInfoModel> GetAll();
        SocialInfoModel GetById(int id);
        void Add(SocialInfoModel model);
    }
}
