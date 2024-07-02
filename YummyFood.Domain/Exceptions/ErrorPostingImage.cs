namespace YummyFood.Domain.Exceptions
{
    public class ErrorPostingImage : Exception
    {
        public ErrorPostingImage(string message)
            : base(message)
        { }
    }
}
