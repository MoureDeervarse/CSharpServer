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

        public async Task<ApiResponse> CreateAccountAsync(CreateAccountDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.Password)) {
                return new ApiResponse(ErrorCode.InvalidInput);
            }
            
            if (await _db.Accounts.AnyAsync(a => a.Email == dto.Email))
            {
                return new ApiResponse(ErrorCode.EmailAlreadyExists);
            }

            _db.Accounts.Add(new AccountModel
            {
                Email = dto.Email,
                Password = dto.Password
            });
            await _db.SaveChangesAsync();

            return ApiResponse.SUCCESS;
        }
    }
}
