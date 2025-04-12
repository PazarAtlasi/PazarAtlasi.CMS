namespace PazarAtlasi.CMS.Application.Features.MenuItems.Constants
{
    public static class MenuConstants
    {
        public static class MenuTypes
        {
            public const string MegaMenu = "megamenu";
            public const string ServiceTabs = "servicetabs";
            public const string Categorized = "categorized";
            public const string Link = "link";
            public const string Dropdown = "dropdown";
        }

        public static class IconPositions
        {
            public const string Left = "left";
            public const string Right = "right";
            public const string Top = "top";
            public const string Bottom = "bottom";
        }

        public static class ErrorMessages
        {
            public const string MenuItemNotFound = "Menu item not found.";
            public const string ParentMenuItemNotFound = "Parent menu item not found.";
            public const string CannotDeleteParentMenuItem = "Cannot delete a menu item that has children.";
            public const string InvalidMenuType = "Invalid menu type.";
        }
    }
} 