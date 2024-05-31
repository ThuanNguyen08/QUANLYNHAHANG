using System.ComponentModel.DataAnnotations;

namespace QLNH_APIs.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int parentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }   
        public DateTime Updated {  get; set; }
        public bool Deleted { get; set; }
    }
}
