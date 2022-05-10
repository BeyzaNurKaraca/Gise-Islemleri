using GiseIslemleri.DAL;
using GiseIslemleri.Repository.Abstract;
using GiseIslemleri.UnitOfWork.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GiseIslemleriContext _context;
        public IAuthRepository _authRepository { get; }

        public IUserRepository _userRepository { get; }

        public IRoleRepository _roleRepository { get; }

        public IBillRepository _billRepository { get; }

        public ISubscriptionRepository _subscriptionRepository { get; }
        public UnitOfWork(GiseIslemleriContext giseIslemleriContext, IAuthRepository authRepository,IBillRepository billRepository, IUserRepository userRepository, ISubscriptionRepository subscriptionRepository, IRoleRepository roleRepository)
        {
            _authRepository = authRepository;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _billRepository = billRepository;
            _subscriptionRepository = subscriptionRepository;
            _context = giseIslemleriContext;

        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
