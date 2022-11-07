using BookMarkManager.Dal;
using BookMarkManager.Dal.Repositories.BaseRepository;
using BookMarkManager.Model.Context;
using BookMarkManager.Model.DTO;
using BookMarkManager.Model.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BookMarkManager.Services
{
    public class FolderService : IFolderService
    {

        IFolderRepository _folderRepository;
        public FolderService(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }
        public ResponseStatus Delete(int id)
        {
            var oldItem = _folderRepository.GetByID(id);
            if (oldItem == null)
                return ResponseStatus.NotFound;
            return _folderRepository.Delete(id).GetResponseStatus();
        }
        public ResponseStatus FolderExists(int id)
        {
            var existingItem = _folderRepository.GetByID(id);
            return existingItem == null ? ResponseStatus.NotFound : ResponseStatus.Success;
        }
        public IEnumerable<FolderView> GetAll()
        {

            var includers = new List<Expression<Func<Folder, object>>>();
            includers.Add(x => x.BookMarks);
            return _folderRepository.GetAll(null, includers).Select(x => new FolderView()
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.Createdat.ToString("yyyymmdd HH:mm:ss"),
                UpdatedAt = x.Updatedat.ToString("yyyymmdd HH:mm:ss"),
                Description = x.Description,
                BookMarkList = x.BookMarks?.Select(b => new BookMarkView()
                {
                    Id = b.Id,
                    Name = b.Name,
                    CreatedAt = b.Createdat.ToString("yyyymmdd HH:mm:ss"),
                    UpdatedAt = b.Updatedat.ToString("yyyymmdd HH:mm:ss"),
                    FolderId = b.FolderId,
                    URL = b.URL
                }).ToList()
            });
        }
        public ResponseStatus Insert(FolderDTO request)
        {
            return _folderRepository.Insert(new Folder()
            {
                Description = request.Description,
                Name = request.Name,
                Createdat = DateTime.Now,
                Updatedat = DateTime.Now
            }).GetResponseStatus();
        }
        public ResponseStatus Update(int id, FolderDTO request)
        {
            var existingItem = _folderRepository.GetByID(id);
            if (existingItem == null)
                return ResponseStatus.NotFound;
            existingItem.Updatedat = DateTime.Now;
            existingItem.Name = request.Name;
            existingItem.Description = request.Description;
            return _folderRepository.Update(id, existingItem).GetResponseStatus();
        }
    }
}
