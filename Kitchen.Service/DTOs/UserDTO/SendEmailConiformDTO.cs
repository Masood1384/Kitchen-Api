using Kitchen.Service.DTOs.CommonsDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.UserDTO
{
    public class SendEmailConiformDTO:BaseDTO
    {
        [EmailAddress]
        public string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}
