using BookMarkManager.Model.Context;
using System.Collections.Generic;

namespace BookMarkManager.Dal.Repositories.BaseRepository
{
    public interface IBookMarkRepository : IGenericRepository<BookMark>
    {
        IEnumerable<BookMark> GetByFolderID(int folderId);
    }
}
