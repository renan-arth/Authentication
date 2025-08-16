namespace Authentication.Interfaces
{
    public interface ITokenValidator
    {
        bool IsValid(string token);
    }
}