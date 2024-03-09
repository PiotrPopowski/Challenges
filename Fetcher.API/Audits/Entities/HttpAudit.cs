namespace Fetcher.API.Audits.Entities
{
    public class HttpAudit
    {
        public Guid Id { get; private set; }
        public string Request { get; private set; }
        public string Response { get; private set; }
        public int StatusCode { get; private set; }

        private HttpAudit() { }

        public HttpAudit(string request, string response, int statusCode)
        {
            Id = Guid.NewGuid();
            Request = request;
            Response = response;
            StatusCode = statusCode;
        }
    }
}
