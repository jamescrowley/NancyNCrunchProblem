using FluentValidation;

namespace NancyNCrunch
{
    public class CreateRequestValidator : AbstractValidator<CreateRequest>
    {
        public CreateRequestValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty();
        }
    }
}