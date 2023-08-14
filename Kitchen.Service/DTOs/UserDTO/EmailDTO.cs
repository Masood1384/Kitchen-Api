using Kitchen.Service.DTOs.CommonsDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.UserDTO
{
    public class EmailDTO:BaseDTO
    {
        [EmailAddress]
        public string Subject { get; set; }
        public string message { get; set; }
    }
}
