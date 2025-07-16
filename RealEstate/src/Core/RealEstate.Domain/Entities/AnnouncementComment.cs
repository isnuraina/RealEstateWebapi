using RealEstate.Domain.Commons;

namespace RealEstate.Domain.Entities
{
    public class AnnouncementComment:BaseEntity<int>
    {
        public int AnnouncementId { get; set; }
        public int? ParentId { get; set; }
        public string Text { get; set; }

    }
}
