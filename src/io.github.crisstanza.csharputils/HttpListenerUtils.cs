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
			string input;
			if (parameterInput == null)
			{
				input = WebUtility.UrlDecode(rawInput);
			}
			else
			{
				input = WebUtility.UrlDecode(parameterInput);

			}
			return input;
		}
		public string GetRawRequestInput(HttpListenerRequest request)
		{
			String input = this.streamUtils.ReadToEnd(request.InputStream, request.ContentEncoding);
			return input;
		}
		public void Write(HttpListenerResponse response, string contentType, string buffer)
		{
			Write(response, contentType, Encoding.UTF8.GetBytes(buffer ?? ""));
		}
		public void Write(HttpListenerResponse response, string contentType, byte[] buffer)
		{
			if (contentType != null)
			{
				response.ContentType = contentType;
			}
			response.ContentLength64 = buffer.Length;
			response.StatusCode = (int)HttpStatusCode.OK;
			Stream output = response.OutputStream;
			output.Write(buffer, 0, buffer.Length);
			output.Close();
		}
	}
}
