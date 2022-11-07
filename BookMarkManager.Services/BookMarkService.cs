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
    public class BookMarkService : IBookMarkService
    {
        IBookMarkRepository _bookMarkRepository;
        public BookMarkService(IBookMarkRepository bookMarkRepository)
        {
            _bookMarkRepository = bookMarkRepository;
        }

        public ResponseStatus Delete(int id)
        {
            var oldItem = _bookMarkRepository.GetByID(id);
            if (oldItem == null)
                return ResponseStatus.NotFound;
            return _bookMarkRepository.Delete(id).GetResponseStatus();
        }

        public IEnumerable<BookMarkView> GetAll()
        {
            var includers = new List<Expression<Func<BookMark, object>>>();
            includers.Add(x => x.Folder);
            return _bookMarkRepository.GetAll(null, includers).Select(b => new BookMarkView()
            {
                Id = b.Id,
                Name = b.Name,
                CreatedAt = b.Createdat.ToString("yyyymmdd HH:mm:ss"),
                UpdatedAt = b.Updatedat.ToString("yyyymmdd HH:mm:ss"),
                FolderId = b.FolderId,
                URL = b.URL,
            });
        }

        public IEnumerable<BookMarkView> GetByFolderID(int folderId)
        {
            var includers = new List<Expression<Func<BookMark, object>>>();
            includers.Add(x => x.Folder);

            var wherePredicates = new List<Expression<Func<BookMark, bool>>>();
            wherePredicates.Add(x => x.FolderId == folderId);

            return _bookMarkRepository.GetAll(wherePredicates, includers).Select(b => new BookMarkView()
            {
                Id = b.Id,
                Name = b.Name,
                CreatedAt = b.Createdat.ToString("yyyymmdd HH:mm:ss"),
                UpdatedAt = b.Updatedat.ToString("yyyymmdd HH:mm:ss"),
                FolderId = b.FolderId,
                URL = b.URL,
            });
        }

        public ResponseStatus Insert(BookMarkDTO request)
        {
            return _bookMarkRepository.Insert(new BookMark()
            {
                FolderId = request.FolderId,
                Name = request.Name,
                URL = request.URL,
                Createdat = DateTime.Now,
                Updatedat = DateTime.Now
            }).GetResponseStatus();
        }

        public ResponseStatus Update(int id, BookMarkDTO request)
        {
            var existingItem = _bookMarkRepository.GetByID(id);
            if (existingItem == null)
                return ResponseStatus.NotFound;
            existingItem.Updatedat = DateTime.Now;
            existingItem.FolderId = request.FolderId;
            existingItem.Name = request.Name;
            existingItem.URL = request.URL;
            return _bookMarkRepository.Update(id, existingItem).GetResponseStatus();
        }
    }
}
