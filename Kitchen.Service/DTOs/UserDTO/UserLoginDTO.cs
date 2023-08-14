using Kitchen.Service.DTOs.CommonsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.UserDTO
{
    public class UserLoginDTO : BaseDTO
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
