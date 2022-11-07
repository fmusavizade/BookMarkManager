using System.Text.Json.Serialization;

namespace BookMarkManager.Model.DTO
{
    public class BaseResponse<T>
    {
        [JsonIgnore]
        public ResponseStatus ResponseStatus { get; set; }
        [JsonIgnore]
        public string ResponseMessage { get; set; }
        public string Message
        {
            get => string.IsNullOrEmpty(ResponseMessage) ? ResponseStatus.ToString() : ResponseMessage;
        }
        public T Result { get; set; }
    }
}
