namespace Application.Commons.Models.ResponseModels
{
    public class CustomResponse<T>
    {
        public T? Data { get; set; }
        public string? Message { get; set; }

        public static CustomResponse<T> SuccesWithData(T data) { return new CustomResponse<T> { Data = data }; }
        public static CustomResponse<T> SuccesWithOutData(string? message) { return new CustomResponse<T> { Message = message }; }
    }
}
