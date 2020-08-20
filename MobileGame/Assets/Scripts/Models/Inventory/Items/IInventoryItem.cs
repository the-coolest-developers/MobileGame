namespace Models.Inventory.Items
{
    public interface IInventoryItem
    {
        int Id { get; set; }
        string Name { get; set; }
        InventoryItemType Type { get; set; }
        string ImageFolderPath { get; set; }

        void Use();
    }
}