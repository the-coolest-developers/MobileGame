using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Models.Inventory.Items
{
    public abstract class InventoryItem : IInventoryItem
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; protected set; }
        public abstract InventoryItemType Type { get; }

        public virtual string ImageFolderPath => Type.ToString();
        public virtual string ImageFileName => Name;
        public virtual string ImagePathInFolder => $"{ImageFolderPath}/{Name}";


        public abstract void Use();

        protected InventoryItem(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected InventoryItem(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}