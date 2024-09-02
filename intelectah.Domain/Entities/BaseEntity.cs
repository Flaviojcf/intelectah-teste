
namespace intelectah.Domain.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime UpdatedAt { get; protected set; } = DateTime.Now;
        public bool IsActive { get; private set; } = true;

        public void Active()
        {
            IsActive = true;
            UpdatedAt = DateTime.Now;
        }

        public void DeActive()
        {
            IsActive = false;
            UpdatedAt = DateTime.Now;
        }
    }
}
