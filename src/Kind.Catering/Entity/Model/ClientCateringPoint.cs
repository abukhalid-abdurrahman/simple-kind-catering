namespace Kind.Catering.Entity.Model
{
    public class ClientCateringPoint
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public long CateringId { get; set; }
        public int DateOfWeek { get; set; }
        public bool IsDeleted { get; set; }
    }
}