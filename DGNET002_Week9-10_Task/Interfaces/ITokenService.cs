using DGNET002_Week9_10_Task.Models;

namespace DGNET002_Week9_10_Task.Interfaces
{
    public interface ITokenService
    {
        public string CreateToken(User user);
    }
}
