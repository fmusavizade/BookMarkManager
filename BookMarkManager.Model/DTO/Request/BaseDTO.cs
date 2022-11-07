using System.ComponentModel.DataAnnotations;

namespace BookMarkManager.Model.DTO
{
    public class BaseDTO
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
    }
}
