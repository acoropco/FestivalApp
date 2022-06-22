namespace FestivalApp.Core.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message, Exception ex) : base(message, ex) {}

        public BadRequestException(string message) : base(message) {}

        public BadRequestException() : base() {}
    }
}
