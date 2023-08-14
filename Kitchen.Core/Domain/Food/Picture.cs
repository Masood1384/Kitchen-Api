using Kitchen.Core.Commons;

namespace Kitchen.Core.Domain.Food
{
    public class Picture:BaseEntity
    {
        public string VirtualPath { get; set; }
        public string MimeType { get; set; }

        //*Navigation Properties
        public virtual ICollection<FoodPicture> FoodPictures { get; set; }
    }
}