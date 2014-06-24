using System.Net.Http;
using Machine.Specifications;
using Microsoft.Owin.Testing;

namespace NancyNCrunch
{
    public class WebTests
    {
        protected static TestServer Server;
        protected static HttpResponseMessage Response;

        Establish context = () =>
        {
            Server = TestServer.Create(new Startup().Configuration);
        };
        Cleanup cleanup = () =>
        {
            Response.Dispose();
            Response = null;
        };
        static WebTests()
        {

        }
    }
}