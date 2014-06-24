using Nancy;
using Nancy.ModelBinding;
using Nancy.Validation;

namespace NancyNCrunch
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            this.Post["/create"] = _ =>
            {
                var validationResult = this.Validate(this.Bind<CreateRequest>());
                if (validationResult.IsValid)
                {
                    return "success";
                }
                return "failure";
            };
        }
    }
}