using BookMarkManager.Model.DTO;
using BookMarkManager.Model.DTO.Response;
using BookMarkManager.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FolderManager.WebAPI.Controllers
{
    [Route("api/v1/folders")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        IFolderService _folderService;
        public FoldersController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        // GET: api/<FoldersController>
        [HttpGet]
        public BaseResponse<IEnumerable<FolderView>> Get()
        {
            var response = new BaseResponse<IEnumerable<FolderView>>();
            try
            {
                response.Result = _folderService.GetAll();
            }
            catch (Exception exc)
            {
                response.ResponseMessage = exc.Message;
                response.ResponseStatus = ResponseStatus.UnSuccess;
            }
            return response;
        }

        // POST api/<FoldersController>
        [HttpPost]
        public BaseResponse<bool> Post([FromBody] FolderDTO request)
        {

            var response = new BaseResponse<bool>();
            try
            {
                response.ResponseStatus = _folderService.Insert(request);
                response.Result = response.ResponseStatus == ResponseStatus.Success;
            }
            catch (Exception exc)
            {
                response.ResponseMessage = exc.Message;
                response.ResponseStatus = ResponseStatus.UnSuccess;
            }
            return response;
        }

        // PUT api/<FoldersController>/5
        [HttpPut("{id}")]
        public BaseResponse<bool> Put(int id, [FromBody] FolderDTO request)
        {

            var response = new BaseResponse<bool>();
            try
            {
                response.ResponseStatus = _folderService.Update(id, request);
                response.Result = response.ResponseStatus == ResponseStatus.Success;
            }
            catch (Exception exc)
            {
                response.ResponseMessage = exc.Message;
                response.ResponseStatus = ResponseStatus.UnSuccess;
            }
            return response;
        }

        // DELETE api/<FoldersController>/5
        [HttpDelete("{id}")]
        public BaseResponse<bool> Delete(int id)
        {
            var response = new BaseResponse<bool>();
            try
            {
                response.ResponseStatus = _folderService.Delete(id);
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
