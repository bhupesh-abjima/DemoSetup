namespace Xamplifier.Api.Models.Response
{
    public class ResponseWrapper<T>
    {
        public ResponseWrapper()
        {
        }

        public ResponseWrapper(T result)
        {
            Result = result;
        }

        public ResponseWrapper(Exception exception)
        {
            IsError = true;
            ErrorMessage = exception?.Message;
        }

        public ResponseWrapper(string message, T result)
            : this(result)
        {
            Message = message;
        }

        public bool IsError { get; set; }
        public string ErrorMessage { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }

        public void Set(T result)
        {
            Result = result;
        }

        public void Set(Exception exception)
        {
            IsError = true;
            ErrorMessage = exception?.Message;
        }

        public void Set(string message, T result)
        {
            Message = message;
            Set(result);
        }
    }
}
