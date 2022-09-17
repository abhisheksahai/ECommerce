using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}