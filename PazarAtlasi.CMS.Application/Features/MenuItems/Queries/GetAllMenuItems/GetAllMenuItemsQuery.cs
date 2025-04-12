using MediatR;
using System.Collections.Generic;

namespace PazarAtlasi.CMS.Application.Features.MenuItems.Queries.GetAllMenuItems
{
    public class GetAllMenuItemsQuery : IRequest<List<MenuItemDto>>
    {
        // Add any filter parameters if needed
    }
} 