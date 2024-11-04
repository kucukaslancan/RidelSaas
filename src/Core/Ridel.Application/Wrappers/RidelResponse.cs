namespace Ridel.Application.Wrappers
{
    public class RidelResponse<T>
    {
        public RidelResponse()
        {
        }

        public RidelResponse(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        public RidelResponse(string message)
        {
            Succeeded = false;
            Message = message;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
