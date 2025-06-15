using WebServer.DTOs;
using WebServer.Models;
using WebServer.Common;
using WebServer.Repositories;

namespace WebServer.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;

        public AccountService(AccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<ApiResponse> GetAccountByEmail(string email)
        {
            var account = await _accountRepository.GetByEmail(email);
            if (account == null)
            {
                return new ApiResponse(ErrorCode.InvalidInput);
            }

            return new ApiResponse(account);
        }

        public async Task<ApiResponse> GetAccountById(int id)
        {
            var account = await _accountRepository.GetById(id);
            if (account == null)
            {
                return new ApiResponse(ErrorCode.InvalidInput);
            }

            return new ApiResponse(account);
        }
        public async Task<ApiResponse> GetAllAccounts()
        {
            var accounts = await _accountRepository.GetAll();
            return new ApiResponse(accounts);
        }

        public async Task<ApiResponse> CreateAccount(CreateAccountDto dto)
        {
            if (await _accountRepository.GetByEmail(dto.Email) != null)
            {
                return new ApiResponse(ErrorCode.EmailAlreadyExists);
            }

            var model = new AccountModel
            {
                Email = dto.Email,
                Password = dto.Password
            };

            await _accountRepository.Add(model);
            await _accountRepository.SaveChanges();
            return ApiResponse.SUCCESS;
        }
    }
}
