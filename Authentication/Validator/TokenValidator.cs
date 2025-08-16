using Authentication.Interfaces;

namespace Authentication.Validator
{
    public class TokenValidator : ITokenValidator
    {
        private readonly ICryptoService _crypto;

        public TokenValidator(ICryptoService crypto)
        {
            _crypto = crypto;
        }

        public bool IsValid(string token)
        {
            var expectedHash = "RrDM90dlBWRhSmbFa+YSs7UQpvbtPPDF9wlZeGkNiBQ=";
            return _crypto.VerifyHash(token, expectedHash);
        }
    }
}