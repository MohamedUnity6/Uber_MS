using UberMS.Models;

namespace UberMS.Heplers
{
    public interface ITokenHelper
    {
        string GenerateToken(User user); 
    }
}
