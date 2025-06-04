using BusinessObjects.Entities;

namespace Services.Interface
{
    public interface IAuthService
    {
        SystemAccount Authenticate(string email, string password);
    }
}
