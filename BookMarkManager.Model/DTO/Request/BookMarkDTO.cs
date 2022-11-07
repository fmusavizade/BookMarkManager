using System.ComponentModel.DataAnnotations;

namespace BookMarkManager.Model.DTO
{
    public class BookMarkDTO : BaseDTO
    {
        [Required]
        public string URL { get; set; }
        public int? FolderId { get; set; }
    }
}
