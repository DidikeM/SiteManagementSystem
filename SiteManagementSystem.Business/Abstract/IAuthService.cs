using SiteManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Business.Abstract
{
    public interface IAuthService
    {
        User Login(string username, string password);
        void Register(User user);
    }
}
