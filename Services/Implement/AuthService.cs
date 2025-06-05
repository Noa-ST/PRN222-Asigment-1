using BusinessObjects.Entities;
using Microsoft.Extensions.Configuration;
using Repositories.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implement
{
    public class AuthService : IAuthService
    {
        private readonly ISystemAccountRepository _accountRepo;
        private readonly IConfiguration _configuration;

        public AuthService(ISystemAccountRepository accountRepo, IConfiguration configuration)
        {
            _accountRepo = accountRepo;
            _configuration = configuration;
        }

        public SystemAccount Authenticate(string email, string password)
        {
            // Admin mặc định 
            var adminEmail = _configuration["AdminAccount:Email"];
            var adminPassword = _configuration["AdminAccount:Password"];

            if (email == adminEmail && password == adminPassword)
            {
                return new SystemAccount
                {
                    Email = adminEmail,
                    Role = "Admin",
                    FullName = "Default Admin"
                };
            }

            // Kiểm tra tài khoản Staff/Lecturer/Admin từ database
            var account = _accountRepo.GetByEmail(email);

            if (account == null) return null;

            // So sánh mật khẩu
            if (account.Password != password)
                return null;

            return account;
        }
    }
}
