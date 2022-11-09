namespace Domain.Entities.Common
{
    public class BaseEntity<T> : IEntity where T : struct
    {
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
