using BlazorPOC.Configuration;
using System.Threading.Tasks;

namespace BlazorPOC.Services
{
    public class ImmediateNameService : INameService
    {
        public ImmediateNameService(IAppConfiguration appConfiguration)
        {
            _name = appConfiguration.Name;
        }

        public Task<string> GetNameAsync()
        {
            return Task.FromResult(_name);
        }

        #region Private Members

        private string _name;

        #endregion
    }
}