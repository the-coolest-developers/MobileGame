using UnityEngine;

namespace Models.Inventory.Items
{
    public abstract class InventoryItem : IInventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract InventoryItemType Type { get; set; }
        public abstract string ImageFolderPath { get; set; }

        public abstract void Use();

        protected InventoryItem(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}