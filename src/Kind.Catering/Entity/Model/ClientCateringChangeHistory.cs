using System;

namespace Kind.Catering.Entity.Model
{
    public class ClientCateringChangeHistory
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long CateringPointId { get; set; }
        public string Event { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}