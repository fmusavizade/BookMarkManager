using BookMarkManager.Model.DTO;
using BookMarkManager.Model.DTO.Response;
using BookMarkManager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMarkManager.WebAPI.Controllers
{
    [Route("api/v1/bookmarks")]
    [ApiController]
    public class BookMarksController : ControllerBase
    {
        IBookMarkService _bookMarkService;
        IFolderService _folderService;
        public BookMarksController(IBookMarkService bookMarkService, IFolderService folderService)
        {
            _bookMarkService = bookMarkService;
            _folderService = folderService;
        }

        // GET: api/<BookMarksController>
        [HttpGet]
        public BaseResponse<IEnumerable<BookMarkView>> Get()
        {
            var response = new BaseResponse<IEnumerable<BookMarkView>>();
            try
            {
                response.Result = _bookMarkService.GetAll();
            }
            catch (Exception exc)
            {
                response.ResponseMessage = exc.Message;
                response.ResponseStatus = ResponseStatus.UnSuccess;
            }
            return response;
        }

        // GET api/<BookMarksController>/Folder/5
        [HttpGet("folders/{id}")]
        public BaseResponse<IEnumerable<BookMarkView>> Get(int id)
        {
            var response = new BaseResponse<IEnumerable<BookMarkView>>();
            try
            {
                if (_folderService.FolderExists(id) == ResponseStatus.NotFound)
                {
                    response.ResponseMessage = "Invalid Folder Id";
                    response.ResponseStatus = ResponseStatus.InvalidRequest;
                }
                else
                    response.Result = _bookMarkService.GetByFolderID(id);
            }
            catch (Exception exc)
            {
                response.ResponseMessage = exc.Message;
                response.ResponseStatus = ResponseStatus.UnSuccess;
            }
            return response;
        }
        // POST api/<BookMarksController>
        [HttpPost]
        public BaseResponse<bool> Post([FromBody] BookMarkDTO request)
        {
            var response = new BaseResponse<bool>();
            try
            {

                if (request.FolderId != null && _folderService.FolderExists(request.FolderId.Value) == ResponseStatus.NotFound)
                {
                    response.ResponseMessage = "Invalid Folder Id";
                    response.ResponseStatus = ResponseStatus.InvalidRequest;
                }
                else
                    response.ResponseStatus = _bookMarkService.Insert(request);
                response.Result = response.ResponseStatus == ResponseStatus.Success;

            }
            catch (Exception exc)
            {
                response.ResponseMessage = exc.Message;
                response.ResponseStatus = ResponseStatus.UnSuccess;
            }
            return response;
        }

        // PUT api/<BookMarksController>/5
        [HttpPut("{id}")]
        public BaseResponse<bool> Put(int id, [FromBody] BookMarkDTO request)
        {
            var response = new BaseResponse<bool>();
            try
            {
                if (request.FolderId != null && _folderService.FolderExists(request.FolderId.Value) == ResponseStatus.NotFound)
                {
                    response.ResponseMessage = "Invalid Folder Id";
                    response.ResponseStatus = ResponseStatus.InvalidRequest;
                }
                else
                    response.ResponseStatus = _bookMarkService.Update(id, request);

                response.Result = response.ResponseStatus == ResponseStatus.Success;

            }
            catch (Exception exc)
            {
                response.ResponseMessage = exc.Message;
                response.ResponseStatus = ResponseStatus.UnSuccess;
            }
            return response;
        }

        // DELETE api/<BookMarksController>/5
        [HttpDelete("{id}")]
        public BaseResponse<bool> Delete(int id)
        {
            var response = new BaseResponse<bool>();
            try
            {
                response.ResponseStatus = _bookMarkService.Delete(id);
                response.Result = response.ResponseStatus == ResponseStatus.Success;

            }
            catch (Exception exc)
            {
                response.ResponseMessage = exc.Message;
                response.ResponseStatus = ResponseStatus.UnSuccess;
            }
            return response;
        }
    }
}

