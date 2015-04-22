using System.Threading.Tasks;
using OwinDemo.Business.Models;

namespace ServiceLibrary
{
    public interface IServiceWrapper
    {
        Task<TokenModel> GetAuthorizationTokenData();
        Task<bool> ValidateUser(UserLoginModel loginModel, string authenticationToken);
        Task<string> RegisterUser(UserLoginModel loginModel, string authenticationToken);
    }
}