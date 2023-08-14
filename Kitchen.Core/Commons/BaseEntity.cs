namespace Kitchen.Core.Commons
{
    public abstract class BaseEntity : Entity, IDateEntity
    {
        public int ID { get; set; }
        public DateTime CreateON { get; set; }
        public DateTime UpdateON { get; set; }
    }
}