using System;
using System.Collections.Generic;
using System.Text;

namespace BookMarkManager.Model.DTO
{
    public enum ResponseStatus
    {
        Success,
        UnSuccess,
        NotFound,
        InvalidRequest,
        InternalError,
    }
    public static class BoolianExtention
    {
        public static ResponseStatus GetResponseStatus(this bool status)
        {
            return status ? ResponseStatus.Success : ResponseStatus.UnSuccess;

        }
    }
}
