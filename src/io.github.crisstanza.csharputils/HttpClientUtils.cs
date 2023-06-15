using io.github.crisstanza.csharputils.constants;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;

namespace io.github.crisstanza.csharputils
{
    public class HttpClientUtils
    {
        private readonly string requestUri;
        private readonly bool debug;
        protected readonly JsonUtils jsonUtils;
        private readonly StringUtils stringUtils;
        public HttpClientUtils(string requestUri) : this(requestUri, false) { }
        public HttpClientUtils(string requestUri, bool debug)
        {
            this.requestUri = requestUri;
            this.debug = debug;
            this.jsonUtils = new JsonUtils(debug);
            this.stringUtils = new StringUtils();
        }
        public void PostAsJson(object payload)
        {
            this.PostJson(this.jsonUtils.Serialize(payload));
        }
        public void PostJson(string json)
        {
            if (this.debug)
            {
                Console.WriteLine("[PostJson] " + json + " [/PostJson]");
            }
            if (this.stringUtils.IsBlank(this.requestUri))
            {
                if (this.debug)
                {
                    Console.WriteLine("[PostJson] no requestUri [/PostJson]");
                }
            }
            else
            {
                HttpClient client = new HttpClient();
                HttpContent content = new StringContent(json, Encoding.UTF8, MediaTypeNamesConstants.APPLICATION_JSON);
                if (this.debug)
                {
                    Console.WriteLine("[PostJson] Posting to " + this.requestUri + " [/PostJson]");
                }
                try
                {
                    client.PostAsync(this.requestUri, content);
                }
                catch (InvalidOperationException exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
        }
    }
}
