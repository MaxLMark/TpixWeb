using System;

namespace TpixWeb.Services
{
    public class JsonRestException : Exception
    {
        public JsonRestException() { }
        public JsonRestException(string message) : base(message) { }
        public JsonRestException(string message, Exception innerException) : base(message, innerException) { }

        public JsonRestException(string payload, int statusCode, string url, object request, string message = null, Exception innerException = null)
            : base(message, innerException)
        {
            Payload = payload;
            StatusCode = statusCode;
            Request = request;
            Url = url;
        }
        public string Payload { get; }
        public int StatusCode { get; }
        public object Request { get; }
        public string Url { get; }
    }
}
