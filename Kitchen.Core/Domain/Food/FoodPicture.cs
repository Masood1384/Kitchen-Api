using Kitchen.Core.Commons;

namespace Kitchen.Core.Domain.Food
{
    public class FoodPicture:BaseRelation
    {
        public int PictureID { get; set; }
        public int FoodID { get; set; }

        //*Navigation Properties
        public virtual Food Food { get; set; }
        public virtual Picture Picture { get; set; }
    }
}