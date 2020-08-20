namespace Models.Inventory.Items
{
    public interface IInventoryItem
    {
        int Id { get; }
        string Name { get; }
        InventoryItemType Type { get; }
        string ImageFolderPath { get; }

        void Use();
    }
}