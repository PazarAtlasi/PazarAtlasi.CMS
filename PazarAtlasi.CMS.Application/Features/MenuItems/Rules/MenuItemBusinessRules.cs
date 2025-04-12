using PazarAtlasi.CMS.Application.Features.MenuItems.Constants;
using PazarAtlasi.CMS.Application.Interfaces;
using PazarAtlasi.CMS.Domain.Entities.Content;
using System;
using System.Threading.Tasks;

namespace PazarAtlasi.CMS.Application.Features.MenuItems.Rules
{
    public class MenuItemBusinessRules
    {
        private readonly IUnitOfWork _unitOfWork;

        public MenuItemBusinessRules(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MenuItem> MenuItemShouldExistWhenRequested(int id)
        {
            var menuItem = await _unitOfWork.Repository<MenuItem>().GetByIdAsync(id);
            if (menuItem == null || menuItem.IsDeleted)
            {
                throw new Exception(MenuConstants.ErrorMessages.MenuItemNotFound);
            }
            return menuItem;
        }

        public async Task MenuItemParentShouldExistWhenRequested(int? parentId)
        {
            if (parentId.HasValue)
            {
                var parentMenuItem = await _unitOfWork.Repository<MenuItem>().GetByIdAsync(parentId.Value);
                if (parentMenuItem == null || parentMenuItem.IsDeleted)
                {
                    throw new Exception(MenuConstants.ErrorMessages.ParentMenuItemNotFound);
                }
            }
        }

        public async Task MenuItemShouldNotHaveChildrenWhenDeleted(int id)
        {
            var children = await _unitOfWork.Repository<MenuItem>().GetAsync(m => m.ParentId == id && !m.IsDeleted);
            if (children.Count > 0)
            {
                throw new Exception(MenuConstants.ErrorMessages.CannotDeleteParentMenuItem);
            }
        }

        public void MenuTypeShouldBeValid(string menuType)
        {
            bool isValid = false;
            foreach (var field in typeof(MenuConstants.MenuTypes).GetFields())
            {
                if (field.GetValue(null).ToString() == menuType)
                {
                    isValid = true;
                    break;
                }
            }

            if (!isValid)
            {
                throw new Exception(MenuConstants.ErrorMessages.InvalidMenuType);
            }
        }
    }
} 