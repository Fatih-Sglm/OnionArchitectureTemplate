namespace CrossCuttingConcerns.Exceptions
{
    public class IdentityException : Exception
    {
        public object Errors { get; set; }

        public IdentityException(object errors)
        {
            Errors = errors;
        }
    }
}
