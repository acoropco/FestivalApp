namespace FestivalApp.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message, Exception ex) : base(message, ex) {}

        public ValidationException(string message) : base(message) {}

        public ValidationException() : base() {}
    }
}
