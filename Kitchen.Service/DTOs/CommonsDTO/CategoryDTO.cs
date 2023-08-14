using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.CommonsDTO
{
    public class CategoryDTO : BaseEntityDTO
    {
        public string Name { get; set; }
        public int ParentID { get; set; }
        public string? ParentName { get; set; }
    }
}
