using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PazarAtlasi.CMS.Application.Interfaces.Infrastructure;
using PazarAtlasi.CMS.Persistence.Context;

namespace PazarAtlasi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly PazarAtlasiDbContext _pazarAtlasiDbContext;

        public ContentController(
            PazarAtlasiDbContext pazarAtlasiDbContext)
        {
            _pazarAtlasiDbContext = pazarAtlasiDbContext;
        }
    }
}
