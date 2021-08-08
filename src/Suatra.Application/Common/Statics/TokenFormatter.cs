using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace Suatra.Application.Common.Statics
{
    public class TokenFormatter
    {
        /// <summary>
        /// Encodes a string to a Base64 Url
        /// </summary>
        /// <param name="token">The string token to encode</param>
        /// <returns>The Encoded Base64Url</returns>
        public static string EncodeToken(string token)
        {
            var tokenInBytes = Encoding.UTF8.GetBytes(token);
            return WebEncoders.Base64UrlEncode(tokenInBytes);
        }

        /// <summary>
        /// Decodes a Base64Url to its original string
        /// </summary>
        /// <param name="encodedToken">The Base64URL Encoded string</param>
        /// <returns>The Original string</returns>
        public static string DecodeToken(string encodedToken)
        {
            var decodedTokenInByte = WebEncoders.Base64UrlDecode(encodedToken);
            return Encoding.UTF8.GetString(decodedTokenInByte);
        }
    }
}