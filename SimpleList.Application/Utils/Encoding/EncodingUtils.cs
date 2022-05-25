using System.Text;

namespace SimpleList.Application.Utils.Encode
{
    public static class EncodingUtils
    {
        public static byte[]? EncodeToBytes(string s) 
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return null;
            }

            return Encoding.UTF8.GetBytes(s);        
        }
    }
}
