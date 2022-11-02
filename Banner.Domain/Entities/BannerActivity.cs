using Banner.Domain.Shared.Enums;

namespace Banner.Domain.Entities
{
    public class BannerActivity : IEntity
    {
        public Guid Id { get; set; }
        public Guid BannerId { get; set; }
        public Event Event { get; set; }
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;
        public virtual Banner Banner { get; set;}
    }
}
