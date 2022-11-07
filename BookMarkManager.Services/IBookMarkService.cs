using BookMarkManager.Model.DTO;
using BookMarkManager.Model.DTO.Response;
using System.Collections.Generic;

namespace BookMarkManager.Services
{
    public interface IBookMarkService
    {
        IEnumerable<BookMarkView> GetByFolderID(int folderId);
        IEnumerable<BookMarkView> GetAll();
        ResponseStatus Insert(BookMarkDTO request);
        ResponseStatus Update(int id, BookMarkDTO request);
        ResponseStatus Delete(int id);
    }
}
