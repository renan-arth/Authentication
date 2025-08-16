namespace Authentication.Interfaces
{
    public interface ICryptoService
    {
        string ComputeHash(string input);
        bool VerifyHash(string input, string hash);
    }
}