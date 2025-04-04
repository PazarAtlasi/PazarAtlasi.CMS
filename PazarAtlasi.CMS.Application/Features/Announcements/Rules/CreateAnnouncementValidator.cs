using FluentValidation;
using PazarAtlasi.CMS.Application.Features.Announcements.Commands;
using PazarAtlasi.CMS.Application.Features.Announcements.Constants;

namespace PazarAtlasi.CMS.Application.Features.Announcements.Rules;

public class CreateAnnouncementValidator : AbstractValidator<CreateAnnouncementCommand>
{
    public CreateAnnouncementValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage(AnnouncementConstants.TitleRequired)
            .MaximumLength(200).WithMessage(AnnouncementConstants.TitleMaxLength);

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage(AnnouncementConstants.ContentRequired)
            .MaximumLength(2000).WithMessage(AnnouncementConstants.ContentMaxLength);

        RuleFor(x => x.PublishDate)
            .NotEmpty().WithMessage(AnnouncementConstants.PublishDateRequired);
    }
} 