using BookMarkManager.Dal.Repositories.BaseRepository;
using BookMarkManager.Model.Context;

namespace BookMarkManager.Dal.Repositories
{
    public class FolderRepository : GenericRepository<Folder>, IFolderRepository
    {
        public FolderRepository(BookmarkManagerDataContext dbContext) : base(dbContext)
        {
        }

    }
}
