using Microsoft.AspNetCore.Mvc;
using PazarAtlasi.CMS.Application.Features.Campaigns.Queries;
using MediatR;

namespace PazarAtlasi.CMS.Controllers;

public class CampaignsController : Controller
{
    private readonly IMediator _mediator;

    public CampaignsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IActionResult Index()
    {
        // Örnek veriler
        var campaigns = new List<CampaignDto>
        {
            new CampaignDto
            {
                Id = 1,
                Title = "Yaz İndirimi",
                Description = "Tüm ürünlerde %50'ye varan indirimler!",
                ImageUrl = "/images/campaigns/summer-sale.jpg",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(1),
                IsActive = true,
                TargetUrl = "/kampanyalar/yaz-indirimi"
            },
            new CampaignDto
            {
                Id = 2,
                Title = "Sezon Sonu",
                Description = "Sezon sonu fırsatları başladı!",
                ImageUrl = "/images/campaigns/season-end.jpg",
                StartDate = DateTime.Now.AddDays(7),
                EndDate = DateTime.Now.AddMonths(2),
                IsActive = true,
                TargetUrl = "/kampanyalar/sezon-sonu"
            }
        };

        return View(campaigns);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CampaignDto campaign)
    {
        if (ModelState.IsValid)
        {
            // TODO: Implement CreateCampaignCommand
            return RedirectToAction(nameof(Index));
        }

        return View(campaign);
    }

    public IActionResult Edit(int id)
    {
        // TODO: Implement GetCampaignByIdQuery
        var campaign = new CampaignDto
        {
            Id = id,
            Title = "Örnek Kampanya",
            Description = "Örnek kampanya açıklaması",
            ImageUrl = "/images/campaigns/example.jpg",
            StartDate = DateTime.Now,
            EndDate = DateTime.Now.AddMonths(1),
            IsActive = true,
            TargetUrl = "/kampanyalar/ornek"
        };

        return View(campaign);
    }

    [HttpPost]
    public IActionResult Edit(int id, CampaignDto campaign)
    {
        if (ModelState.IsValid)
        {
            // TODO: Implement UpdateCampaignCommand
            return RedirectToAction(nameof(Index));
        }

        return View(campaign);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        // TODO: Implement DeleteCampaignCommand
        return RedirectToAction(nameof(Index));
    }
} 