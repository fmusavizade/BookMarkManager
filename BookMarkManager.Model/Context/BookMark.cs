using System;
using System.ComponentModel.DataAnnotations;

namespace BookMarkManager.Model.Context
{
    public class BookMark
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string URL { get; set; }
        public int? FolderId { get; set; }
        public virtual Folder Folder { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime Updatedat { get; set; }

    }
}
