using System;

namespace Models.Inventory.Items
{
    public interface IInventoryItem
    {
        int Id { get; }
        string Name { get; }
        InventoryItemType Type { get; }

        string ImageFolderPath { get; }
        string ImageFileName { get; }
        string ImagePathInFolder { get; }

        void Use();
    }
}