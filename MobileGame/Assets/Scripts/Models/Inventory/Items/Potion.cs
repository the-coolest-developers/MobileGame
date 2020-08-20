namespace Models.Inventory.Items
{
    public class Potion : InventoryItem
    {
        public override InventoryItemType Type { get; set; } = InventoryItemType.Consumable;
        public override string ImageFolderPath { get; set; }

        public override void Use()
        {
            throw new System.NotImplementedException();
        }

        public Potion(int id, string name) : base(id, name)
        {
        }
    }
}