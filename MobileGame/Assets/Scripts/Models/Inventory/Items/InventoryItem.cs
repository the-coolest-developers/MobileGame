using UnityEngine;

namespace Models.Inventory.Items
{
    public abstract class InventoryItem : IInventoryItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public abstract InventoryItemType Type { get; }
        public abstract string ImageFolderPath { get; }

        public abstract void Use();

        public void OnClicked()
        {
            Debug.Log("It has been clicked!");
            Use();
        }

        protected InventoryItem(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}