namespace L2code.Manoelcaixas.Apirest.TokenServices
{
    public class RevokedTokens
    {
        private static readonly List<string> _revokedTokens = new List<string>();

        public static void RevokeToken(string token)
        {
            _revokedTokens.Add(token);
        }

        public static bool IsTokenRevoked(string token)
        {
            return _revokedTokens.Contains(token);
        }
    }
}
