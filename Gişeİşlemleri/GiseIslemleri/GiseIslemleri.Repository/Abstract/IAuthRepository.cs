using GiseIslemleri.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.Repository.Abstract
{
    public interface IAuthRepository
    {
        User Login(string email, string password);
        User Register(User user, string password);
    }
}
