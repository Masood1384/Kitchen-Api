namespace Kitchen.Core.Domain.Order
{
    public enum OrderStatus
    {
       //! Pending
        Pending = 10,
        //! Processing
        Processing = 20,
        //! Completed
        Completed = 30,
        //! Failed
        Failed = 40 
    }
}