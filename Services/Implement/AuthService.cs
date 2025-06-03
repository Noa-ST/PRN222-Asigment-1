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
            // Lấy từ appsettings
            var adminEmail = _configuration["AdminAccount:Email"];
            var adminPassword = _configuration["AdminAccount:Password"];

            var lecturerEmail = _configuration["LecturerAccount:Email"];
            var lecturerPassword = _configuration["LecturerAccount:Password"];

            var staffEmail = _configuration["StaffAccount:Email"];
            var staffPassword = _configuration["StaffAccount:Password"];

            // 1. Admin
            if (email == adminEmail && password == adminPassword)
            {
                return new SystemAccount
                {
                    Email = adminEmail,
                    Role = "Admin",
                    FullName = "Default Admin"
                };
            }

            // 2. Lecturer
            if (email == lecturerEmail && password == lecturerPassword)
            {
                return new SystemAccount
                {
                    Email = lecturerEmail,
                    Role = "Lecturer",
                    FullName = "Default Lecturer"
                };
            }

            // 3. Staff
            if (email == staffEmail && password == staffPassword)
            {
                return new SystemAccount
                {
                    Email = staffEmail,
                    Role = "Staff",
                    FullName = "Default Staff"
                };
            }

            // 4. Nếu không phải user mặc định => kiểm tra DB
            var account = _accountRepo.GetByEmail(email);

            if (account == null)
                return null;

            // So sánh password đơn giản (nên mã hóa thực tế)
            if (account.Password != password)
                return null;

            return account;
        }
    }
}
