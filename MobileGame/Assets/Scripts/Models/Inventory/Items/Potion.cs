using UnityEngine;

namespace Models.Inventory.Items
{
    public class Potion : InventoryItem
    {
        public override InventoryItemType Type => InventoryItemType.Consumable;

        public override void Use()
        {
            Debug.Log("A potion has been used!");
        }

        public Potion(int id, string name) : base(id, name)
        {
        }
    }
}