namespace AvaTrade.Domain.Common
{
    /// <summary>
    /// Base entity class
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    public class Entity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
