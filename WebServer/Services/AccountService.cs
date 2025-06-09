using WebServer.Models;
using WebServer.Repositories;
using System.Collections.Generic;
using WebServer.Data;
using Microsoft.EntityFrameworkCore;
using WebServer.DTOs;
using WebServer.Common;

namespace WebServer.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepo;
        private readonly IDeviceInfoRepository _deviceInfoRepo;
        private readonly ISocialInfoRepository _socialInfoRepo;
        private readonly AppDbContext _db;

        public AccountService(IAccountRepository accountRepo,
                              IDeviceInfoRepository deviceInfoRepo,
                              ISocialInfoRepository socialInfoRepo,
                              AppDbContext db)
        {
            _accountRepo = accountRepo;
            _deviceInfoRepo = deviceInfoRepo;
            _socialInfoRepo = socialInfoRepo;
            _db = db;
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

        public async Task<ErrorCode> CreateAccountAsync(CreateAccountDto dto)
        {
            if (await _db.Accounts.AnyAsync(a => a.Email == dto.Email))
                return ErrorCode.EmailAlreadyExists;

            var model = new AccountModel
            {
                Email = dto.Email,
                Password = dto.Password
            };

            _db.Accounts.Add(model);
            await _db.SaveChangesAsync();
            return ErrorCode.None;
        }
    }
}
