namespace Application.Wrappers
{
    public class Response<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }

        public Response() { }

        public Response(T data, string message)
        {
            IsSuccess = true;
            Data = data;
            Message = message;
        }

        public Response(string message)
        {
            IsSuccess = false;
            Message = message;
        }
    }
}
