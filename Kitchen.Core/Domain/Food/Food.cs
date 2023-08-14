using System.ComponentModel.DataAnnotations;
using System;
using Kitchen.Core.Commons;
using Kitchen.Core.Domain.Order;

namespace Kitchen.Core.Domain.Food
{
    public class Food:BaseEntity
    {        
        public string Name { get; set; }
        
        [MaxLength(250)]
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Deleted { get; set; }
        [MaxLength(100)]
        public bool Available { get; set; }

        //*Navigation Properties

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<GroupFood> GroupFoods { get; set; }
        public virtual ICollection<FoodPicture> FoodPictures { get; set; }
        
    }
}