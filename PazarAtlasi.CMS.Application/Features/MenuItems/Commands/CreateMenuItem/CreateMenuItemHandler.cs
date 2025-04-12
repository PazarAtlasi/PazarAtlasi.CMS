using AutoMapper;
using MediatR;
using PazarAtlasi.CMS.Application.Interfaces;
using PazarAtlasi.CMS.Domain.Entities.Content;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Application.Features.MenuItems.Commands.CreateMenuItem
{
    public class CreateMenuItemHandler : IRequestHandler<CreateMenuItemCommand, CreateMenuItemResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMenuItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateMenuItemResponse> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            // Create a new MenuItem entity
            var menuItem = new MenuItem(
                request.WebUrlId,
                request.Label,
                request.Type,
                request.DisplayOrder,
                request.TranslationKey
            );

            // Set optional properties
            if (!string.IsNullOrEmpty(request.Url))
            {
                menuItem.SetUrl(request.Url);
            }

            if (request.ParentId.HasValue)
            {
                var parentMenuItem = await _unitOfWork.Repository<MenuItem>().GetByIdAsync(request.ParentId.Value);
                if (parentMenuItem != null)
                {
                    menuItem.SetParent(parentMenuItem);
                }
            }

            menuItem.SetStatus(request.ShowStatus, request.Status);

            if (!request.IsActive)
            {
                menuItem.Deactivate();
            }

            // Add to repository
            await _unitOfWork.Repository<MenuItem>().AddAsync(menuItem);
            await _unitOfWork.SaveChangesAsync();

            // Return the response
            return _mapper.Map<CreateMenuItemResponse>(menuItem);
        }
    }
} 