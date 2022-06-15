namespace FestivalApp.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message, Exception ex) : base(message, ex) {}

        public NotFoundException(string message) : base(message) {}

        public NotFoundException() : base() {}
    }
}
