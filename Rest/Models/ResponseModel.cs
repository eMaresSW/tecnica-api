namespace Rest.Models
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; } = true;

        public string Message { get; set; } = string.Empty;

        public T Result { get; set; }
    }
}
