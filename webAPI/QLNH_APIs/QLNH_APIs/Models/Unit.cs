namespace QLNH_APIs.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime Updated { get; set; }
        public bool Deleted { get; set; }
        public UnitType UnitType { get; set; }
    }
}
