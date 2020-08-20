using System.Collections.Generic;
using Models.Inventory.Items;
using UnityEngine;

namespace Controllers.InventoryСontrollers
{
    public class InventoryController : MonoBehaviour
    {
        private List<IInventoryItem> Items { get; set; }

        void Start()
        {
            Items = new List<IInventoryItem>();
        }

        List<IInventoryItem> GetUserItems()
        {
            return new List<IInventoryItem>()
            {
                new Potion(1, "SomePotion"),
                new Potion(2, "SomePotion")
            };
        }
    }
}