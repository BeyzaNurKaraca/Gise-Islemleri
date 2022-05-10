using GiseIslemleri.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.UnitOfWork.Abstract
{
    public interface IUnitOfWork
    {
        IAuthRepository _authRepository { get; }
        IUserRepository _userRepository { get; }
        IRoleRepository _roleRepository { get; }
        IBillRepository _billRepository { get; }
        ISubscriptionRepository _subscriptionRepository { get; }

        void Save();
    }
}
