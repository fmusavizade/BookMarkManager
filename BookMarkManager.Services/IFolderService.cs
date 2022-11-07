using BookMarkManager.Model.DTO;
using BookMarkManager.Model.DTO.Response;
using System.Collections.Generic;

namespace BookMarkManager.Services
{
    public interface IFolderService
    {
        IEnumerable<FolderView> GetAll();
        ResponseStatus FolderExists(int id);
        ResponseStatus Insert(FolderDTO request);
        ResponseStatus Update(int id, FolderDTO request);
        ResponseStatus Delete(int id);
    }
}
