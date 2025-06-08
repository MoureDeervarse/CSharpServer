using WebServer.Models;
using WebServer.Repositories;
using System.Collections.Generic;

namespace WebServer.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly IDeviceInfoRepository _deviceInfoRepo;
        private readonly ISocialInfoRepository _socialInfoRepo;

        public AccountService(IAccountRepository accountRepo,
                              IDeviceInfoRepository deviceInfoRepo,
                              ISocialInfoRepository socialInfoRepo)
        {
            _accountRepo = accountRepo;
            _deviceInfoRepo = deviceInfoRepo;
            _socialInfoRepo = socialInfoRepo;
        }

        public IEnumerable<AccountModel> GetAllAccounts()
        {
            return _accountRepo.GetAll();
        }

        public IEnumerable<DeviceInfoModel> GetAllDeviceInfos()
        {
            return _deviceInfoRepo.GetAll();
        }
        
        public IEnumerable<SocialInfoModel> GetAllSocialInfos()
        {
            return _socialInfoRepo.GetAll();
        }
    }
}
