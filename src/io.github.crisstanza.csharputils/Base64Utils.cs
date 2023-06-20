using System;

namespace io.github.crisstanza.csharputils
{
    public class Base64Utils
    {
        public string FromByteArray(byte[] array)
        {
            return Convert.ToBase64String(array);
        }
    }
}
