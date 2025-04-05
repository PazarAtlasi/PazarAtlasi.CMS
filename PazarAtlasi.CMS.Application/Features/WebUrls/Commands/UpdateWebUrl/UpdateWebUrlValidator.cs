using FluentValidation;
using PazarAtlasi.CMS.Application.Features.WebUrls.Constants;

namespace PazarAtlasi.CMS.Application.Features.WebUrls.Commands.UpdateWebUrl
{
    public class UpdateWebUrlValidator : AbstractValidator<UpdateWebUrlCommand>
    {
        public UpdateWebUrlValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);

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