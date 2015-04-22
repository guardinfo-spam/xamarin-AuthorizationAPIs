using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinDemo.Business.Functionality
{
    public interface IUserSettings
    {
        void RefreshAuthenticationToken();
        string GetAuthenticationToken();
    }
}
