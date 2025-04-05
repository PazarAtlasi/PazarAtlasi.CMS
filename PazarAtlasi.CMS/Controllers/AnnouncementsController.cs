using Microsoft.AspNetCore.Mvc;
using PazarAtlasi.CMS.Application.Features.Announcements.Queries;
using PazarAtlasi.CMS.Application.Features.Announcements.Commands;
using MediatR;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly IMediator _mediator;

        public AnnouncementsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            // Örnek veriler
            var announcements = new List<AnnouncementDto>
            {
                new AnnouncementDto
                {
                    Id = 1,
                    Title = "Hoş Geldiniz!",
                    Content = "Pazar Atlası CMS'e hoş geldiniz. Bu platform üzerinden duyurularınızı yönetebilirsiniz.",
                    PublishDate = DateTime.Now.AddDays(-2),
                    IsActive = true
                },
                new AnnouncementDto
                {
                    Id = 2,
                    Title = "Yeni Özellikler",
                    Content = "Platformumuzda yeni özellikler eklendi. Daha iyi bir deneyim için güncellemeler yapıldı.",
                    PublishDate = DateTime.Now.AddDays(-1),
                    IsActive = true
                },
                new AnnouncementDto
                {
                    Id = 3,
                    Title = "Bakım Çalışması",
                    Content = "Yarın saat 02:00-04:00 arasında sistem bakım çalışması yapılacaktır.",
                    PublishDate = DateTime.Now,
                    IsActive = true
                }
            };

            return View(announcements);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAnnouncementCommand command)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }

        public IActionResult Edit(int id)
        {
            // TODO: Implement GetAnnouncementByIdQuery
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CreateAnnouncementCommand command)
        {
            if (ModelState.IsValid)
            {
                // TODO: Implement UpdateAnnouncementCommand
                return RedirectToAction(nameof(Index));
            }

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            // TODO: Implement DeleteAnnouncementCommand
            return RedirectToAction(nameof(Index));
        }
    }
} 