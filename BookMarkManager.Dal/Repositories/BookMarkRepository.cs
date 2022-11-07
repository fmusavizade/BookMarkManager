using BookMarkManager.Dal.Repositories.BaseRepository;
using BookMarkManager.Model.Context;
using System.Collections.Generic;
using System.Linq;

namespace BookMarkManager.Dal.Repositories
{
    public class BookMarkRepository : GenericRepository<BookMark>, IBookMarkRepository
    {
        public BookMarkRepository(BookmarkManagerDataContext dbContext) : base(dbContext)
        {
        }
        public override bool Insert(BookMark item)
        {
            if (!_dbContext.Folders.Any(x => x.Id == item.FolderId))
                return false;

            return base.Insert(item);
        }
        public IEnumerable<BookMark> GetByFolderID(int folderId) => _dbSet.Where(x => x.FolderId == folderId);
    }
}
