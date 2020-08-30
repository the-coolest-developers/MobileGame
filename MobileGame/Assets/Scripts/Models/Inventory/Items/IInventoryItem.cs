namespace Models.Inventory.Items
{
    public interface IInventoryItem
    {
        int Id { get; }
        string Name { get; }
        string ImageFolderPath { get; }
        string ImageFileName { get; }
        string ImagePathInFolder { get; }

        InventoryItemType Type { get; }

        void Use();
    }
}