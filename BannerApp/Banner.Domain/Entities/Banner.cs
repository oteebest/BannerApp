namespace Banner.Domain.Entities
{
    public class Banner : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }
        public bool Online { get; set; }
        public IEnumerable<BannerActivity> BannerActivities { get; set; }
    }
}
