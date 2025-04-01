using FluentValidation;
using PazarAtlasi.CMS.Application.Features.WebUrls.Constants;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Commands.CreateWebUrl
{
    public class CreateWebUrlValidator : AbstractValidator<CreateWebUrlCommand>
    {
        public CreateWebUrlValidator()
        {
            RuleFor(x => x.Slug)
                .NotEmpty().WithMessage(WebUrlMessages.SlugRequired)
                .MaximumLength(100).WithMessage(WebUrlMessages.SlugTooLong);

            RuleFor(x => x.TargetUrl)
                .NotEmpty().WithMessage(WebUrlMessages.TargetUrlRequired)
                .MaximumLength(500).WithMessage(WebUrlMessages.TargetUrlTooLong);

            RuleFor(x => x.Notes)
                .MaximumLength(500).WithMessage(WebUrlMessages.NolesTooLong);
        }
    }
}