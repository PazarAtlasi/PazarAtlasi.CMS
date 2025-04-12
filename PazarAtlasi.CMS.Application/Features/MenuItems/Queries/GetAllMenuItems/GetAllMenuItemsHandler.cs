using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PazarAtlasi.CMS.Application.Interfaces;
using PazarAtlasi.CMS.Domain.Entities.Content;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Application.Features.MenuItems.Queries.GetAllMenuItems
{
    public class GetAllMenuItemsHandler : IRequestHandler<GetAllMenuItemsQuery, List<MenuItemDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllMenuItemsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<MenuItemDto>> Handle(GetAllMenuItemsQuery request, CancellationToken cancellationToken)
        {
            // Get all menu items including navigation properties
            var menuItems = await _unitOfWork.Repository<MenuItem>()
                .GetAsync(m => !m.IsDeleted);

            // Convert to DTOs
            var menuItemDtos = _mapper.Map<List<MenuItemDto>>(menuItems);

            return menuItemDtos;
        }
    }
} 