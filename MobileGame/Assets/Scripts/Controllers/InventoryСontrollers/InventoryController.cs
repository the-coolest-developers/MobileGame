using System.Collections.Generic;
using Models.Inventory.Items;
using UnityEngine;

namespace Controllers.InventoryСontrollers
{
    public class InventoryController : MonoBehaviour
    {
        private List<GameObject> Items { get; set; }

        void Start()
        {
            Items = GetUserItems();
        }

        List<GameObject> GetUserItems()
        {
            return new List<GameObject>()
            {
                //new Potion(1, "SomePotion"),
                //new Potion(2, "SomePotion")
            };
        }
    }
}