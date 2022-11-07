using System.Collections.Generic;

namespace BookMarkManager.Model.DTO.Response
{
    public class FolderView : BaseModel
    {
        public string Description { get; set; }
        public virtual ICollection<BookMarkView> BookMarkList { get; set; }
    }
}
