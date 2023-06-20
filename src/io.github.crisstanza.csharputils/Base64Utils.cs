using System;

namespace io.github.crisstanza.csharputils
{
    public class Base64Utils
    {
        public string FromByteArray(byte[] array)
        {
            return array == null ? null : Convert.ToBase64String(array);
        }
    }
}
