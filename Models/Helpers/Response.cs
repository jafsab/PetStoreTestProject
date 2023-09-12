namespace Models.Helpers
{
    public class Response<T> : IResponse
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
