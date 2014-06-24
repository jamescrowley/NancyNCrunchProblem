using System.Collections.Generic;
using Machine.Specifications;

namespace NancyNCrunch
{
    public class LoginModuleTests : WebTests
    {
        class when_sending_valid_request 
        { 
            Because of = () => Response = Server.PostToJsonUrl("/create", new Dictionary<string, string> { { "name", "john" } });
            It should_be_successful = () => Response.EnsureSuccessStatusCode();
            It should_respond_with_success = () => Response.Content.ReadAsStringAsync().Result.ShouldEqual("success");
        }
        class when_sending_invalid_request
        {
            Because of = () => Response = Server.PostToJsonUrl("/create", new Dictionary<string, string> { { "name", "" } });
            It should_be_successful = () => Response.EnsureSuccessStatusCode();
            It should_respond_with_failure = () => Response.Content.ReadAsStringAsync().Result.ShouldEqual("failure");
        }
    }
}