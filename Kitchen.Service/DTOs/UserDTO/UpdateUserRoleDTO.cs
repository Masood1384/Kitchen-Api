﻿using Kitchen.Core.Commons;
using Kitchen.Service.DTOs.CommonsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.UserDTO
{
    public class UpdateUserRoleDTO:BaseEntityDTO
    {
        public string Role { get; set; }
    }
}
