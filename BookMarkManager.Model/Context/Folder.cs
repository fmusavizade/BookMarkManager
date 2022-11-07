using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookMarkManager.Model.Context
{
    public class Folder
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Createdat { get; set; }
        public DateTime Updatedat { get; set; }
        public virtual ICollection<BookMark> BookMarks { get; set; }
    }
}
