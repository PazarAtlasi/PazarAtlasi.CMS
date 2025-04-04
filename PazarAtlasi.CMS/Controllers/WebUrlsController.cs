using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PazarAtlasi.CMS.Application.Features.WebUrls.Commands.CreateWebUrl;
using PazarAtlasi.CMS.Application.Features.WebUrls.Commands.DeleteWebUrl;
using PazarAtlasi.CMS.Application.Features.WebUrls.Commands.UpdateWebUrl;
using PazarAtlasi.CMS.Application.Features.WebUrls.Queries.GetAllWebUrls;
using PazarAtlasi.CMS.Application.Features.WebUrls.Queries.GetWebUrlById;

namespace PazarAtlasi.CMS.Controllers
{
    public class WebUrlsController : Controller
    {
        private readonly IMediator _mediator;

        public WebUrlsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllWebUrlsQuery();
            var webUrls = await _mediator.Send(query);
            return View(webUrls);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWebUrlCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);
                if (result.IsSuccess)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(command);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var query = new GetWebUrlByIdQuery { Id = id };
            var webUrl = await _mediator.Send(query);

            var command = new UpdateWebUrlCommand
            {
                Id = webUrl.Id,
                Slug = webUrl.Slug,
                OriginalUrl = webUrl.OriginalUrl,
                TargetUrl = webUrl.TargetUrl,
                IsActive = webUrl.IsActive,
                IsPermanent = webUrl.IsPermanent,
                ExpiryDate = webUrl.ExpiryDate,
                Notes = webUrl.Notes,
                Category = webUrl.Category,
                Priority = webUrl.Priority
            };

            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateWebUrlCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);
                if (result.IsSuccess)
                {
                    TempData["SuccessMessage"] = result.Message;
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(command);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteWebUrlCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                TempData["SuccessMessage"] = result.Message;
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}