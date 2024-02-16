using SiteManagementSystem.Business.Abstract;
using SiteManagementSystem.DataAccess.Abstract;
using SiteManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagementSystem.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserDal _userDal;

        public AuthService(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public User Login(string username, string password)
        {
            return _userDal.Get(x => x.Username == username && x.Password == password);
        }

        public void Register(User user)
        {
            _userDal.Add(user);
        }
    }
}
