using Kitchen.Service.DTOs.CommonsDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.UserDTO
{
    public class UserListItmeDTO:BaseItemDTO
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool ConiformEmail { get; set; }
        public string RefreshToken { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
    }
}
