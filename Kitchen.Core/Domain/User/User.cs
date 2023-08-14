using Kitchen.Core.Commons;
using Kitchen.Core.Domain.Order;
using System.Diagnostics.CodeAnalysis;

namespace Kitchen.Core.Domain.User
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool ConiformEmail { get; set; }
        public string Role { get; set; }

        [AllowNull]
        public string RefreshToken { get; set; }
        [AllowNull]
        public DateTime Created { get; set; }
        [AllowNull]
        public DateTime Expires { get; set; }



        //*Navigation Properties
        public virtual ICollection<Order.Order> Order { get; set; }

    }
}