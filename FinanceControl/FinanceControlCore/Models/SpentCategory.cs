using System.ComponentModel.DataAnnotations;

namespace FinanceControl.Models
{
    public class SpentCategory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsActive { get; set; }
        public SpentCategory() { }
        public SpentCategory(string name)
        {
            Name = name;
            IsActive = true;
        }
    }
}