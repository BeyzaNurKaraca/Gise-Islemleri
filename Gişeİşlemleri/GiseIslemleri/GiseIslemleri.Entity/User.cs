using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.Entity
{
    public class User
    {
        public User()
        {
            Subscriptions = new HashSet<Subscriptions>();
        }
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[]? PasswordSalt { get; set; }
        public byte[]? PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<Subscriptions> Subscriptions { get; set; }

    }
}
