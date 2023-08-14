using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitchen.Service.DTOs.CommonsDTO
{
    public class CategoryListItemDTO : BaseItemDTO
    {
        public string Name { get; set; }
        public string ParentName { get; set; }
        public int ChildCount { get; set; }
        public int ProductCount { get; set; }
    }
}
