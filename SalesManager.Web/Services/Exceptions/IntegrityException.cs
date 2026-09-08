namespace SalesManager.Web.Services.Exceptions;

public class IntegrityException : ApplicationException
{
    public IntegrityException (string msg) : base(msg)
    {
    }
}