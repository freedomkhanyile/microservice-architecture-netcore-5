using BC = BCrypt.Net.BCrypt;

namespace Account.Microservice.Core.Application.Services
{
    public interface IEncryptionService
    {
        bool IsValidPassword(string password, string passwordHash);
    }

    public class EncryptionService : IEncryptionService
    {
        public bool IsValidPassword(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
