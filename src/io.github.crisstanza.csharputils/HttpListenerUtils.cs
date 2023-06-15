using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Web;

namespace io.github.crisstanza.csharputils
{
    public class HttpListenerUtils
    {
        public class OutputBody
        {
            public byte[] Body { get; set; }
            public string ContentType { get; set; }
            public HttpStatusCode Status { get; set; }
        }

        private readonly StreamUtils streamUtils;
        private readonly StringUtils stringUtils;

        public HttpListenerUtils()
        {
            this.streamUtils = new StreamUtils();
            this.stringUtils = new StringUtils();
        }

        public string SegmentToMethod(string segment)
        {
            StringBuilder method = new StringBuilder();
            char[] array = segment.ToCharArray();
            int length = array.Length;
            bool upper = true;
            for (int i = 0; i < length; i++)
            {
                char character = array[i];
                if (character == '-' || character == '/' || character == '.')
                {
                    upper = true;
                }
                else
                {
                    if (upper)
                    {
                        character = Char.ToUpper(character);
                        upper = false;
                    }
                    method.Append(character);
                }
            }
            return method.ToString();
        }
        public string GetPostParameterOrRequestInput(HttpListenerRequest request, string parameterName)
        {
            String rawInput = GetRawRequestInput(request);
            NameValueCollection parameters = HttpUtility.ParseQueryString(rawInput);
            string parameterInput = parameters.Get(parameterName);
            if (parameterInput == null)
            {
                return WebUtility.UrlDecode(rawInput);
            }
            return WebUtility.UrlDecode(parameterInput);
        }
        public string GetRawRequestInput(HttpListenerRequest request)
        {
            return this.streamUtils.ReadToEnd(request.InputStream, request.ContentEncoding);
        }
        public void Write(HttpListenerResponse response, string contentType, string buffer, HttpStatusCode statusCode)
        {
            Write(response, contentType, Encoding.UTF8.GetBytes(buffer ?? ""), statusCode);
        }
        public void Write(HttpListenerResponse response, string contentType, byte[] buffer, HttpStatusCode statusCode)
        {
            if (contentType != null)
            {
                response.ContentType = contentType;
            }
            response.ContentLength64 = buffer.Length;
            response.StatusCode = (int)statusCode;
            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }
    }
}
