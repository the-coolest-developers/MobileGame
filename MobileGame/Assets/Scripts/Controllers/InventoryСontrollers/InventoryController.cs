using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Controllers.InventoryСontrollers.ItemControllers;
using Controllers.UI_Controllers.Inventory;
using Models.Inventory.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers.InventoryСontrollers
{
    public class InventoryController : MonoBehaviour
    {
        private InventoryUiController InventoryUiController { get; set; }
        private List<GameObject> ItemUiObjects { get; set; }

        void Start()
        {
            InventoryUiController = GetComponent<InventoryUiController>();

            ItemUiObjects = new List<GameObject>();

            SetItems(new List<InventoryItem>()
            {
                new Potion(1, "HealthPotion"),
                new Potion(2, "Test"),
                new Potion(1, "HealthPotion"),
            });

            var first = ItemUiObjects.FirstOrDefault();
            if (first != null)
            {
                InventoryUiController.SetSelectedItem(first.GetComponent<InventoryItemController>());
            }
        }

        public void AddItem(InventoryItem item)
        {
            var instantiatedItem = InventoryUiController.InstantiateItem(item);
            ItemUiObjects.Add(instantiatedItem);

            InventoryUiController.RefreshItemArrangement(ItemUiObjects);
        }

        public void RemoveItem(InventoryItem item)
        {
            var itemGameObject = ItemUiObjects.FirstOrDefault(i =>
                i.GetComponent<InventoryItemController>().InventoryItem == item);

            RemoveItem(itemGameObject);
        }

        public void RemoveItemById(int id)
        {
            var itemGameObject = ItemUiObjects.FirstOrDefault(i =>
                i.GetComponent<InventoryItemController>().InventoryItem.Id == id);

            RemoveItem(itemGameObject);
        }

        public void RemoveItem(GameObject itemGameObject)
        {
            ItemUiObjects.Remove(itemGameObject);
            Destroy(itemGameObject);

            InventoryUiController.RefreshItemArrangement(ItemUiObjects);
        }

        public void SetItems(List<InventoryItem> items)
        {
            items.ForEach(AddItem);
        }
    }
}